using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualSerialJoystick
{
    public partial class MainForm : Form
    {

        System.IO.Ports.SerialPort comPort = new System.IO.Ports.SerialPort();
        VJoyControl vJoystick = new VJoyControl();       

        List<AxisNode> axes = new List<AxisNode>();
        ConfigFileWriter filer = new ConfigFileWriter();

        /*This is an array to store the values gotten from the Serial Device
         * The setup of this array is as follows:
         * 0-15 are for joystick axes
         * 16-40 are for buttons
         * 40 - 50 are for POVs
         */
        public int[] joyValues = new int[Properties.Settings.Default.maxIndex];


        private bool m_isRunning;

        private bool isRunning
        {
            get
            {
                return m_isRunning;
            }
            set
            {
                m_isRunning = value;
                if (value == true)
                {
                    beginJoystick();
                }
                else
                {
                    stopJoystick();
                }
            }
        }
        public MainForm()
        {
            InitializeComponent();
            
        }

        void setupAxesList()
        {
            axes.Add(new AxisNode("Test Axis", 1, HID_USAGES.HID_USAGE_SL1));
            axes.Add(new AxisNode("Test Button", 4, 50));
            axes.Add(new AxisNode("MyButton", 25, 17));
            loadAxisList();
        }

        public void loadAxisList()
        {
            tv_Axes.Nodes.Clear();
            foreach (AxisNode joyAxis in axes){
                tv_Axes.Nodes.Add(joyAxis);
            }
            safeToStart();
        }

        private void safeToStart()
        {
            try
            {
                if (cb_COMPort.SelectedItem.ToString().Length > 0 &&
                axes.Count > 0)
                {
                    btn_StartStop.Enabled = true;
                }
                else
                {
                    btn_StartStop.Enabled = false;
                }
            }
            catch (Exception)
            {

                btn_StartStop.Enabled = false;
            }
            
        }


        private void reloadPorts()
        {
            if (System.IO.Ports.SerialPort.GetPortNames().Length != 0)
            {
                foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
                {
                    cb_COMPort.Items.Add(portName);
                }
                cb_COMPort.SelectedIndex = 0;
                
            }
            else
            {
                MessageBox.Show("There are no available COM ports on the system.  Connect a compatible COM device and try reloading the ports again.",
                    "Failed to Find any COM Ports",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                
            }
            safeToStart();
            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            reloadPorts();
            setupAxesList();
        }    

        private void btn_ReloadPorts_Click(object sender, EventArgs e)
        {
            reloadPorts();
        }
        private bool configureNewPort()
        {
            Console.WriteLine(cb_COMPort.SelectedItem);
            
            comPort = new System.IO.Ports.SerialPort((string)cb_COMPort.SelectedItem, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
             if (comPort.IsOpen)
            {
                MessageBox.Show("The selected COM port is already open, close it, then try again, or select a different port.");
                return false;
            }
             vJoystick.AcquireVJD(1);
             comPort.NewLine = ";";
             comPort.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
             comPort.Open();
            
            return true;
        }

        /*This method performs the core operation of taking in a line of Serial Data and then writing values to the joyValues
         * The line data is set up in the following manner (double quotes are just used to designate the named parts of each message component):
         * "Axis Type","Axis Number","Axis Value";
         * 
         * This is written into the joyValues array in that fashion
         */
        public void parseJoystickData(string line)
        {
            int seg1 = line.IndexOf(",");
            int seg2 = line.IndexOf(",", seg1 + 1);
            int seg3 = line.IndexOf(";");
            string type = line.Substring(0, seg1);
            string sNumber = line.Substring(seg1 + 1, (seg2 - seg1) - 1);
            
            string sValue = line.Substring(seg2 + 1, (seg3 - seg2)-1);
            int number = int.Parse(sNumber);
            int value = int.Parse(sValue);
            Console.WriteLine("Type: (" + type + ") Number: (" + number + ") Value: (" + value + ")");
            int arrayOffset = number;

            /*
            switch (type)
            {
                case "Axis":
                    arrayOffset = number;
                    break;
                case "BTN":
                    arrayOffset = 16 + number;
                    break;
                case "POV":
                    arrayOffset = 40 + number;
                    break;
                default:
                    arrayOffset = 0;
                    break;
            }
             */
            joyValues[arrayOffset] = value; //Write the value to the array
            writeToJoystick();
            
        }


        public void writeToJoystick()
        {
            foreach (AxisNode binding in axes)
            {
                switch (binding.bindingType)
                {
                    case "Axis":
                        vJoystick.SetAxis(joyValues[binding.bindingInputIndex], 1, binding.bindingOutputAxis);
                        break;
                    case "Button":
                        vJoystick.SetBtn(Convert.ToBoolean(joyValues[binding.bindingInputIndex]), 1, (uint)binding.bindingOutputBtn);
                        break;
                    default:
                        break;
                }
            }
            
        }


        public void parseInitialConfig(string data)
        {
            //TODO: It would be nice if each of the axes could be defined on the end device and named pretty things to make configuring this application easier

        }



        string dataLine;
        private void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            
            SerialPort sp = (SerialPort)sender;
            
            bool gotLine = false;
            try
            {
               dataLine = dataLine + sp.ReadExisting();

                if (dataLine.EndsWith(";")){
                    gotLine = true;
                    Console.WriteLine(dataLine);
                    parseJoystickData(dataLine);
                    dataLine = "";
                }

               
                //We succeeded in getting a whole line of data.  Now we can do something with it
              // parseJoystickData(dataLine);
              
            }
            catch (Exception)
            {
                dataLine = sp.ReadExisting();
                gotLine = false; //We failed to get a full line of data, so we are jsut going to throw this data out most likely
            }
            


        }




        private void beginJoystick()
        {
            
            if (!vJoystick.isJoystickReady())
            {
                MessageBox.Show("The vJoy virtual joystick driver was unable to be located.  Make sure you installed the driver correctly, then try again",
                    "The Virtual Joystick Cannot be Started");
                isRunning = false;
                return;
            }


            
                cb_COMPort.Enabled = false;
                btn_ReloadPorts.Enabled = false;
                tv_Axes.Enabled = false;
                btn_StartStop.Text = "Stop Joystick";
                configureNewPort();
           
            
            
           
            

        }
        private void stopJoystick()
        {
            btn_StartStop.Text = "Start On Selected Port";
            cb_COMPort.Enabled = true;
            tv_Axes.Enabled = true;
            btn_ReloadPorts.Enabled = true;

            if (comPort.IsOpen)
            {
                comPort.Close();
            }
        }

        private void btn_StartStop_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopJoystick();
        }
        
        int lastNodeCount = 0;
        //This is perhaps the worst way to go about this, but there is really no other option...
        private void tv_Axes_VisibleChanged(object sender, EventArgs e)
        {
            
            //Check to see if the collection of nodes has changed
            if (lastNodeCount != tv_Axes.Nodes.Count)
            {
                lastNodeCount = tv_Axes.Nodes.Count;
                axes.Clear();
                foreach (TreeNode node in tv_Axes.Nodes)
                {
                    AxisNode axNode = (AxisNode)node;
                    axes.Add(axNode);
                }
                loadAxisList();
            }
           
           
            
        }

        private void btnAddNewBinding_Click(object sender, EventArgs e)
        {
            AddNewBindingDialog addNewDiag = new AddNewBindingDialog();


            DialogResult results = addNewDiag.ShowDialog(this);
           if (results == DialogResult.OK) //Time to add a new binding!
           {
               AxisNode newBinding;
               HID_USAGES usage = HID_USAGES.HID_USAGE_X;

               switch (addNewDiag.bindingOutputAxis)
	            {
                   case "HID_USAGE_X":
                       usage = HID_USAGES.HID_USAGE_X;
                       break;
                        case "HID_USAGE_Y":
                       usage = HID_USAGES.HID_USAGE_Y;
                       break;
                        case "HID_USAGE_Z":
                       usage = HID_USAGES.HID_USAGE_Z;
                       break;
                        case "HID_USAGE_RX":
                       usage = HID_USAGES.HID_USAGE_RX;
                       break;
                        case "HID_USAGE_RY":
                       usage = HID_USAGES.HID_USAGE_RY;
                       break;
                        case "HID_USAGE_RZ":
                       usage = HID_USAGES.HID_USAGE_RZ;
                       break;
                        case "HID_USAGE_SL0":
                       usage = HID_USAGES.HID_USAGE_SL0;
                       break;
                        case "HID_USAGE_SL1":
                       usage = HID_USAGES.HID_USAGE_SL1;
                       break;
                        case "HID_USAGE_POV":
                       usage = HID_USAGES.HID_USAGE_POV;
                       break;
                        case "HID_USAGE_WHL":
                       usage = HID_USAGES.HID_USAGE_WHL;
                       break;
		            default:
                     break;
	                }
              

                  
               switch (addNewDiag.bindingType)
               {
                      
                   case "Axis":

                       newBinding = new AxisNode(addNewDiag.bindingName, addNewDiag.bindingInputIndex, usage);
                       break;
                   case "Button":
                       newBinding = new AxisNode(addNewDiag.bindingName, addNewDiag.bindingInputIndex, addNewDiag.bindingOutputButton);
                       break;
                   default:
                       newBinding = new AxisNode(addNewDiag.bindingName, addNewDiag.bindingInputIndex, usage);
                       break;
               }
               axes.Add(newBinding);
              loadAxisList();
           
           }

        }

        private void btn_loadConfig_Click(object sender, EventArgs e)
        {
            filer.readFile("");
            axes = filer.bindings;
            loadAxisList();
        }

        private void btn_SaveConfig_Click(object sender, EventArgs e)
        {
            filer.setConfigs(axes);
            filer.makeFile();
        }

    }
}
