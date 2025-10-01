using System.Net.Http;

namespace Anthropic.Client.Exceptions;

public class AnthropicUnexpectedStatusCodeException : AnthropicApiException
{
    public AnthropicUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
