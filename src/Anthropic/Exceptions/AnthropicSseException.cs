using System;

namespace Anthropic.Exceptions;

public class AnthropicSseException : AnthropicServiceException
{
    public AnthropicSseException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
