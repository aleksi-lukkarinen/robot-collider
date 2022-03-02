// <copyright file="RightTurnStrategy.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;


internal class RightTurnStrategy : ITurningStrategy {
    /// <inheritdoc/>
    public Direction NextDirection(Direction currentDirection) {
        return currentDirection switch {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            _ => Direction.Up,
        };
    }
}
