using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Messages;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

/// <summary>
/// The OpenTelemetry options that <c>WithOptions</c> sets take the place of those of the client
/// it was called on, as a whole: the two are not merged.
/// </summary>
[Collection("EnvVarMutating")]
public sealed class OptionReplacementTest : IDisposable
{
    static readonly string[] Variables =
    [
        "ANTHROPIC_OPEN_TELEMETRY",
        "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
        "ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES",
    ];

    readonly string?[] _values = Array.ConvertAll(Variables, Environment.GetEnvironmentVariable);

    public OptionReplacementTest()
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

    static readonly OpenTelemetryOptions TracesWithContent = new()
    {
        Traces = new() { Enabled = true, ContentMode = OpenTelemetryContentMode.Content },
    };

    static readonly OpenTelemetryOptions ContentOnly = new()
    {
        Traces = new() { ContentMode = OpenTelemetryContentMode.Content },
    };

    static MessageCreateParams Params =>
        new()
        {
            MaxTokens = 8,
            Messages = [new() { Role = Role.User, Content = "Hi" }],
            Model = "claude-test",
        };

    static ScriptedHandler Handler(int responses)
    {
        var handler = new ScriptedHandler();
        for (var index = 0; index < responses; index++)
        {
            handler.RespondJson(Fixtures.MessageJson);
        }
        return handler;
    }

    static Task<Message> Create(IAnthropicClient client) =>
        client.Messages.Create(Params, TestContext.Current.CancellationToken);

    static bool HasContent(Activity span) => span.GetTagItem("gen_ai.input.messages") != null;

    static OpenTelemetryOptions? Replacement(string name) =>
        name switch
        {
            "true" => true,
            "enabled" => new() { Traces = new() { Enabled = true } },
            "empty" => new(),
            "empty traces" => new() { Traces = new() },
            "null" => null,
            _ => throw new ArgumentOutOfRangeException(nameof(name)),
        };

    [Theory]
    [InlineData("true")]
    [InlineData("enabled")]
    [InlineData("empty")]
    [InlineData("empty traces")]
    [InlineData("null")]
    public async Task ContentMode_ThatTheNewOptionsLeaveUnset_IsNotThatOfTheClientTheyReplaceThoseOf(
        string replacement
    )
    {
        using var trace = new RecordedTrace();
        var client = Fixtures.Client(Handler(1), TracesWithContent);

        await Create(
            client.WithOptions(options => options with { OpenTelemetry = Replacement(replacement) })
        );

        Assert.False(HasContent(trace.Single("anthropic.messages.create")));
    }

    [Fact]
    public async Task Enabled_ThatTheNewOptionsLeaveUnset_IsOn_WhateverTheClientAndTheVariableSaid()
    {
        using var trace = new RecordedTrace();
        var handler = Handler(2);

        // The client had its spans off, and the new options do not say: they are on, the default.
        await Create(
            Fixtures
                .Client(handler, openTelemetry: false)
                .WithOptions(options => options with { OpenTelemetry = ContentOnly })
        );
        Assert.True(HasContent(trace.Single("anthropic.messages.create")));

        // The variable says off, and options that are set take nothing from it.
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "false");
        var on = Fixtures.Client(handler, openTelemetry: true);
        await Create(on.WithOptions(options => options with { OpenTelemetry = ContentOnly }));
        Assert.Equal(2, trace.Spans.Count);
        Assert.All(trace.Spans, span => Assert.True(HasContent(span)));
    }

    [Fact]
    public async Task EverySetting_IsThatOfTheNewOptions()
    {
        using var trace = new RecordedTrace();
        var handler = Handler(3);

        await Create(
            Fixtures
                .Client(
                    handler,
                    new()
                    {
                        Traces = new()
                        {
                            Enabled = false,
                            ContentMode = OpenTelemetryContentMode.Content,
                        },
                    }
                )
                .WithOptions(options => options with { OpenTelemetry = true })
        );
        await Create(
            Fixtures
                .Client(handler, TracesWithContent)
                .WithOptions(options =>
                    options with
                    {
                        OpenTelemetry = new()
                        {
                            Traces = new() { ContentMode = OpenTelemetryContentMode.MetadataOnly },
                        },
                    }
                )
        );
        await Create(
            Fixtures
                .Client(handler, openTelemetry: true)
                .WithOptions(options => options with { OpenTelemetry = TracesWithContent })
        );

        Assert.Equal(3, trace.Spans.Count);
        Assert.False(HasContent(trace.Spans[0]));
        Assert.False(HasContent(trace.Spans[1]));
        Assert.True(HasContent(trace.Spans[2]));
    }

    [Fact]
    public async Task MaxContentBytes_ThatTheNewOptionsLeaveUnset_IsNotThatOfTheClientTheyReplaceThoseOf()
    {
        using var trace = new RecordedTrace();
        var client = Fixtures.Client(
            Handler(2),
            new()
            {
                Traces = new()
                {
                    ContentMode = OpenTelemetryContentMode.Content,
                    MaxContentBytes = 60,
                },
            }
        );

        await Create(client);
        await Create(client.WithOptions(options => options with { OpenTelemetry = ContentOnly }));

        Assert.Equal(2, trace.Spans.Count);
        Assert.Equal(true, trace.Spans[0].GetTagItem("anthropic.content.truncated"));
        Assert.Null(trace.Spans[1].GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task OnlyTheLastOptionsThatWereSet_Count_AcrossClientsMadeFromOneAnother()
    {
        using var trace = new RecordedTrace();
        var client = Fixtures
            .Client(Handler(1), openTelemetry: false)
            .WithOptions(options =>
                options with
                {
                    OpenTelemetry = ContentOnly,
                    OpenTelemetryRequest = new() { ConversationId = "conv_1" },
                }
            )
            .WithOptions(options => options with { MaxRetries = 0 })
            .WithOptions(options => options with { OpenTelemetry = true });

        await Create(client);

        // What `WithOptions` does not set is copied, as every other option is.
        var span = trace.Single("anthropic.messages.create");
        Assert.False(HasContent(span));
        Assert.Equal("conv_1", span.GetTagItem("gen_ai.conversation.id"));
    }

    [Fact]
    public async Task OptionsThatWithOptionsDoesNotSet_AreThoseOfTheClientItWasCalledOn()
    {
        using var trace = new RecordedTrace();
        var client = Fixtures
            .Client(Handler(1), TracesWithContent)
            .WithOptions(options => options with { MaxRetries = 0 });

        await Create(client);

        Assert.True(HasContent(trace.Single("anthropic.messages.create")));
    }

    [Theory]
    [InlineData(false, null, null)]
    [InlineData(true, null, null)]
    [InlineData(true, "conv_2", "conv_2")]
    [InlineData(true, "", null)]
    public async Task ConversationId_IsThatOfTheNewRequestOptions(
        bool hasRequestOptions,
        string? conversationId,
        string? expected
    )
    {
        using var trace = new RecordedTrace();
        var client = Fixtures
            .Client(Handler(1))
            .WithOptions(options =>
                options with
                {
                    OpenTelemetryRequest = new() { ConversationId = "conv_1" },
                }
            );

        await Create(
            client.WithOptions(options =>
                options with
                {
                    OpenTelemetryRequest = hasRequestOptions
                        ? new() { ConversationId = conversationId }
                        : null,
                }
            )
        );

        Assert.Equal(
            expected,
            trace.Single("anthropic.messages.create").GetTagItem("gen_ai.conversation.id")
        );
    }

    [Fact]
    public async Task OptionsSetOnAServiceOrOnTheClientThatGivesRawResponses_ReplaceTheSame()
    {
        using var trace = new RecordedTrace();
        var client = Fixtures.Client(Handler(2), TracesWithContent);

        await client
            .Messages.WithOptions(options => options with { OpenTelemetry = new() })
            .Create(Params, TestContext.Current.CancellationToken);
        using (
            var response = await client
                .WithRawResponse.WithOptions(options => options with { OpenTelemetry = true })
                .Messages.Create(Params, TestContext.Current.CancellationToken)
        )
        {
            await response.Deserialize(TestContext.Current.CancellationToken);
        }

        Assert.Equal(2, trace.Spans.Count);
        Assert.All(trace.Spans, span => Assert.False(HasContent(span)));
    }

    [Fact]
    public async Task NewOptions_TakeNothingFromTheEnvironment_ButOptionsMadeAnewReadItAgain()
    {
        Environment.SetEnvironmentVariable(
            "ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE",
            "content"
        );
        using var trace = new RecordedTrace();
        var handler = Handler(2);
        var client = Fixtures.Client(handler);
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY", "false");
        Environment.SetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE", null);

        await Create(
            client.WithOptions(options => options with { OpenTelemetry = new() { Traces = new() } })
        );
        // Neither what the client read when it was made, nor what the variables say now.
        Assert.False(HasContent(trace.Single("anthropic.messages.create")));

        await Create(
            client.WithOptions(options => new ClientOptions
            {
                HttpClient = options.HttpClient,
                BaseUrl = options.BaseUrl,
                ApiKey = options.ApiKey,
            })
        );
        Assert.Single(trace.Spans);
        Assert.Equal(2, handler.Requests.Count);
    }

    [Fact]
    public void OpenTelemetry_OfAClientThatWithOptionsMade_IsWhatItsOwnOptionsSet()
    {
        var client = Fixtures.Client(Handler(0), openTelemetry: false);

        var kept = client.WithOptions(options => options with { MaxRetries = 0 });
        var replaced = client.WithOptions(options => options with { OpenTelemetry = ContentOnly });

        Assert.Equal(client.OpenTelemetry, kept.OpenTelemetry);
        Assert.Same(ContentOnly, replaced.OpenTelemetry);
    }

    [Theory]
    [InlineData("Bedrock")]
    [InlineData("BedrockMantle")]
    [InlineData("Vertex")]
    [InlineData("Foundry")]
    [InlineData("Aws")]
    [InlineData("GoogleCloud")]
    public async Task PlatformClient_ReplacesItsOwnOptions(string name)
    {
        using var trace = new RecordedTrace();
        var handler = Handler(2);
        var client = HttpAttributesTest
            .PlatformClient(name)
            .WithOptions(options =>
                options with
                {
                    HttpClient = new HttpClient(handler),
                    MaxRetries = 0,
                    OpenTelemetry = TracesWithContent,
                    OpenTelemetryRequest = new() { ConversationId = "conv_1" },
                }
            );

        await Create(client.WithOptions(options => options with { OpenTelemetry = true }));
        var span = trace.Single("anthropic.messages.create");
        Assert.False(HasContent(span));
        Assert.Equal("conv_1", span.GetTagItem("gen_ai.conversation.id"));

        await Create(client.WithOptions(options => options with { OpenTelemetry = false }));
        Assert.Single(trace.Spans);
        Assert.Equal(2, handler.Requests.Count);
    }

    [Fact]
    public async Task ToolRunner_FollowsTheNewOptionsOfItsClient()
    {
        using var trace = new RecordedTrace();

        static ScriptedHandler ToolUseThenText() =>
            new ScriptedHandler()
                .RespondJson(Fixtures.MessageJson.Replace("end_turn", "tool_use"))
                .RespondJson(
                    Fixtures.MessageJson.Replace("tool_use\"", "text\", \"text\": \"done\"")
                );

        static async Task Run(IAnthropicClient client)
        {
            var runner = client.Beta.Messages.ToolRunner(
                new()
                {
                    MaxTokens = 8,
                    Messages = [new() { Role = Beta.Role.User, Content = "Weather?" }],
                    Model = "claude-test",
                },
                [
                    new BetaRunnableTool
                    {
                        Name = "get_weather",
                        Definition = new Beta.BetaTool
                        {
                            Name = "get_weather",
                            InputSchema = new(),
                        },
                        Run = (_, _) =>
                            Task.FromResult<Beta.BetaToolResultBlockParamContent>("rainy"),
                    },
                ]
            );
            await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken))
            { }
        }

        await Run(
            Fixtures
                .Client(ToolUseThenText(), TracesWithContent)
                .WithOptions(options => options with { OpenTelemetry = false })
        );
        Assert.Empty(trace.Spans);

        await Run(
            Fixtures
                .Client(ToolUseThenText(), TracesWithContent)
                .WithOptions(options =>
                    options with
                    {
                        OpenTelemetryRequest = new() { ConversationId = "conv_1" },
                    }
                )
                .WithOptions(options =>
                    options with
                    {
                        OpenTelemetry = true,
                        OpenTelemetryRequest = new(),
                    }
                )
        );
        Assert.Null(
            trace.Single("anthropic.messages.tool_runner").GetTagItem("gen_ai.conversation.id")
        );
        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Null(tool.GetTagItem("gen_ai.conversation.id"));
        Assert.Null(tool.GetTagItem("gen_ai.tool.call.arguments"));
    }
}
