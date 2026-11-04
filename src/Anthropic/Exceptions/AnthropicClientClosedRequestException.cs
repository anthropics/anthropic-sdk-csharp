using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicClientClosedRequestException : Anthropic4xxException
{
    public AnthropicClientClosedRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
