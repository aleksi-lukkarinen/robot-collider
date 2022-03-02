namespace ApplicationTests;

using ColliderApp.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class PointTests {
    [TestMethod]
    public void Created_Point_Has_Correct_Coordinates() {
        const int testX = 1;
        const int testY = 2;

        Point p = new(testX, testY);

        Assert.AreEqual(testX, p.X);
        Assert.AreEqual(testY, p.Y);
    }
}
