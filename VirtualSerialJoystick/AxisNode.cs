using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vJoyInterfaceWrap;
namespace VirtualSerialJoystick
{
    public partial class AxisNode : TreeNode
    {
        private string type;
        private int inputIndex;
        private int btnNumber;
        private string name;
        private HID_USAGES axis;

        public string bindingType
        {
            get
            {
                return type;
            }
        }
        public string bindingName
        {
            get
            {
                return name;
            }
        }
        public int bindingInputIndex
        {
            get
            {
                return inputIndex;
            }
        }
        public int bindingOutputBtn
        {
            get
            {
                return btnNumber;
            }
        }
        public HID_USAGES bindingOutputAxis
        {
            get
            {
                return axis;
            }
        }
        TreeNode outputAxisNode = new TreeNode();
        TreeNode inputIndexNode = new TreeNode();
        /// <summary>
        /// This Constuctor is for adding a new Axis
        /// </summary>
        /// <param name="_name">This is the friendly name of the Axis in question</param>
        /// <param name="_inputIndex">This is the index of input value that the axis should be tied to</param>
        /// <param name="_axis">This is virtual axis this axis should be tied to</param>
        public AxisNode(string _name, int _inputIndex, HID_USAGES _axis)
        {

            changeName(_name);
            this.ContextMenuStrip = changeNameMenu;
            this.ToolTipText = "Right-click to edit/delete this binding.";
            type = "Axis";
            inputIndex = _inputIndex;
            axis = _axis;
            Nodes.Add("Type: " + type);
            inputIndexNode.Text = ("Input Index: " +inputIndex.ToString());
            inputIndexNode.ToolTipText = "This is the index of the input value array that with value will be gotten from.  Right-click to change.";
            inputIndexNode.ContextMenuStrip = inputIndexChangeMenu;
            Nodes.Add(inputIndexNode);

            outputAxisNode.Text = ("Output Axis Name: " + axis.ToString());
            outputAxisNode.ToolTipText = "This is the axis on the virtual joystick the value will be sent to.  Right-click to change.";
            outputAxisNode.ContextMenuStrip = hidAxisChangeMenu;
            Nodes.Add(outputAxisNode);
            
            }

        public AxisNode(string _name, int _inputIndex, int _btnNumber)
        {
            
            changeName(_name);
            this.ContextMenuStrip = changeNameMenu;
            type = "Button";
            inputIndex = _inputIndex;
            btnNumber = _btnNumber;
            Nodes.Add("Type: " + type);
            inputIndexNode.Text = ("Input Index: " + inputIndex.ToString());
            inputIndexNode.ToolTipText = "This is the index of the input value array that with value will be gotten from.  Right-click to change.";
            inputIndexNode.ContextMenuStrip = inputIndexChangeMenu;
            Nodes.Add(inputIndexNode);

            outputAxisNode.Text = ("Output Button Number: " + btnNumber.ToString());
            outputAxisNode.ToolTipText = "This is the button on the virtual joystick the value will be sent to.  Right-click to change.";
            outputAxisNode.ContextMenuStrip = btnNumberChangeMenu;
            Nodes.Add(outputAxisNode);

        }













        //Below are all of the graphical things and shenanigans to make it pretty and nice and configurable
        private ContextMenuStrip m_changeNameMenu = null;
        private ContextMenuStrip changeNameMenu
        {
            get
            {
                if (m_changeNameMenu == null)
                {
                    m_changeNameMenu = new ContextMenuStrip();
                    m_changeNameMenu.Items.Add(new ToolStripLabel("Enter in a new name below."));
                    m_changeNameMenu.Items.Add(new ToolStripSeparator());
                    ToolStripTextBox tbName = new ToolStripTextBox();
                    tbName.Text = name;
                    tbName.TextChanged += tbName_TextChanged;
                    m_changeNameMenu.Items.Add(tbName);
                    ToolStripButton btnRemove = new ToolStripButton("Delete this Binding");
                    btnRemove.Click += btnRemove_Click;
                    m_changeNameMenu.Items.Add(btnRemove);
                   
                }
                return m_changeNameMenu;
            }
        }

        void btnRemove_Click(object sender, EventArgs e)
        {
          DialogResult results = MessageBox.Show("Clicking OK will delete the selected binding, press Cancel to keep this binding",
                       "Just Making Sure...",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2,
                       MessageBoxOptions.DefaultDesktopOnly);
          if (results == DialogResult.OK)
          {
              TreeView mine = this.TreeView;
              this.Remove();
              mine.Visible = false;
              mine.Visible = true;

          }
        }

        void tbName_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox box = (ToolStripTextBox)sender;
            changeName(box.Text);
        }

        private ContextMenuStrip m_hidAxisChangeMenu = null;
        private ContextMenuStrip hidAxisChangeMenu
        {
            get
            {
                if (m_hidAxisChangeMenu == null)
                {
                    m_hidAxisChangeMenu = new System.Windows.Forms.ContextMenuStrip();
                    m_hidAxisChangeMenu.Items.Add(new ToolStripLabel("Select a new ouput axis below."));
                    m_hidAxisChangeMenu.Items.Add(new ToolStripSeparator());

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_X.ToString()));
                    m_hidAxisChangeMenu.Items[2].Click += AxisNodeX_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_Y.ToString()));
                    m_hidAxisChangeMenu.Items[3].Click += AxisNodeY_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_Z.ToString()));
                    m_hidAxisChangeMenu.Items[4].Click += AxisNodeZ_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_RX.ToString()));
                    m_hidAxisChangeMenu.Items[5].Click += AxisNodeRX_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_RY.ToString()));
                    m_hidAxisChangeMenu.Items[6].Click += AxisNodeRY_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_RZ.ToString()));
                    m_hidAxisChangeMenu.Items[7].Click += AxisNodeRZ_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_POV.ToString()));
                    m_hidAxisChangeMenu.Items[8].Click += AxisNodePOV_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_SL0.ToString()));
                    m_hidAxisChangeMenu.Items[9].Click += AxisNodeSL0_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_SL1.ToString()));
                    m_hidAxisChangeMenu.Items[10].Click += AxisNodeSL1_Click;

                    m_hidAxisChangeMenu.Items.Add(new ToolStripMenuItem(HID_USAGES.HID_USAGE_WHL.ToString()));
                    m_hidAxisChangeMenu.Items[11].Click += AxisNodeWHL_Click;
                    
                }
                return m_hidAxisChangeMenu;
            }
        }


        private ContextMenuStrip m_btnNumberChangeMenu = null;
        private ContextMenuStrip btnNumberChangeMenu
        {
            get
            {
                if (m_btnNumberChangeMenu == null)
                {
                    m_btnNumberChangeMenu = new System.Windows.Forms.ContextMenuStrip();
                    ToolStripLabel info = new ToolStripLabel("Set a new button value below.");
                    ToolStripLabel info2 = new ToolStripLabel("Values can range from 1-128.");
                    ToolStripTextBox indexNumber = new ToolStripTextBox();
                    indexNumber.Text = btnNumber.ToString();
                    indexNumber.TextChanged += btnNumber_TextChanged;
                    m_btnNumberChangeMenu.Items.Add(info);
                    m_btnNumberChangeMenu.Items.Add(info2);
                    m_btnNumberChangeMenu.Items.Add(new ToolStripSeparator());
                    m_btnNumberChangeMenu.Items.Add(indexNumber);




                }
                return m_btnNumberChangeMenu;
            }
        }
        void btnNumber_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox box = (ToolStripTextBox)sender;
            string newText = box.Text;


            // We need to check the text to make sure that user doens't try and pull anything stupid...
            foreach (char character in box.Text)
            {
                if (!char.IsDigit(character))
                {
                    newText = newText.Remove(newText.IndexOf(character), 1);
                }
            }

            //Now that we are confident that the text is only numbers, lets do a sanity check to make sure the user isn't going to set the index to an unreasonable value
            if (newText.Length > 0)
            {
                if (int.Parse(newText) > Properties.Settings.Default.maxButton)
                {
                    newText = "128";
                    MessageBox.Show("The acceptable values for this are 1-128.  Try a different value",
                        "Unreasonable Value",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);

                }
                if (int.Parse(newText) < 1)
                {
                    newText = "1";
                    MessageBox.Show("The acceptable values for this are 1-128.  Try a different value",
                        "Unreasonable Value",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);

                }
                box.Text = newText;
                changeBtnNumber(int.Parse(newText));
            }


        }

        private ContextMenuStrip m_inputIndexChangeMenu = null;
        private ContextMenuStrip inputIndexChangeMenu
        {
            get
            {
                if (m_inputIndexChangeMenu == null)
                {
                    m_inputIndexChangeMenu = new System.Windows.Forms.ContextMenuStrip();
                    ToolStripLabel info = new ToolStripLabel("Set a new index value below.");
                    ToolStripLabel info2 = new ToolStripLabel("Values can range from 0-145.");
                    ToolStripTextBox indexNumber = new ToolStripTextBox();
                    indexNumber.Text = inputIndex.ToString();
                    indexNumber.TextChanged += indexNumber_TextChanged;
                    m_inputIndexChangeMenu.Items.Add(info);
                    m_inputIndexChangeMenu.Items.Add(info2);
                    m_inputIndexChangeMenu.Items.Add(new ToolStripSeparator());
                    m_inputIndexChangeMenu.Items.Add(indexNumber);
                   
                    
                   

                }
                return m_inputIndexChangeMenu;
            }
        }

      

        void indexNumber_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox box = (ToolStripTextBox)sender;
            string newText = box.Text;
            

            // We need to check the text to make sure that user doens't try and pull anything stupid...
            foreach (char character in box.Text)
            {                
                if (!char.IsDigit(character))
                {                    
                    newText = newText.Remove(newText.IndexOf(character), 1);
                }
            }           
 
            //Now that we are confident that the text is only numbers, lets do a sanity check to make sure the user isn't going to set the index to an unreasonable value
            if (newText.Length > 0)
            {
                if (int.Parse(newText) > Properties.Settings.Default.maxIndex)
                {
                    newText = "145";
                    MessageBox.Show("The acceptable values for this are 0-145.  Try a different value",
                        "Unreasonable Value",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);

                }
                box.Text = newText;
                changeInputIndex(int.Parse(newText));
            }
            
           
        }


        void changeName(string _newName)
        {
            name = _newName;
            this.Text = name;

        }

        void changeBtnNumber(int _newNumber)
        {
            btnNumber = _newNumber;
            outputAxisNode.Text = ("Output Button Number: " + btnNumber.ToString());

        }

        void changeInputIndex(int _newIndex)
        {
            inputIndex = _newIndex;
            inputIndexNode.Text = ("Input Index: " + inputIndex.ToString());

        }

        void changeAxis(HID_USAGES _newUsage)
        {
            axis = _newUsage;
            outputAxisNode.Text = ("Output Axis Name: " + axis.ToString());

        }

        void AxisNodeX_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_X);
        }

        void AxisNodeY_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_Y);
        }

        void AxisNodeZ_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_Z);
        }
        
        void AxisNodeRX_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_RX);
        }
        void AxisNodeRY_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_RY);
        }
        void AxisNodeRZ_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_RZ);
        }

        void AxisNodePOV_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_POV);
        }
        void AxisNodeSL0_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_SL0);
        }
        void AxisNodeSL1_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_SL1);
        }
        void AxisNodeWHL_Click(object sender, EventArgs e)
        {
            changeAxis(HID_USAGES.HID_USAGE_WHL);
        }

      }
    
    }

