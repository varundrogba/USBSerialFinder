using System;
using System.Management;
using System.IO;

namespace USBSerialFinder
{
    class USBSerialTextFile
    {
        static void Main(string[] args)
        {
            //Path where the txt file will be created. This is the path of the folder where the exe will be stored.
            string path = AppDomain.CurrentDomain.BaseDirectory + "FileName.txt";
            ManagementObjectSearcher Search = new ManagementObjectSearcher(Constants.Query);
            foreach (ManagementObject currentObject in Search.Get())
            {
                ManagementObject Query = new ManagementObject(Constants.WindowsPhysicalMediaTag + "='" + currentObject[Constants.DeviceID] + "'");
                if (!File.Exists(path))
                {
                    File.Create(path);
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(Query[Constants.SerialNumber].ToString());
                    tw.Close();
                }
            }
        }
    }
}
