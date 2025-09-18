// 代码生成时间: 2025-09-19 00:21:36
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

// 声明命名空间DataCleaningTool
namespace DataCleaningTool
{
    // MainWindow类代表数据清洗和预处理工具的主窗口
    public partial class MainWindow : Window
    {
        // 构造函数，初始化主窗口
        public MainWindow()
        {
            InitializeComponent();
        }

        // 加载数据的方法
        private void LoadData(string filePath)
        {
            try
            {
                // 读取文件内容
                string[] lines = File.ReadAllLines(filePath);

                // 清洗数据
                var cleanedData = CleanData(lines);

                // 将清洗后的数据写入新的文件
                File.WriteAllLines(filePath, cleanedData);

                MessageBox.Show("数据清洗完成！");
            }
            catch (Exception ex)
            {
                // 错误处理
                MessageBox.Show($"加载数据时发生错误：{ex.Message}");
            }
        }

        // 清洗数据的方法
        private IEnumerable<string> CleanData(IEnumerable<string> data)
        {
            // 遍历数据行
            foreach (var line in data)
            {
                // 去除前后空白字符
                var trimmedLine = line.Trim();

                // 去除特殊字符
                var cleanedLine = Regex.Replace(trimmedLine, "[^\w\s]", "");

                // 将清洗后的行返回
                yield return cleanedLine;
            }
        }
    }
}
