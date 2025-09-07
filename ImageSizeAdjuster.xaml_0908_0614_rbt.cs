// 代码生成时间: 2025-09-08 06:14:37
public partial class ImageSizeAdjuster : Window
# 增强安全性
{
    public ImageSizeAdjuster()
    {
        InitializeComponent();
    }

    // 调整图片尺寸的方法
# 改进用户体验
    private async void ResizeImages_Click(object sender, RoutedEventArgs e)
# TODO: 优化性能
    {
        if (string.IsNullOrWhiteSpace(inputFolderPathTextBox.Text) || string.IsNullOrWhiteSpace(outputFolderPathTextBox.Text))
# TODO: 优化性能
        {
            MessageBox.Show("Please provide both input and output folder paths.");
            return;
        }

        if (!Directory.Exists(inputFolderPathTextBox.Text))
        {
            MessageBox.Show("Input folder path does not exist.");
            return;
# 添加错误处理
        }

        var files = Directory.GetFiles(inputFolderPathTextBox.Text, "*.*");
        int processedCount = 0;
        int errorCount = 0;

        foreach (var file in files)
        {
# 改进用户体验
            try
            {
                var newImage = ResizeImage(file, int.Parse(widthTextBox.Text), int.Parse(heightTextBox.Text));
                var outputFilePath = Path.Combine(outputFolderPathTextBox.Text, Path.GetFileName(file));
                // 保存调整后的图片
                SaveImage(newImage, outputFilePath);
                processedCount++;
            }
            catch (Exception ex)
            {
                errorCount++;
                MessageBox.Show($"Error processing {Path.GetFileName(file)}: {ex.Message}");
            }
        }

        if (processedCount == 0)
        {
            MessageBox.Show("No images were processed.");
        }
        else
        {
            MessageBox.Show($"Processed {processedCount} images with {errorCount} errors.");
# NOTE: 重要实现细节
        }
    }

    // 调整图片尺寸
    private BitmapImage ResizeImage(string imagePath, int width, int height)
# 添加错误处理
    {
# 优化算法效率
        var originalImage = new BitmapImage();
        originalImage.BeginInit();
        originalImage.UriSource = new Uri(imagePath, UriKind.Relative);
        originalImage.EndInit();
# FIXME: 处理边界情况

        var newWidth = width;
        var newHeight = height;

        var resizedImage = new TransformedBitmap(originalImage, new ScaleTransform(newWidth / originalImage.Width, newHeight / originalImage.Height));
# NOTE: 重要实现细节
        return new BitmapImage();
    }

    // 保存调整后的图片
# 添加错误处理
    private void SaveImage(BitmapSource image, string filePath)
    {
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(image));
        using (var fileStream = new FileStream(filePath, FileMode.Create))
# 改进用户体验
        {
            encoder.Save(fileStream);
        }
# TODO: 优化性能
    }
}