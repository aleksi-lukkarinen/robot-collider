// <copyright file="ColliderException.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Exceptions;


public class ColliderException : Exception {
    /// <summary>
    /// Initializes a new instance of the <see cref="ColliderException"/> class.
    /// </summary>
    public ColliderException()
        : base() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColliderException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public ColliderException(string? message)
        : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColliderException"/> class.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public ColliderException(string? message, Exception? innerException)
        : base(message, innerException) {
    }
}
