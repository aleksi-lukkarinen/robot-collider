namespace ColliderApp.Common.Utils.Tests;
using ColliderApp.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class Point_Tests {
    private readonly static int testX = 1;
    private readonly static int testY = 2;

    private readonly static Point testPoint = new(testX, testY);


    [TestMethod]
    public void Represents_Correct_Coordinates() {
        Assert.AreEqual(testX, testPoint.X);
        Assert.AreEqual(testY, testPoint.Y);
    }

    [TestMethod]
    public void String_Representation_Is_Correct() {
        Assert.AreEqual("(1, 2)", testPoint.ToString());
    }

    [TestMethod]
    public void Equality_Is_Determined_Correctly() {
        (bool, Point, Point)[] cases = {
            ( true, testPoint, testPoint ),
            ( true, new Point(testX, testY), testPoint ),
            ( false, new Point(testX + 1, testY), testPoint ),
            ( false, new Point(testX, testY + 1), testPoint ),
            ( false, new Point(testX + 1, testY + 1), testPoint ),
        };

        foreach ((bool, Point, Point) c in cases) {
            Assert.AreEqual(c.Item1, c.Item2.Equals(c.Item3));
        }
    }

    [TestMethod]
    public void Adjacent_Coordinates_Are_Correct() {
        (Point, Point)[] cases = {
            ( new Point(testX - 1, testY), testPoint.Next(Direction.Left) ),
            ( new Point(testX + 1, testY), testPoint.Next(Direction.Right) ),
            ( new Point(testX, testY - 1), testPoint.Next(Direction.Up) ),
            ( new Point(testX, testY + 1), testPoint.Next(Direction.Down) ),
        };

        foreach ((Point, Point) c in cases) {
            Assert.AreEqual(c.Item1, c.Item2);
        }
    }
}
