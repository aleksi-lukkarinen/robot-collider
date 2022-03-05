// <copyright file="Collider.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Collider;

using ColliderApp.Common.Exceptions;
using ColliderApp.Common.Map;
using ColliderApp.Common.Robot;
using ColliderApp.Common.Utils;


internal class Collider {
    private const int MaxAllowedSteps = 999;

    private readonly ApplicationContext appCtx;

    private readonly WorldMap map;
    private readonly Direction startDirection;
    private readonly ITurningStrategy turningStrategy;

    private Robot robot;

    /// <summary>
    /// Initializes a new instance of the <see cref="Collider"/> class.
    /// </summary>
    /// <param name="map"></param>
    /// <param name="startDirection"></param>
    /// <param name="turningStrategy"></param>
    /// <param name="outputStram"></param>
    public Collider(
        WorldMap map,
        Direction startDirection,
        ITurningStrategy turningStrategy,
        ApplicationContext applicationContext) {

        this.map = map;
        this.startDirection = startDirection;
        this.turningStrategy = turningStrategy;
        robot = NewRobot();

        appCtx = applicationContext;
    }

    public void Execute() {
        CreateNewRobot();
        Walk();
        PrintResults();
    }

    private void CreateNewRobot() {
        robot = NewRobot();
    }

    private Robot NewRobot() {
        return Robot.Create(map.StartingPoint, startDirection);
    }

    private void Walk() {
        while (robot.Steps <= MaxAllowedSteps) {
            if (map.EndingExistsAt(robot.Position)) {
                break;
            }

            appCtx.OutputStream.WriteLine($"{robot} @ {map.CharAt(robot.Position)}");

            TurnIfNecessary();
            robot = robot.Advance();
        }
    }

    private void PrintResults() {
        if (robot.Steps > MaxAllowedSteps) {
            throw new MaximumStepsExceededException(MaxAllowedSteps);
        }

        appCtx.OutputStream.WriteLine($"{robot} @ {map.CharAt(robot.Position)}");
        appCtx.OutputStream.WriteLine();
        appCtx.OutputStream.WriteLine($"Answer: {map.MapCode}:{robot.Steps}");
    }

    private void TurnIfNecessary() {
        if (NextPositionIsObstacle()) {
            Direction nextDirection = turningStrategy.NextDirection(robot.Direction);
            robot = robot.TurnTo(nextDirection);
        }
    }

    private bool NextPositionIsObstacle() {
        Point nextPosition = robot.Position.Next(robot.Direction);
        return map.ObstacleExistsAt(nextPosition);
    }
}
