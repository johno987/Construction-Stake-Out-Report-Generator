using System.Runtime.CompilerServices;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport : Form
    {
        List<Point> DesignData = new(); //Both Design and AsBuilt info is read into here
        List<Point> AsBuiltData = new();
        List<Point> ErrorInPoints = new(); //essentially stores the difference between the design and as built
        List<PointError3D> ErrorWith3D = new();

        public StakeOutReport()
        {
            InitializeComponent();
            SetCurrentDate();
        }

        //Now design data etc has been read, need to parse the error

        private void CalculateErrorButton_Click(object sender, EventArgs e) //if calculate error button has been pressed, we then calculate the error
        {
            bool SuccessfulErrorCalc = false;
            try
            {
                //if ErrorInPoints is not empty (perhaps from previous read, empty it here first)
                if(ErrorInPoints.Count > 0)
                    ErrorInPoints.Clear();
                StoreErrorInPoints();
                SuccessfulErrorCalc = true;
                populateErrorTableData(SuccessfulErrorCalc);
            }
            catch(Exception ex)
            {
                MessageUser.SpawnMessageBox();
            }

        }
        private void StoreErrorInPoints()
        {
            var differences =
        from designPoint in DesignData
        join asBuiltPoint in AsBuiltData on "STKE" + designPoint.PointID equals asBuiltPoint.PointID into gj
        from subAsBuiltPoint in gj.DefaultIfEmpty()
        select CalculateAndReturnDifference(
        designPoint,
        subAsBuiltPoint ?? new Point { PointID = designPoint.PointID }

    );

            ErrorInPoints.AddRange(differences); //first add the difference in points into here

            ErrorWith3D = ErrorInPoints.Select(baseItem => new PointError3D //then iterate over them and calculate the error
            //and add this to the property
            {
                PointID = baseItem.PointID,
                Easting = baseItem.Easting,
                Northing = baseItem.Northing,
                Level = baseItem.Level,
                Error3D = Calculate3DError(baseItem)
            }).ToList();
        }
        private Point CalculateAndReturnDifference(Point A, Point B)
        {
            if (A.PointID == B.PointID)
                return new Point(A.PointID, null, null, null); //append the actual point ID so we know its number
            return new Point(A.PointID, (A.Easting - B.Easting), (A.Northing - B.Northing), (A.Level - B.Level));
        }

        private decimal? Calculate3DError(Point A)
        {
            if (A.Easting != null && A.Northing != null && A.Level != null)
            {
                var result = Math.Round(Math.Sqrt((double)(A.Easting * A.Easting) + (double)(A.Northing * A.Northing) +
                (double)(A.Level * A.Level)), 3); //3D error, need to find a way to add this into a new collection
                return (decimal)result;
            }
            return null;    
        }
        private void populateErrorTableData(bool SuccessfulErrorCalc)
        {
            ErrorPreviewLabel.Visible = SuccessfulErrorCalc ? true : false;
            ErrorPreviewDataTable.Visible = SuccessfulErrorCalc ? true : false;
            ErrorPreviewDataTable.DataSource = SuccessfulErrorCalc ? ErrorWith3D : null;
            ErrorPreviewDataTable.Columns["PointID"].DisplayIndex = 0;
            ErrorPreviewDataTable.Columns["Easting"].DisplayIndex = 1;
            ErrorPreviewDataTable.Columns["Northing"].DisplayIndex = 2;
            ErrorPreviewDataTable.Columns["Level"].DisplayIndex = 3;
            ErrorPreviewDataTable.Columns["Error3D"].DisplayIndex = 4;
        }

    }

}
