// 代码生成时间: 2025-09-02 16:34:32
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

// MainWindow.xaml.cs 是 WPF 应用的入口点
namespace UriValidatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
# 添加错误处理
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当用户在文本框中输入链接并触发事件时调用此方法
        /// </summary>
        /// <param name="sender">事件触发的控件</param>
        /// <param name="e">事件参数</param>
        private void CheckUriButton_Click(object sender, RoutedEventArgs e)
        {
            // 获取用户输入的 URL
            string inputUri = UriTextBox.Text;

            try
            {
                // 验证 URL 是否有效
                if (IsValidUri(inputUri))
                {
                    // 如果 URL 有效，尝试创建 Uri 实例
                    Uri uri = new Uri(inputUri);
# 扩展功能模块

                    // 检查是否能够解析 DNS
                    IPHostEntry hostEntry = Dns.GetHostEntry(uri.Host);

                    // 显示验证结果
                    MessageBox.Show("The URL is valid and can be resolved.", "Validation Result", MessageBoxButton.OK, MessageBoxImage.Information);
# NOTE: 重要实现细节
                }
                else
                {
                    // 如果 URL 无效，显示错误消息
                    MessageBox.Show("The URL is invalid.", "Validation Result", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (UriFormatException)
            {
                // 处理不合法的 URL 格式异常
                MessageBox.Show("The URL format is incorrect.", "Validation Result", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // 处理其他潜在异常
                MessageBox.Show($"An error occurred: {ex.Message}", "Validation Result", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 检查输入的字符串是否是有效的 URL
        /// </summary>
        /// <param name="input">要检查的字符串</param>
        /// <returns>如果字符串是有效的 URL，则返回 true；否则返回 false</returns>
        private bool IsValidUri(string input)
# NOTE: 重要实现细节
        {
            // 尝试解析字符串为 Uri 对象，如果抛出异常则返回 false
            try
            {
                var uri = new Uri(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}