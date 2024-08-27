using System.Runtime.CompilerServices;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport : Form
    {
        List<Point> DesignData = new(); //Both Design and AsBuilt info is read into here
        List<Point> AsBuiltData = new();
        List<Point> ErrorInPoints = new(); //essentially stores the difference between the design and as built
        List<PointError3D> ErrorWith3D = new();
        string AsBuiltPrefixSelection;

        public StakeOutReport()
        {
            InitializeComponent();
            SetCurrentDate();
            InitialiseComboBox();
        }
        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            //UP TO THE BUTTON CLICK FOR THE REPORT

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
    }

}
