namespace ColliderApp.Common.Utils.Tests;

using System.Collections.Generic;
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



    [DataTestMethod]
    [DynamicData(nameof(EqualityTestData), DynamicDataSourceType.Method)]
    public void Equality_Is_Determined_Correctly(bool expected, Point A, Point B) {
        Assert.AreEqual(expected, A.Equals(B));
    }

    public static IEnumerable<object[]> EqualityTestData() {
        yield return new object[] { true, testPoint, testPoint };
        yield return new object[] { true, new Point(testX, testY), testPoint };
        yield return new object[] { false, new Point(testX + 1, testY), testPoint };
        yield return new object[] { false, new Point(testX, testY + 1), testPoint };
        yield return new object[] { false, new Point(testX + 1, testY + 1), testPoint };
    }



    [DataTestMethod]
    [DynamicData(nameof(AdjacencyTestData), DynamicDataSourceType.Method)]
    public void Adjacent_Coordinates_Are_Correct(Point expected, Point actual) {
        Assert.AreEqual(expected, actual);
    }

    public static IEnumerable<object[]> AdjacencyTestData() {
        yield return new object[] { new Point(testX - 1, testY), testPoint.Next(Direction.Left) };
        yield return new object[] { new Point(testX + 1, testY), testPoint.Next(Direction.Right) };
        yield return new object[] { new Point(testX, testY - 1), testPoint.Next(Direction.Up) };
        yield return new object[] { new Point(testX, testY + 1), testPoint.Next(Direction.Down) };
    }

}
