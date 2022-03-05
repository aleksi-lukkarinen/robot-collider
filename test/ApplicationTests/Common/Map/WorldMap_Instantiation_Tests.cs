namespace ColliderApp.Common.Map.Tests;

using ColliderApp.Common.Exceptions;
using ColliderApp.Common.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;



[TestClass]
public class WorldMap_Instantiation_Tests {
    private readonly static int testMapCode = 149;

    [TestMethod("Map has a correct map code")]
    public void MapHasCorrectMapCode() {
        string[] minimalValidMapData = new string[] { "S" };
        WorldMap m = new(testMapCode, minimalValidMapData);

        Assert.AreEqual(m.MapCode, testMapCode);
    }

    [TestMethod("An exception is thrown if a starting position is not found")]
    [ExpectedException(typeof(StartingPositionNotFoundException))]
    public void ExceptionIsThrownIfStartingPositionIsNotFound() {
        string[] emptyMapData = new string[] { "" };

        new WorldMap(testMapCode, emptyMapData);
    }
}
