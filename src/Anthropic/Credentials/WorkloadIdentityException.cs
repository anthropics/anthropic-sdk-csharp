using System;
using System.Net;
using Anthropic.Exceptions;

namespace Anthropic.Credentials;

/// <summary>
/// Exception thrown when a workload identity token exchange fails.
/// </summary>
public class WorkloadIdentityException : AnthropicException
{
    /// <summary>
    /// The HTTP status code from the token endpoint, if available.
    /// </summary>
    public HttpStatusCode? StatusCode { get; }

    /// <summary>
    /// The redacted response body from the token endpoint, if available.
    /// </summary>
    public string? ResponseBody { get; }

    public WorkloadIdentityException(string message)
        : base(message) { }

    public WorkloadIdentityException(string message, Exception innerException)
        : base(message, innerException) { }

    public WorkloadIdentityException(
        string message,
        HttpStatusCode statusCode,
        string? responseBody
    )
        : base(message)
    {
        StatusCode = statusCode;
        ResponseBody = responseBody;
    }
}
