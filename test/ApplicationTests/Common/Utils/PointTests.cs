using ColliderApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationTests;


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
