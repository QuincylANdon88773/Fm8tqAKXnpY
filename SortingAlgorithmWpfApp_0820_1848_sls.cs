// 代码生成时间: 2025-08-20 18:48:09
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfSortingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortNumbersButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NumberListTextBox.Text))
            {
                MessageBox.Show("Please enter a list of numbers to sort.");
                return;
            }

            try
            {
                List<int> numbers = ParseNumberList(NumberListTextBox.Text);
                SortNumbers(numbers);
                DisplaySortedNumbers(numbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private List<int> ParseNumberList(string input)
        {
            // Split the input string by commas and parse each part to an int
            string[] numberStrings = input.Split(',');
            List<int> numbers = new List<int>();
            foreach (var numberString in numberStrings)
            {
                if (int.TryParse(numberString.Trim(), out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    throw new ArgumentException("Invalid number format. All entries must be integers.");
                }
            }
            return numbers;
        }

        private void SortNumbers(List<int> numbers)
        {
            // Use the built-in OrderBy method for simplicity
            numbers = numbers.OrderBy(n => n).ToList();
        }

        private void DisplaySortedNumbers(List<int> sortedNumbers)
        {
            SortedNumbersTextBox.Text = string.Join(",", sortedNumbers);
        }
    }
}
