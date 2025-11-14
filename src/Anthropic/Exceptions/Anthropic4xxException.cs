using System.Net.Http;

namespace Anthropic.Exceptions;

public class Anthropic4xxException : AnthropicApiException
{
    public Anthropic4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
