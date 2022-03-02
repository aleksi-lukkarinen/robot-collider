// <copyright file="ITurningStrategy.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Collider;

using ColliderApp.Common.Utils;


internal interface ITurningStrategy {
    Direction NextDirection(Direction currentDirection);
}
