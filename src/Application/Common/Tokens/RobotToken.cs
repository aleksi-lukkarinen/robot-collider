// <copyright file="Robot.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Tokens;

using ColliderApp.Common.Utils;


internal class RobotToken {
    private RobotToken(
        int steps,
        Point position,
        Direction direction) {

        Steps = steps;
        Position = position;
        Direction = direction;
    }

    public int Steps { get; }

    public Point Position { get; }

    public Direction Direction { get; }

    public static RobotToken Create(
        Point position,
        Direction direction) {

        return new RobotToken(
            steps: 0,
            position,
            direction);
    }

    public RobotToken Advance() {
        int newSteps = Steps + 1;
        Point newPosition = Position.Next(Direction);

        return new RobotToken(newSteps, newPosition, Direction);
    }

    public RobotToken TurnTo(Direction newDirection) {
        return new RobotToken(Steps, Position, newDirection);
    }

    /// <inheritdoc/>
    public override string ToString() {
        return $"[Robot: {Steps}, {Position}, {Direction}]";
    }
}
