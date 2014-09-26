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


        /*This is an array to store the values gotten from the Serial Device
         * The setup of this array is as follows:
         * 0-15 are for joystick axes
         * 16-40 are for buttons
         * 40 - 50 are for POVs
         */
        public int[] joyValues = new int[50];


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

        private void reloadPorts()
        {
            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                cb_COMPort.Items.Add(portName);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            reloadPorts();
            parseJoystickData("Axis,10,50;");
            parseJoystickData("POV,2,790;");
        }    

        private void btn_ReloadPorts_Click(object sender, EventArgs e)
        {
            reloadPorts();
        }
        private bool configureNewPort()
        {
            comPort = new System.IO.Ports.SerialPort(cb_COMPort.SelectedText, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
             if (comPort.IsOpen)
            {
                MessageBox.Show("The selected COM port is already open, close it, then try again, or select a different port.");
                return false;
            }
             comPort.NewLine = ";";
             comPort.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
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
            int arrayOffset = 0;
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
            joyValues[arrayOffset] = value; //Write the value to the array

            
        }

        



        public void parseInitialConfig(string data)
        {
            //TODO: It would be nice if each of the axes could be defined on the end device and named pretty things to make configuring this application easier

        }


        private static void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string dataLine;
            bool gotLine = false;
            try
            {
               dataLine = sp.ReadLine();
               gotLine = true; //We succeeded in getting a whole line of data.  Now we can do something with it
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
                MessageBox.Show("The vJoy Virtual Joystick Drive was unable to be located.  Make sure you installed the driver correctly, then try again",
                    "The Virtual Joystick Cannot be Started");
                isRunning = false;
                return;
            }


            
                cb_COMPort.Enabled = false;
                btn_ReloadPorts.Enabled = false;
                btn_StartStop.Text = "Stop Joystick";
            
           
            
            
           
            

        }
        private void stopJoystick()
        {
            btn_StartStop.Text = "Start On Selected Port";
            cb_COMPort.Enabled = true;
            btn_ReloadPorts.Enabled = true;
        }

        private void btn_StartStop_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
              if (comPort.IsOpen)
            {
                comPort.Close();
            }
        }

    }
}
