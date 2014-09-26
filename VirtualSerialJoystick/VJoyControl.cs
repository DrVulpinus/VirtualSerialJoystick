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
                Console.WriteLine("Failed getting vJoy Attributes");
                 return true;
            }
            else
            {
                Console.WriteLine("Vendor: %S\nProduct :%S\nVersion Number:%S\n", GetvJoyManufacturerString(), GetvJoyProductString(), GetvJoyVersion());
                 return false;
            }
        }

        
    }
}
