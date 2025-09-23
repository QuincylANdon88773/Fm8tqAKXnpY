// 代码生成时间: 2025-09-23 19:12:28
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace HttpHandlerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient httpClient;

        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Handles the Click event of the SendRequestButton.
        /// </summary>
        private async void SendRequestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = UrlTextBox.Text;
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                ResultTextBox.Text = responseBody;
            }
            catch (HttpRequestException httpException)
            {
                MessageBox.Show($"Error sending request: {httpException.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}