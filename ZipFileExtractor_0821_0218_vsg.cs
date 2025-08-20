// 代码生成时间: 2025-08-21 02:18:34
// ZipFileExtractor.cs
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows; // For MessageBox

namespace ZipFileExtractorApp
{
    // 主程序类
    public class ZipFileExtractor
    {
        public static void ExtractZipFile(string zipFilePath, string destinationFolder)
        {
            // 确保 ZIP 文件路径有效
            if (string.IsNullOrWhiteSpace(zipFilePath) || !File.Exists(zipFilePath))
            {
                MessageBox.Show("Invalid zip file path.");
                return;
            }

            // 确保目标文件夹路径有效
            if (string.IsNullOrWhiteSpace(destinationFolder))
            {
                MessageBox.Show("Invalid destination folder path.");
                return;
            }

            try
            {
                // 使用 System.IO.Compression 命名空间中的 ZipFile 类来解压文件
                ZipFile.ExtractToDirectory(zipFilePath, destinationFolder);
                MessageBox.Show("Files have been extracted successfully!");
            }
            catch (Exception ex)
            {
                // 捕获并显示错误消息
                MessageBox.Show($"An error occurred while extracting the zip file: {ex.Message}");
            }
        }
    }
}

// 以下为辅助函数或类，根据需要添加到项目中
// 例如，可以有一个 ViewModel 类或者一个用于启动程序的 Main 方法等。
