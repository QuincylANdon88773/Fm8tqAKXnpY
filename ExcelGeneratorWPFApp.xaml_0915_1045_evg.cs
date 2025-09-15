// 代码生成时间: 2025-09-15 10:45:31
using System;
using System.Windows;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

namespace ExcelGeneratorWPFApp
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

        private void GenerateExcelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Specify the path where the Excel file will be saved
                string filePath = "GeneratedExcel.xlsx";

                // Create the spreadsheet document by opening the file in write mode
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    // Add a WorkbookPart to the document
                    WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    // Add a WorksheetPart to the WorkbookPart
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // Add Sheets to the Workbook
                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Sheet1"
                    };
                    sheets.Append(sheet);

                    // Add some sample data to the worksheet
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    int rowCount = 5; // Number of rows
                    int colCount = 3; // Number of columns

                    for (int row = 1; row <= rowCount; row++)
                    {
                        Row newRow = new Row();
                        for (int cell = 1; cell <= colCount; cell++)
                        {
                            // Cells are 1-based index
                            Cell newCell = new Cell() {
                                CellReference = $"A{row}{cell}",
                                DataType = new EnumValue<CellValues>(CellValues.String)
                            };
                            newCell.CellValue = new CellValue($"Row {row}, Column {cell}");
                            newRow.Append(newCell);
                        }
                        sheetData.Append(newRow);
                    }
                }

                // Inform the user that the Excel file has been generated
                MessageBox.Show("Excel file generated successfully!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the generation process
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
