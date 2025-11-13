using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicUnexpectedStatusCodeException : AnthropicApiException
{
    public AnthropicUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
