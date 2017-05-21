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
using System.Windows.Threading;
using Microsoft.Phone.Net.NetworkInformation;


namespace DeviceInfo
{
    public partial class DeviceStatusPage : PhoneApplicationPage
    {
        DispatcherTimer timer;
        double CurrentMemoryUsage;
        double MemoryUsageLimit;
        double PeakMemoryUsage;
        double DeviceTotalMemory;

        public DeviceStatusPage()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,3);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            CurrentMemoryUsage = Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage;
            MemoryUsageLimit = Microsoft.Phone.Info.DeviceStatus.ApplicationMemoryUsageLimit;
            PeakMemoryUsage = Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage;
            DeviceTotalMemory = Microsoft.Phone.Info.DeviceStatus.DeviceTotalMemory;


            AppCurrentMemUsageProgressBar.Value = (CurrentMemoryUsage / MemoryUsageLimit) * 100;
            AppPeakMemUsageProgressBar.Value = (PeakMemoryUsage / MemoryUsageLimit) * 100;
            AppMemUsageLimitProgressBar.Value = (MemoryUsageLimit / DeviceTotalMemory) * 100;


            #region Memory
            // Application
            ApplicationCurrentMemoryUsageTextBlock.Text = "App Current Memory Usage: " + Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage.ToString();

            ApplicationMemoryUsageLimitTextBlock.Text = "App Memory(byte) Limit: " + Microsoft.Phone.Info.DeviceStatus.ApplicationMemoryUsageLimit.ToString();
            ApplicationPeakMemoryUsageTextBlock.Text = "App Peak Memory(bytes): " + Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage.ToString();
            // device
            DeviceTotalMemoryTextBlock.Text = "Total Memory: " + Microsoft.Phone.Info.DeviceStatus.DeviceTotalMemory.ToString();
            #endregion


            DeviceNameTextBlock.Text = "Device Name: " + Microsoft.Phone.Info.DeviceStatus.DeviceName.ToString();
            DeviceManufacturerTextBlock.Text = "Device Manufacturer: " + Microsoft.Phone.Info.DeviceStatus.DeviceManufacturer.ToString();
            DeviceHardwareVersionTextBlock.Text = "Device Hardware Version: " + Microsoft.Phone.Info.DeviceStatus.DeviceHardwareVersion.ToString();
            DeviceFirmwareVersionTextBlock.Text = "Device Firmware Version: " + Microsoft.Phone.Info.DeviceStatus.DeviceFirmwareVersion.ToString();

            // power
            PowerSourceTextBlock.Text = "Power Source: " + Microsoft.Phone.Info.DeviceStatus.PowerSource.ToString();
            //keyboard
            IsKeyboardDeployedTextBlock.Text = "Is Keyboard Deployed: " + Microsoft.Phone.Info.DeviceStatus.IsKeyboardDeployed.ToString();
            IsKeyboardPresentTextBlock.Text = "Is Keyboard Present: " + Microsoft.Phone.Info.DeviceStatus.IsKeyboardPresent.ToString();

            DeviceNetworkInformationTextBlock.Text = "Mobile operator: " + DeviceNetworkInformation.CellularMobileOperator;
            DeviceNetworkInformationTextBlock.Text = DeviceNetworkInformationTextBlock.Text + "Network: " + DeviceNetworkInformation.IsNetworkAvailable.ToString();
        }


        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // These are TextBlock controls that are created in the page’s XAML file.      

                #region Memory
                // Application
                ApplicationCurrentMemoryUsageTextBlock.Text = "App Current Memory Usage: " + Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage.ToString();
                ApplicationMemoryUsageLimitTextBlock.Text = "App Memory(byte) Limit: " + Microsoft.Phone.Info.DeviceStatus.ApplicationMemoryUsageLimit.ToString();
                ApplicationPeakMemoryUsageTextBlock.Text = "App Peak Memory(bytes): " + Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage.ToString();
                // device
                DeviceTotalMemoryTextBlock.Text = "Total Memory: " + Microsoft.Phone.Info.DeviceStatus.DeviceTotalMemory.ToString();
                #endregion


                DeviceNameTextBlock.Text = "Device Name: " + Microsoft.Phone.Info.DeviceStatus.DeviceName.ToString();
                DeviceManufacturerTextBlock.Text = "Device Manufacturer: "+ Microsoft.Phone.Info.DeviceStatus.DeviceManufacturer.ToString();
                DeviceHardwareVersionTextBlock.Text = "Device Hardware Version: " + Microsoft.Phone.Info.DeviceStatus.DeviceHardwareVersion.ToString();
                DeviceFirmwareVersionTextBlock.Text = "Device Firmware Version: " + Microsoft.Phone.Info.DeviceStatus.DeviceFirmwareVersion.ToString();

                // power
                PowerSourceTextBlock.Text = "Power Source: " +Microsoft.Phone.Info.DeviceStatus.PowerSource.ToString();
                //keyboard
                IsKeyboardDeployedTextBlock.Text = "Is Keyboard Deployed: " + Microsoft.Phone.Info.DeviceStatus.IsKeyboardDeployed.ToString();
                IsKeyboardPresentTextBlock.Text = "Is Keyboard Present: " + Microsoft.Phone.Info.DeviceStatus.IsKeyboardPresent.ToString();
            }
            catch (Exception ex)
            {
                ApplicationCurrentMemoryUsageTextBlock.Text = ex.Message;
                ApplicationMemoryUsageLimitTextBlock.Text = ex.Message;
                ApplicationPeakMemoryUsageTextBlock.Text = ex.Message;
                DeviceTotalMemoryTextBlock.Text = ex.Message;
                DeviceNameTextBlock.Text = ex.Message;
                DeviceManufacturerTextBlock.Text = ex.Message;
                DeviceHardwareVersionTextBlock.Text = ex.Message;
                DeviceFirmwareVersionTextBlock.Text = ex.Message;
                PowerSourceTextBlock.Text = ex.Message;
                IsKeyboardDeployedTextBlock.Text = ex.Message;
                IsKeyboardPresentTextBlock.Text = ex.Message;

            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            #region Trial Mode Check
            if (App.IsTrial == true)
            {
                // enable ads
                adControl.Visibility = System.Windows.Visibility.Visible;
                //adControl.IsAutoRefreshEnabled = true;
                adControl.IsEnabled = true;
                adControl.IsAutoCollapseEnabled = false;
            }
            else
            {
                // disables ads
                adControl.Visibility = System.Windows.Visibility.Collapsed;
                //adControl.IsAutoRefreshEnabled = false;
                adControl.IsEnabled = false;
                adControl.IsAutoCollapseEnabled = false;
            }
            #endregion
        }
    }
}