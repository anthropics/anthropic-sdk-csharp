using System.Net.Http;

namespace Anthropic.Exceptions;

public class Anthropic5xxException : AnthropicApiException
{
    public Anthropic5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
