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
        decimal? DefinedErrorTolerance;

        public StakeOutReport()
        {
            InitializeComponent();
            SetCurrentDate();
            InitialiseComboBox();
        }
    }
}
