using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicBadRequestException : Anthropic4xxException
{
    public AnthropicBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
