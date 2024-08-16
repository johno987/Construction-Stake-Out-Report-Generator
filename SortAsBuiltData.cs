using System.Data;

namespace StakeOutReport_WinForms
{
    internal class SortAsBuiltData //class soley responsible for sorting the AsBuiltData
    {
        //sort the data points by numerical ascending
        public static List<Point> Sort(List<Point> points)
        {
           points = points.OrderBy(p => ExtractNumber(p.PointID))
                .ThenBy(p => p.PointID)
                .ToList();
            return points;
        }
        private static int ExtractNumber(string s)
        {
            return int.Parse(string.Concat(s.Where(char.IsDigit)));
        }
    }

}
