using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCutter
{
    public class CutterUsb :  UsbDevice
    {
        public static Guid deviceInterfaceGuid = new Guid("ecfb0cfd-74c4-4f52-bbf7-343461cd72ac");

        //36fc9e60-c465-11cf-8056-444553540000

        /// <summary>Pololu's USB vendor id.</summary>
        /// <value>0x1FFB</value>
        public const ushort vendorID = 0x1ffb;

        /// <summary>The Micro Maestro's product ID.</summary>
        /// <value>0x0089</value>
        public const ushort productID = 0x5448;


        public CutterUsb(DeviceListItem deviceListItem) : base(deviceListItem)
        {
        }

        public static List<DeviceListItem> getConnectedDevices()
        {
            try
            {
                return UsbDevice.getDeviceList(deviceInterfaceGuid);
            }
            catch (NotImplementedException)
            {
                // use vendor and product instead
                return UsbDevice.getDeviceList(vendorID, new ushort[] { productID });
            }
        }

    }
}
