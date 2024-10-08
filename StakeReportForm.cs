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

    public StakeOutReport()
    {
        InitializeComponent();
        SetCurrentDate();
        InitialiseComboBox();
    }
}
