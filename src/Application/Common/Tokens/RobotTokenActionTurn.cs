// <copyright file="RobotTokenActionTurn.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace Application.Common.Tokens;

using ColliderApp.Common.Tokens;
using ColliderApp.Common.Utils;


/// <summary>
/// The <see cref="RobotTokenActionStep"/> class represents
/// <see cref="RobotToken"/>'s turn towards a specific <see cref="Direction"/>.
/// The class is immutable.
/// </summary>
internal class RobotTokenActionTurn : IRobotTokenAction {

    public RobotTokenActionTurn(Direction towards) {
        Towards = towards;
    }

    public Direction Towards { get; }
}
