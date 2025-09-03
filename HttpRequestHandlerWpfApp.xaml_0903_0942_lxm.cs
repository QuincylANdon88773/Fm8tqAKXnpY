// 代码生成时间: 2025-09-03 09:42:30
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WpfHttpRequestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void SendRequestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clear previous response
                ResponseTextBox.Clear();

                string url = UrlTextBox.Text;
                if (string.IsNullOrWhiteSpace(url))
                {
                    MessageBox.Show("Please enter a valid URL.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Send GET request
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Read response content as string
                string content = await response.Content.ReadAsStringAsync();

                // Display response content
                ResponseTextBox.Text = content;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"An error occurred while sending the request: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
