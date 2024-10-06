using CsvHelper.Configuration.Attributes;

public struct Point
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

public struct PointError3D //seperate class that adds on the error property
{
    [Index(1)]
    public string PointID { get; init; }

    [Index(2)]
    public decimal? Easting { get; init; }

    [Index(3)]
    public decimal? Northing { get; init; }

    [Index(4)]
    public decimal? Level { get; init; }
    [Index(5)]
    public decimal? Error { get; init; }

    public PointError3D(string id, decimal? east, decimal? north, decimal? height, decimal? Error)
    {
        this.PointID = id;
        this.Easting = east;
        this.Northing = north;
        this.Level = height;
        this.Error = Error;
    }

    public PointError3D() { }
}
