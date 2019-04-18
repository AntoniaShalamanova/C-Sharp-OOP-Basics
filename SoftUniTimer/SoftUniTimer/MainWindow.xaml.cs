using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoftUniTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            ProcessStartInfo processStartInfo = ExecuteCommand($"/s /t {seconds}"); ;

            Process.Start(processStartInfo);
        }

        private void Hibernate(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            ProcessStartInfo processStartInfo = ExecuteCommand($"/h /t {seconds}"); ;

            Process.Start(processStartInfo);
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            ProcessStartInfo processStartInfo = ExecuteCommand($"/r /t {seconds}"); ;

            Process.Start(processStartInfo);
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo processStartInfo = ExecuteCommand("/a"); ;

            Process.Start(processStartInfo);
        }

        private ProcessStartInfo ExecuteCommand(string command)
        {
            return new ProcessStartInfo("shutdown", command)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
        }

        private int GetSeconds()
        {
            if (TimeList.SelectedIndex == 0)
            {
                return 900;
            }
            else if (TimeList.SelectedIndex == 1)
            {
                return 1800;
            }
            else if(TimeList.SelectedIndex == 2)
            {
                return 3600;
            }
            else if(TimeList.SelectedIndex == 3)
            {
                return 7200;
            }

            return 0;
        }
    }
}