using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJoyInterfaceWrap;


namespace VirtualSerialJoystick
{
    public partial class VJoyControl : vJoy
    {
        
        public Boolean isJoystickReady(){
             if (vJoyEnabled())
            {
                  Console.WriteLine("Vendor: " + GetvJoyManufacturerString() + " Product: " + GetvJoyProductString() + " Version Number: " + GetvJoyVersion());
                 return true;
            }
            else
            {
                Console.WriteLine("Failed getting vJoy Attributes");
                 return false;
            }
        }

        
    }
}
