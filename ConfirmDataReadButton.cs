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
            catch (Exception ex) //catches any errors in reading the data (empty, incorrect info etc) will catch the bad read and advise the user the input file is bad
            {
                SuccessfulRead = false;
                MessageUser.BadFileRead();
            } 

            //now sort the asBuilt data that has been read in
            ChangeReadStatusLabelColourAndSortData(SuccessfulRead);
        }
        private void ChangeReadStatusLabelColourAndSortData(bool successfullRead)
        {
            bool correctPrefix = ConfirmPrefix();
            if (successfullRead && correctPrefix)//if successful read, turn the label green and sort the data that has been read in
            {
                ReadStatusLabel.Text = "Data Successfully Read";
                ReadStatusLabel.BackColor = Color.Green;
                AsBuiltData = SortAsBuiltData.Sort(AsBuiltData); //sort the data into ascending order
                populateDesignTablesData(successfullRead);
            }
            else
            {
                ReadStatusLabel.Text = "Error In Reading Data";
                ReadStatusLabel.BackColor = Color.Red;
                if(!correctPrefix)
                    MessageUser.BadDataPrefix();
                populateDesignTablesData(!successfullRead);
            }
        }
        private void populateDesignTablesData(bool successfulRead) //preference at the min is to load all the data in for the preview and allow the user to scroll
        {
            //DesignDataTable.DataSource = successfulRead ? DesignData.GetRange(0, 10) : null;
            //AsBuiltDataTable.DataSource = successfulRead ? AsBuiltData.GetRange(0, 10) : null;
            DesignDataTable.DataSource = successfulRead ? DesignData : null;
            AsBuiltDataTable.DataSource = successfulRead ? AsBuiltData : null;
            ErrorPreviewDataTable.Visible = false;
            ErrorPreviewLabel.Visible = false;
            CalculateErrorButton.Visible = successfulRead ? true : false;
        }
    }
}