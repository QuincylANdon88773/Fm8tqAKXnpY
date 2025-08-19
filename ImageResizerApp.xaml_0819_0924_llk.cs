// 代码生成时间: 2025-08-19 09:24:05
using System;
# 优化算法效率
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
# 增强安全性
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

// 图片尺寸批量调整器应用
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // 选择图片文件夹
    private void BtnSelectFolder_Click(object sender, RoutedEventArgs e)
    {
# 扩展功能模块
        var dialog = new System.Windows.Forms.FolderBrowserDialog();
        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
# 添加错误处理
        {
            TxtFolderPath.Text = dialog.SelectedPath;
        }
    }

    // 开始调整图片尺寸
# 改进用户体验
    private async void BtnResize_Click(object sender, RoutedEventArgs e)
    {
# TODO: 优化性能
        if (string.IsNullOrWhiteSpace(TxtFolderPath.Text))
# NOTE: 重要实现细节
        {
            MessageBox.Show("请选择图片文件夹");
            return;
        }
# 改进用户体验

        if (!int.TryParse(TxtWidth.Text, out int width) || !int.TryParse(TxtHeight.Text, out int height))
        {
            MessageBox.Show("请输入正确的图片尺寸");
            return;
        }

        try
        {
            await ResizeImagesInFolder(TxtFolderPath.Text, width, height);
# 扩展功能模块
            MessageBox.Show("图片尺寸调整完成");
        }
        catch (Exception ex)
        {
# 优化算法效率
            MessageBox.Show($"发生错误：{ex.Message}");
# 增强安全性
        }
    }

    // 在文件夹中调整所有图片的尺寸
    private async Task ResizeImagesInFolder(string folderPath, int newWidth, int newHeight)
# TODO: 优化性能
    {
        var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            if (IsImageFile(file))
            {
                await ResizeImage(file, newWidth, newHeight);
            }
        }
    }
# TODO: 优化性能

    // 检查文件是否为图片
    private bool IsImageFile(string file)
    {
        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
        return Array.Exists(imageExtensions, element => file.EndsWith(element, StringComparison.OrdinalIgnoreCase));
    }

    // 调整单个图片的尺寸
# 增强安全性
    private async Task ResizeImage(string filePath, int newWidth, int newHeight)
    {
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
# NOTE: 重要实现细节
            BitmapImage image = new BitmapImage();
# 增强安全性
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(filePath, UriKind.Relative);
# 改进用户体验
            image.EndInit();
# FIXME: 处理边界情况

            // 计算新尺寸
            double aspectRatio = image.Width / image.Height;
            int finalWidth = newWidth;
# 扩展功能模块
            int finalHeight = (int)(newWidth / aspectRatio);
# 优化算法效率
            if (finalHeight > newHeight)
            {
                finalHeight = newHeight;
# FIXME: 处理边界情况
                finalWidth = (int)(newHeight * aspectRatio);
            }

            // 调整图片尺寸
            BitmapImage resizedImage = new BitmapImage();
            resizedImage.BeginInit();
            resizedImage.CacheOption = BitmapCacheOption.OnLoad;
            resizedImage.UriSource = new Uri(filePath, UriKind.Relative);
            resizedImage.DecodePixelWidth = finalWidth;
            resizedImage.DecodePixelHeight = finalHeight;
            resizedImage.EndInit();

            // 保存调整后的图片
            SaveResizedImage(resizedImage, filePath);
# 优化算法效率
        }
    }
# NOTE: 重要实现细节

    // 保存调整后的图片
    private void SaveResizedImage(BitmapImage resizedImage, string filePath)
    {
        // 确定图片格式
        string extension = Path.GetExtension(filePath);
        string directory = Path.GetDirectoryName(filePath);
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
        string resizedFilePath = Path.Combine(directory, $"resized_{fileNameWithoutExtension}{extension}");
# NOTE: 重要实现细节

        using (var outStream = new FileStream(resizedFilePath, FileMode.Create))
        {
# FIXME: 处理边界情况
            BitmapEncoder encoder;
# 扩展功能模块
            if (extension.ToLower() == ".png")
            {
                encoder = new PngBitmapEncoder();
# 添加错误处理
            }
            else if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
# 增强安全性
            {
                encoder = new JpegBitmapEncoder();
            }
            else
            {
# 改进用户体验
                throw new InvalidOperationException("不支持的图片格式");
            }

            encoder.Frames.Add(BitmapFrame.Create(resizedImage));
# 扩展功能模块
            encoder.Save(outStream);
        }
    }
}