using Microsoft.VisualBasic;
using System;
using System.Management;
using static System.Net.Mime.MediaTypeNames;

namespace WinCutter
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const int ProductId = 0x5448;

        //Put your Vendor Id Here
        private const int VendorId = 0x0483;
        private void button1_Click(object sender, EventArgs e)
        {

            //    List<ManagementBaseObject> managementBaseObjects = new List<ManagementBaseObject>();

            //    managementBaseObjects = TestUSB.GetLogicalDevices();

            //    List<usblist> vendorNames = new List<usblist>();

            //    foreach (var usbDevice in managementBaseObjects.ToList())
            //    {
            //        //vendorNames.Add(String.Format("Name: {0}, Status: {1}, Instance Path: {2}, GUID: {3}",
            //        //                    usbDevice.GetPropertyValue("Caption"),
            //        //                    usbDevice.GetPropertyValue("Status"),
            //        //                    usbDevice.GetPropertyValue("DeviceID"),
            //        //                    usbDevice.GetPropertyValue("ClassGuid")));
            //        usblist vendorName = new usblist();
            //        vendorName.name = (string)usbDevice.GetPropertyValue("Caption");
            //        var h= usbDevice .GetText(TextFormat.Mof);
            //        vendorName.Guid=h.ToString();
            //        vendorNames.Add(vendorName);

            //    }

            //    var item =vendorNames.Where(a=>a.name.Contains("Princess")).ToList();

            //var item2 = vendorNames.FirstOrDefault(a => a.name == "USB Printing Support");
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> listdata = new List<string>();
            var textdata= TextBoxData.Text;

            //Has³o 1688

            int index = 0;
            int charint=textdata.Length;

            if (textdata.Length > 109)
            {

                for (int i = 0; i < textdata.Length; i += 109)
                {
                    charint = textdata.Length - i;

                    if (i <= 109)
                    {
                        string line = textdata.Substring(index, 109);
                        listdata.Add(line);
                    }
                    else
                    {
                        string line = textdata.Substring(index, charint);
                        listdata.Add(line);
                    }


                    index += 109;
                }

            }
            else
             
            { 
                listdata.Add(textdata); 
            }


                var charcount = "XSR; U0,0; U1417,4370; D1446,4364; D1459,4357; D1470,4348; D1479,4337; D1486,4324; D1492,4295; D1486,4266; D1".Length; //109


            
            var result =   TestUSB.SendData(listdata);

            if (result)
            {
                MessageBox.Show("Wydrukowano");
            }

        }
    }

    public class usblist
    {
        public string name { get; set; }
        public System.String ? Guid { get; set; }
    }
}
