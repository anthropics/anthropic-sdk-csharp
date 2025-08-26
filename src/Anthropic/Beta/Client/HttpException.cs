using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Anthropic.Beta.Client;

public sealed class HttpException : Exception
{
    public required HttpStatusCode? StatusCode { get; set; }
    public required string ResponseBody { get; set; }
    public override string Message
    {
        get
        {
            return string.Format(
                "Status Code: {0}\n{1}",
                this.StatusCode?.ToString() ?? "Unknown",
                this.ResponseBody
            );
        }
    }

    [SetsRequiredMembers]
    public HttpException(HttpStatusCode? statusCode, string responseBody)
    {
        this.StatusCode = statusCode;
        this.ResponseBody = responseBody;
    }
}
