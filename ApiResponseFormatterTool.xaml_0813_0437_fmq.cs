// 代码生成时间: 2025-08-13 04:37:57
// ApiResponseFormatterTool.xaml.cs
// This file contains the logic for the WPF application that formats API responses.

using System;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiFormatterTool
{
    /// <summary>
    /// Interaction logic for ApiResponseFormatterTool.xaml
    /// </summary>
    public partial class ApiResponseFormatterTool : Window
    {
        public ApiResponseFormatterTool()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the 'Format' button click event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void FormatButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputJson = InputJsonTextBox.Text;
                if (string.IsNullOrWhiteSpace(inputJson))
                {
                    MessageBox.Show("Please enter a JSON string.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                JObject jsonResponse = JObject.Parse(inputJson);
                FormattedJsonTextBox.Text = jsonResponse.ToString(Formatting.Indented);
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"Error parsing JSON: {ex.Message}", "JSON Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}