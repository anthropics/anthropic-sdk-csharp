using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicNotFoundException : Anthropic4xxException
{
    public AnthropicNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
