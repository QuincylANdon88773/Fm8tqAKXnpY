// 代码生成时间: 2025-09-30 16:40:56
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

// 定义IoT网关管理的ViewModel
namespace IoTGatewayManager
{
    public partial class IoTGatewayManager : Window
    {
        private readonly Dictionary<string, string> gateways = new Dictionary<string, string>();

        public IoTGatewayManager()
        {
            InitializeComponent();
            LoadGateways();
        }

        // 加载IoT网关信息
        private void LoadGateways()
        {
            try
            {
                // 假设从数据库或API获取网关信息，这里使用模拟数据
                gateways.Add("Gateway1", "192.168.1.1");
                gateways.Add("Gateway2", "192.168.1.2");
                // 将网关信息显示在ListBox中
                gatewayListBox.ItemsSource = gateways.Keys;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading gateways: " + ex.Message);
            }
        }

        // 添加IoT网关
        private void AddGateway_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string gatewayName = gatewayNameTextBox.Text;
                string ipAddress = ipAddressTextBox.Text;
                if (string.IsNullOrEmpty(gatewayName) || string.IsNullOrEmpty(ipAddress))
                {
                    MessageBox.Show("Please enter both gateway name and IP address.");
                    return;
                }
                if (gateways.ContainsKey(gatewayName))
                {
                    MessageBox.Show("Gateway already exists.");
                    return;
                }
                gateways.Add(gatewayName, ipAddress);
                gatewayListBox.Items.Add(gatewayName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding gateway: " + ex.Message);
            }
        }

        // 删除IoT网关
        private void RemoveGateway_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedGateway = (string)gatewayListBox.SelectedItem;
                if (string.IsNullOrEmpty(selectedGateway))
                {
                    MessageBox.Show("Please select a gateway to remove.");
                    return;
                }
                gateways.Remove(selectedGateway);
                gatewayListBox.Items.Remove(selectedGateway);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing gateway: " + ex.Message);
            }
        }
    }
}
