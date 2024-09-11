using StakeOutReport_WinForms.UserMessages;

namespace StakeOutReport_WinForms;

public partial class StakeOutReport
{
    private void CalculateErrorButton_Click(object sender, EventArgs e) //if calculate error button has been pressed, we then calculate the error
    {
        bool SuccessfulErrorCalc = false;
        try //can probably remove this try catch block
        {
            //if ErrorInPoints is not empty (perhaps from previous read, empty it here first)
            if (ErrorInPoints.Count > 0)
                ErrorInPoints.Clear();
            StoreErrorInPoints();
            SuccessfulErrorCalc = true;
            populateErrorTableData(SuccessfulErrorCalc);
        }
        catch (Exception) //dont think this ever gets called
        {
            MessageUser.BadFileRead();
        }
    }

    private void StoreErrorInPoints()
    {
        var differences =
            from designPoint in DesignData
            join asBuiltPoint in AsBuiltData
                on AsBuiltPrefixSelection + designPoint.PointID equals asBuiltPoint.PointID
                into gj
            from subAsBuiltPoint in gj.DefaultIfEmpty()
            select CalculateAndReturnDifference(
                designPoint,
                subAsBuiltPoint ?? new Point { PointID = designPoint.PointID }
            );

        ErrorInPoints.AddRange(differences); //first add the difference in points into here

        ErrorWith3D = ErrorInPoints
            .Select(baseItem => new PointError3D //then iterate over them and calculate the error
            //and add this to the property
            {
                PointID = baseItem.PointID,
                Easting = baseItem.Easting,
                Northing = baseItem.Northing,
                Level = Error2DCheckBox.Checked ? null : baseItem.Level,
                Error = Error2DCheckBox.Checked
                    ? Calculate2DError(baseItem)
                    : Calculate3DError(
                        baseItem
                    ) //if it is checked
                ,
                //only the easting and northings will be considered
            })
            .ToList();
    }

    private Point CalculateAndReturnDifference(Point A, Point B)
    {
        //IF A NULL VALUE IS SUBTRACTED FROM A DECIMAL VALUE (IN A VARIABLE THAT CAN BE NULLABLE) THE RESULT WILL BE NULL
        //FOR THIS REASON, THE BELOW RETURN STATEMENT COVERS ALL BASES
        return new Point(
            A.PointID,
            (A.Easting - B.Easting),
            (A.Northing - B.Northing),
            (A.Level - B.Level)
        );
    }

    private decimal? Calculate3DError(Point A)
    {
        if (A.Easting != null && A.Northing != null && A.Level != null)
        {
            var result = Math.Round(
                Math.Sqrt(
                    (double)(A.Easting * A.Easting)
                        + (double)(A.Northing * A.Northing)
                        + (double)(A.Level * A.Level)
                ),
                3
            ); //3D error, need to find a way to add this into a new collection
            return (decimal)result;
        }
        return null;
    }

    private decimal? Calculate2DError(Point A)
    {
        if (A.Easting != null && A.Northing != null && A.Level != null)
        {
            var result = Math.Round(
                Math.Sqrt((double)(A.Easting * A.Easting) + (double)(A.Northing * A.Northing)),
                3
            );
            return (decimal)result;
        }
        return null;
    }

    private void populateErrorTableData(bool SuccessfulErrorCalc)
    {
        ErrorPreviewLabel.Visible = SuccessfulErrorCalc ? true : false;
        ErrorPreviewDataTable.Visible = SuccessfulErrorCalc ? true : false;
        ErrorPreviewDataTable.DataSource = SuccessfulErrorCalc ? ErrorWith3D : null;

        DefineErrorCheckBox.Visible = SuccessfulErrorCalc ? true : false;

        ErrorPreviewDataTable.Columns["PointID"].DisplayIndex = 0;
        ErrorPreviewDataTable.Columns["Easting"].DisplayIndex = 1;
        ErrorPreviewDataTable.Columns["Northing"].DisplayIndex = 2;
        ErrorPreviewDataTable.Columns["Level"].DisplayIndex = 3;
        ErrorPreviewDataTable.Columns["Error"].DisplayIndex = 4;

        ReportOptionVisibility(SuccessfulErrorCalc);
    }

    private void ReportOptionVisibility(bool success)
    {
        ReportOptionsLabel.Visible = success ? true : false;
        PDFCheckBox.Visible = success ? true : false;
        CSVCheckBox.Visible = success ? true : false;
        GenerateReportButton.Visible = success ? true : false;
        ProjectNameLabel.Visible = success ? true : false;
        ProjectNameTextBox.Visible = success ? true : false;
        ElementOfWorksLabel.Visible = success ? true : false;
        ElementOfWorksTextBox.Visible = success ? true : false;
    }
}
