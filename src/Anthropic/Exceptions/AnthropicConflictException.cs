using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicConflictException : Anthropic4xxException
{
    public AnthropicConflictException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
