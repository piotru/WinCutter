using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using LibUsbDotNet;

namespace WinCutter
{


    public static class TestUSB
    {
        //Put your Product Id Here
        private const int ProductId = 0x5448;

        //Put your Vendor Id Here
        private const int VendorId = 0x0483;
        public static List<ManagementBaseObject> GetLogicalDevices()
        {
            List<ManagementBaseObject> devices = new List<ManagementBaseObject>();
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher("root\\CIMV2",
                                  @"Select * From CIM_LogicalDevice Where Caption='Princess'"))
                collection = searcher.Get();
            foreach (var device in collection)
            {
                devices.Add(device);
            }
            collection.Dispose();
            return devices;
        }


        public static bool SendData(List<string> listdata) {



            using (var context = new  UsbContext())
            {
                context.SetDebugLevel(LogLevel.Info);

                //Get a list of all connected devices
                using var usbDeviceCollection = context.List();

                //Narrow down the device by vendor and pid
                var selectedDevice = usbDeviceCollection.FirstOrDefault(d => d.ProductId == ProductId && d.VendorId == VendorId);

                //Open the device
                selectedDevice.Open();

                //Get the first config number of the interface
                selectedDevice.ClaimInterface(selectedDevice.Configs[0].Interfaces[0].Number);

                //Open up the endpoints
                var writeEndpoint = selectedDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
                //   var otherEndpoint = selectedDevice.OpenEndpointWriter(WriteEndpointID.Ep02);
                var readEnpoint = selectedDevice.OpenEndpointReader(ReadEndpointID.Ep01);

               

                byte[] buffer = null;
                foreach (var line in listdata)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(line);
                    var er = writeEndpoint.Write(bytes, 3000, out var bytesWritten);

                    System.Console.WriteLine(line);
                    System.Console.WriteLine(er);


                }

                //Write three bytes

                //    var t = otherEndpoint.Transfer(buffer,0,buffer.Length,3000,out bytesWritten);



                var readBuffer = new byte[64];

                //Read some data
                readEnpoint.Read(readBuffer, 3000, out var readBytes);
            }


            return true;
        }










    }




    }

