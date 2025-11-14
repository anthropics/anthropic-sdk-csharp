using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicUnprocessableEntityException : Anthropic4xxException
{
    public AnthropicUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
