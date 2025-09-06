// 代码生成时间: 2025-09-07 00:39:54
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OxyPlot;
# 扩展功能模块
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace WpfApp
{
# 添加错误处理
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlotModel _plotModel;

        public MainWindow()
        {
            InitializeComponent();
            _plotModel = new PlotModel { Title = "Interactive Chart Generator" };
            myPlotView.Model = _plotModel;
        }

        /// <summary>
        /// Generates a simple line chart.
        /// </summary>
        private void GenerateLineChart()
        {
            try
            {
                var lineSeries = new LineSeries
                {
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 4,
                    MarkerStroke = OxyColors.Black,
                    MarkerFill = OxyColors.White,
                    Title = "Line Chart"
                };

                lineSeries.Points.Add(new DataPoint(0, 0));
                lineSeries.Points.Add(new DataPoint(10, 10));
                lineSeries.Points.Add(new DataPoint(20, 20));
                
                _plotModel.Series.Add(lineSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating line chart: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates a scatter plot.
        /// </summary>
        private void GenerateScatterPlot()
# 改进用户体验
        {
            try
            {
                var scatterSeries = new ScatterSeries
                {
                    Title = "Scatter Plot"
                };

                scatterSeries.Points.Add(new ScatterPoint(0, 0));
                scatterSeries.Points.Add(new ScatterPoint(10, 10));
                scatterSeries.Points.Add(new ScatterPoint(20, 20));
                
                _plotModel.Series.Add(scatterSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating scatter plot: {ex.Message}");
            }
        }

        // Additional methods for other chart types can be added here.
    }
# 添加错误处理
}

// Note: This code assumes the presence of the OxyPlot library and its WPF bindings.
// Make sure to include the OxyPlot.Wpf NuGet package in your project.
