// 代码生成时间: 2025-08-16 16:02:32
using System;
using System.Net.NetworkInformation;
using System.Windows;

// 网络连接状态检查器
public partial class NetworkConnectionStatusChecker : Window
{
    public NetworkConnectionStatusChecker()
    {
        InitializeComponent();
    }

    // 检查网络连接状态
    private void CheckNetworkConnection(object sender, RoutedEventArgs e)
    {
        try
        {
            // 获取所有网络接口
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // 检查接口状态
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    MessageBox.Show("Network Interface: " + ni.Name + " is connected.
Status: " + ni.OperationalStatus.ToString(), "Network Connection Status");
                    return;
                }
            }
            MessageBox.Show("No network interface is connected.", "Network Connection Status");
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show("Error: " + ex.Message, "Network Connection Status");
        }
    }
}

// XAML代码部分（NetworkConnectionStatusChecker.xaml）
// <Window x:Class="NetworkConnectionStatusChecker"
//         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//         Title="Network Connection Status Checker" Height="200" Width="300">
//     <Button Content="Check Connection" Click="CheckNetworkConnection" HorizontalAlignment="Center" VerticalAlignment="Center" />
// </Window>