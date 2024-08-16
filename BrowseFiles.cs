using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport //this section of the class is responsible for sorting the browse buttons out and getting the file path
    {

        public string? DesignDataFilePath;
        public string? AsBuiltDataFilePath;
        private void BrowseDesignDataButton_Click(object sender, EventArgs e) //navigate the file explorer for the design data
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse CSV Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "CSV Files (*.csv)|*.csv|txt Files (*.txt)|*.txt",
                FilterIndex = 1, //set to 1 here so it shows CSV first
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DesignDataFilePathTextBox.Text = openFileDialog.FileName; //once this is stored in here, we can pass the path to the CSV reader to parse the data
                DesignDataFilePath = openFileDialog.FileName; //assign the file path to the string variable so we can read the data
            }
        }

        private void BrowseAsBuiltData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse CSV Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "CSV Files (*.csv)|*.csv|txt Files (*.txt)|*.txt",
                FilterIndex = 1, //set to 1 here so it shows CSV first
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AsBuiltDataFilePathTextBox.Text = openFileDialog.FileName; //once this is stored in here, we can pass the path to the CSV reader to parse the data
                AsBuiltDataFilePath = openFileDialog.FileName;
            }
        }
    }
}
