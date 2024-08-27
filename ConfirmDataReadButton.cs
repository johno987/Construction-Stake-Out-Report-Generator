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
                ReadStatusLabel.Text = "Error In Reading Data";
                ReadStatusLabel.BackColor = Color.Red;
                populateDesignTablesData(SuccessfulRead); //in this case sets them to null as the read failed
                return;
            } 

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
            //THIS FUNCTION NEEDS REFACTORING AND SPLITTIG UP
            DesignDataTable.DataSource = successfulRead ? DesignData : null;
            AsBuiltDataTable.DataSource = successfulRead ? AsBuiltData : null;
            ErrorPreviewDataTable.Visible = false;
            ErrorPreviewLabel.Visible = false;
            ReportOptionsLabel.Visible = false;
            PDFCheckBox.Visible = false;
            CSVCheckBox.Visible = false;
            GenerateReportButton.Visible = false;
            CalculateErrorButton.Visible = successfulRead ? true : false;
            ElementOfWorksLabel.Visible = false;
            ElementOfWorksTextBox.Visible = false;

            //ReportOptionVisibility(successfulRead);
        }
    }
}