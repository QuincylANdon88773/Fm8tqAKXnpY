// 代码生成时间: 2025-10-03 02:37:23
 * device is connected to the internet or not.
 *
 * The program consists of a MainWindow with a button to trigger the network check,
 * and a label to display the result.
 */

using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows; // Required for WPF components

namespace NetworkStatusCheckerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Method to check network connection status
        private void CheckNetworkStatus(object sender, RoutedEventArgs e)
        {
            try
            {
                // Ping Google to check if the internet connection is working
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send("www.google.com");

                if (reply.Status == IPStatus.Success)
                {
                    // Display the result in the UI
                    NetworkStatusLabel.Content = "Connected to the internet";
                    NetworkStatusLabel.Foreground = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    NetworkStatusLabel.Content = "No internet connection";
                    NetworkStatusLabel.Foreground = System.Windows.Media.Brushes.Red;
                }
            }
            catch (PingException ex)
            {
                // Handle exception and display error message
                MessageBox.Show("Error: " + ex.Message, "Ping Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Handle any other exception and display error message
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

// XAML code for MainWindow.xaml (not included in this snippet)
// Should include a button to trigger the CheckNetworkStatus method
// and a label to display the network status result.