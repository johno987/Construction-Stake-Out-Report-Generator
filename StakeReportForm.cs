using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Runtime.CompilerServices;
using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2013.Excel;
using System.Data;
using System.Reflection;
using DocumentFormat.OpenXml.Spreadsheet;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport : Form
    {
        List<Point> DesignData = new(); //Both Design and AsBuilt info is read into here
        List<Point> AsBuiltData = new();
        List<Point> ErrorInPoints = new(); //essentially stores the difference between the design and as built
        List<PointError3D> ErrorWith3D = new();
        string? AsBuiltPrefixSelection;
        string? ProjectTitle;
        string? ElementOfWorks;

        public StakeOutReport()
        {
            InitializeComponent();
            SetCurrentDate();
            InitialiseComboBox();
        }
        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            //UP TO THE BUTTON CLICK FOR THE REPORT
            if (!PDFCheckBox.Checked && !CSVCheckBox.Checked)
            {
                MessageUser.EmptyReportSelection();
                return;
            }
            if(PDFCheckBox.Checked)
            {
                //MAKE PDF REPORT
            }
            if (CSVCheckBox.Checked)
            {
                //MAKE CSV REPORT
                //GenerateCSVReport();
                GenerateExcelDocument();
            }



            //CHECK WHICH CHECKBOXES ARE CHECKED
            //IF PDF -> MAKE PDF REPORT
            //IF CSV -> MAKE CSV REPORT
            //OR BOTH

            //APPEND ALL DATA TABLES
            //APPEND JOB TITLE
            //APPEND ELEMENT OF WORKS
            //APPEND THE DATE AND TIME THE REPORT WAS MADE

            //EVENTUALLY MAKE IT SO THE LEVEL CAN BE OMITTED FROM THE 3D ERROR (PILING PINS FOR EXAMPLE)
        }

        private void GenerateCSVReport()
        {
            SaveFileDialog CSVFile = new SaveFileDialog();
            CSVFile.Filter = "CSV Files(*.csv)|*.csv";
            CSVFile.Title = "Save a CSV file";
            CSVFile.ShowDialog();
            CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                InjectionOptions = InjectionOptions.Strip
            };

            using (var writer = new StreamWriter(CSVFile.FileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ErrorWith3D);

                writer.Flush(); //ensures all data is flushes to the file
                 
            }
              
        }

        private void GenerateExcelDocument()
        {
            //FIRST GET THE USERS SAVE NAME AND FILE PATH
            SaveFileDialog CSVFile = new SaveFileDialog();
            CSVFile.Filter = "Excel Files|*.xlsx;*.xlsm";
            CSVFile.Title = "Save a CSV file";
            CSVFile.ShowDialog();
            string filePath = CSVFile.FileName; //FILEPATH IS STORED HERE

            //CREATE THE WORKBOOK
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(ElementOfWorks + " Report");
                const int columnWidth = 18;
                // Set column widths
                for(int i = 1; i <= 5; ++i)
                {
                    if (i == 3)
                    {
                        worksheet.Column(i).Width = 25;
                        continue;
                    }
                    worksheet.Column(i).Width = columnWidth;
                }
                for (int i = 7; i <= 10; ++i)
                {
                    worksheet.Column(i).Width = columnWidth;
                }
                for (int i = 12; i <= 15; ++i)
                {
                    worksheet.Column(i).Width = columnWidth;
                }


                // Add header information
                worksheet.Cell("A1").Value = "Project Title";
                worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Cell("B1").Value = ProjectTitle;
                worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.AshGrey;

                worksheet.Cell("C1").Value = "Date Report Generated";
                worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Cell("D1").Value = DateTime.Now.ToString("dd/MM/yyyy");
                worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.AshGrey;

                // Add main headers
                worksheet.Cell("A3").Value = "Point Errors";
                worksheet.Range("A3:E3").Row(1).Merge();
                worksheet.Cell("A3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Cell("G3").Value = "Design Info";
                worksheet.Range("G3:J3").Row(1).Merge();
                worksheet.Cell("G3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Cell("L3").Value = "As Built Info";
                worksheet.Range("L3:O3").Row(1).Merge();
                worksheet.Cell("L3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Add sub-headers
                string[] subHeaders = { "Point ID", "Easting", "Northing", "Elevation", "3D Error" };
                string[] subHeadersWithoutError = { "Point ID", "Easting", "Northing", "Elevation"};
                for (int i = 0; i < subHeaders.Length; i++)
                {
                    worksheet.Cell(4, i + 1).Value = subHeaders[i];
                }
                for (int i = 0; i < subHeadersWithoutError.Length; i++)
                {
                    worksheet.Cell(4, i + 7).Value = subHeadersWithoutError[i];
                    worksheet.Cell(4, i + 12).Value = subHeadersWithoutError[i];
                }

                //Add borders
                var ProjectHeaderRange = worksheet.Range("A1:D1");
                ProjectHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ProjectHeaderRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                var ErrorTableRange = worksheet.Range("A4:E4");
                ErrorTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ErrorTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                var DesignDataTableRange = worksheet.Range("G4:J4");
                DesignDataTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                DesignDataTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                var AsBuiltDataTableRange = worksheet.Range("L4:O4");
                AsBuiltDataTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                AsBuiltDataTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;


                //do the final header borders thick last so they arent overwrote
                var ErrorHeader = worksheet.Range("A3:E3");
                ErrorHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                var DesignHeader = worksheet.Range("G3:J3");
                DesignHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                var AsBuiltHeader = worksheet.Range("L3:O3");
                AsBuiltHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;



                //text styling
                var headerRange = worksheet.Range("A1:D1");
                headerRange.Style.Font.Bold = true;

                var subHeaderRange = worksheet.Range("A3:L3");
                subHeaderRange.Style.Font.Bold = true;
                subHeaderRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                var tableHeaders = worksheet.Range("A4:O4");
                tableHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                //write the table data into the corresponding ranges
                //this works, however does not respect the property indexes when writing to the file
                var errorRange = worksheet.Cell("A5").InsertData(ErrorWith3D);

                //need to swap 1st and last column
                var Col1RangeData = worksheet.Range($"A5:A{5 + ErrorWith3D.Count}");
                var Col5RangeData = worksheet.Range($"E5:E{5 + ErrorWith3D.Count}");

                var targetCell = worksheet.Cell("A5");
                var targetCell2 = worksheet.Cell("E5");

                Col5RangeData.CopyTo(targetCell);
                Col1RangeData.CopyTo(targetCell2);
                //worksheet.Cells($"A5:A{5 + ErrorWith3D.Count}").Value = Col5RangeData;

                var DesignRange = worksheet.Cell("G5").InsertData(DesignData);
                var AsBuiltRange = worksheet.Cell("L5").InsertData(AsBuiltData);

                //trying with the datatable approach as these already exist
                //var error3DRange = worksheet.Cell("A5").InsertData(ErrorPreviewDataTable.AsEnumerble());
                //var errorDataTable = ErrorWith3D.ToDataTable();
                //var designDataTable = DesignData.ToDataTable();
                //var asBuiltDataTable = AsBuiltData.ToDataTable();

                //var error3DRange = worksheet.Cell("A5").InsertData(errorDataTable.AsEnumerable());
                //var DesignDataRange = worksheet.Cell("G5").InsertData(designDataTable.AsEnumerable());
                //var AsBuiltDataRange = worksheet.Cell("L5").InsertData(asBuiltDataTable.AsEnumerable());

                // Save the workbook
                workbook.SaveAs(filePath);
            }
    }
        private void ProjectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ProjectTitle = ProjectNameTextBox.Text;
        }

        private void ElementOfWorksTextBox_TextChanged(object sender, EventArgs e)
        {
            ElementOfWorks = ElementOfWorksTextBox.Text;
        }
    }

    internal static class ListToDataTable
    {
        public static DataTable ToDataTable<T>(this List<T> points) //extension to list
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //get properties of each list type
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //use the properties as the columns
            foreach(var property in properties)
            {
                dataTable.Columns.Add(property.Name);
            }
            //insert values of properties into the data table
            foreach(T item in points)
            {
                var values = new object[properties.Length];
                for(int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }

}
