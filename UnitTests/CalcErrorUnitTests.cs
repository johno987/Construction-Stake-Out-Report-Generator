using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using StakeOutReport_WinForms;

namespace unitTesting;

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

        //need to roll back the nuget packages to get AreEqual back

    }
}
