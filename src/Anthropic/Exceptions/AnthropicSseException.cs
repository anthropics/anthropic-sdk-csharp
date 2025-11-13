using System;

namespace Anthropic.Exceptions;

public class AnthropicSseException : AnthropicException
{
    public AnthropicSseException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
