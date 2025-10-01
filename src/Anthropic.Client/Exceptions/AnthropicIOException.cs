using System;
using System.Net.Http;

namespace Anthropic.Client.Exceptions;

public class AnthropicIOException : AnthropicException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public AnthropicIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
