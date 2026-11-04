using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicRequestTimeoutException : Anthropic4xxException
{
    public AnthropicRequestTimeoutException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
