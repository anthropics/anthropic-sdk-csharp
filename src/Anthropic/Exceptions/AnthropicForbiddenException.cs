using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicForbiddenException : Anthropic4xxException
{
    public AnthropicForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
