// 代码生成时间: 2025-08-03 21:10:35
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SortingAlgorithmWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> numbers;

        public MainWindow()
        {
            InitializeComponent();
            numbers = new List<int>();
        }

        private void SortNumbers(object sender, RoutedEventArgs e)
        {
            try
            {
                // Convert the text to integers
                numbers = Int32.Parse(textBox.Text.Split(',')).ToList();

                // Sort the numbers using the QuickSort algorithm
                QuickSort(numbers, 0, numbers.Count - 1);

                // Display the sorted numbers
                resultTextBox.Text = string.Join(", ", numbers);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a comma-separated list of numbers.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// QuickSort algorithm implementation
        /// </summary>
        /// <param name="list">List of integers to sort</param>
        /// <param name="left">Starting index of the list</param>
        /// <param name="right">Ending index of the list</param>
        private void QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(list, left, right);
                QuickSort(list, left, pivot - 1);
                QuickSort(list, pivot + 1, right);
            }
        }

        /// <summary>
        /// Partitions the list for QuickSort algorithm
        /// </summary>
        /// <param name="list">List of integers</param>
        /// <param name="left">Starting index of the list</param>
        /// <param name="right">Ending index of the list</param>
        /// <returns>The pivot index</returns>
        private int Partition(List<int> list, int left, int right)
        {
            int pivot = list[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    Swap(list, i, j);
                }
            }
            Swap(list, i + 1, right);
            return i + 1;
        }

        /// <summary>
        /// Swaps two elements in the list
        /// </summary>
        /// <param name="list">List of integers</param>
        /// <param name="i">First index</param>
        /// <param name="j">Second index</param>
        private void Swap(List<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        private void ClearNumbers(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
            resultTextBox.Clear();
        }
    }
}