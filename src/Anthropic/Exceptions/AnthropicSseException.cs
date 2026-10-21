using System;

namespace Anthropic.Exceptions;

public class AnthropicSseException : AnthropicServiceException
{
    public AnthropicSseException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    /// <summary>
    /// The data of the <c>error</c> event as the server sent it. <c>ErrorType</c> holds only a
    /// type that this SDK version knows, so the data is what keeps any other type.
    /// </summary>
    internal string? EventData { get; init; }
}
