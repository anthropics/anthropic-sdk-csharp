using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Messages;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

[Collection("EnvVarMutating")]
public sealed class TracingEnvironmentTest : IDisposable
{
    const string FormerContentModeVariable = "ANTHROPIC_OPEN_TELEMETRY_CONTENT_MODE";

    static readonly string[] Variables =
    [
        "ANTHROPIC_OPEN_TELEMETRY",
        "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
        "ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES",
        FormerContentModeVariable,
    ];

    readonly string?[] _values = Array.ConvertAll(Variables, Environment.GetEnvironmentVariable);

    public TracingEnvironmentTest()
    {
        foreach (var variable in Variables)
        {
            Environment.SetEnvironmentVariable(variable, null);
        }
    }

    public void Dispose()
    {
        for (var index = 0; index < Variables.Length; index++)
        {
            Environment.SetEnvironmentVariable(Variables[index], _values[index]);
        }
    }

    static MessageCreateParams Params =>
        new()
        {
            MaxTokens = 8,
            Messages = [new UserMessageParam { Content = "Hi" }],
            Model = "claude-test",
        };

    [Fact]
    public async Task EnvironmentVariable_DisablesSpans_UnlessTheOptionIsSet()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "FALSE");
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);

        await Fixtures
            .Client(handler)
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        Assert.Empty(trace.Spans);
        Assert.Null(handler.Requests.Last().Header("traceparent"));

        await Fixtures
            .Client(handler, new() { Traces = true })
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        trace.Single("anthropic.messages.create");
    }

    [Fact]
    public async Task EnvironmentVariable_SelectsTheContentMode_OnlyForContent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);

        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "Content"
        );
        await Fixtures
            .Client(handler)
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        // The option takes precedence over the variable.
        await Fixtures
            .Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.MetadataOnly } }
            )
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "everything"
        );
        await Fixtures
            .Client(handler)
            .Messages.Create(Params, TestContext.Current.CancellationToken);

        Assert.Equal(3, trace.Spans.Count);
        Assert.NotNull(trace.Spans[0].GetTagItem("gen_ai.input.messages"));
        Assert.Null(trace.Spans[1].GetTagItem("gen_ai.input.messages"));
        Assert.Null(trace.Spans[2].GetTagItem("gen_ai.input.messages"));
    }

    [Fact]
    public async Task FormerContentModeVariable_IsNotRead()
    {
        Environment.SetEnvironmentVariable(FormerContentModeVariable, "content");
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);

        await Fixtures
            .Client(handler)
            .Messages.Create(Params, TestContext.Current.CancellationToken);

        Assert.Null(trace.Single("anthropic.messages.create").GetTagItem("gen_ai.input.messages"));
    }

    [Theory]
    [InlineData("60", true)]
    [InlineData("0", null)]
    [InlineData("-60", null)]
    [InlineData("sixty", null)]
    [InlineData(null, null)]
    public async Task MaxContentBytesVariable_IsTheSizeBound_UnlessItIsInvalid(
        string? value,
        bool? expectedTruncated
    )
    {
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES",
            value
        );
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);

        await Fixtures
            .Client(handler)
            .Messages.Create(Params, TestContext.Current.CancellationToken);

        // The request's content is under 60 characters, and with the response's it is over.
        var span = trace.Single("anthropic.messages.create");
        Assert.NotNull(span.GetTagItem("gen_ai.output.messages"));
        Assert.Equal(expectedTruncated, span.GetTagItem("anthropic.content.truncated"));
    }

    static void SetEveryVariableAgainstItsDefault()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "false");
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES",
            "60"
        );
    }

    static OpenTelemetryOptions Option(string name) =>
        name switch
        {
            "false" => (OpenTelemetryOptions)false,
            "true" => (OpenTelemetryOptions)true,
            "empty" => new(),
            "empty traces" => new() { Traces = new() },
            "enabled" => new() { Traces = new() { Enabled = true } },
            "metadata only" => new()
            {
                Traces = new() { ContentMode = OpenTelemetryContentMode.MetadataOnly },
            },
            "max content bytes" => new() { Traces = new() { MaxContentBytes = 100_000 } },
            "content" => new()
            {
                Traces = new() { ContentMode = OpenTelemetryContentMode.Content },
            },
            _ => throw new ArgumentOutOfRangeException(nameof(name)),
        };

    [Theory]
    [InlineData("false", false, false, false)]
    [InlineData("true", false, true, false)]
    [InlineData("empty", false, true, false)]
    [InlineData("empty traces", false, true, false)]
    [InlineData("enabled", false, true, false)]
    [InlineData("metadata only", false, true, false)]
    [InlineData("max content bytes", false, true, false)]
    [InlineData("content", false, true, true)]
    [InlineData("true", true, true, false)]
    [InlineData("content", true, true, true)]
    public async Task ClientThatIsGivenAnyOption_ReadsNoneOfTheVariables(
        string option,
        bool throughWithOptions,
        bool expectedSpan,
        bool expectedContent
    )
    {
        SetEveryVariableAgainstItsDefault();
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        // Through WithOptions, the option is that of a client made from one that is given none.
        IAnthropicClient client = throughWithOptions
            ? Fixtures
                .Client(handler)
                .WithOptions(options => options with { OpenTelemetry = Option(option) })
            : Fixtures.Client(handler, Option(option));

        await client.Messages.Create(Params, TestContext.Current.CancellationToken);

        if (!expectedSpan)
        {
            Assert.Empty(trace.Spans);
            return;
        }
        // The request's content is under 60 characters, and with the response's it is over.
        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(expectedContent, span.GetTagItem("gen_ai.input.messages") != null);
        Assert.Equal(expectedContent, span.GetTagItem("gen_ai.output.messages") != null);
        Assert.Null(span.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task ClientThatIsGivenNoOption_ReadsAllThreeVariables()
    {
        SetEveryVariableAgainstItsDefault();
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);

        await Fixtures
            .Client(handler)
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        Assert.Empty(trace.Spans);

        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        await Fixtures
            .Client(handler)
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        var span = trace.Single("anthropic.messages.create");
        Assert.NotNull(span.GetTagItem("gen_ai.output.messages"));
        Assert.Equal(true, span.GetTagItem("anthropic.content.truncated"));
    }

    [Theory]
    [InlineData("null", false)]
    [InlineData("empty", true)]
    [InlineData("empty traces", true)]
    [InlineData("false", false)]
    public void TracesEnabled_ReadsTheVariable_OnlyWithoutOptions(string option, bool expected)
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "false");

        Assert.Equal(expected, Tracing.TracesEnabled(option == "null" ? null : Option(option)));
    }

    [Fact]
    public async Task Enabled_ThatIsFalse_EmitsNoSpans_WhateverTheOtherSettingsAndVariablesSay()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "true");
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);

        await Fixtures
            .Client(
                handler,
                new()
                {
                    Traces = new()
                    {
                        Enabled = false,
                        ContentMode = OpenTelemetryContentMode.Content,
                        MaxContentBytes = 60,
                    },
                }
            )
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        await Fixtures
            .Client(handler, new() { Traces = false })
            .Messages.Create(Params, TestContext.Current.CancellationToken);

        Assert.Empty(trace.Spans);
        Assert.Equal(2, handler.Requests.Count);
        Assert.All(handler.Requests, request => Assert.Null(request.Header("traceparent")));
    }

    [Fact]
    public async Task EnvironmentVariables_AreReadOnce_WhenTheClientIsMade()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);

        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "false");
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);
        await client.Messages.Create(Params, TestContext.Current.CancellationToken);
        // A copy keeps what its client read.
        await client
            .WithOptions(options => options with { MaxRetries = 0 })
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        using (
            var response = await client
                .WithRawResponse.WithOptions(options => options with { MaxRetries = 0 })
                .Messages.Create(Params, TestContext.Current.CancellationToken)
        )
        {
            await response.Deserialize(TestContext.Current.CancellationToken);
        }

        Assert.Equal(3, trace.Spans.Count);
        Assert.All(trace.Spans, span => Assert.NotNull(span.GetTagItem("gen_ai.input.messages")));

        // A client made now reads the environment as it is now.
        await Fixtures
            .Client(handler)
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        Assert.Equal(3, trace.Spans.Count);
        Assert.Equal(4, handler.Requests.Count);
    }

    [Fact]
    public async Task EnvironmentVariables_ThatChangeLater_DoNotTurnAClientsSpansOn()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "false");
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        var withTraces = Fixtures.Client(handler, new() { Traces = true });

        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        await client.Messages.Create(Params, TestContext.Current.CancellationToken);
        await client
            .WithOptions(options => options with { MaxRetries = 0 })
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        Assert.Empty(trace.Spans);

        // A client that is given an option takes none of the variables, then or later.
        await withTraces.Messages.Create(Params, TestContext.Current.CancellationToken);
        Assert.Null(trace.Single("anthropic.messages.create").GetTagItem("gen_ai.input.messages"));
    }

    static readonly string[] ContentAttributes =
    [
        "gen_ai.input.messages",
        "gen_ai.output.messages",
        "gen_ai.system_instructions",
        "url.query",
    ];

    static ScriptedHandler HandlerForEachKindOfCall() =>
        new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondStream(Fixtures.Sse(Fixtures.StreamBody))
            .RespondStream(Fixtures.Sse(Fixtures.StreamBody))
            .RespondJson("""{"input_tokens": 21}""")
            .RespondJson("{}");

    /// <summary>
    /// One call of each kind whose span can hold content: a message read whole, streamed, and
    /// streamed through the beta service, a token count, and a list whose query is content.
    /// </summary>
    static async Task CallEachKind(IAnthropicClient client)
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        var parameters = Params with { System = "Be brief." };
        await client.Messages.Create(parameters, cancellationToken);
        await foreach (var _ in client.Messages.CreateStreaming(parameters, cancellationToken)) { }
        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                new()
                {
                    MaxTokens = 8,
                    Messages = [new Beta.BetaUserMessageParam { Content = "Hi" }],
                    Model = "claude-test",
                    System = "Be brief.",
                },
                cancellationToken
            )
        ) { }
        await client.Messages.CountTokens(
            new()
            {
                Messages = [new UserMessageParam { Content = "Hi" }],
                Model = "claude-test",
                System = "Be brief.",
            },
            cancellationToken
        );
        await client.Beta.Organization.Users.List(
            new() { Email = "a@b.test", Limit = 5 },
            cancellationToken
        );
    }

    [Theory]
    [InlineData("true")]
    [InlineData("empty")]
    [InlineData("traces")]
    public async Task ContentModeVariable_SetAfterAClientWasMade_PutsNoContentOnTheSpansOfAClientMadeFromIt(
        string layer
    )
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);
        using var trace = new RecordedTrace();
        var client = Fixtures.Client(HandlerForEachKindOfCall());

        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        OpenTelemetryOptions openTelemetry = layer switch
        {
            "true" => (OpenTelemetryOptions)true,
            "empty" => new(),
            "traces" => new() { Traces = new() { Enabled = true } },
            _ => throw new ArgumentOutOfRangeException(nameof(layer)),
        };
        await CallEachKind(
            client.WithOptions(options => options with { OpenTelemetry = openTelemetry })
        );

        Assert.Equal(5, trace.Spans.Count);
        Assert.All(
            trace.Spans,
            span =>
                Assert.All(ContentAttributes, attribute => Assert.Null(span.GetTagItem(attribute)))
        );
    }

    [Fact]
    public async Task ContentMode_ThatAClientMadeFromAnotherSets_TakesPrecedenceOverWhatThatClientRead()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);
        using var trace = new RecordedTrace();
        var client = Fixtures.Client(HandlerForEachKindOfCall());

        await CallEachKind(
            client.WithOptions(options =>
                options with
                {
                    OpenTelemetry = new()
                    {
                        Traces = new() { ContentMode = OpenTelemetryContentMode.Content },
                    },
                }
            )
        );

        Assert.Equal(5, trace.Spans.Count);
        Assert.All(
            trace.Spans.Take(3),
            span =>
            {
                Assert.NotNull(span.GetTagItem("gen_ai.input.messages"));
                Assert.NotNull(span.GetTagItem("gen_ai.output.messages"));
                Assert.NotNull(span.GetTagItem("gen_ai.system_instructions"));
            }
        );
        Assert.Contains(
            "email=",
            Assert.IsType<string>(trace.Spans[4].GetTagItem("url.query")),
            StringComparison.Ordinal
        );
    }

    static readonly string[] ToolRunContentAttributes =
    [
        .. ContentAttributes,
        "gen_ai.tool.call.arguments",
        "anthropic.tool_result.content",
    ];

    /// <summary>
    /// A tool run of <paramref name="client"/> in which the model uses the tool once: its spans
    /// are the run's, those of its two Messages calls, and the tool's.
    /// </summary>
    static async Task RunATool(IAnthropicClient client)
    {
        var runner = client.Beta.Messages.ToolRunner(
            new()
            {
                MaxTokens = 8,
                Messages = [new Beta.BetaUserMessageParam { Content = "Weather?" }],
                Model = "claude-test",
                System = "Be brief.",
            },
            [
                new BetaRunnableTool
                {
                    Name = "get_weather",
                    Definition = new Beta.BetaTool { Name = "get_weather", InputSchema = new() },
                    Run = (_, _) => Task.FromResult<Beta.BetaToolResultBlockParamContent>("rainy"),
                },
            ]
        );
        await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken)) { }
    }

    static ScriptedHandler HandlerForAToolRun() =>
        new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson.Replace("end_turn", "tool_use"))
            .RespondJson(Fixtures.MessageJson.Replace("tool_use\"", "text\", \"text\": \"done\""));

    [Fact]
    public async Task ContentModeVariable_SetAfterAClientWasMade_PutsNoContentOnTheSpansOfAToolRunOfAClientMadeFromIt()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);
        using var trace = new RecordedTrace();
        var client = Fixtures.Client(HandlerForAToolRun());

        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        await RunATool(client.WithOptions(options => options with { OpenTelemetry = true }));

        Assert.Equal(4, trace.Spans.Count);
        trace.Single("anthropic.messages.tool_runner");
        trace.Single("anthropic.custom_tool_use get_weather");
        Assert.All(
            trace.Spans,
            span =>
                Assert.All(
                    ToolRunContentAttributes,
                    attribute => Assert.Null(span.GetTagItem(attribute))
                )
        );
    }

    [Fact]
    public async Task ContentMode_ThatAClientMadeFromAnotherSets_IsThatOfItsToolRuns()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);
        using var trace = new RecordedTrace();
        var client = Fixtures.Client(HandlerForAToolRun());

        await RunATool(
            client.WithOptions(options =>
                options with
                {
                    OpenTelemetry = new()
                    {
                        Traces = new() { ContentMode = OpenTelemetryContentMode.Content },
                    },
                }
            )
        );

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal("""{"city":"Paris"}""", tool.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.NotNull(tool.GetTagItem("anthropic.tool_result.content"));
    }

    [Theory]
    [InlineData("Bedrock")]
    [InlineData("BedrockMantle")]
    [InlineData("Vertex")]
    [InlineData("Foundry")]
    [InlineData("Aws")]
    [InlineData("GoogleCloud")]
    public async Task PlatformClient_ReadsTheEnvironmentVariablesOnce_WhenItIsMade(string name)
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);
        var client = HttpAttributesTest.PlatformClient(name);

        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "false");
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);
        await client
            .WithOptions(options =>
                options with
                {
                    HttpClient = new HttpClient(handler),
                    MaxRetries = 0,
                }
            )
            .Messages.Create(Params, TestContext.Current.CancellationToken);

        Assert.NotNull(
            trace.Single("anthropic.messages.create").GetTagItem("gen_ai.input.messages")
        );

        await HttpAttributesTest
            .PlatformClient(name)
            .WithOptions(options =>
                options with
                {
                    HttpClient = new HttpClient(handler),
                    MaxRetries = 0,
                }
            )
            .Messages.Create(Params, TestContext.Current.CancellationToken);
        Assert.Single(trace.Spans);
        Assert.Equal(2, handler.Requests.Count);
    }

    [Fact]
    public async Task ToolRunner_FollowsWhatItsClientReadOfTheEnvironmentVariables()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", null);
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson.Replace("end_turn", "tool_use"))
            .RespondJson(Fixtures.MessageJson.Replace("tool_use\"", "text\", \"text\": \"done\""));
        var client = Fixtures.Client(handler);

        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "false");
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);
        var runner = client.Beta.Messages.ToolRunner(
            new()
            {
                MaxTokens = 8,
                Messages = [new Beta.BetaUserMessageParam { Content = "Weather?" }],
                Model = "claude-test",
            },
            [
                new BetaRunnableTool
                {
                    Name = "get_weather",
                    Definition = new Beta.BetaTool { Name = "get_weather", InputSchema = new() },
                    Run = (_, _) => Task.FromResult<Beta.BetaToolResultBlockParamContent>("rainy"),
                },
            ]
        );
        await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken)) { }

        trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(
            """{"city":"Paris"}""",
            trace
                .Single("anthropic.custom_tool_use get_weather")
                .GetTagItem("gen_ai.tool.call.arguments")
        );
    }
}
