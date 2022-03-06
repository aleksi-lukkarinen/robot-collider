// <copyright file="Collider.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Collider;

using System.Collections.Immutable;
using ColliderApp.Common.Exceptions;
using ColliderApp.Common.Map;
using ColliderApp.Common.Tokens;
using ColliderApp.Common.Utils;


internal class Collider {
    private readonly ApplicationContext appCtx;

    private readonly WorldMap map;
    private readonly Direction startDirection;
    private readonly ITurningStrategy turningStrategy;

    private RobotToken robot;

    public ImmutableList<Application.Common.Tokens.IRobotTokenAction> Actions {
        get { return robot.Actions; }
    }

    public int Steps {
        get { return robot.Steps; }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Collider"/> class.
    /// </summary>
    /// <param name="map"></param>
    /// <param name="startDirection"></param>
    /// <param name="turningStrategy"></param>
    /// <param name="applicationContext"></param>
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

    public void Execute(int maxAllowedSteps) {
        CreateNewRobot();
        Walk(maxAllowedSteps);
    }

    private void CreateNewRobot() {
        robot = NewRobot();
    }

    private RobotToken NewRobot() {
        return RobotToken.Create(map.StartingPoint, startDirection);
    }

    private void Walk(int maxAllowedSteps) {
        while (robot.Steps < maxAllowedSteps) {
            if (map.EndingExistsAt(robot.Position)) {
                break;
            }

            TurnIfNecessary();
            robot = robot.Advance();
        }

        if (!map.EndingExistsAt(robot.Position)) {
            throw new MaximumStepsExceededException(maxAllowedSteps);
        }
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
