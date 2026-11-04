using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicGatewayTimeoutException : Anthropic5xxException
{
    public AnthropicGatewayTimeoutException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
