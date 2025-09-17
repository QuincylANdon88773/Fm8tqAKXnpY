// 代码生成时间: 2025-09-18 00:46:11
// SortAlgorithmApp.xaml.cs
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

// MainWindow.xaml.cs 的代码部分
namespace SortAlgorithmApp
{    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            // 获取数值列表
            List<int> numbers = GetNumbersFromListBox(NumbersListBox);
            if (numbers == null)
            {
                // 显示错误消息
                MessageBox.Show("Please enter valid numbers.");
                return;
            }

            // 选择排序算法并排序
            string selectedAlgorithm = (string)AlgorithmComboBox.SelectedItem;
            List<int> sortedNumbers = SortNumbers(numbers, selectedAlgorithm);
            if (sortedNumbers == null)
            {
                // 显示错误消息
                MessageBox.Show("Selected algorithm is not valid.");
                return;
            }

            // 显示排序结果
            DisplaySortedNumbers(sortedNumbers);
        }

        private List<int> GetNumbersFromListBox(ListBox listBox)
        {
            try
            {
                List<int> numbers = new List<int>();
                foreach (string item in listBox.Items)
                {
                    if (int.TryParse(item, out int number))
                    {
                        numbers.Add(number);
                    }
                }
                return numbers;
            }
            catch (Exception ex)
            {
                // 记录错误
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private List<int> SortNumbers(List<int> numbers, string algorithm)
        {
            switch (algorithm)
            {
                case "Bubble Sort":
                    return BubbleSort(numbers);
                case "Quick Sort":
                    return QuickSort(numbers);
                case "Merge Sort":
                    return MergeSort(numbers);
                default:
                    return null;
            }
        }

        private List<int> BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        // Swap
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
            return list;
        }

        private List<int> QuickSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }
            int pivot = list[0];
            List<int> less = new List<int>();
            List<int> greater = new List<int>();
            foreach (int item in list.Skip(1))
            {
                if (item < pivot)
                {
                    less.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }
            return QuickSort(less).Concat(new List<int> { pivot }).Concat(QuickSort(greater)).ToList();
        }

        private List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }
            int middle = list.Count / 2;
            List<int> left = MergeSort(list.Take(middle).ToList());
            List<int> right = MergeSort(list.Skip(middle).ToList());
            return Merge(left, right);
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Any() && right.Any())
            {
                if (left.First() < right.First())
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }
            }
            result.AddRange(left);
            result.AddRange(right);
            return result;
        }

        private void DisplaySortedNumbers(List<int> numbers)
        {
            ResultsTextBox.Text = string.Join(",", numbers);
        }
    }
}
