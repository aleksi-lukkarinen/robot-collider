// <copyright file="Point.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

using ColliderApp.Common.Collider;

namespace ColliderApp.Common.Utils;


public class Point {
    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> class.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    public int X { get; }

    public int Y { get; }

    public Point Next(Direction direction) {
        return direction switch {
            Direction.Up => new Point(X, Y - 1),
            Direction.Right => new Point(X + 1, Y),
            Direction.Down => new Point(X, Y + 1),
            Direction.Left => new Point(X - 1, Y),

            _ => throw new NotImplementedException(),
        };
    }

    /// <inheritdoc/>
    public override string ToString() {
        return $"({X}, {Y})";
    }
}
