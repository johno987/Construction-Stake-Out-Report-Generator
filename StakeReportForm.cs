using CsvHelper;
using System.Globalization;
using System.Runtime.CompilerServices;

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
                GenerateCSVReport();
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
            CSVFile.Filter = "CSV Files(*.csv) | *.csv";
            CSVFile.Title = "Save a CSV file";
            CSVFile.ShowDialog();
            using (var writer = new StreamWriter(CSVFile.FileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ErrorWith3D);
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

}
