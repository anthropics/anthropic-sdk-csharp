using System.Net.Http;

namespace Anthropic.Client.Exceptions;

public class AnthropicRateLimitException : Anthropic4xxException
{
    public AnthropicRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
