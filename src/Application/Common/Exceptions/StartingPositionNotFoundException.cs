// <copyright file="StartingPositionNotFoundException.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;


internal class StartingPositionNotFoundException : ColliderException {
    /// <summary>
    /// Initializes a new instance of the <see cref="StartingPositionNotFoundException"/> class.
    /// </summary>
    public StartingPositionNotFoundException()
        : base("Invalid map: Starting position was not found.") {
    }
}
