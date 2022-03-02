// <copyright file="MaximumStepsExceededException.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Exceptions;


public class MaximumStepsExceededException : ColliderException {
    /// <summary>
    /// Initializes a new instance of the <see cref="MaximumStepsExceededException"/> class.
    /// </summary>
    /// <param name="maxAllowedSteps"></param>
    public MaximumStepsExceededException(int maxAllowedSteps)
        : base(CreateMessage(maxAllowedSteps)) {
    }

    private static string CreateMessage(int maxAllowedSteps) {
        return $"Invalid map: Maximum number of steps ({maxAllowedSteps}) exceeded during walk.";
    }
}
