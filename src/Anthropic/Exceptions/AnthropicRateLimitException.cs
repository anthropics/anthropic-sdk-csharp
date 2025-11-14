using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicRateLimitException : Anthropic4xxException
{
    public AnthropicRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
