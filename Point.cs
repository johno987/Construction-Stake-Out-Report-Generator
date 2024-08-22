using CsvHelper.Configuration;

public class Point
{
    public string PointID { get; init; }
    public decimal? Easting { get; init; }
    public decimal? Northing { get; init; }
    public decimal? Level { get; init; }


    public Point()
    {

    }

    public Point(string doesNotExist)
    {
        PointID = doesNotExist;
    }
    public Point(string id, decimal? east, decimal? north, decimal? height)
    {
        PointID = id;
        Easting = east;
        Northing = north;
        Level = height;
    }

    public override string ToString()
    {
        return $"Point ID: {PointID,-10} \tEasting: {this.Easting,-10} \tNorthing: {this.Northing,-10} \tLevel: {this.Level}";
    }
}

public class PointError3D : Point //seperate class that adds on the error property
{
    public decimal? Error3D { get; init; }
    public PointError3D(string id, decimal? east, decimal? north, decimal? height, decimal? Error)
    {
        PointID = id;
        Easting = east;
        Northing = north;
        Level = height;
        Error3D = Error;
    }
    public PointError3D(string doesNotExist)
    {
        PointID = doesNotExist;
    }
    public PointError3D()
    {

    }
}