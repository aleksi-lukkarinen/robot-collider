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

    [TestMethod]
    public void EndingExists_Finds_Ending() {
        Assert.IsTrue(testMap.EndingExistsAt(endingPosition));
    }

    [TestMethod]
    public void EndingExists_Returns_False_For_NonEnding() {
        Assert.IsFalse(testMap.EndingExistsAt(startingPosition));
    }

    [TestMethod]
    public void ObstacleExists_Finds_Obstacle() {
        Assert.IsTrue(testMap.ObstacleExistsAt(obstaclePosition));
    }

    [TestMethod]
    public void ObstacleExists_Returns_False_For_NonObstacle() {
        Assert.IsFalse(testMap.ObstacleExistsAt(startingPosition));
    }

    [TestMethod]
    public void CharAt_Finds_Correct_Characters() {
        Assert.AreEqual(startingChar, testMap.CharAt(startingPosition));
        Assert.AreEqual(endingChar, testMap.CharAt(endingPosition));
        Assert.AreEqual(obstacleChar, testMap.CharAt(obstaclePosition));
    }
}
