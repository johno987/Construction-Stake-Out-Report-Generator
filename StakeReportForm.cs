using System.Runtime.CompilerServices;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport : Form
    {
        List<Point> DesignData = new(); //Both Design and AsBuilt info is read into here
        List<Point> AsBuiltData = new();
        public StakeOutReport()
        {
            InitializeComponent();
        }

        //Now design data etc has been read, need to parse the error

    }

}
