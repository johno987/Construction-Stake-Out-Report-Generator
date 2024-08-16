using System.Runtime.CompilerServices;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport : Form
    {
        List<Point> DesignData = new(); //Take these with me when I move the confirm button into its own file
        List<Point> AsBuiltData = new();
        public StakeOutReport()
        {
            InitializeComponent();
        }

        private void ConfirmChoiceAndReadButton_Click(object sender, EventArgs e) //once confirm button has been pressed
        {
            try
            {
                DesignData = CSVData.ReadDesignData(DesignDataFilePath);
                AsBuiltData = CSVData.ReadAsBuiltData(AsBuiltDataFilePath);
            }
            catch(Exception ex) //catches any errors in reading the data (empty, incorrect info etc)
            {
                MessageUser.SpawnMessageBox();
            } //will catch the bad read and advise the user the input file is bad

            //now sort the asBuilt data that has been read in, pass it by reference
            AsBuiltData = SortAsBuiltData.Sort(AsBuiltData);
        }
    }

}
