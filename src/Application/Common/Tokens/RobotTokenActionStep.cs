// <copyright file="RobotTokenActionStep.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace Application.Common.Tokens;

using ColliderApp.Common.Tokens;
using ColliderApp.Common.Utils;


/// <summary>
/// The <see cref="RobotTokenActionStep"/> class represents
/// <see cref="RobotToken"/>'s movement of one step to a new position.
/// The class is immutable.
/// </summary>
internal class RobotTokenActionStep : IRobotTokenAction {

    public RobotTokenActionStep(Point newLocation) {
        Location = newLocation;
    }

    public Point Location { get; }
}
