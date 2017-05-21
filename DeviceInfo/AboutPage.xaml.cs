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
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
//using Calculator.objects;

namespace Calculator
{
    public partial class AboutPage : PhoneApplicationPage
    {
        private static string TAG = "AboutPage";
        public AboutPage()
        {
            Debug.WriteLine(TAG + " created");
            InitializeComponent();

     //       Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("https://google.com");
      //      StreamReader reader = new StreamReader(stream);
        //    string html = reader.ReadToEnd();
         //   mWebBrowser.NavigateToString(html);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //mAuthors.Text = "Authors:\nChris Cederstrom\nHung Nguyen\nIsmael Gonzalez\nVictor Perez";
            //IsolatedStorageSettings mSettings = IsolatedStorageSettings.ApplicationSettings;
            //textBlock1.Text = "Compile count = " + (mSettings["Dev_Data"] as DevData).CompileCount;
            mSystemVersion.Text = Assembly.GetExecutingAssembly().FullName.ToString();
            mSystemVersion.Text = mSystemVersion.Text + "\nRun time: " + Assembly.GetExecutingAssembly().ImageRuntimeVersion.ToString();
           // mSystemVersion.Text = mSystemVersion.Text + "\nManifest: " + Assembly.GetExecutingAssembly().ManifestModule.ToString();
            //mSystemVersion.Text = mSystemVersion.Text + "\nEntry Point: " + Assembly.GetExecutingAssembly().EntryPoint.ToString();
           // mSystemVersion.Text = mSystemVersion.Text + "\nAssembly: " + Assembly.GetExecutingAssembly().ToString();
            mSystemVersion.Text = mSystemVersion.Text + "\n" + Assembly.GetCallingAssembly().ToString();
            //mSystemVersion.Text = mSystemVersion.Text + "\nFull name: " + Assembly.GetExecutingAssembly().FullName.ToString();
           // mSystemVersion.Text = mSystemVersion.Text + "\nRuntime ver: " + Assembly.GetExecutingAssembly().ImageRuntimeVersion.ToString();
           // mSystemVersion.Text = mSystemVersion.Text + "\nManifest module: " + Assembly.GetExecutingAssembly().ManifestModule.ToString();

           // mSystemVersion.Text = "Build: " + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            //mSystemVersion.Text = mSystemVersion.Text + "\nMajor: " + Assembly.GetExecutingAssembly().GetName().Version.Major;
            //mSystemVersion.Text = mSystemVersion.Text + "\nMinor: " + Assembly.GetExecutingAssembly().GetName().Version.Minor;
            //mSystemVersion.Text = mSystemVersion.Text + "\nRevision: " + Assembly.GetExecutingAssembly().GetName().Version.Revision;
            
            /*if (IsolatedStorageSettings.ApplicationSettings.Contains("testDATA"))
            {
                textBlock1.Text = IsolatedStorageSettings.ApplicationSettings["testDATA"] as string;
            }*/
        }

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    IsolatedStorageSettings mSettings = IsolatedStorageSettings.ApplicationSettings;
        //    if (!mSettings.Contains("testDATA"))
        //    {                
        //    }
        //    else
        //    {
        //        mSettings["testDATA"] = "changed";
        //    }
        //    mSettings.Save();
        //}
    }
}