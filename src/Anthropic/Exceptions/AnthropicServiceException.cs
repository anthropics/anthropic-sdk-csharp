using System;
using System.Net.Http;
using Anthropic.Models;

namespace Anthropic.Exceptions;

public class AnthropicServiceException : AnthropicException
{
    public AnthropicServiceException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected AnthropicServiceException(HttpRequestException? innerException)
        : base(innerException) { }

    public ErrorType? ErrorType { get; init; }
}
