using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Core.Telemetry;

public class PropagationTest : TracingTestBase
{
    [Fact]
    public async Task DisabledClient_EmitsNoSpanAndNoTraceHeaders()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler, openTelemetry: false);

        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        Assert.Empty(trace.Spans);
        Assert.Null(Assert.Single(handler.Requests).Header("traceparent"));
    }

    [Fact]
    public async Task TraceHeaders_ComeFromTheCallSpan_AndAreNotKeptOnTheParams()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        var parameters = MessageParams();

        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);
        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);

        Assert.Equal(2, trace.Spans.Count);
        var requests = handler.Requests.ToArray();
        for (var i = 0; i < 2; i++)
        {
            var traceparent = requests[i].Header("traceparent");
            Assert.NotNull(traceparent);
            Assert.Contains(trace.Root.TraceId.ToHexString(), traceparent);
            Assert.Contains(trace.Spans[i].SpanId.ToHexString(), traceparent);
        }
        Assert.NotEqual(requests[0].Header("traceparent"), requests[1].Header("traceparent"));
        Assert.DoesNotContain("traceparent", parameters.RawHeaderData.Keys);
    }

    [Fact]
    public async Task CallSpan_IsCurrentWhileEachRequestIsSent_AndOnlyThen()
    {
        using var trace = new RecordedTrace();
        // Stands in for an HTTP instrumentation: a span started while the request is sent.
        var attempts = new List<Activity>();
        HttpResponseMessage Attempt(string body)
        {
            var attempt = new Activity("attempt").Start();
            attempts.Add(attempt);
            attempt.Stop();
            return ScriptedHandler.Response(HttpStatusCode.OK, body, "req_1");
        }
        var handler = new ScriptedHandler()
            .Respond(_ => Attempt(Fixtures.MessageJson))
            .Respond(_ => Attempt("{}"));
        var client = Fixtures.Client(handler);

        // A method that starts its span itself, and one whose span the client starts.
        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);
        Assert.Same(trace.Root, Activity.Current);
        await client.Models.Retrieve("claude-test", null, TestContext.Current.CancellationToken);
        Assert.Same(trace.Root, Activity.Current);

        Assert.Equal(2, attempts.Count);
        Assert.Equal(trace.Single("anthropic.messages.create").SpanId, attempts[0].ParentSpanId);
        Assert.Equal(trace.Single("anthropic.models.retrieve").SpanId, attempts[1].ParentSpanId);
        Assert.All(trace.Spans, span => Assert.Equal(trace.Root.SpanId, span.ParentSpanId));
    }

    [Fact]
    public async Task CallSpan_IsNotCurrentWhileTheApplicationReadsTheStream()
    {
        using var trace = new RecordedTrace();
        Activity? attempt = null;
        var handler = new ScriptedHandler().Respond(_ =>
        {
            attempt = new Activity("attempt").Start();
            attempt.Stop();
            var response = ScriptedHandler.Response(
                HttpStatusCode.OK,
                Fixtures.Sse(Fixtures.StreamBody),
                "req_stream"
            );
            response.Content.Headers.ContentType = new("text/event-stream");
            return response;
        });
        var client = Fixtures.Client(handler);

        using var response = await client.WithRawResponse.Messages.CreateStreaming(
            MessageParams(),
            TestContext.Current.CancellationToken
        );
        // The call span is still open, since the stream is unread, but the application's own
        // span is the current one again, and stays so while it reads the stream.
        Assert.Same(trace.Root, Activity.Current);
        Assert.Empty(trace.Spans);
        var read = 0;
        await foreach (var _ in response.Enumerate(TestContext.Current.CancellationToken))
        {
            read++;
            Assert.Same(trace.Root, Activity.Current);
        }
        Assert.Same(trace.Root, Activity.Current);

        Assert.Equal(Fixtures.StreamBody.Length, read);
        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal(trace.Root.SpanId, span.ParentSpanId);
        Assert.Equal(span.SpanId, attempt?.ParentSpanId);
    }

    static readonly string[] W3CTraceContextHeaders = ["traceparent", "tracestate", "baggage"];

    const string SigV4AccessKey = "AKIAIOSFODNN7EXAMPLE";
    const string SigV4SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";

    /// <summary>
    /// The client of <paramref name="platform"/> that signs its requests with AWS Signature
    /// Version 4 and static credentials, sending them to <paramref name="handler"/>.
    /// </summary>
    static AnthropicClient SigningClient(string platform, HttpMessageHandler handler)
    {
        AnthropicClient client = platform switch
        {
            "aws" => new Anthropic.Aws.AnthropicAwsClient(
                new()
                {
                    AwsAccessKey = SigV4AccessKey,
                    AwsSecretAccessKey = SigV4SecretKey,
                    AwsRegion = "us-east-1",
                    WorkspaceId = "default",
                    BaseUrl = "https://aws-external-anthropic.us-east-1.api.aws",
                }
            ),
            "bedrock" => new Anthropic.Bedrock.AnthropicBedrockClient(
                new Anthropic.Bedrock.AnthropicBedrockPrivateKeyCredentials
                {
                    ApiAccessKey = SigV4AccessKey,
                    ApiSecret = SigV4SecretKey,
                    Region = "us-east-1",
                }
            ),
            "bedrock-mantle" => new Anthropic.Bedrock.AnthropicBedrockMantleClient(
                new()
                {
                    AwsAccessKey = SigV4AccessKey,
                    AwsSecretAccessKey = SigV4SecretKey,
                    AwsRegion = "us-east-1",
                }
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(platform)),
        };
        return (AnthropicClient)
            client.WithOptions(options =>
                options with
                {
                    HttpClient = new HttpClient(handler),
                    MaxRetries = 0,
                }
            );
    }

    /// <summary>
    /// The names in the <c>SignedHeaders</c> of a Signature Version 4 <c>Authorization</c> header.
    /// </summary>
    static string[] SignedHeaders(string? authorization)
    {
        Assert.NotNull(authorization);
        Assert.StartsWith("AWS4-HMAC-SHA256 ", authorization);
        var field = Assert.Single(
            authorization.Split(','),
            part => part.Trim().StartsWith("SignedHeaders=", StringComparison.Ordinal)
        );
        return field.Trim().Substring("SignedHeaders=".Length).Split(';');
    }

    [Theory]
    [InlineData("aws")]
    [InlineData("bedrock")]
    [InlineData("bedrock-mantle")]
    public async Task SignedRequest_SendsTheTraceContextHeadersUnsigned(string platform)
    {
        using var trace = new RecordedTrace();
        trace.Root.TraceStateString = "vendor=value";
        trace.Root.AddBaggage("tenant", "t1");
        var handler = new ScriptedHandler().RespondJson("{}");
        var client = SigningClient(platform, handler);

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<PingParams>
            {
                Method = HttpMethod.Post,
                Params = new(),
                SpanName = "anthropic.messages.create",
            },
            TestContext.Current.CancellationToken
        );
        response.Dispose();

        var span = trace.Single("anthropic.messages.create");
        var sent = Assert.Single(handler.Requests);
        // The trace context is on the wire.
        Assert.Equal($"00-{span.TraceId}-{span.SpanId}-01", sent.Header("traceparent"));
        Assert.Equal("vendor=value", sent.Header("tracestate"));
        // An HTTP instrumentation may replace it with that of its own span after the request is
        // signed, so the signature must not cover it, under any name that the propagator writes.
        var signed = SignedHeaders(sent.Header("authorization"));
        Assert.Contains("host", signed);
        Assert.Contains("x-amz-date", signed);
        var unsigned = W3CTraceContextHeaders
            .Concat(DistributedContextPropagator.Current.Fields)
            .Select(name => name.ToLowerInvariant())
            .Distinct()
            .ToArray();
        Assert.Contains(unsigned, name => name != "traceparent" && sent.Header(name) != null);
        Assert.All(unsigned, name => Assert.DoesNotContain(name, signed));
    }

    [Theory]
    [InlineData("aws")]
    [InlineData("bedrock-mantle")]
    public async Task SignedRequest_WhoseTraceContextAnInstrumentationReplaces_StillVerifies(
        string platform
    )
    {
        using var trace = new RecordedTrace();
        var gateway = new SigV4VerifyingHandler(SigV4SecretKey, "{}");
        var client = SigningClient(platform, new ReplacingTraceContext { InnerHandler = gateway });

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<PingParams>
            {
                Method = HttpMethod.Post,
                Params = new(),
                SpanName = "anthropic.messages.create",
            },
            TestContext.Current.CancellationToken
        );
        response.Dispose();

        Assert.Single(gateway.VerifiedRequestUris);
        Assert.Equal(ActivityStatusCode.Ok, trace.Single("anthropic.messages.create").Status);
    }

    [Fact]
    public async Task BackendAdaptationHandler_DoesNotSeeTheTraceContextHeadersThatAreSent()
    {
        using var trace = new RecordedTrace();
        trace.Root.TraceStateString = "vendor=value";
        trace.Root.AddBaggage("tenant", "t1");
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var applicationHandler = new RecordingHandler();
        var backendAdaptationHandler = new RecordingHandler();
        var client = new AnthropicClient
        {
            HttpClient = new HttpClient(handler),
            BaseUrl = Fixtures.BaseUrl,
            ApiKey = "test-key",
            Handlers = [applicationHandler],
            BackendAdaptationHandler = () => backendAdaptationHandler,
        };

        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        var names = TraceContextHeaders.Names();
        var seen = Assert.Single(applicationHandler.Requests);
        var adapted = Assert.Single(backendAdaptationHandler.Requests);
        var sent = Assert.Single(handler.Requests);
        Assert.Equal($"00-{span.TraceId}-{span.SpanId}-01", sent.Header("traceparent"));
        Assert.Equal("vendor=value", sent.Header("tracestate"));
        Assert.Contains(sent.Headers.Values, value => value.Contains("tenant"));
        Assert.DoesNotContain(adapted.Headers.Keys, names.Contains);
        Assert.Equal(seen.Headers, sent.Headers);
        Assert.Equal(seen.Headers.Where(header => !names.Contains(header.Key)), adapted.Headers);
    }

    sealed class RecordingHandler : DelegatingHandler
    {
        public List<RecordedRequest> Requests { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Requests.Add(RecordedRequest.From(request));
            return base.SendAsync(request, cancellationToken);
        }
    }

    /// <summary>
    /// Stands in for an HTTP instrumentation below the SDK: replaces the trace context of each
    /// request with that of its own attempt span.
    /// </summary>
    sealed class ReplacingTraceContext : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Assert.True(request.Headers.Contains("traceparent"));
            request.Headers.Remove("traceparent");
            request.Headers.TryAddWithoutValidation(
                "traceparent",
                "00-0af7651916cd43dd8448eb211c80319c-b7ad6b7169203331-01"
            );
            request.Headers.Remove("baggage");
            request.Headers.TryAddWithoutValidation("baggage", "attempt=1");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
