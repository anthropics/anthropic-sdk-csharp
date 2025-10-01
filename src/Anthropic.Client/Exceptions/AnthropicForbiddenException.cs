using System.Net.Http;

namespace Anthropic.Client.Exceptions;

public class AnthropicForbiddenException : Anthropic4xxException
{
    public AnthropicForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
