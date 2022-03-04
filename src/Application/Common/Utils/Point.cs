// <copyright file="Point.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Utils;


/// <summary>
/// The <see cref="Point"/> class represents
/// an immutable two-dimensional integer coordinate pair.
/// </summary>
public class Point {
    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> class.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Gets the X coordinate.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Gets the Y coordinate.
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Calculates the next point in the given direction.
    /// </summary>
    /// <param name="direction">The direction of the requested point.</param>
    /// <returns>A new <see cref="Point"/> instance that represents the requested point.</returns>
    /// <exception cref="NotImplementedException">
    /// Thrown if the <paramref name="direction"/> is given an unknown value.
    /// </exception>
    public Point Next(Direction direction) {
        return direction switch {
            Direction.Up => new Point(X, Y - 1),
            Direction.Right => new Point(X + 1, Y),
            Direction.Down => new Point(X, Y + 1),
            Direction.Left => new Point(X - 1, Y),

            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// Determines if the specified <see cref="Point"/> is equal to this <see cref="Point"/>.
    /// </summary>
    /// <param name="obj">The other point to compare this point to.</param>
    /// <returns>
    /// <see langword="true"/> if the points represent the same coordinate pair;
    /// <see langword="false"/> otherwise.
    /// </returns>
    public override bool Equals(object? obj) {
        return obj is Point point &&
               X == point.X &&
               Y == point.Y;
    }

    /// <summary>
    /// Computes a hash code for this <see cref="Point"/>.
    /// </summary>
    /// <returns>A hash code for this <see cref="Point"/>.</returns>
    public override int GetHashCode() {
        return HashCode.Combine(X, Y);
    }

    /// <summary>
    /// Returns a string that represents this <see cref="Point"/>.
    /// The format of the string is <c>(X, Y)</c>.
    /// </summary>
    /// <returns>A string that represents this <see cref="Point"/>.</returns>
    public override string ToString() {
        return $"({X}, {Y})";
    }
}
