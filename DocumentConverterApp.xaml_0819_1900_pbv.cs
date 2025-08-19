// 代码生成时间: 2025-08-19 19:00:35
 * Best practices, error handling, and maintainability are considered in this implementation.
 */

using System;
using System.IO;
using System.Windows;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace DocumentConverterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Application wordApp;
        private Document wordDoc;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Converts the document from one format to another.
        /// </summary>
        /// <param name="sourcePath">The path to the source document.</param>
        /// <param name="targetPath">The path to the target document.</param>
        public void ConvertDocument(string sourcePath, string targetPath)
        {
            try
            {
                // Initialize Word application
                wordApp = new Application();
                wordApp.Visible = false; // Run in the background

                // Open the source document
                wordDoc = wordApp.Documents.Open(sourcePath);

                // Save the document in the target format
                wordDoc.SaveAs2(targetPath);
                wordDoc.Close();

                // Quit the Word application
                wordApp.Quit();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the conversion process
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Release COM objects
                if (wordDoc != null) Marshal.ReleaseComObject(wordDoc);
                if (wordApp != null) Marshal.ReleaseComObject(wordApp);
            }
        }

        // Additional methods for UI interaction and other functionalities can be added here
    }
}
