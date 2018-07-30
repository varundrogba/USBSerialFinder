using System;
using System.Management;
using System.IO;
using System.Linq;

namespace USBDataProtector
{
    class USBSerialProtector
    {
        static void Main(string[] args)
        {
            //Path to text file. Can be modified as per your requirement.
            //This should be defined in the Constants.cs file for easier use in future
            string path = AppDomain.CurrentDomain.BaseDirectory + "FileName.txt"; 
            ManagementObjectSearcher Search = new ManagementObjectSearcher(Constants.Query);
            foreach (ManagementObject currentObject in Search.Get())
            {
                ManagementObject Query = new ManagementObject(Constants.WindowsPhysicalMediaTag + "='" + currentObject[Constants.DeviceID] + "'");
                //Insert path of folder which contains files to be deleted below. Modify this as per requirement. This should be defined in the Constants.cs file for easier use in future
                DirectoryInfo Folder = new DirectoryInfo(path);
                if (!File.Exists(path))
                {
                    // Insert Name pattern of File(s) to be deleted below. This should be defined in the Constants.cs file for easier use in future
                    foreach (FileInfo file in Folder.GetFiles("Delete.txt"))
                    {
                        file.Delete();
                    }
                }
                else if(File.Exists(path))
                {
                    //This should be defined in the Constants.cs file for easier use in future
                    string passCode = File.ReadLines("FileName.txt").First();
                    if (passCode.Equals(Query[Constants.SerialNumber].ToString()))
                    {
                        // Do something.
                        break;
                    }
                    else
                    {
                        // Insert Name pattern of File(s) to be deleted below. This should be defined in the Constants.cs file for easier use in future
                        foreach (FileInfo file in Folder.GetFiles("Delete.txt"))
                        {
                            file.Delete();
                        }
                    }
                }
            }
        }
    }
}
