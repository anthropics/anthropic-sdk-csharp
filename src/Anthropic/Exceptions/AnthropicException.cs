using System;
using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicException : Exception
{
    public AnthropicException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected AnthropicException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
