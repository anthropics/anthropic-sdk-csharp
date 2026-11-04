using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicPreconditionFailedException : Anthropic4xxException
{
    public AnthropicPreconditionFailedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
