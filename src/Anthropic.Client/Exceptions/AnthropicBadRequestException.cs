using System.Net.Http;

namespace Anthropic.Client.Exceptions;

public class AnthropicBadRequestException : Anthropic4xxException
{
    public AnthropicBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
