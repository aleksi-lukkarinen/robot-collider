namespace ColliderApp.Common.Map.Tests;

using ColliderApp.Common.Exceptions;
using ColliderApp.Common.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;



[TestClass]
public class WorldMap_Instantiation_Tests {
    private readonly static int testMapCode = 149;

    [TestMethod]
    public void Map_Has_Correct_MapCode() {
        string[] minimalValidMapData = new string[] { "S" };
        WorldMap m = new(testMapCode, minimalValidMapData);

        Assert.AreEqual(m.MapCode, testMapCode);
    }

    [TestMethod]
    [ExpectedException(typeof(StartingPositionNotFoundException))]
    public void Exception_Is_Thrown_If_Starting_Position_Is_Not_Found() {
        string[] emptyMapData = new string[] { "" };

        new WorldMap(testMapCode, emptyMapData);
    }
}
