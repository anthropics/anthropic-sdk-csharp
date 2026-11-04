using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicRequestHeaderFieldsTooLargeException : Anthropic4xxException
{
    public AnthropicRequestHeaderFieldsTooLargeException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }
}
