using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WAV2ByteArray
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            try
            {
                MainWindow = new MainWindow();
                MainWindow.Show();
            }

            catch (Exception test)
            {
                MessageBox.Show (test.ToString());
                Process.GetCurrentProcess().Kill();
            }            
        }
    }
}
