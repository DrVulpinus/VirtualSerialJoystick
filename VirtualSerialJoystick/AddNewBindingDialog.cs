using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualSerialJoystick
{
    public partial class AddNewBindingDialog : Form
    {

        public string bindingType
        {
            get
            {
                return cb_BindType.SelectedItem.ToString();
            }
        }
        public string bindingName
        {
            get
            {
                return tb_BindingName.Text;
            }
        }
        public string bindingOutputAxis
        {
            get
            {
                return cb_OutputAxis.SelectedItem.ToString();
            }
        }
        public int bindingInputIndex
        {
            get
            {
                return (int)nud_InputIndex.Value;
            }
        }
        public int bindingOutputButton
        {
            get
            {
                return (int)nud_OutputButton.Value;
            }
        }







        public AddNewBindingDialog()
        {
            InitializeComponent();
        }

        private void AddNewBindingDialog_Load(object sender, EventArgs e)
        {
            cb_BindType.SelectedIndex = 0;
            cb_OutputAxis.SelectedIndex = 0;
        }
        
        ComboBox m_cb_OutputAxis = null;

        ComboBox cb_OutputAxis
        {
            get
            {
                if (m_cb_OutputAxis == null)
                {
                    m_cb_OutputAxis = new ComboBox();
                    m_cb_OutputAxis.Dock = DockStyle.Top;
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_X.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_Y.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_Z.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_RX.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_RY.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_RZ.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_SL0.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_SL1.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_POV.ToString());
                    m_cb_OutputAxis.Items.Add(HID_USAGES.HID_USAGE_WHL.ToString());
                }
                return m_cb_OutputAxis;
            }
        }


        NumericUpDown m_nud_OutputButton = null;

        NumericUpDown nud_OutputButton
        {
            get
            {
                if (m_nud_OutputButton == null)
                {
                    m_nud_OutputButton = new NumericUpDown();
                    m_nud_OutputButton.Dock = DockStyle.Top;
                    m_nud_OutputButton.Maximum = 128;
                    m_nud_OutputButton.Minimum = 1;
                }
                return m_nud_OutputButton;
            }
        }

        Label m_lbl_AxisName = null;

        Label lbl_AxisName
        {
            get
            {
                if (m_lbl_AxisName == null)
                {
                    m_lbl_AxisName = new Label();
                    m_lbl_AxisName.Text = "Select the Output Axis Binding:";
                    m_lbl_AxisName.Dock = DockStyle.Top;
                }
                return m_lbl_AxisName;
            }
        }





        Label m_lbl_BtnNumber = null;

        Label lbl_BtnNumber
        {
            get
            {
                if (m_lbl_BtnNumber == null)
                {
                    m_lbl_BtnNumber = new Label();
                    m_lbl_BtnNumber.Text = "Select the Output Button Binding:";
                    m_lbl_BtnNumber.Dock = DockStyle.Top;
                }
                return m_lbl_BtnNumber;
            }
        }
        
        
        
        
        
        void setupForAxis()
        {
            pnl_SpecialConfigs.Controls.Clear();
            pnl_SpecialConfigs.Controls.Add(cb_OutputAxis);
            pnl_SpecialConfigs.Controls.Add(lbl_AxisName);
            
            
        }
        void setupForButton()
        {
            pnl_SpecialConfigs.Controls.Clear();
            pnl_SpecialConfigs.Controls.Add(nud_OutputButton);
            pnl_SpecialConfigs.Controls.Add(lbl_BtnNumber);
        }

        private void cb_BindType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_BindType.SelectedItem.ToString())
            {
                case "Axis":
                    setupForAxis();
                    break;
                case "Button":
                    setupForButton();
                    break;
                default:
                    break;
            }
        }

        private void tb_BindingName_TextChanged(object sender, EventArgs e)
        {
            if (tb_BindingName.Text.Length > 0)
            {
                btn_Add.Enabled = true;
            }
            else
            {
                btn_Add.Enabled = false;
            }
        }
    }
}
