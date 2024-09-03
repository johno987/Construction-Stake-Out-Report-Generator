using System.Data;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport
    {
        private void ConfirmChoiceAndReadButton_Click(object sender, EventArgs e) //once confirm button has been pressed
        {
            bool SuccessfulRead = true;
            if(!string.IsNullOrEmpty(DesignDataFilePath) && !string.IsNullOrEmpty(AsBuiltDataFilePath))
            {
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
            else
            {
                //MESSAGE USER CONFIRMING SELECTION CANNOT BE EMPTY
                MessageUser.EmptyFilePathMessage();
                return;
            }
            
        }
        private void ChangeReadStatusLabelColourAndSortData(bool successfullRead)
        {
            AsBuiltData = RemoveControlPoints();
            bool correctPrefix = ConfirmPrefix();
            if (successfullRead && correctPrefix)//if successful read, turn the label green and sort the data that has been read in
            {
                ReadStatusLabel.Text = "Data Successfully Read";
                ReadStatusLabel.BackColor = Color.Green;
                AsBuiltData = AsBuiltData.SortExtension(); //sort the data using the extension method
                //ould sanitise the data here and remove any point that is not contained within the 
                //original design data

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
            Error2DCheckBox.Visible = successfulRead ? true : false;
            ProjectNameLabel.Visible = false;
            ProjectNameTextBox.Visible = false;
            ElementOfWorksLabel.Visible = false;
            ElementOfWorksTextBox.Visible = false;

            //ReportOptionVisibility(successfulRead);
        }
        private List<Point> RemoveControlPoints() //removes control points and set up data from the 
            //as built data set
        {
            // Create lists of point IDs for AsBuiltData and DesignData
            var asBuiltIDList = AsBuiltData.Select(x => x.PointID);
            var designIDList = DesignData.Select(x => x.PointID);

            // Filter AsBuiltData to include only those points whose PointID exists in DesignData
            var sanitisedPoints = AsBuiltData
                .Where(asBuiltPoint => designIDList.Contains(RemovePrefix(asBuiltPoint.PointID, AsBuiltPrefixSelection)))
                .ToList();

            return sanitisedPoints;
        }

        // Helper method to remove the prefix from PointID
        private string RemovePrefix(string pointID, string prefix)
        {
            if (pointID.StartsWith(prefix))
            {
                return pointID.Substring(prefix.Length);
            }
            return pointID;
        }
    }



    
}