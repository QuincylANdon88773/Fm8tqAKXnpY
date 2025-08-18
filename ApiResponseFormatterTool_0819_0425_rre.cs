// 代码生成时间: 2025-08-19 04:25:25
using System;

using System.Windows;

using System.Windows.Controls;

using Newtonsoft.Json;

using Newtonsoft.Json.Linq;


namespace ApiResponseFormatterTool

{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window

    {

        public MainWindow()

        {

            InitializeComponent();

        }

    }



    public class ApiResponseFormatter

    {

        /// <summary>
        /// Formats the API response to a structured JSON format.
        /// </summary>
        /// <param name="response">The raw API response string.</param>
        /// <returns>Formatted JSON string or error message.</returns>
        public string FormatResponse(string response)
        {
            try
            {
                // Attempt to parse the response as JSON
                JObject jsonResponse = JObject.Parse(response);

                // Serialize the JObject back to a JSON string with indentation for readability
                return jsonResponse.ToString(Formatting.Indented);
            }
            catch (JsonReaderException ex)
            {
                // Handle JSON parsing exceptions
                return $"Error: Invalid JSON format. {ex.Message}";
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that may occur
                return $"Error: {ex.Message}";
            }
        }
    }

}
