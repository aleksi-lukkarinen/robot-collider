// <copyright file="RightTurnStrategy.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Collider;

using ColliderApp.Common.Utils;


/// <summary>
/// A strategy for always turning to the right
/// in relation to the given current direction.
/// </summary>
internal class RightTurnStrategy : ITurningStrategy {
    /// <summary>
    /// Returns a direction that represents turning to
    /// the right in regards the given current direction.
    /// </summary>
    /// <param name="currentDirection">The current direction.</param>
    /// <returns>The direction to the right regarding the current direction.</returns>
    public Direction NextDirection(Direction currentDirection) {
        return currentDirection switch {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            _ => Direction.Up,
        };
    }
}
