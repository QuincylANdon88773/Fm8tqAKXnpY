// 代码生成时间: 2025-09-04 12:10:25
// <copyright file="DatabaseMigrationTool.cs" company="YourCompany">
//   Copyright (c) YourCompany. All rights reserved.
// </copyright>

using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Windows;

namespace YourNamespace
{
    /// <summary>
    /// A WPF application to perform database migrations.
    /// </summary>
    public partial class DatabaseMigrationTool : Window
    {
        private DatabaseContext _dbContext;
        private IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the DatabaseMigrationTool class.
        /// </summary>
        public DatabaseMigrationTool()
        {
            InitializeComponent();
            _dbContext = new DatabaseContext();
            _config = new Configuration();
        }

        /// <summary>
        /// Handles the button click event to start the migration process.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void StartMigrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check for valid database connection settings
                if (string.IsNullOrEmpty(_config.ConnectionString))
                {
                    MessageBox.Show("Database connection string is missing.");
                    return;
                }

                // Start the migration process
                await _dbContext.Database.MigrateAsync();

                MessageBox.Show("Database migration completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions and show error message
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// A simple database context class for Entity Framework.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DatabaseContext")
        {
        }
    }

    /// <summary>
    /// A configuration class to manage database connection settings.
    /// </summary>
    public class Configuration
    {
        public string ConnectionString
        {
            get;
            set;
        }
    }
}
