// 代码生成时间: 2025-08-14 16:08:54
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ThemeSwitcherApp
{
    public partial class MainWindow : Window
    {
        // 定义两个主题资源字典
        private ResourceDictionary lightTheme = new ResourceDictionary() { Source = new Uri("./LightTheme.xaml", UriKind.Relative) };
        private ResourceDictionary darkTheme = new ResourceDictionary() { Source = new Uri("./DarkTheme.xaml", UriKind.Relative) };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SwitchTheme(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取触发事件的按钮
                Button toggleButton = (Button)sender;

                // 检查当前主题是否为浅色主题
                if (toggleButton.Content.ToString().Equals("Light"))
                {
                    // 应用深色主题
                    Application.Current.Resources.MergedDictionaries.Remove(lightTheme);
                    Application.Current.Resources.MergedDictionaries.Add(darkTheme);
                    toggleButton.Content = "Dark";
                }
                else
                {
                    // 应用浅色主题
                    Application.Current.Resources.MergedDictionaries.Remove(darkTheme);
                    Application.Current.Resources.MergedDictionaries.Add(lightTheme);
                    toggleButton.Content = "Light";
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 其他窗口逻辑...
    }
}

// LightTheme.xaml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <SolidColorBrush x:Key="BackgroundBrush" Color="#FFFFFF"/>
    <SolidColorBrush x:Key="ForegroundBrush" Color="#000000"/>
    <!-- 其他浅色主题资源 -->
</ResourceDictionary>

// DarkTheme.xaml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <SolidColorBrush x:Key="BackgroundBrush" Color="#333333"/>
    <SolidColorBrush x:Key="ForegroundBrush" Color="#FFFFFF"/>
    <!-- 其他深色主题资源 -->
</ResourceDictionary>