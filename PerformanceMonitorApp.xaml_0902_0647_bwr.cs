// 代码生成时间: 2025-09-02 06:47:04
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace PerformanceMonitorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        public MainWindow()
        {
            InitializeComponent();
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        private void UpdatePerformanceData()
        {
            try
            {
                // Update CPU usage data
                cpuUsageTextBlock.Text = $"\{cpuCounter.NextValue():F2}%";

                // Update RAM available data
                ramAvailableTextBlock.Text = $"\{ramCounter.NextValue()} MB";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating performance data: {ex.Message}");
            }
        }

        private void StartMonitoringButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Start monitoring performance data
                UpdatePerformanceData();
                timer.Interval = TimeSpan.FromSeconds(1); // Update every second
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting monitoring: {ex.Message}");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdatePerformanceData();
        }

        private void StopMonitoringButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
