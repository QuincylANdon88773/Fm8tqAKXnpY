// 代码生成时间: 2025-09-20 05:38:36
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageResizerApp
{
    // MainWindow.xaml.cs是WPF应用程序的主窗口类
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 点击按钮时触发的事件处理程序
        private void ResizeImagesButton_Click(object sender, RoutedEventArgs e)
        {
            // 获取输入框的值
            string sourceFolder = sourceFolderTextBox.Text;
            string targetFolder = targetFolderTextBox.Text;
            string width = widthTextBox.Text;
            string height = heightTextBox.Text;
            
            // 验证输入
            if (string.IsNullOrWhiteSpace(sourceFolder) || !Directory.Exists(sourceFolder))
            {
                MessageBox.Show("Source folder not specified or invalid.");
                return;
            }
            if (string.IsNullOrWhiteSpace(targetFolder) || !Directory.Exists(targetFolder))
            {
                MessageBox.Show("Target folder not specified or invalid.");
                return;
            }
            int newWidth, newHeight;
            if (!int.TryParse(width, out newWidth) || !int.TryParse(height, out newHeight))
            {
                MessageBox.Show("Invalid width or height.");
                return;
            }
            
            try
            {
                // 调用图片尺寸调整的函数
                ResizeImages(sourceFolder, targetFolder, newWidth, newHeight);
                MessageBox.Show("Images resized successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // 图片尺寸调整函数
        private void ResizeImages(string sourceFolder, string targetFolder, int newWidth, int newHeight)
        {
            // 遍历源文件夹中的所有图片文件
            foreach (var file in Directory.GetFiles(sourceFolder, "*.*"))
            {
                if (IsImageFile(file))
                {
                    try
                    {
                        // 创建BitmapImage对象
                        using (var image = new BitmapImage(new Uri(file)))
                        {
                            // 创建新的图片尺寸
                            var resizedImage = new TransformedBitmap(image, new ScaleTransform(newWidth / (image.PixelWidth), newHeight / (image.PixelHeight)));

                            // 保存调整尺寸后的图片到目标文件夹
                            string targetFilePath = Path.Combine(targetFolder, Path.GetFileName(file));
                            using (var fileStream = new FileStream(targetFilePath, FileMode.Create))
                            {
                                resizedImage.Save(fileStream, GetImageFormat(file));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // 错误处理
                        MessageBox.Show($"Error resizing {Path.GetFileName(file)}: {ex.Message}");
                    }
                }
            }
        }

        // 检查文件是否为图片格式
        private static bool IsImageFile(string file)
        {
            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            return imageExtensions.Contains(Path.GetExtension(file).ToLowerInvariant(), StringComparer.OrdinalIgnoreCase);
        }

        // 根据文件扩展名获取图片格式
        private static BitmapImageFormat GetImageFormat(string file)
        {
            switch (Path.GetExtension(file).ToLowerInvariant())
            {
                case ".jpg":
                case ".jpeg":
                    return BitmapImageFormat.Jpeg;
                case ".png":
                    return BitmapImageFormat.Png;
                case ".gif":
                    return BitmapImageFormat.Gif;
                case ".bmp":
                    return BitmapImageFormat.Bmp;
                default:
                    throw new ArgumentException("Unsupported image format.");
            }
        }
    }
}
