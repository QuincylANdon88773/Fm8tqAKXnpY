// 代码生成时间: 2025-09-16 10:12:16
 * This program provides a simple user interface to select multiple images,
 * specify a new size, and resize all selected images accordingly.
 *
 * Copyright (c) 2023 YourCompanyName
 *
 * Usage:
 *   1. Launch the application.
 *   2. Use the 'Select Images' button to choose the images to resize.
 *   3. Enter the desired new size in the 'New Size' text boxes.
 *   4. Click the 'Resize Images' button to apply the changes.
 */

using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageResizerWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Handle the 'Select Images' button click event
        private void btnSelectImages_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff"
            };

            if (dialog.ShowDialog() == true)
            {
                foreach (var file in dialog.FileNames)
                {
                    lstSelectedImages.Items.Add(file);
                }
            }
        }

        // Handle the 'Resize Images' button click event
        private void btnResizeImages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int width, height;
                if (int.TryParse(txtNewWidth.Text, out width) && int.TryParse(txtNewHeight.Text, out height))
                {
                    foreach (var item in lstSelectedImages.Items)
                    {
                        string filePath = (string)item;
                        ResizeImage(filePath, width, height);
                    }

                    MessageBox.Show("All images have been resized successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please enter valid numbers for the new size.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Resize the image to the specified dimensions
        private void ResizeImage(string filePath, int newWidth, int newHeight)
        {
            using (var bitmap = new BitmapImage(new Uri(filePath)))
            {
                var resizedBitmap = new TransformedBitmap(bitmap, new ScaleTransform(newWidth / (double)bitmap.PixelWidth, newHeight / (double)bitmap.PixelHeight));

                using (var encoder = new PngBitmapEncoder())
                {
                    encoder.Frames.Add(BitmapFrame.Create(resizedBitmap));
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        encoder.Save(fileStream);
                    }
                }
            }
        }
    }
}