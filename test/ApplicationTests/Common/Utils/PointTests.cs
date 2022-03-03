namespace ApplicationTests;

using ColliderApp.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class PointTests {
    private const int testX = 1;
    private const int testY = 2;

    private readonly Point testPoint = new(testX, testY);

    [TestMethod]
    public void Point_Has_Correct_Coordinates() {
        Assert.AreEqual(testX, testPoint.X);
        Assert.AreEqual(testY, testPoint.Y);
    }

    [TestMethod]
    public void Point_Has_Correct_String_Representation() {
        Assert.AreEqual("(1, 2)", testPoint.ToString());
    }

    [TestMethod]
    public void Equality_Is_Determined_Correctly() {
        Assert.AreEqual(testPoint, testPoint);
        Assert.AreEqual(new Point(testX, testY), testPoint);
        Assert.AreNotEqual(new Point(testX + 1, testY), testPoint);
        Assert.AreNotEqual(new Point(testX, testY + 1), testPoint);
        Assert.AreNotEqual(new Point(testX + 1, testY + 1), testPoint);
    }

    [TestMethod]
    public void Point_Has_Correct_Adjacent_Coordinates() {
        Assert.AreEqual(new Point(testX - 1, testY), testPoint.Next(Direction.Left));
        Assert.AreEqual(new Point(testX + 1, testY), testPoint.Next(Direction.Right));
        Assert.AreEqual(new Point(testX, testY - 1), testPoint.Next(Direction.Up));
        Assert.AreEqual(new Point(testX, testY + 1), testPoint.Next(Direction.Down));
    }

}
