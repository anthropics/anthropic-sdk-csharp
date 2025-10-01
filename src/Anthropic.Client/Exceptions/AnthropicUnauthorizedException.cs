using System.Net.Http;

namespace Anthropic.Client.Exceptions;

public class AnthropicUnauthorizedException : Anthropic4xxException
{
    public AnthropicUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
