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

                string print = @"XSR;U0,0;U0,1613;D0,0;D1612,0;D1612,1613;D0,1613;U1612,0;@";

                List<string> list = new List<string>();

                list.Add("XSR;U0,255;D0,2585;D6,2637;D23,2684;D50,2728;D67,2748;D85,2766;D128,2797;D177,2821;D232,2836;D290,2841");
                list.Add("D6123,2841;D6182,2836;D6236,2821;D6285,2797;D6328,2766;D6347,2748;D6364,2728;D6390,2684;D6407,2637;D6413,2585;D6413,255;D6407,204");
                list.Add("D6390,156;D6364,113;D6347,93;D6328,75;D6285,43;D6236,20;D6182,5;D6123,0;D290,0;D232,5;D177,20;D128,43;D85,75;D67,93");
                list.Add("D50,113;D23,156;D6,204;D0,255;U43,1417;D49,1446;D56,1459;D65,1470;D76,1479;D89,1486;D118,1492;D147,1486;D160,1479;D171,1470;D180,1459;D187,1446");
                list.Add("D193,1417;D187,1387;D180,1374;D171,1363;D160,1354;D147,1347;D118,1341;D89,1347;D76,1354;D65,1363;D56,1374;D49,1387;D43,1417;@");
                //list.Add(";D255,0;D204,4;D156,23;D113,69;D93,46;D35,85;D53,128;D20,177;D4,231;D0,290;D0,4123;D4,4181;D20,4236");
                //list.Add(";D53,4285;D35,4328;D93,4346;D113,4363;D156,4390;D204,4407;D255,4413;U2841,0;@");

                //list.Add("XSR;U0,0;U1417,4370;D1446,4364;D1459,4357;D1470,4348;D1479,4337;D1486,4324;D1492,4295;D1486,4266;D1");
                //list.Add("479,4253;D1470,4242;D1459,4233;D1446,4226;D1417,4220;D1387,4226;D1374,4233;D1363,4242;D1354,4253;D1");
                //list.Add("347,4266;D1341,4295;D1347,4324;D1354,4337;D1363,4348;D1374,4357;D1387,4364;D1417,4370;U255,4413;D25");
                //list.Add("85,4413;D2637,4407;D2684,4390;D2728,4363;D2748,4346;D2766,4328;D2797,4285;D2821,4236;D2836,4181;D28");
                //list.Add("41,4123;D2841,290;D2836,231;D2821,177;D2797,128;D2766,85;D2748,46;D2728,69;D2684,23;D2637,4;D2585,0");
                //list.Add(";D255,0;D204,4;D156,23;D113,69;D93,46;D35,85;D53,128;D20,177;D4,231;D0,290;D0,4123;D4,4181;D20,4236");
                //list.Add(";D53,4285;D35,4328;D93,4346;D113,4363;D156,4390;D204,4407;D255,4413;U2841,0;@");
                // byte[] bytes = Encoding.ASCII.GetBytes(print);

                ////Create a buffer with some data in it
                //var buffer = new byte[64];
                //buffer[0] = 0x3f;
                //buffer[1] = 0x23;
                //buffer[2] = 0x23;




                byte[] buffer = null;
                foreach (var line in list)
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

