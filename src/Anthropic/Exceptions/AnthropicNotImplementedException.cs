using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicNotImplementedException : Anthropic5xxException
{
    public AnthropicNotImplementedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
