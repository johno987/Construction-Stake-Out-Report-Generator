using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace StakeOutReport_WinForms
{
    internal class CSVData
    {
        public static List<Point> ReadDesignData(string DesignDataFilePath)
        {
            List<Point> DesignData = new();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) //this allows us to read in data with no headers
            {
                HasHeaderRecord = false
            };

            using (var reader = new StreamReader(DesignDataFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                DesignData = csv.GetRecords<Point>().ToList();
            }
            return DesignData;
        }

        public static List<Point> ReadAsBuiltData(string AsBuiltDataFilePath)
        {
            List<Point> AsBuiltData = new();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) //this allows us to read in data with no headers
            {
                HasHeaderRecord = false
            };

            using (var reader = new StreamReader(AsBuiltDataFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                AsBuiltData = csv.GetRecords<Point>().ToList();
            }
            return AsBuiltData;
        }
    }

}
