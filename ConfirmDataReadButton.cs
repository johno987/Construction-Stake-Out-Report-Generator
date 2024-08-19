using System.Data;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport
    {
        private void ConfirmChoiceAndReadButton_Click(object sender, EventArgs e) //once confirm button has been pressed
        {
            bool SuccessfulRead = true;
            try
            {
                DesignData = CSVData.ReadDesignData(DesignDataFilePath);
                AsBuiltData = CSVData.ReadAsBuiltData(AsBuiltDataFilePath);
            }
            catch (Exception ex) //catches any errors in reading the data (empty, incorrect info etc)
            {
                SuccessfulRead = false;
                MessageUser.SpawnMessageBox();
            } //will catch the bad read and advise the user the input file is bad

            //now sort the asBuilt data that has been read in, pass it by reference
            ChangeReadStatusLabelColour(SuccessfulRead);
        }
        private void ChangeReadStatusLabelColour(bool successfullRead)
        {
            if (successfullRead) //if successful read, turn the label green and sort the data that has been read in
            {
                ReadStatusLabel.Text = "Data Successfully Read";
                ReadStatusLabel.BackColor = Color.Green;
                AsBuiltData = SortAsBuiltData.Sort(AsBuiltData); //sort the data into ascending order
                populateTableData(successfullRead);
            }
            else
            {
                ReadStatusLabel.Text = "Error In Reading Data";
                ReadStatusLabel.BackColor = Color.Red;
                populateTableData(successfullRead);
            }
        }
        private void populateTableData(bool successfulRead)
        {
            //get 1st 10 entries and read them in the table
            if(successfulRead)
            {
                DesignDataTable.DataSource = DesignData.GetRange(0, 10);
            }
            else
            {
                DesignDataTable.DataSource = null;
            }
            
        }
    }
}