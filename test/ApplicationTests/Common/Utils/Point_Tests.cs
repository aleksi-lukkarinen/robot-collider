namespace ColliderApp.Common.Utils.Tests;

using ColliderApp.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class Point_Tests {
    private readonly static int testX = 1;
    private readonly static int testY = 2;

    private readonly static Point testPoint = new(testX, testY);


    [TestMethod("Represents the X and Y coordinates given to it")]
    public void RepresentsCorrectCoordinates() {
        Assert.AreEqual(testX, testPoint.X);
        Assert.AreEqual(testY, testPoint.Y);
    }

    [TestMethod("String representation is of form (X, Y)")]
    public void StringRepresentationIsCorrect() {
        Assert.AreEqual("(1, 2)", testPoint.ToString());
    }

    [TestMethod("Two Points are equal only when the X and Y coordinates are equal")]
    public void EqualityIsDeterminedCorrectly() {
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

    [TestMethod("Adjacent coordinates are correctly computed")]
    public void AdjacentCoordinatesAreCorrect() {
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
