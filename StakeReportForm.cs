
namespace StakeOutReport_WinForms;

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
    const string SoftwareVersion = "V1.0.2";

    public StakeOutReport()
    {
        InitializeComponent();
        SetCurrentDate();
        InitialiseComboBox();
        SetSoftwareVersion();
    }

    private void SetSoftwareVersion()
    {
        WaterMarkLabel.Text = $"Software created By W.Johnson\n{SoftwareVersion}";
    }
}
