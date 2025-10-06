// 代码生成时间: 2025-10-06 20:34:47
using System;
using System.Windows;
using System.Net.Http;
using Newtonsoft.Json.Linq;

// 程序的主入口点
namespace BlockchainBrowserApp
{
    // MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        private HttpClient _httpClient;
        private const string BlockchainApiUrl = "https://blockchain.info/unspent?active=";

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string address = AddressTextBox.Text;
                if (string.IsNullOrEmpty(address))
                {
                    MessageBox.Show("Please enter a blockchain address.");
                    return;
                }

                string response = await _httpClient.GetStringAsync(BlockchainApiUrl + address);
                JObject unspentOutputs = JObject.Parse(response);
                TransactionsListView.ItemsSource = unspentOutputs["unspent_outputs"];
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Error fetching data: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}

// XAML code for MainWindow.xaml
// <Window x:Class="BlockchainBrowserApp.MainWindow"
//         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//         Title="Blockchain Browser" Height="450" Width="800">
//     <Grid>
//         <TextBox x:Name="AddressTextBox" Margin="10" PlaceholderText="Enter blockchain address"/>
//         <Button x:Name="BrowseButton" Content="Browse" Click="BrowseButton_Click" Margin="10" Width="100" HorizontalAlignment="Right"/>
//         <ListView x:Name="TransactionsListView" Margin="10">
//             <ListView.View>
//                 <GridView>
//                     <GridViewColumn Header="Address" DisplayMemberBinding="{Binding address}" />
//                     <GridViewColumn Header="Tx Hash" DisplayMemberBinding="{Binding tx_index}" />
//                     <GridViewColumn Header="Output Index" DisplayMemberBinding="{Binding vout}" />
//                     <GridViewColumn Header="Amount" DisplayMemberBinding="{Binding satoshis}" />
//                 </GridView>
//             </ListView.View>
//         </ListView>
//     </Grid>
// </Window>