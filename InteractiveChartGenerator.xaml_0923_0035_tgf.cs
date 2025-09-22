// 代码生成时间: 2025-09-23 00:35:30
using System;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace InteractiveChartGenerator
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();
            plotModel = new PlotModel { Title = "Interactive Chart Generator" };
            myPlotView.Model = plotModel;
        }

        private void AddDataPointButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var xValue = double.Parse(xValueTextBox.Text);
                var yValue = double.Parse(yValueTextBox.Text);
                AddDataPoint(xValue, yValue);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for x and y values.");
            }
        }

        private void AddDataPoint(double x, double y)
        {
            var scatterSeries = new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerFill = OxyColors.Blue
            };

            if (plotModel.Series.Contains(scatterSeries))
            {
                scatterSeries.Points.Add(new ScatterPoint(x, y));
            }
            else
            {
                plotModel.Series.Add(scatterSeries);
                scatterSeries.Points.Add(new ScatterPoint(x, y));
            }
        }

        private void ClearChartButton_Click(object sender, RoutedEventArgs e)
        {
            plotModel.Series.Clear();
        }

        private void SaveChartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PngExporter pngExporter = new PngExporter
                {
                    Width = 800,
                    Height = 600,
                   Background = OxyColors.White
                };
                string filePath = @"C:\Chart.png";
                pngExporter.ExportToFile(plotModel, filePath);
                MessageBox.Show("Chart saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the chart: {ex.Message}");
            }
        }
    }
}