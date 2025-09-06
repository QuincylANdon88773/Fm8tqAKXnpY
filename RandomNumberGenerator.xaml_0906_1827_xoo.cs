// 代码生成时间: 2025-09-06 18:27:22
using System;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for RandomNumberGenerator.xaml
    /// </summary>
    public partial class RandomNumberGenerator : Window
    {
        private Random _random;
        private int _minValue;
        private int _maxValue;

        public RandomNumberGenerator()
        {
            InitializeComponent();
            _random = new Random();
            _minValue = 0;
            _maxValue = 100;
        }

        /// <summary>
        /// Generates a random number within the specified range.
        /// </summary>
        private void GenerateRandomNumberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate the input values
                if (int.TryParse(MinValueTextBox.Text, out _minValue) && int.TryParse(MaxValueTextBox.Text, out _maxValue))
                {
                    // Ensure the minimum value is less than the maximum value
                    if (_minValue >= _maxValue)
                    {
                        throw new ArgumentException("The minimum value must be less than the maximum value.");
                    }

                    // Generate and display the random number
                    int randomNumber = _random.Next(_minValue, _maxValue + 1);
                    RandomNumberTextBlock.Text = $"Random Number: {randomNumber}";
                }
                else
                {
                    throw new FormatException("Invalid number format. Please enter integer values.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}