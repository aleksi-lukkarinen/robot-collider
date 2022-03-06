// <copyright file="Program.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;

using Application.Common.Tokens;
using ColliderApp.Common.Collider;
using ColliderApp.Common.Exceptions;
using ColliderApp.Common.Map;
using ColliderApp.Common.Utils;


public class Program {
    private const int RetValFailure = 1;

    private const int MaxAllowedSteps = 999;

    private const string DataFileName = @"Data\MapData.txt";

    private Program() {
    }

    public static void Main() {
        Program p = new();
        p.Run();
    }

    private void Run() {
        ApplicationContext appCtx = PrepareAppContext();
        Direction startDirection = Direction.Up;
        ITurningStrategy turningStrategy = new RightTurnStrategy();

        try {
            MapDataLoader mapDataLoader = new(DataFileName);
            WorldMap map = mapDataLoader.Load();
            Collider collider = new(map, startDirection, turningStrategy, appCtx);

            collider.Execute(MaxAllowedSteps);

            foreach (IRobotTokenAction a in collider.Actions) {
                appCtx.OutputStream.WriteLine(a);
            }

            appCtx.OutputStream.WriteLine();
            appCtx.OutputStream.WriteLine($"Answer: {map.MapCode}:{collider.Steps}");

        }
        catch (Exception e) {
            if (e is ColliderException) {
                appCtx.ErrorStream.WriteLine(e.Message);
                Environment.Exit(RetValFailure);
            }

            throw;
        }
    }

    private ApplicationContext PrepareAppContext() {
        ApplicationContext ctx = new ApplicationContext(
            Console.Out, Console.Error);

        return ctx;
    }
}
