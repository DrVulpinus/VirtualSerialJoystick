using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualSerialJoystick
{
    class ConfigFileWriter
    {
        List<AxisNode> m_bindings = new List<AxisNode>();

        public List<AxisNode> bindings
        {
            get
            {
                return m_bindings;
            }
        }

        public void setConfigs(List<AxisNode> _bindings)
        {
            m_bindings = _bindings;
        }

        public void makeFile()
        {
            SaveFileDialog saver = new SaveFileDialog();
            saver.AddExtension = true;
            saver.Filter = "Binding Files (*.bind)|*.bind";
            saver.DefaultExt = "Binding Files (*.bind)|*.bind";
            if (saver.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saver.FileName);
                foreach (string line in lineAssembler())
                {
                    Console.WriteLine(line);

                    writer.WriteLine(line);


                }
                writer.Close();
            }
            
        }


        public void readFile(string _inString)
        {
            OpenFileDialog opener = new OpenFileDialog();

            opener.AddExtension = true;
            opener.Filter = "Binding Files (*.bind)|*.bind";
            opener.DefaultExt = "Binding Files (*.bind)|*.bind";

            if (opener.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(opener.FileName);

                m_bindings.Clear();
                while (!reader.EndOfStream)
                {
                    m_bindings.Add(lineToBind(reader.ReadLine()));
                }
                reader.Close();
            }

           
            
        }
        
        private string[] lineAssembler()
        {
            string[] outStr = new string[m_bindings.Count];

            for (int i = 0; i < m_bindings.Count; i++)
            {
                AxisNode bind = m_bindings[i];
                string lineString = "";
                switch (bind.bindingType)
                {
                    case "Axis":
                        lineString = delimetedLineBuilder(bind.bindingType, bind.bindingName, bind.bindingInputIndex.ToString(), bind.bindingOutputAxis.ToString());
                        break;
                    case "Button":
                        lineString = delimetedLineBuilder(bind.bindingType, bind.bindingName, bind.bindingInputIndex.ToString(), bind.bindingOutputBtn.ToString());
                        break;
                    default:
                        break;
                }
                outStr[i] = lineString;
            }
            return outStr;
            
        }

        private string delimetedLineBuilder(string part1, string part2, string part3, string part4)
        {
            return part1 + "," + part2 + "," + part3 + "," + part4 + ";";
        }

        private AxisNode lineToBind(string _line)
        {
            Console.WriteLine(_line);
            AxisNode outBind = null;
            int seg1 = _line.IndexOf(",");
            int seg2 = _line.IndexOf(",", seg1 + 1);
            int seg3 = _line.IndexOf(",", seg2 + 1);
            int seg4 = _line.IndexOf(";");
            string type = _line.Substring(0, seg1);
            string name = _line.Substring(seg1 + 1, (seg2 - seg1) - 1);

            string sIndex = _line.Substring(seg2 + 1, (seg3 - seg2) - 1);
            string sOutBind = _line.Substring(seg3 + 1, (seg4 - seg3) - 1);
            int index = int.Parse(sIndex);

             

               
            switch (type)
            {
                case "Axis":
                    HID_USAGES usage = HID_USAGES.HID_USAGE_X;
                    switch (sOutBind)
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
                    outBind = new AxisNode(name, index, usage);
                    break;
                case "Button":
                    outBind = new AxisNode(name, index, int.Parse(sOutBind));
                    break;
                default:
                    
                    break;
            }
            return outBind;
        }
    }
}
