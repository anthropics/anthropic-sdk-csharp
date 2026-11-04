using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicContentTooLargeException : Anthropic4xxException
{
    public AnthropicContentTooLargeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
