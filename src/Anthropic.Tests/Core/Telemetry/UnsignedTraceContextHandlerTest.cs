using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core.Telemetry;

namespace Anthropic.Tests.Core.Telemetry;

public class UnsignedTraceContextHandlerTest
{
    [Fact]
    public async Task TraceContextHeaders_SkipTheBackendAdaptationHandler()
    {
        var httpClient = new ScriptedHandler().RespondJson("{}");
        var backendAdaptationHandler = new SigningEveryHeader();
        using var invoker = new HttpMessageInvoker(
            new UnsignedTraceContextHandler(backendAdaptationHandler, httpClient)
        );
        using var request = new HttpRequestMessage(HttpMethod.Post, Fixtures.BaseUrl);
        request.Headers.Add("x-api-key", "test-key");
        request.Headers.Add(
            "traceparent",
            "00-0af7651916cd43dd8448eb211c80319c-b7ad6b7169203331-01"
        );
        request.Headers.Add("TraceState", ["vendor=value", "other=2"]);
        request.Headers.Add("baggage", "tenant=t1");

        await invoker.SendAsync(request, TestContext.Current.CancellationToken);

        var sent = Assert.Single(httpClient.Requests);
        Assert.Equal("x-api-key", sent.Header("signed"));
        Assert.Equal(
            "00-0af7651916cd43dd8448eb211c80319c-b7ad6b7169203331-01",
            sent.Header("traceparent")
        );
        Assert.Equal("vendor=value,other=2", sent.Header("tracestate"));
        Assert.Equal("tenant=t1", sent.Header("baggage"));
    }

    [Fact]
    public async Task RequestWithoutTraceContextHeaders_IsSentAsTheBackendAdaptationHandlerLeftIt()
    {
        var httpClient = new ScriptedHandler().RespondJson("{}");
        using var invoker = new HttpMessageInvoker(
            new UnsignedTraceContextHandler(new SigningEveryHeader(), httpClient)
        );
        using var request = new HttpRequestMessage(HttpMethod.Post, Fixtures.BaseUrl);
        request.Headers.Add("x-api-key", "test-key");

        await invoker.SendAsync(request, TestContext.Current.CancellationToken);

        var sent = Assert.Single(httpClient.Requests);
        Assert.Equal(
            ["signed", "x-api-key"],
            sent.Headers.Keys.OrderBy(name => name, StringComparer.Ordinal)
        );
    }

    /// <summary>
    /// Stands in for a handler that signs every header of the request: lists their names in a
    /// <c>signed</c> header.
    /// </summary>
    sealed class SigningEveryHeader : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            IEnumerable<string> names = request.Headers.Select(header =>
                header.Key.ToLowerInvariant()
            );
            request.Headers.Add("signed", string.Join(";", names));
            return base.SendAsync(request, cancellationToken);
        }
    }
}
