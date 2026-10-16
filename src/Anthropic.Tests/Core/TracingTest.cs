using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;

namespace Anthropic.Tests.Core;

[Collection("Tracing")]
public sealed class TracingTest : IDisposable
{
    const string Variable = "ANTHROPIC_OPEN_TELEMETRY";

    // The SDK does not read this variable, so every test runs with it set.
    const string UnreadVariable = "ANTHROPIC_OPEN_TELEMETRY_PROPAGATION";

    readonly string? _previousVariable = Environment.GetEnvironmentVariable(Variable);
    readonly string? _previousUnreadVariable = Environment.GetEnvironmentVariable(UnreadVariable);
    readonly DistributedContextPropagator _previousPropagator =
        DistributedContextPropagator.Current;
    readonly CountingPropagator _propagator = new();
    readonly List<Activity> _spans = new();
    readonly ActivityListener _listener;

    public TracingTest()
    {
        Environment.SetEnvironmentVariable(Variable, null);
        Environment.SetEnvironmentVariable(UnreadVariable, "false");
        DistributedContextPropagator.Current = _propagator;
        _listener = new()
        {
            ShouldListenTo = source => source.Name == "com.anthropic.sdk.csharp",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = _spans.Add,
        };
        ActivitySource.AddActivityListener(_listener);
    }

    public void Dispose()
    {
        _listener.Dispose();
        DistributedContextPropagator.Current = _previousPropagator;
        Environment.SetEnvironmentVariable(Variable, _previousVariable);
        Environment.SetEnvironmentVariable(UnreadVariable, _previousUnreadVariable);
    }

    [Theory]
    [InlineData(null, null, true)]
    [InlineData(null, false, false)]
    [InlineData(null, true, true)]
    [InlineData("false", null, false)]
    [InlineData("FALSE", null, false)]
    [InlineData("0", null, true)]
    [InlineData("no", null, true)]
    [InlineData("", null, true)]
    [InlineData("false", true, true)]
    [InlineData("true", false, false)]
    public Task OptionAndVariable_DecideWhetherCallIsTraced(
        string? variable,
        bool? option,
        bool traced
    )
    {
        return Check(variable, option is bool enabled ? enabled : null, traced, HttpStatusCode.OK);
    }

    [Theory]
    [InlineData(null, true)]
    [InlineData("false", false)]
    public Task RetriedCall_SendsTraceContextWithEachAttempt(string? variable, bool traced)
    {
        return Check(variable, null, traced, HttpStatusCode.InternalServerError);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public Task OptionsWithoutEnabled_ReadNoVariable(bool withTraces)
    {
        return Check(
            "false",
            withTraces ? new() { Traces = new() } : new(),
            true,
            HttpStatusCode.OK
        );
    }

    [Fact]
    public async Task WithOptions_KeepsWhatTheClientRead()
    {
        Environment.SetEnvironmentVariable(Variable, "false");
        var handler = new RecordingHandler(HttpStatusCode.OK);
        AnthropicClient client = new() { HttpClient = new HttpClient(handler) };
        Environment.SetEnvironmentVariable(Variable, null);

        await Send(client.WithOptions(options => options with { MaxRetries = 0 }));

        // Options that a copy sets replace the first client's as a whole, and read no variable.
        await Send(client.WithOptions(options => options with { OpenTelemetry = new() }));
        Environment.SetEnvironmentVariable(Variable, "false");
        await Send(
            client.WithOptions(options => options with { OpenTelemetry = new() { Traces = new() } })
        );

        Assert.False(HasTraceContext(handler.Requests[0]));
        Assert.True(HasTraceContext(handler.Requests[1]));
        Assert.True(HasTraceContext(handler.Requests[2]));
    }

    [Fact]
    public async Task NoOutputPropagator_TurnsTraceContextOff()
    {
        DistributedContextPropagator.Current =
            DistributedContextPropagator.CreateNoOutputPropagator();
        var handler = new RecordingHandler(HttpStatusCode.OK);
        AnthropicClient client = new() { HttpClient = new HttpClient(handler) };

        await Send(client);

        Assert.False(HasTraceContext(Assert.Single(handler.Requests)));
        Assert.Single(_spans);
    }

    async Task Check(
        string? variable,
        OpenTelemetryOptions? option,
        bool traced,
        HttpStatusCode firstStatus
    )
    {
        Environment.SetEnvironmentVariable(Variable, variable);
        var handler = new RecordingHandler(firstStatus);
        AnthropicClient client = new()
        {
            HttpClient = new HttpClient(handler),
            OpenTelemetry = option,
            MaxRetries = 2,
        };

        await Send(client);

        // The client retries a first status that is an error once. A call that is traced has one
        // span, and each of its requests carries the trace context.
        var attempts = firstStatus == HttpStatusCode.OK ? 1 : 2;
        var expected = traced ? attempts : 0;
        Assert.Equal(attempts, handler.Requests.Count);
        Assert.Equal(expected, _propagator.Injections);
        Assert.Equal(expected, Enumerable.Count(handler.Requests, HasTraceContext));
        Assert.Equal(traced ? 1 : 0, _spans.Count);
    }

    static async Task Send(IAnthropicClient client)
    {
        // A span takes its parent's ID format. .NET Framework's default one has no traceparent.
        using var root = new Activity("test").SetIdFormat(ActivityIdFormat.W3C).Start();

        // Disposing of the response ends the span.
        using var response = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams>
            {
                Method = HttpMethod.Get,
                Params = new(),
                SpanName = "test",
            },
            TestContext.Current.CancellationToken
        );
    }

    static bool HasTraceContext(HttpRequestHeaders headers) => headers.Contains("traceparent");

    record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // do nothing
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    sealed class CountingPropagator : DistributedContextPropagator
    {
        readonly DistributedContextPropagator _inner = CreateDefaultPropagator();

        public int Injections { get; private set; }

        public override IReadOnlyCollection<string> Fields => _inner.Fields;

        public override void Inject(
            Activity? activity,
            object? carrier,
            PropagatorSetterCallback? setter
        )
        {
            Injections++;
            _inner.Inject(activity, carrier, setter);
        }

        public override void ExtractTraceIdAndState(
            object? carrier,
            PropagatorGetterCallback? getter,
            out string? traceId,
            out string? traceState
        ) => _inner.ExtractTraceIdAndState(carrier, getter, out traceId, out traceState);

        public override IEnumerable<KeyValuePair<string, string?>>? ExtractBaggage(
            object? carrier,
            PropagatorGetterCallback? getter
        ) => _inner.ExtractBaggage(carrier, getter);
    }

    sealed class RecordingHandler : HttpMessageHandler
    {
        readonly HttpStatusCode _firstStatus;

        public RecordingHandler(HttpStatusCode firstStatus)
        {
            _firstStatus = firstStatus;
        }

        public List<HttpRequestHeaders> Requests { get; } = new();

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Requests.Add(request.Headers);
            var response = new HttpResponseMessage(
                Requests.Count == 1 ? _firstStatus : HttpStatusCode.OK
            )
            {
                Content = new StringContent("{}"),
            };
            // Keeps the retry from waiting.
            response.Headers.Add("Retry-After-Ms", "1");
            return Task.FromResult(response);
        }
    }
}

[CollectionDefinition("Tracing", DisableParallelization = true)]
public sealed class TracingCollection { }
