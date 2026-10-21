using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Messages;
using Anthropic.Models.Messages.Batches;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

/// <summary>
/// Tracing costs a call that emits no span one check, and never changes what a call returns or
/// throws. Each test has an activity source of its own, so that what it listens to, or leaves
/// without a listener, is not what the tests that run beside it listen to.
/// </summary>
public sealed class TracingGuardsTest : IDisposable
{
    readonly ActivitySource _source = new("anthropic.tests.guards." + Guid.NewGuid().ToString("N"));
    readonly List<IDisposable> _disposables = [];

    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
        _source.Dispose();
    }

    AnthropicClient Client(ScriptedHandler handler, OpenTelemetryOptions? openTelemetry = null) =>
        new()
        {
            HttpClient = new HttpClient(handler),
            BaseUrl = Fixtures.BaseUrl,
            ApiKey = "test-key",
            MaxRetries = 0,
            // The Messages methods read `max_tokens` for a client that has no timeout.
            Timeout = TimeSpan.FromSeconds(30),
            OpenTelemetry = openTelemetry,
            OpenTelemetrySource = _source,
        };

    /// <summary>
    /// Listens to this test's source, and collects its activities as they stop.
    /// </summary>
    ConcurrentQueue<Activity> Listen(Action<Activity>? stopped = null)
    {
        ConcurrentQueue<Activity> spans = new();
        ActivityListener listener = new()
        {
            ShouldListenTo = source => ReferenceEquals(source, _source),
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                spans.Enqueue(activity);
                stopped?.Invoke(activity);
            },
        };
        ActivitySource.AddActivityListener(listener);
        _disposables.Add(listener);
        return spans;
    }

    /// <summary>
    /// Starts the application's own activity, which the spans of the test's calls are children
    /// of, and makes it current. It has the W3C format whatever the runtime's default: .NET
    /// Framework defaults to the hierarchical one, whose context goes out as <c>Request-Id</c>,
    /// not <c>traceparent</c>.
    /// </summary>
    static Activity StartApplicationActivity() =>
        new Activity("application").SetIdFormat(ActivityIdFormat.W3C).Start();

    static readonly IReadOnlyDictionary<string, JsonElement> None =
        new Dictionary<string, JsonElement>();

    static Dictionary<string, JsonElement> Body(string json) =>
        JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json)
        ?? throw new ArgumentException("Not a JSON object.", nameof(json));

    /// <summary>
    /// A Messages request without <c>max_tokens</c>: reading it from the parameters throws.
    /// </summary>
    const string NoMaxTokens = """{"model":"claude-test","messages":[]}""";

    /// <summary>
    /// The calls whose span starts with attributes read from the parameters, each with parameters
    /// that throw when one of them is read.
    /// </summary>
    public static TheoryData<string> CallsThatReadTheirParameters =>
        ["create", "create-streaming", "beta-create", "batches-create", "sessions-create"];

    static Task Call(AnthropicClient client, string call, CancellationToken cancellationToken) =>
        call switch
        {
            "create" => client.Messages.Create(
                MessageCreateParams.FromRawUnchecked(None, None, Body(NoMaxTokens)),
                cancellationToken
            ),
            "create-streaming" => ReadAll(
                client.Messages.CreateStreaming(
                    MessageCreateParams.FromRawUnchecked(None, None, Body(NoMaxTokens)),
                    cancellationToken
                )
            ),
            "beta-create" => client.Beta.Messages.Create(
                Beta.MessageCreateParams.FromRawUnchecked(None, None, Body(NoMaxTokens)),
                cancellationToken
            ),
            "batches-create" => client.Messages.Batches.Create(
                BatchCreateParams.FromRawUnchecked(None, None, Body("{}")),
                cancellationToken
            ),
            "sessions-create" => client.Beta.Sessions.Create(
                SessionCreateParams.FromRawUnchecked(None, None, Body("{}")),
                cancellationToken
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(call)),
        };

    static async Task ReadAll<T>(IAsyncEnumerable<T> stream)
    {
        await foreach (var _ in stream) { }
    }

    static ScriptedHandler Handler(string call) =>
        call == "create-streaming"
            ? new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody))
            : new ScriptedHandler().RespondJson(
                call switch
                {
                    "batches-create" => """{"id":"msgbatch_1"}""",
                    "sessions-create" => """{"id":"sesn_1"}""",
                    _ => Fixtures.MessageJson,
                }
            );

    /// <summary>
    /// The SDK's exceptions thrown, caught or not, by the code that runs within the scope, and by
    /// nothing that runs beside it: the scope flows with the test's execution context. A
    /// parameter that is read and is not there throws one.
    /// </summary>
    sealed class ThrownExceptions : IDisposable
    {
        static readonly AsyncLocal<ThrownExceptions?> Scope = new();

        public ConcurrentQueue<Exception> Thrown { get; } = new();

        public ThrownExceptions()
        {
            Scope.Value = this;
            AppDomain.CurrentDomain.FirstChanceException += OnThrown;
        }

        void OnThrown(object? sender, FirstChanceExceptionEventArgs e)
        {
            if (e.Exception is AnthropicException && ReferenceEquals(Scope.Value, this))
            {
                Thrown.Enqueue(e.Exception);
            }
        }

        public void Dispose()
        {
            AppDomain.CurrentDomain.FirstChanceException -= OnThrown;
            Scope.Value = null;
        }
    }

    [Theory]
    [MemberData(nameof(CallsThatReadTheirParameters))]
    public async Task WithoutAListener_ACallReadsNothingOfItsParametersForASpan(string call)
    {
        using var application = StartApplicationActivity();
        var handler = Handler(call);
        var client = Client(handler);

        using var thrown = new ThrownExceptions();
        await Call(client, call, TestContext.Current.CancellationToken);

        // A parameter read for an attribute throws, and the throw is caught: only a call that
        // read none threw nothing.
        Assert.Empty(thrown.Thrown.Select(e => e.GetType().Name + ": " + e.Message));
        Assert.Null(Assert.Single(handler.Requests).Header("traceparent"));
    }

    [Theory]
    [MemberData(nameof(CallsThatReadTheirParameters))]
    public async Task WithTracesOff_ACallReadsNothingOfItsParametersForASpan(string call)
    {
        using var application = StartApplicationActivity();
        var spans = Listen();
        var handler = Handler(call);
        var client = Client(handler, openTelemetry: false);

        using var thrown = new ThrownExceptions();
        await Call(client, call, TestContext.Current.CancellationToken);

        Assert.Empty(thrown.Thrown.Select(e => e.GetType().Name + ": " + e.Message));
        Assert.Empty(spans);
        Assert.Null(Assert.Single(handler.Requests).Header("traceparent"));
    }

    [Theory]
    [MemberData(nameof(CallsThatReadTheirParameters))]
    public async Task WithAListener_TheSameCallStillHasItsSpan(string call)
    {
        using var application = StartApplicationActivity();
        var spans = Listen();
        var handler = Handler(call);
        var client = Client(handler);

        await Call(client, call, TestContext.Current.CancellationToken);

        var span = Assert.Single(spans);
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal(application.SpanId, span.ParentSpanId);
        Assert.Contains(
            span.SpanId.ToHexString(),
            Assert.Single(handler.Requests).Header("traceparent")
        );
    }

    [Fact]
    public async Task AListenerThatThrowsAsTheSpanStops_DoesNotReplaceTheErrorOfTheCall()
    {
        var spans = Listen(_ => throw new InvalidOperationException("listener"));
        var handler = new ScriptedHandler()
            .Respond(HttpStatusCode.BadRequest, Fixtures.ErrorJson)
            .RespondJson("null");
        var client = Client(handler);

        // The call fails on the status of its response, and then as its body is read.
        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            client.Models.Retrieve("claude-test", null, TestContext.Current.CancellationToken)
        );
        await Assert.ThrowsAsync<AnthropicInvalidDataException>(() =>
            client.Models.Retrieve("claude-test", null, TestContext.Current.CancellationToken)
        );

        Assert.Equal(2, spans.Count);
    }

    [Fact]
    public async Task AListenerThatThrowsAsTheSpanStops_DoesNotFailACallThatSucceeds()
    {
        var spans = Listen(_ => throw new InvalidOperationException("listener"));
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondStream(Fixtures.Sse(Fixtures.StreamBody))
            .RespondJson(Fixtures.MessageJson);
        var client = Client(handler);
        var parameters = MessageCreateParams.FromRawUnchecked(
            None,
            None,
            Body("""{"model":"claude-test","max_tokens":8,"messages":[]}""")
        );
        var application = StartApplicationActivity();
        try
        {
            var message = await client.Messages.Create(
                parameters,
                TestContext.Current.CancellationToken
            );
            Assert.Equal("msg_1", message.ID);

            await ReadAll(
                client.Messages.CreateStreaming(parameters, TestContext.Current.CancellationToken)
            );

            // A response that the application disposes of unread still releases its connection.
            var response = await client.WithRawResponse.Messages.Create(
                parameters,
                TestContext.Current.CancellationToken
            );
            response.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException>(() =>
                response.RawMessage.Content.ReadAsStringAsync(
#if NET
                    TestContext.Current.CancellationToken
#endif
                )
            );
            Assert.Same(application, Activity.Current);
        }
        finally
        {
            application.Stop();
        }

        Assert.Equal(3, spans.Count);
    }

    [Fact]
    public void AListenerThatThrowsAsTheSpanStops_LeavesTheActivityBeforeTheSpanCurrent()
    {
        Listen(_ => throw new InvalidOperationException("listener"));
        var application = StartApplicationActivity();
        try
        {
            // Started and ended here, not in an async method, whose changes of the current
            // activity would not reach this one.
            var span = Tracing.StartSpan(true, "span", ActivityKind.Internal, source: _source);
            Assert.NotNull(span);
            Assert.Same(span, Activity.Current);

            Tracing.EndApiCallSpan(span);

            Assert.True(span.IsStopped);
            Assert.Same(application, Activity.Current);
        }
        finally
        {
            application.Stop();
        }
    }

    [Fact]
    public async Task AListenerThatThrowsAsTheSpanStarts_LeavesTheCallWithoutASpan()
    {
        ActivityListener listener = new()
        {
            ShouldListenTo = source => ReferenceEquals(source, _source),
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = _ => throw new InvalidOperationException("listener"),
        };
        ActivitySource.AddActivityListener(listener);
        _disposables.Add(listener);
        var handler = new ScriptedHandler().RespondJson("""{"id":"claude-test"}""");
        var client = Client(handler);
        var application = StartApplicationActivity();
        try
        {
            await client.Models.Retrieve(
                "claude-test",
                null,
                TestContext.Current.CancellationToken
            );
            // Started here, not in an async method, whose changes of the current activity would
            // not reach this one.
            Assert.Null(Tracing.StartSpan(true, "span", ActivityKind.Internal, source: _source));
            Assert.Same(application, Activity.Current);
        }
        finally
        {
            application.Stop();
        }

        Assert.Null(Assert.Single(handler.Requests).Header("traceparent"));
    }

    /// <summary>
    /// Throws for the spans of one source, and is the propagator it replaced for any other, so
    /// that the tests that run beside this one propagate as before.
    /// </summary>
    sealed class ThrowingPropagator(ActivitySource source, DistributedContextPropagator inner)
        : DistributedContextPropagator
    {
        public override IReadOnlyCollection<string> Fields => inner.Fields;

        public override void Inject(
            Activity? activity,
            object? carrier,
            PropagatorSetterCallback? setter
        )
        {
            if (ReferenceEquals(activity?.Source, source))
            {
                throw new InvalidOperationException("propagator");
            }
            inner.Inject(activity, carrier, setter);
        }

        public override void ExtractTraceIdAndState(
            object? carrier,
            PropagatorGetterCallback? getter,
            out string? traceId,
            out string? traceState
        ) => inner.ExtractTraceIdAndState(carrier, getter, out traceId, out traceState);

        public override IEnumerable<KeyValuePair<string, string?>>? ExtractBaggage(
            object? carrier,
            PropagatorGetterCallback? getter
        ) => inner.ExtractBaggage(carrier, getter);
    }

    [Fact]
    public async Task APropagatorThatThrows_DoesNotKeepTheRequestFromBeingSent()
    {
        using var application = StartApplicationActivity();
        var spans = Listen();
        var previous = DistributedContextPropagator.Current;
        DistributedContextPropagator.Current = new ThrowingPropagator(_source, previous);
        try
        {
            var handler = new ScriptedHandler().RespondJson("""{"id":"claude-test"}""");
            var client = Client(handler);

            var model = await client.Models.Retrieve(
                "claude-test",
                null,
                TestContext.Current.CancellationToken
            );

            Assert.Equal("claude-test", model.ID);
            Assert.Null(Assert.Single(handler.Requests).Header("traceparent"));
            Assert.Equal(ActivityStatusCode.Ok, Assert.Single(spans).Status);
        }
        finally
        {
            DistributedContextPropagator.Current = previous;
        }
    }
}
