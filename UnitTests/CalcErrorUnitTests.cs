using NUnit.Framework;

namespace StakeOutReport_WinForms.UnitTests;

public class StakeOutReportUnitTesting
{
    [Test]
    public void CalculateError2D_ShallReturnCorrectValue_ForGivenPoint()
    {
        Point PointA = new Point("Point 1", 1000, 2000, 100);
        StakeOutReport stakeoutReport = new StakeOutReport();
        var result = stakeoutReport.Calculate2DError(PointA);

        Assert.AreEqual(2236.068m, result);
    }

    [Test]
    public void CalculateError3D_ShallReturnCorrectValue_ForGivenPoint()
    {
        Point PointA = new Point("Point 1", 5000, 2000, 150);
        StakeOutReport stakeOutReport = new StakeOutReport();

        var result = stakeOutReport.Calculate3DError(PointA);

        Assert.AreEqual(5387.253m, result);
    }

    [TestCaseSource(nameof(GeneratePointDataForTest))]
    public void CalculateAndReturnDifference_ShallReturnCorrectPointValues_ForGivenTwoPoints(
        IEnumerable<Point> collection,
        Point Expected
    )
    {
        var inputCollection = collection.ToList();
        StakeOutReport stakeoutReport = new StakeOutReport();

        var result = stakeoutReport.CalculateAndReturnDifference(
            inputCollection[0],
            inputCollection[1]
        );

        bool AsExpected = Expected.Equals(result);

        Assert.AreEqual(Expected, result);
    }

    private static IEnumerable<object> GeneratePointDataForTest()
    {
        return new[]
        {
            new object[]
            {
                new List<Point> { new Point("A", 5, 3, 2), new Point("B", 4, 2, 1) },
                new Point("A", 1, 1, 1),
            }, //one test case - 2 points and the resulting point value (overridden equals and get hash code)
            new object[]
            {
                new List<Point> { new Point("A", 10, 5, 3), new Point("B", 7, 3, 2) },
                new Point("A", 3, 2, 1),
            },
            new object[]
            {
                new List<Point> { new Point("A", 20, 15, 10), new Point("B", 8, 5, 3) },
                new Point("A", 12, 10, 7),
            },
        };
    }
}
