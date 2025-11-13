using System;

namespace Anthropic.Exceptions;

public class AnthropicInvalidDataException : AnthropicException
{
    public AnthropicInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
