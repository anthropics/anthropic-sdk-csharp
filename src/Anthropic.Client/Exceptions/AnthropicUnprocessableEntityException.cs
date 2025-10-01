using System.Net.Http;

namespace Anthropic.Client.Exceptions;

public class AnthropicUnprocessableEntityException : Anthropic4xxException
{
    public AnthropicUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
