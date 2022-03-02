// <copyright file="Program.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;

using System.IO;


public class Program {
    private const int RetValFailure = 1;

    private const string DataFileName = @"Data\MapData.txt";

    public static void Main() {
        Direction startDirection = Direction.Up;
        ITurningStrategy turningStrategy = new RightTurnStrategy();
        TextWriter outputStram = Console.Out;
        TextWriter errorStram = Console.Error;

        try {
            MapDataLoader mapDataLoader = new(DataFileName);
            WorldMap map = mapDataLoader.Load();
            Collider collider = new(map, startDirection, turningStrategy, outputStram);

            collider.Execute();
        }
        catch (Exception e) {
            if (e is MaximumStepsExceededException
                || e is StartingPositionNotFoundException) {

                errorStram.WriteLine(e.Message);
                Environment.Exit(RetValFailure);
            }

            throw;
        }
    }
}
