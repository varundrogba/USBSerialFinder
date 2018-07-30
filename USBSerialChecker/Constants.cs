using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBSerialFinder
{
    class Constants
    {
        public static readonly string Query = "SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'";
        public static readonly string WindowsPhysicalMediaTag = "Win32_PhysicalMedia.Tag";
        public static readonly string DeviceID = "DeviceID";
        public static readonly string SerialNumber = "SerialNumber";
    }
}
