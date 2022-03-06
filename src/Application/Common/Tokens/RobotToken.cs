// <copyright file="Robot.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Tokens;

using System.Collections.Immutable;
using Application.Common.Tokens;
using ColliderApp.Common.Utils;


internal class RobotToken {
    private RobotToken(
        ImmutableList<IRobotTokenAction> actions,
        int steps,
        Point position,
        Direction direction) {

        Actions = actions;
        Steps = steps;
        Position = position;
        Direction = direction;
    }

    public ImmutableList<IRobotTokenAction> Actions { get; }

    public int Steps { get; }

    public Point Position { get; }

    public Direction Direction { get; }

    public static RobotToken Create(
        Point position,
        Direction direction) {

        return new RobotToken(
            ImmutableList<IRobotTokenAction>.Empty,
            steps: 0,
            position,
            direction);
    }

    public RobotToken Advance() {
        int newSteps = Steps + 1;
        Point newPosition = Position.Next(Direction);
        RobotTokenActionStep newAction = new(newPosition);
        ImmutableList<IRobotTokenAction> newActionList = Actions.Add(newAction);

        return new RobotToken(
            newActionList,
            newSteps,
            newPosition,
            Direction);
    }

    public RobotToken TurnTo(Direction newDirection) {
        RobotTokenActionTurn newAction = new(newDirection);
        ImmutableList<IRobotTokenAction> newActionList = Actions.Add(newAction);

        return new RobotToken(
            newActionList,
            Steps,
            Position,
            newDirection);
    }

    /// <inheritdoc/>
    public override string ToString() {
        return $"[Robot: {Actions.Count}, {Steps}, {Position}, {Direction}]";
    }
}
