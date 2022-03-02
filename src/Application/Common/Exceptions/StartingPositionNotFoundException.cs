// <copyright file="StartingPositionNotFoundException.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;


internal class StartingPositionNotFoundException : Exception {
    public StartingPositionNotFoundException()
        : base("Invalid map: Starting position was not found.") {
    }
}
