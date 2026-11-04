using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicServiceUnavailableException : Anthropic5xxException
{
    public AnthropicServiceUnavailableException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
