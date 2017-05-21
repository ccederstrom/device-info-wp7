using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
using System.Diagnostics;
using Visiblox.Charts;



namespace DeviceInfo
{
    public partial class MainPage : PhoneApplicationPage
    {

        private static readonly int ANIDLength = 32;
        private static readonly int ANIDOffset = 2;
        //string _DeviceName;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Application.Current.Host.Settings.EnableFrameRateCounter = true;

            PrintInfo();
            ///////////////////////////
            //Line Graph
            //////////////////////////
            //We need one data series for each chart series
            DataSeries<double, double> xData = new DataSeries<double, double>("y=x");
            DataSeries<double, double> xSquaredData = new DataSeries<double, double>("y=x^2");
            DataSeries<double, double> xCubedData = new DataSeries<double, double>("y=x^3");

            //Add the data points to the data series according to the correct equation
            for (double i = 0.0; i < 2; i += 0.01)
            {
                xData.Add(new DataPoint<double, double>() { X = i, Y = i });
                xSquaredData.Add(new DataPoint<double, double>() { X = i, Y = i * i });
                xCubedData.Add(new DataPoint<double, double>() { X = i, Y = i * i * i });
            }

            //Finally, associate the data series with the chart series
            exampleChart.Series[0].DataSeries = xData;
            exampleChart.Series[1].DataSeries = xSquaredData;
            exampleChart.Series[2].DataSeries = xCubedData;

            /////////////////////////
            //Pie Chart
            ////////////////////////
            DataSeries<string, double> series = new DataSeries<string, double>();

            series.Add(new DataPoint<string, double>("F. Alonso", 10));
            series.Add(new DataPoint<string, double>("J. Button", 2));
            series.Add(new DataPoint<string, double>("L. Hamilton", 3));
            series.Add(new DataPoint<string, double>("S. Vettel", 5));
            series.Add(new DataPoint<string, double>("M. Webber", 4));

            MainChart.DataSeries = series;
            
        }


        public static void PrintInfo()
        {

            string anid = UserExtendedProperties.GetValue("ANID") as string;
            Debug.WriteLine("anid: " + anid);

            //http://msdn.microsoft.com/en-us/library/microsoft.phone.info.userextendedproperties.trygetvalue%28v=VS.92%29.aspx

            //string anonymousUserId = anid.Substring(2, 32);
            //Debug.WriteLine("user id" + anonymousUserId);

            Debug.WriteLine("" + Microsoft.Devices.VibrateController.Default.ToString());
            Debug.WriteLine("" + Microsoft.Devices.Environment.DeviceType.ToString());
            Debug.WriteLine("" + Microsoft.Devices.MediaHistoryItem.MaxImageSize.ToString());

            //Debug.WriteLine("" + Microsoft.Phone.Shell.SystemTray.BackgroundColor.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.Shell.ApplicationBarMode.Default.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.Shell.ApplicationBarMode.Minimized.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.Shell.PhoneApplicationService.Current.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.Shell.ShellTile.ActiveTiles.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.UserData.StorageKind.Facebook.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.UserData.StorageKind.Other.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.UserData.StorageKind.Outlook.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.UserData.StorageKind.Phone.ToString());
            //Debug.WriteLine("" + Microsoft.Phone.UserData.StorageKind.WindowsLive.ToString());



            Debug.WriteLine("DeviceName: " + Microsoft.Phone.Info.DeviceStatus.DeviceName.ToString());

            Debug.WriteLine("Class Library Reference for Windows Phone: http://msdn.microsoft.com/en-us/library/ff626516.aspx");

            #region Device Information
            Debug.WriteLine("DEVICE\n================================================================");
            Debug.WriteLine("ApplicationCurrentMemoryUsage: " + Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage.ToString());
            Debug.WriteLine("ApplicationMemoryUsageLimit: " + Microsoft.Phone.Info.DeviceStatus.ApplicationMemoryUsageLimit.ToString());
            Debug.WriteLine("ApplicationPeakMemoryUsage: " + Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage.ToString());
            Debug.WriteLine("DeviceFirmwareVersion: " + Microsoft.Phone.Info.DeviceStatus.DeviceFirmwareVersion.ToString());
            Debug.WriteLine("DeviceHardwareVersion: " + Microsoft.Phone.Info.DeviceStatus.DeviceHardwareVersion.ToString());
            Debug.WriteLine("DeviceManufacturer: " + Microsoft.Phone.Info.DeviceStatus.DeviceManufacturer.ToString());
            Debug.WriteLine("DeviceName: " + Microsoft.Phone.Info.DeviceStatus.DeviceName.ToString());
            Debug.WriteLine("DeviceTotalMemory: " + Microsoft.Phone.Info.DeviceStatus.DeviceTotalMemory.ToString());
            Debug.WriteLine("IsKeyboardDeployed: " + Microsoft.Phone.Info.DeviceStatus.IsKeyboardDeployed.ToString());
            Debug.WriteLine("IsKeyboardPresent: " + Microsoft.Phone.Info.DeviceStatus.IsKeyboardPresent.ToString());
            Debug.WriteLine("PowerSource: " + Microsoft.Phone.Info.DeviceStatus.PowerSource.ToString());




            #endregion

            #region Camera

            Debug.WriteLine("Camera Type: " + Microsoft.Devices.CameraType.FrontFacing.ToString());
            Debug.WriteLine("Primary Type: " + Microsoft.Devices.CameraType.Primary.ToString());
            Debug.WriteLine("" + Microsoft.Devices.PhotoCamera.IsCameraTypeSupported(Microsoft.Devices.CameraType.Primary).ToString());
            Debug.WriteLine("" + Microsoft.Devices.PhotoCamera.IsCameraTypeSupported(Microsoft.Devices.CameraType.FrontFacing).ToString());
            #endregion


            #region Media
            Debug.WriteLine("MEDIA\n================================================================");
            Debug.WriteLine("IsMultiResolutionVideoSupported: " + Microsoft.Phone.Info.MediaCapabilities.IsMultiResolutionVideoSupported.ToString());

            Debug.WriteLine("external: " + Microsoft.Phone.BackgroundAudio.PlayState.Unknown.ToString());
            //Debug.WriteLine("" + Microsoft.Devices.MediaHistory.Instance.ToString());
            //Debug.WriteLine("" + Microsoft.Devices.MediaHistory.Instance.NowPlaying.ToString());
            //Debug.WriteLine("" + Microsoft.Devices.MediaHistory.Instance.NowPlaying.Title.ToString());
            //Debug.WriteLine("" + Microsoft.Devices.MediaHistory.Instance.NowPlaying.Source.ToString());
            //Debug.WriteLine("" + Microsoft.Devices.MediaHistory.Instance.NowPlaying.ImageStream.ToString());
            //Debug.WriteLine("" + Microsoft.Devices.MediaHistory.Instance.NowPlaying.PlayerContext.ToString());
            //Debug.WriteLine("" + Microsoft.Devices.MediaHistory.Instance.NowPlaying.GetHashCode().ToString());
            #endregion
            #region Storage
            Debug.WriteLine("STORAGE\n================================================================");
            #endregion

            #region Network
            Debug.WriteLine("NETWORK\n================================================================");
            Debug.WriteLine("CellularMobileOperator: " + Microsoft.Phone.Net.NetworkInformation.DeviceNetworkInformation.CellularMobileOperator.ToString());
            Debug.WriteLine("IsCellularDataEnabled: " + Microsoft.Phone.Net.NetworkInformation.DeviceNetworkInformation.IsCellularDataEnabled.ToString());
            Debug.WriteLine("IsCellularDataRoamingEnabled: " + Microsoft.Phone.Net.NetworkInformation.DeviceNetworkInformation.IsCellularDataRoamingEnabled.ToString());
            Debug.WriteLine("IsNetworkAvailable: " + Microsoft.Phone.Net.NetworkInformation.DeviceNetworkInformation.IsNetworkAvailable.ToString());
            Debug.WriteLine("IsWiFiEnabled: " + Microsoft.Phone.Net.NetworkInformation.DeviceNetworkInformation.IsWiFiEnabled.ToString());
            Debug.WriteLine("Connected: " + Microsoft.Phone.Net.NetworkInformation.ConnectState.Connected.ToString());
            Debug.WriteLine("Disconnected: " + Microsoft.Phone.Net.NetworkInformation.ConnectState.Disconnected.ToString());
            Debug.WriteLine("Wireless80211: " + Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.Wireless80211.ToString());
            
            #endregion

            #region GPS
            Debug.WriteLine("GPS\n================================================================");
            #endregion

            #region Battery
            Debug.WriteLine("BATTERY\n================================================================");
            Debug.WriteLine("battery: " + Microsoft.Phone.Info.PowerSource.Battery.ToString());
            Debug.WriteLine("external: " + Microsoft.Phone.Info.PowerSource.External.ToString());
            #endregion

            #region Radio
            Debug.WriteLine("RADIO\n================================================================");
            Debug.WriteLine("fm radio: " + Microsoft.Devices.Radio.FMRadio.Instance.ToString());
            Debug.WriteLine("CurrentRegion" + Microsoft.Devices.Radio.FMRadio.Instance.CurrentRegion.ToString());
            Debug.WriteLine("Frequency: " + Microsoft.Devices.Radio.FMRadio.Instance.Frequency.ToString());
            Debug.WriteLine("PowerMode:" + Microsoft.Devices.Radio.FMRadio.Instance.PowerMode.ToString());
            Debug.WriteLine("SignalStrength:" + Microsoft.Devices.Radio.FMRadio.Instance.SignalStrength.ToString());




            #endregion

            #region CPU
            Debug.WriteLine("CPU\n================================================================");
            #endregion

            #region Accelerometer
            Debug.WriteLine("ACCELEROMETER\n================================================================");
            #endregion

            Debug.WriteLine("Class Library Reference for Windows Phone: http://msdn.microsoft.com/en-us/library/ff626516.aspx");

        }


        public static string GetManufacturer()
        {
            string result = string.Empty;
            object property;
            if (DeviceExtendedProperties.TryGetValue("DeviceManufacturer", out property))
                result = property.ToString();

            return result;
        }



        public static string GetDeviceName()
        {
            string result = string.Empty;
            object property;
            if (DeviceExtendedProperties.TryGetValue("DeviceManufacturer", out property))
                result = property.ToString();

            return result;
        }


        public static string GetDeviceUniqueId()
        {
            string result = string.Empty;
            object property;
            if (DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out property))
                result = property.ToString();
            return result;
        }

        public static string GetDeviceFirmwareVersion()
        {
            string result = string.Empty;
            object property;
            if (DeviceExtendedProperties.TryGetValue("DeviceFirmwareVersion", out property))
                result = property.ToString();
            return result;
        }

        public static string GetDeviceHardwareVersion()
        {
            string result = string.Empty;
            object property;
            if (UserExtendedProperties.TryGetValue("ANID", out property))
                result = property.ToString();
            return result;
        }

        

        public static string GetDeviceTotalMemory()
        {
            string result = string.Empty;
            object property;
            if (DeviceExtendedProperties.TryGetValue("DeviceTotalMemory", out property))
                result = property.ToString();
            return result;
        }


        public static string GetApplicationCurrentMemoryUsage()
        {
            string result = string.Empty;
            object property;
            if (DeviceExtendedProperties.TryGetValue("ApplicationCurrentMemoryUsage", out property))
                result = property.ToString();
            return result;
        }

        public static string GetApplicationPeakMemoryUsage()
        {
            string result = string.Empty;
            object property;
            if (DeviceExtendedProperties.TryGetValue("ApplicationPeakMemoryUsage", out property))
                result = property.ToString();
            return result;
        }







        //Note: to get a result requires ID_CAP_IDENTITY_DEVICE
        // to be added to the capabilities of the WMAppManifest
        // this will then warn users in marketplace
        public static byte[] GetDeviceUniqueID()
        {
            byte[] result = null;
            object property;
            if (DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out property))
                result = (byte[])property;

            return result;
        }

        // NOTE: to get a result requires ID_CAP_IDENTITY_USER
        //  to be added to the capabilities of the WMAppManifest
        // this will then warn users in marketplace
        public static string GetWindowsLiveAnonymousID()
        {
            string result = string.Empty;
            object anid;
            if (UserExtendedProperties.TryGetValue("ANID", out anid))
            {
                if (anid != null && anid.ToString().Length >= (ANIDLength + ANIDOffset))
                {
                    result = anid.ToString().Substring(ANIDOffset, ANIDLength);
                }
            }

            return result;
        }

    }
}