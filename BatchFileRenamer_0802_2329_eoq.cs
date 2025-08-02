// 代码生成时间: 2025-08-02 23:29:00
    using System;

    using System.IO;

    using System.Linq;

    using System.Windows;

    using System.Windows.Controls;
# 添加错误处理

    using System.Windows.Input;


    /// <summary>
# TODO: 优化性能

    /// Interaction logic for MainWindow.xaml

    /// </summary>

    public partial class MainWindow : Window

    {

        public MainWindow()

        {

            InitializeComponent();

        }
# 扩展功能模块


        private void BrowseButton_Click(object sender, RoutedEventArgs e)
# TODO: 优化性能

        {

            // Open a dialog to select the folder containing files to rename
# 优化算法效率

            var dialog = new System.Windows.Forms.FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)

            {

                FolderTextBox.Text = dialog.SelectedPath;

            }

        }
# FIXME: 处理边界情况


        private void RenameButton_Click(object sender, RoutedEventArgs e)

        {

            try
# 增强安全性

            {

                // Get the folder path and rename pattern from the user input

                string folderPath = FolderTextBox.Text;

                string pattern = PatternTextBox.Text;


                if (string.IsNullOrWhiteSpace(folderPath) || string.IsNullOrWhiteSpace(pattern))

                {
# TODO: 优化性能

                    MessageBox.Show("Please provide a folder path and a rename pattern.");

                    return;

                }


                var files = Directory.GetFiles(folderPath)

                    .Where(file => Path.GetExtension(file) != null) // Filter out hidden files

                    .ToList();


                for (int i = 0; i < files.Length; i++)

                {

                    string newFileName = $