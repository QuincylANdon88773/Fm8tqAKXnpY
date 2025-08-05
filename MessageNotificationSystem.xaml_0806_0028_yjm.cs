// 代码生成时间: 2025-08-06 00:28:28
using System;
using System.Windows;
using System.Windows.Controls;

namespace MessageNotificationSystem
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

        private void NotifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve the message text from the input field
                string message = MessageTextBox.Text;
                
                // Check if the message is not empty
                if (string.IsNullOrWhiteSpace(message))
                {
                    MessageBox.Show("Please enter a message.");
                    return;
                }
                
                // Show the notification message
                MessageBox.Show(message, "Notification");
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}