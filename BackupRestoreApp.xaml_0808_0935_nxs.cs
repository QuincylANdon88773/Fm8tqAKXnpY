// 代码生成时间: 2025-08-08 09:35:07
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

// 定义一个简单的数据备份恢复程序
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // 备份数据的方法
    private void BackupData_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 定义源文件夹和备份文件夹的路径
            string sourcePath = "C:\Data\SourceFolder";
            string backupPath = "C:\Data\BackupFolder\Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // 检查源文件夹是否存在
            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("Source folder does not exist.");
                return;
            }

            // 创建备份文件夹
            Directory.CreateDirectory(backupPath);

            // 复制文件到备份文件夹
            CopyDirectory(sourcePath, backupPath);

            MessageBox.Show("Backup completed successfully.");
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error occurred: {ex.Message}");
        }
    }

    // 恢复数据的方法
    private void RestoreData_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 定义备份文件夹和目标文件夹的路径
            string backupPath = "C:\Data\BackupFolder\Backup_20230101123456";
            string targetPath = "C:\Data\TargetFolder";

            // 检查备份文件夹是否存在
            if (!Directory.Exists(backupPath))
            {
                MessageBox.Show("Backup folder does not exist.");
                return;
            }

            // 复制文件到目标文件夹
            CopyDirectory(backupPath, targetPath);

            MessageBox.Show("Restore completed successfully.");
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error occurred: {ex.Message}");
        }
    }

    // 复制目录的方法
    private void CopyDirectory(string sourceDir, string destinationDir)
    {
        // 获取源目录的所有文件，并复制到目标目录
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
            File.Copy(file, destFile, true); // true to overwrite
        }

        // 获取源目录的所有子目录，并递归复制
        foreach (string directory in Directory.GetDirectories(sourceDir))
        {
            string destDirectory = Path.Combine(destinationDir, Path.GetFileName(directory));
            Directory.CreateDirectory(destDirectory);
            CopyDirectory(directory, destDirectory);
        }
    }
}
