namespace ColliderApp.Common.Map.Tests;

using ColliderApp.Common.Map;
using ColliderApp.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;



[TestClass]
public class WorldMap_Simple_Content_Tests {
    private readonly static int testMapCode = 149;

    private readonly static string[] testMapData = new string[] {
        "#######",
        "# S E #",
        "#######"
    };

    private readonly static char startingChar = 'S';
    private readonly static char endingChar = 'E';
    private readonly static char obstacleChar = '#';

    private readonly static Point startingPosition = new(2, 1);
    private readonly static Point endingPosition = new(4, 1);
    private readonly static Point obstaclePosition = new(0, 0);

    private readonly static WorldMap testMap = new(testMapCode, testMapData);

    [TestMethod("EndingExists() returns true for an ending")]
    public void EndingExistsFindsEnding() {
        Assert.IsTrue(testMap.EndingExistsAt(endingPosition));
    }

    [TestMethod("EndingExists() returns false for a non-ending")]
    public void EndingExistsReturnsFalseForNonEnding() {
        Assert.IsFalse(testMap.EndingExistsAt(startingPosition));
    }

    [TestMethod("ObstacleExists() returns true for an obstacle")]
    public void ObstacleExistsFindsObstacle() {
        Assert.IsTrue(testMap.ObstacleExistsAt(obstaclePosition));
    }

    [TestMethod("ObstacleExists() returns false for a non-obstacle")]
    public void ObstacleExistsReturnsFalseForNonObstacle() {
        Assert.IsFalse(testMap.ObstacleExistsAt(startingPosition));
    }

    [TestMethod("CharAt() finds correct characters")]
    public void CharAtFindsCorrectCharacters() {
        Assert.AreEqual(startingChar, testMap.CharAt(startingPosition));
        Assert.AreEqual(endingChar, testMap.CharAt(endingPosition));
        Assert.AreEqual(obstacleChar, testMap.CharAt(obstaclePosition));
    }
}
