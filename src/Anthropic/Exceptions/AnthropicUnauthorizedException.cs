using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicUnauthorizedException : Anthropic4xxException
{
    public AnthropicUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
