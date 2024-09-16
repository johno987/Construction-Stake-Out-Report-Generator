using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using StakeOutReport_WinForms;

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

    [Test]
    public void CalculateAndReturnDifference_ShallReturnCorrectPointValues_ForGivenTwoPoints()
    {
        Point PointA = new Point("A", 5, 3, 2);
        Point PointB = new Point("B", 4, 2, 1);

        StakeOutReport stakeoutReport = new StakeOutReport();


        var result = stakeoutReport.CalculateAndReturnDifference(PointA, PointB);

        //Assert the various elements of a point
        Assert.AreEqual(PointA.PointID , result.PointID, "Incorrect Point ID");
        Assert.AreEqual(1, result.Easting , "Incorrect Easting Delta, should be 1");
        Assert.AreEqual(1, result.Northing, "Incorrect Northing Delta, should be 1");
        Assert.AreEqual(1, result.Level, "Incorrect Level Detla, should be 1");
    }
}
