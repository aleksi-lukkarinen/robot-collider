// <copyright file="ApplicationContext.cs" company="Aleksi Lukkarinen">
// Copyright (c) Aleksi Lukkarinen. All rights reserved.
// </copyright>

namespace ColliderApp.Common.Utils;


internal class ApplicationContext {

    public ApplicationContext(TextWriter outputStream, TextWriter errorStream) {
        OutputStream = outputStream;
        ErrorStream = errorStream;
    }

    public TextWriter OutputStream { get; set; }

    public TextWriter ErrorStream { get; set; }
}
