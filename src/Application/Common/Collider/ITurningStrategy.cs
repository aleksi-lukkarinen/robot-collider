// <copyright file="ITurningStrategy.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Collider;

using ColliderApp.Common.Utils;


/// <summary>
/// An interface for strategies for turning based on current direction.
/// </summary>
internal interface ITurningStrategy {
    /// <summary>
    /// Computes a new direction based on the given current direction.
    /// </summary>
    /// <param name="currentDirection">The current direction.</param>
    /// <returns>A new direction.</returns>
    Direction NextDirection(Direction currentDirection);
}
