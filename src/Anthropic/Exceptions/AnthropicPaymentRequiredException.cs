using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicPaymentRequiredException : Anthropic4xxException
{
    public AnthropicPaymentRequiredException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
