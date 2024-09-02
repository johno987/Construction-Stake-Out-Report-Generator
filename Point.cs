using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

public class Point
{
    [Index(0)]
    public string PointID { get; init; }
    [Index(1)]
    public decimal? Easting { get; init; }
    [Index(2)]
    public decimal? Northing { get; init; }
    [Index(3)]
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

    [Index(4)]
    public decimal? Error { get; init; }
    public PointError3D(string id, decimal? east, decimal? north, decimal? height, decimal? Error)
    {
        PointID = id;
        Easting = east;
        Northing = north;
        Level = height;
        this.Error = Error;
    }
    public PointError3D(string doesNotExist)
    {
        PointID = doesNotExist;
    }
    public PointError3D()
    {

    }
}