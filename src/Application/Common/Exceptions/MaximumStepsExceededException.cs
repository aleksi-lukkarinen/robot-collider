// <copyright file="MaximumStepsExceededException.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp;


public class MaximumStepsExceededException : Exception {
    public MaximumStepsExceededException(int maxAllowedSteps)
        : base(CreateMessage(maxAllowedSteps)) {
    }

    private static string CreateMessage(int maxAllowedSteps) {
        return $"Invalid map: Maximum number of steps ({maxAllowedSteps}) exceeded during walk.";
    }
}
