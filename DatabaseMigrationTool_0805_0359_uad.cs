// 代码生成时间: 2025-08-05 03:59:03
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

// DatabaseMigrationTool 是一个WPF应用程序，用于实现数据库迁移功能。
namespace DatabaseMigrationTool
{
    public partial class MainWindow : Window
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=YourDatabase;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
        }

        // 按钮点击事件，启动数据库迁移
        private void MigrateDatabase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 读取迁移脚本文件
                string migrationScript = File.ReadAllText("MigrationScript.sql");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(migrationScript, connection))
                    {
                        // 执行迁移脚本
                        command.ExecuteNonQuery();
                        MessageBox.Show("数据库迁移成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据库迁移失败: {ex.Message}");
            }
        }
    }
}
