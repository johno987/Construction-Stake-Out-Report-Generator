using System.Data;

namespace StakeOutReport_WinForms
{
    internal static class SortAsBuiltData //class soley responsible for sorting the AsBuiltData
    {
        //sort the data points by numerical ascending
        public static List<Point> Sort(List<Point> points) //no longer needed, keep for time being
        {
           points = points.OrderBy(p => ExtractNumber(p.PointID))
                .ThenBy(p => p.PointID)
                .ToList();
            return points;
        }
        private static int? ExtractNumber(string s)
        {
            //add parse check to weed on control points and set ups
            
            if(int.TryParse(string.Concat(s.Where(char.IsDigit)), out int result))
                return result;
            return null;
            //if (int.TryParse(string.Concat(s.Where(char.IsDigit));
            //return int.Parse(string.Concat(s.Where(char.IsDigit)));
        }

        public static List<Point> SortExtension(this List<Point> points)
        {
            return points.OrderBy(p => ExtractNumber(p.PointID))
                .ThenBy(p => p.PointID).ToList();
        }
    }

}
