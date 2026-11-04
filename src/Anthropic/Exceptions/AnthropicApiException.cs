using System;
using System.Net;
using System.Net.Http;

namespace Anthropic.Exceptions;

public class AnthropicApiException : AnthropicServiceException
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

    public AnthropicApiException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }

    protected AnthropicApiException(HttpRequestException? innerException)
        : base(innerException) { }

    public required HttpStatusCode StatusCode { get; init; }

    public required string ResponseBody
    {
        get { return _responseBody; }
        init
        {
            _responseBody = value;
            Body = ParseBody(value);
        }
    }

    readonly string _responseBody = "";

    /// <summary>
    /// Returns the value of the <c>request-id</c> header,
    /// or null if there's no such header in the response.
    /// </summary>
    public string? RequestID { get; init; }

    /// <summary>
    /// Returns the value of the <c>anthropic-workspace-id</c> header,
    /// or null if there's no such header in the response.
    /// </summary>
    public string? WorkspaceID { get; init; }

    public override string Message
    {
        get
        {
            return ResponseBody.Length == 0
                ? string.Format("Status Code: {0}", StatusCode)
                : string.Format("Status Code: {0}\n{1}", StatusCode, ResponseBody);
        }
    }
}
