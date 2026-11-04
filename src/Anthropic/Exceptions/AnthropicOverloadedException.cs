using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicOverloadedException : Anthropic5xxException
{
    public AnthropicOverloadedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
