// <copyright file="Robot.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;


internal class Robot {
    private Robot(
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

    public static Robot Create(
        Point position,
        Direction direction) {

        return new Robot(
            steps: 0,
            position,
            direction);
    }

    public Robot Advance() {
        int newSteps = Steps + 1;
        Point newPosition = Position.Next(Direction);

        return new Robot(newSteps, newPosition, Direction);
    }

    public Robot TurnTo(Direction newDirection) {
        return new Robot(Steps, Position, newDirection);
    }

    /// <inheritdoc/>
    public override string ToString() {
        return $"[Robot: {Steps}, {Position}, {Direction}]";
    }
}
