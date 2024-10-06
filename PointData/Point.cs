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

    public Point() { }

    public Point(string id, decimal? east, decimal? north, decimal? height)
    {
        PointID = id;
        Easting = east;
        Northing = north;
        Level = height;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point point
            && PointID == point.PointID
            && Easting == point.Easting
            && Northing == point.Northing
            && Level == point.Level;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PointID, Easting, Northing, Level);
    }
}

public class PointError3D : Point //seperate class that adds on the error property
{
    [Index(4)]
    public decimal? Error { get; init; }

    public PointError3D(string id, decimal? east, decimal? north, decimal? height, decimal? Error)
        : base(id, east, north, height)
    {
        this.Error = Error;
    }

    public PointError3D() { }
}
