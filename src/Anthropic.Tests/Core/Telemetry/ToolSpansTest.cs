using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Exceptions;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Messages;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

public class ToolSpansTest : TracingTestBase
{
    [Fact]
    public async Task ToolRunner_EmitsToolRunnerAndToolSpans()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(
                Fixtures.MessageJson.Replace(
                    "tool_use\", \"id\"",
                    "text\", \"text\": \"done\", \"id\""
                )
            );
        var client = Fixtures
            .Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            )
            .WithOptions(options =>
                options with
                {
                    OpenTelemetryRequest = new() { ConversationId = "conv_7" },
                }
            );
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [WeatherTool(_ => "rainy", "Gets the weather of a city.")]
        );

        var messages = new List<Beta.BetaMessage>();
        await foreach (
            var message in runner.WithCancellation(TestContext.Current.CancellationToken)
        )
        {
            messages.Add(message);
        }

        Assert.Equal(2, messages.Count);
        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityKind.Internal, toolRunnerSpan.Kind);
        Assert.Equal(ActivityStatusCode.Ok, toolRunnerSpan.Status);
        Assert.Equal(trace.Root.SpanId, toolRunnerSpan.ParentSpanId);
        Assert.Equal("invoke_agent", toolRunnerSpan.GetTagItem("gen_ai.operation.name"));
        Assert.Equal("claude-test", toolRunnerSpan.GetTagItem("gen_ai.request.model"));
        Assert.Null(toolRunnerSpan.GetTagItem("gen_ai.output.type"));
        Assert.Equal("conv_7", toolRunnerSpan.GetTagItem("gen_ai.conversation.id"));
        Assert.Equal("anthropic", toolRunnerSpan.GetTagItem("gen_ai.provider.name"));
        // The stop reason is that of a request, so only the spans of the requests have one.
        Assert.Null(toolRunnerSpan.GetTagItem("anthropic.message.stop_reason"));
        Assert.Null(toolRunnerSpan.GetTagItem("gen_ai.response.finish_reasons"));

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(ActivityKind.Internal, tool.Kind);
        Assert.Equal(toolRunnerSpan.SpanId, tool.ParentSpanId);
        Assert.Equal(ActivityStatusCode.Ok, tool.Status);
        Assert.Equal("execute_tool", tool.GetTagItem("gen_ai.operation.name"));
        Assert.Equal("get_weather", tool.GetTagItem("gen_ai.tool.name"));
        Assert.Equal("Gets the weather of a city.", tool.GetTagItem("gen_ai.tool.description"));
        Assert.Equal("toolu_w", tool.GetTagItem("gen_ai.tool.call.id"));
        Assert.Equal("conv_7", tool.GetTagItem("gen_ai.conversation.id"));
        // The SDK has no Sessions tool runner, and a Messages tool call is in no Session.
        Assert.Null(tool.GetTagItem("anthropic.session.id"));
        Assert.Null(tool.GetTagItem("anthropic.session.thread.id"));
        Assert.Equal("function", tool.GetTagItem("gen_ai.tool.type"));
        Assert.Null(tool.GetTagItem("anthropic.toolset.name"));
        AssertJson("""{"city":"Oslo"}""", tool.GetTagItem("gen_ai.tool.call.arguments"));
        // A result whose content is a string is one text block.
        AssertJson(
            """[{"type":"text","text":"rainy"}]""",
            tool.GetTagItem("anthropic.tool_result.content")
        );
        Assert.Null(tool.GetTagItem("gen_ai.tool.call.result"));
        Assert.Null(tool.GetTagItem("anthropic.content.truncated"));

        var calls = trace.Spans.Where(s => s.OperationName == "anthropic.messages.create").ToList();
        Assert.Equal(2, calls.Count);
        Assert.All(calls, call => Assert.Equal(toolRunnerSpan.SpanId, call.ParentSpanId));
        Assert.All(
            calls,
            call => Assert.Equal("conv_7", call.GetTagItem("gen_ai.conversation.id"))
        );
        Assert.Equal(
            ["tool_use", "end_turn"],
            calls.Select(call => call.GetTagItem("anthropic.message.stop_reason"))
        );
        // The requests were sent while the tool runner span was current.
        Assert.All(
            handler.Requests,
            r => Assert.Contains(toolRunnerSpan.TraceId.ToHexString(), r.Header("traceparent"))
        );
    }

    [Fact]
    public async Task ToolRunner_ToolUseOfAToolset_HasTheToolsetNameWithoutContentMode()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(
                ToolUseMessage.Replace("\"name\":", "\"toolset_name\": \"computer\", \"name\":")
            )
            .RespondJson(Fixtures.MessageJson.Replace("tool_use\"", "text\", \"text\": \"done\""));
        var runner = Fixtures
            .Client(handler)
            .Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "rainy")]);

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal("computer", tool.GetTagItem("anthropic.toolset.name"));
        Assert.Null(tool.GetTagItem("gen_ai.tool.call.arguments"));
    }

    [Fact]
    public async Task ToolRunner_ToolUseWithoutAnInput_RunsTheToolAndTheSpanHasNoArguments()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage.Replace(", \"input\": {\"city\": \"Oslo\"}", ""))
            .RespondJson(Fixtures.MessageJson.Replace("tool_use\"", "text\", \"text\": \"done\""));
        var ran = 0;
        var runner = Fixtures
            .Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            )
            .Beta.Messages.ToolRunner(
                BetaParams(),
                [
                    WeatherTool(_ =>
                    {
                        ran++;
                        return "rainy";
                    }),
                ]
            );

        // Telemetry does not fail the loop over a block that it cannot read.
        await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken)) { }

        Assert.Equal(1, ran);
        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(ActivityStatusCode.Ok, tool.Status);
        Assert.Equal("toolu_w", tool.GetTagItem("gen_ai.tool.call.id"));
        Assert.Null(tool.GetTagItem("gen_ai.tool.call.arguments"));
        AssertJson(
            """[{"type":"text","text":"rainy"}]""",
            tool.GetTagItem("anthropic.tool_result.content")
        );
        Assert.Equal(ActivityStatusCode.Ok, trace.Single("anthropic.messages.tool_runner").Status);
    }

    /// <summary>
    /// The attributes of an HTTP request, which only the span of an API call has.
    /// </summary>
    static readonly string[] HttpAttributes =
    [
        "http.request.method",
        "http.route",
        "http.request.resend_count",
        "http.response.status_code",
        "url.scheme",
        "url.path",
        "url.query",
        "url.full",
    ];

    [Fact]
    public async Task ToolRunner_OnlyTheSpansOfItsRequestsHaveTheHttpAttributes()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .Respond(HttpStatusCode.InternalServerError, Fixtures.ErrorJson)
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson.Replace("tool_use\"", "text\", \"text\": \"done\""));
        var runner = Fixtures
            .Client(handler)
            .Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "rainy")]);

        await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken)) { }

        var helpers = trace.Spans.Where(span => span.Kind == ActivityKind.Internal).ToList();
        Assert.Equal(
            ["anthropic.custom_tool_use get_weather", "anthropic.messages.tool_runner"],
            helpers.Select(span => span.OperationName)
        );
        Assert.All(
            helpers,
            span =>
                Assert.DoesNotContain(
                    span.TagObjects,
                    tag => HttpAttributes.Contains(tag.Key, StringComparer.Ordinal)
                )
        );
        var calls = trace.Spans.Where(span => span.Kind == ActivityKind.Client).ToList();
        Assert.Equal(2, calls.Count);
        Assert.All(
            calls,
            call =>
            {
                Assert.Equal("POST", call.GetTagItem("http.request.method"));
                Assert.Equal("/v1/messages", call.GetTagItem("http.route"));
                Assert.Equal("https://api.example.test/v1/messages", call.GetTagItem("url.full"));
            }
        );
        // The first request of the first call was sent again.
        Assert.Equal([1, null], calls.Select(call => call.GetTagItem("http.request.resend_count")));
    }

    [Fact]
    public async Task ToolRunner_OfAPlatformClient_HasTheScopeOfTheClientsPackage()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson.Replace("tool_use\"", "text\", \"text\": \"done\""));
        var client = new Anthropic.Foundry.AnthropicFoundryClient(
            new Anthropic.Foundry.AnthropicFoundryApiKeyCredentials("key", "resource")
        ).WithOptions(options => options with { HttpClient = new(handler) });
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "rainy")]);

        await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken)) { }

        Assert.Equal(4, trace.Spans.Count);
        Assert.All(
            trace.Spans,
            span => Assert.Equal("com.anthropic.sdk.csharp.foundry", span.Source.Name)
        );
    }

    [Fact]
    public async Task ToolRunner_Spans_StartWithTheAttributesThatASamplerDecidesOn()
    {
        using var trace = new RecordedTrace();
        // What a sampler sees of each span.
        var atStart = new Dictionary<string, Dictionary<string, object?>>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "com.anthropic.sdk.csharp",
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
            {
                if (options.Parent.TraceId == trace.Root.TraceId)
                {
                    lock (atStart)
                    {
                        atStart[options.Name] = (options.Tags ?? []).ToDictionary(
                            tag => tag.Key,
                            tag => tag.Value
                        );
                    }
                }
                return ActivitySamplingResult.AllDataAndRecorded;
            },
        };
        ActivitySource.AddActivityListener(listener);
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(
                Fixtures.MessageJson.Replace(
                    "tool_use\", \"id\"",
                    "text\", \"text\": \"done\", \"id\""
                )
            );
        var client = Fixtures
            .Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            )
            .WithOptions(options =>
                options with
                {
                    OpenTelemetryRequest = new() { ConversationId = "conv_7" },
                }
            );
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [WeatherTool(_ => "rainy", "Gets the weather of a city.")]
        );

        await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken)) { }

        var toolRunner = atStart["anthropic.messages.tool_runner"];
        Assert.Equal("invoke_agent", toolRunner["gen_ai.operation.name"]);
        Assert.Equal("anthropic", toolRunner["gen_ai.provider.name"]);
        Assert.Equal("conv_7", toolRunner["gen_ai.conversation.id"]);
        Assert.Equal("claude-test", toolRunner["gen_ai.request.model"]);
        var tool = atStart["anthropic.custom_tool_use get_weather"];
        Assert.Equal("execute_tool", tool["gen_ai.operation.name"]);
        Assert.Equal("anthropic", tool["gen_ai.provider.name"]);
        Assert.Equal("conv_7", tool["gen_ai.conversation.id"]);
        Assert.Equal("get_weather", tool["gen_ai.tool.name"]);
        Assert.Equal("Gets the weather of a city.", tool["gen_ai.tool.description"]);
        Assert.Equal("toolu_w", tool["gen_ai.tool.call.id"]);
        Assert.Equal("function", tool["gen_ai.tool.type"]);
        // The spans of a tool runner are of no request, so they have no server.
        Assert.DoesNotContain("server.address", toolRunner.Keys);
        Assert.DoesNotContain("server.port", toolRunner.Keys);
        Assert.DoesNotContain("server.address", tool.Keys);
        Assert.DoesNotContain("server.port", tool.Keys);
        // Only the content and the outcome of a tool runner's own spans are set after the start.
        Assert.Equal(
            toolRunner.Keys.OrderBy(key => key, StringComparer.Ordinal),
            trace
                .Single("anthropic.messages.tool_runner")
                .TagObjects.Select(tag => tag.Key)
                .OrderBy(key => key, StringComparer.Ordinal)
        );
        Assert.Equal(
            tool.Keys.Concat(["gen_ai.tool.call.arguments", "anthropic.tool_result.content"])
                .OrderBy(key => key, StringComparer.Ordinal),
            trace
                .Single("anthropic.custom_tool_use get_weather")
                .TagObjects.Select(tag => tag.Key)
                .OrderBy(key => key, StringComparer.Ordinal)
        );
    }

    [Fact]
    public async Task ToolRunner_ToolError_FailsTheToolSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [WeatherTool(_ => throw new InvalidOperationException("no weather"))]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(ActivityStatusCode.Error, tool.Status);
        Assert.Equal("tool_error", tool.GetTagItem("error.type"));
        Assert.Null(tool.GetTagItem("gen_ai.tool.call.arguments"));
        // The tool's definition has no description.
        Assert.Null(tool.GetTagItem("gen_ai.tool.description"));
        // The application set no conversation ID on the runner.
        Assert.Null(tool.GetTagItem("gen_ai.conversation.id"));
        Assert.Null(
            trace.Single("anthropic.messages.tool_runner").GetTagItem("gen_ai.conversation.id")
        );
        Assert.Equal(ActivityStatusCode.Ok, trace.Single("anthropic.messages.tool_runner").Status);
    }

    [Fact]
    public async Task ToolRunner_ToolError_InContentMode_RecordsTheErrorResultsContent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [WeatherTool(_ => throw new InvalidOperationException("no weather"))]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal("tool_error", tool.GetTagItem("error.type"));
        // The error result is recorded as any other: the content blocks of its content. That it
        // is an error is the span's status.
        var content = JsonDocument
            .Parse(Assert.IsType<string>(tool.GetTagItem("anthropic.tool_result.content")))
            .RootElement;
        var block = Assert.Single(content.EnumerateArray());
        Assert.Equal("text", block.GetProperty("type").GetString());
        Assert.Contains("no weather", block.GetProperty("text").GetString());
        Assert.Null(tool.GetTagItem("gen_ai.tool.call.result"));
        Assert.Null(tool.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task ToolRunner_ResultWithAListOfBlocks_RecordsTextAndSearchResultBlocksWhole()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var weather = WeatherTool(_ => "rainy");
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [
                new BetaRunnableTool
                {
                    Name = weather.Name,
                    Definition = weather.Definition,
                    Run = (_, _) =>
                        Task.FromResult<Beta.BetaToolResultBlockParamContent>(
                            new List<Beta.Block>
                            {
                                new Beta.BetaTextBlockParam
                                {
                                    Text = "rainy",
                                    CacheControl = new(),
                                },
                                new Beta.BetaSearchResultBlockParam
                                {
                                    Source = "https://example.com",
                                    Title = "Weather",
                                    Content = [new() { Text = "Rainy all day" }],
                                },
                                new Beta.BetaImageBlockParam
                                {
                                    Source = new Beta.BetaBase64ImageSource
                                    {
                                        Data = "U3RhaW5sZXNzIHJvY2tz",
                                        MediaType = Beta.MediaType.ImageJpeg,
                                    },
                                },
                            }
                        ),
                },
            ]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        var content = JsonDocument
            .Parse(Assert.IsType<string>(tool.GetTagItem("anthropic.tool_result.content")))
            .RootElement;
        Assert.Equal(3, content.GetArrayLength());
        Assert.Equal("text", content[0].GetProperty("type").GetString());
        Assert.Equal("rainy", content[0].GetProperty("text").GetString());
        Assert.Equal(
            "ephemeral",
            content[0].GetProperty("cache_control").GetProperty("type").GetString()
        );
        Assert.Equal("search_result", content[1].GetProperty("type").GetString());
        Assert.Equal("https://example.com", content[1].GetProperty("source").GetString());
        Assert.Equal("Weather", content[1].GetProperty("title").GetString());
        Assert.Equal(
            "Rainy all day",
            content[1].GetProperty("content")[0].GetProperty("text").GetString()
        );
        // Any other block has only its type, without a prefix.
        AssertJson("""{"type":"image"}""", content[2].GetRawText());
        Assert.Null(tool.GetTagItem("gen_ai.tool.call.result"));
    }

    [Fact]
    public async Task ToolRunner_ResultWithAnEncryptedField_LeavesTheFieldOut()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var weather = WeatherTool(_ => "rainy");
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [
                new BetaRunnableTool
                {
                    Name = weather.Name,
                    Definition = weather.Definition,
                    Run = (_, _) =>
                        Task.FromResult(
                            new Beta.BetaToolResultBlockParamContent(
                                JsonSerializer.Deserialize<JsonElement>(
                                    """[{"type":"text","text":"rainy","citations":[{"type":"web_search_result_location","cited_text":"rain","encrypted_index":"enc_index","title":"Weather","url":"https://example.com"}]}]"""
                                )
                            )
                        ),
                },
            ]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        // The rest of the citation is kept, in the tool span and in the next request's messages.
        AssertJson(
            """[{"type":"text","text":"rainy","citations":[{"type":"web_search_result_location","cited_text":"rain","title":"Weather","url":"https://example.com"}]}]""",
            trace
                .Single("anthropic.custom_tool_use get_weather")
                .GetTagItem("anthropic.tool_result.content")
        );
        Assert.DoesNotContain(
            trace.Spans,
            span => span.TagObjects.Any(tag => $"{tag.Value}".Contains("enc_index"))
        );
        Assert.Contains(
            trace.Spans,
            span =>
                $"{span.GetTagItem("gen_ai.input.messages")}".Contains("web_search_result_location")
        );
    }

    [Fact]
    public async Task ToolRunner_ResultWithoutContent_RecordsAnEmptyList()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var weather = WeatherTool(_ => "rainy");
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [
                new BetaRunnableTool
                {
                    Name = weather.Name,
                    Definition = weather.Definition,
                    // A tool that returns no content makes a result without content.
                    Run = (_, _) => Task.FromResult<Beta.BetaToolResultBlockParamContent>(null!),
                },
            ]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(ActivityStatusCode.Ok, tool.Status);
        AssertJson("[]", tool.GetTagItem("anthropic.tool_result.content"));
    }

    [Fact]
    public async Task ToolRunner_ResultOverTheSizeLimit_LosesItsLastBlocks()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var weather = WeatherTool(_ => "rainy");
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [
                new BetaRunnableTool
                {
                    Name = weather.Name,
                    Definition = weather.Definition,
                    Run = (_, _) =>
                        Task.FromResult<Beta.BetaToolResultBlockParamContent>(
                            new List<Beta.Block>
                            {
                                new Beta.BetaTextBlockParam { Text = new string('a', 300_000) },
                                new Beta.BetaTextBlockParam { Text = new string('b', 300_000) },
                                new Beta.BetaTextBlockParam { Text = new string('c', 300_000) },
                            }
                        ),
                },
            ]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        var content = JsonDocument
            .Parse(Assert.IsType<string>(tool.GetTagItem("anthropic.tool_result.content")))
            .RootElement;
        // The first two blocks fit with the arguments, whole, and the third does not.
        Assert.Equal(2, content.GetArrayLength());
        Assert.Equal(new string('a', 300_000), content[0].GetProperty("text").GetString());
        Assert.Equal(new string('b', 300_000), content[1].GetProperty("text").GetString());
        Assert.Equal(true, tool.GetTagItem("anthropic.content.truncated"));
        AssertJson("""{"city":"Oslo"}""", tool.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Equal(ActivityStatusCode.Ok, tool.Status);
    }

    [Fact]
    public async Task ToolRunner_StringResultOverTheSizeLimit_RecordsAnEmptyList()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [WeatherTool(_ => new string('a', Anthropic.Core.Telemetry.Content.ContentLimit))]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        // A string is one content block, which is removed whole.
        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        AssertJson("[]", tool.GetTagItem("anthropic.tool_result.content"));
        Assert.Equal(true, tool.GetTagItem("anthropic.content.truncated"));
        AssertJson("""{"city":"Oslo"}""", tool.GetTagItem("gen_ai.tool.call.arguments"));
    }

    [Theory]
    [InlineData(200L, "[]", true)]
    [InlineData(null, null, null)]
    public async Task ToolRunner_MaxContentBytesOfTheOptions_IsTheSizeLimitOfAToolResult(
        long? maxContentBytes,
        string? expectedContent,
        bool? expectedTruncated
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new()
            {
                Traces = new()
                {
                    ContentMode = OpenTelemetryContentMode.Content,
                    MaxContentBytes = maxContentBytes,
                },
            }
        );
        var result = new string('a', 500);
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => result)]);

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        // 500 characters are over a bound of 200, and far under the default.
        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        AssertJson(
            expectedContent ?? $$"""[{"type":"text","text":"{{result}}"}]""",
            tool.GetTagItem("anthropic.tool_result.content")
        );
        Assert.Equal(expectedTruncated, tool.GetTagItem("anthropic.content.truncated"));
        AssertJson("""{"city":"Oslo"}""", tool.GetTagItem("gen_ai.tool.call.arguments"));
    }

    [Theory]
    // The arguments are 51 characters, which is not over a limit of 51: they stay, whole, and
    // leave no room for the result's one block.
    [InlineData(51L, true, "[]")]
    // They are over a limit of 50 by themselves: they are left out, and the result has all of it.
    [InlineData(50L, false, """[{"type":"text","text":"ok"}]""")]
    public async Task ToolRunner_ArgumentsOverTheSizeLimitByThemselves_AreLeftOutWhole(
        long maxContentBytes,
        bool expectedArguments,
        string expectedContent
    )
    {
        using var trace = new RecordedTrace();
        var city = new string('o', 40);
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage.Replace("Oslo", city))
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new()
            {
                Traces = new()
                {
                    ContentMode = OpenTelemetryContentMode.Content,
                    MaxContentBytes = maxContentBytes,
                },
            }
        );
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "ok")]);

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(
            expectedArguments ? $$"""{"city":"{{city}}"}""" : null,
            tool.GetTagItem("gen_ai.tool.call.arguments")
        );
        Assert.Equal(expectedContent, tool.GetTagItem("anthropic.tool_result.content"));
        Assert.Equal(true, tool.GetTagItem("anthropic.content.truncated"));
        Assert.Equal(ActivityStatusCode.Ok, tool.Status);
    }

    [Fact]
    public async Task ToolRunner_ArgumentsAndResult_HaveNonAsciiCharactersAsThemselves()
    {
        using var trace = new RecordedTrace();
        var city = "S\u00e3o Paulo <\u6771\u4eac> & 'x' \ud83d\ude00";
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage.Replace("Oslo", city))
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => city)]);

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var written = "S\u00e3o Paulo <\u6771\u4eac> & 'x' \\uD83D\\uDE00";
        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal($$"""{"city":"{{written}}"}""", tool.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Equal(
            $$"""[{"type":"text","text":"{{written}}"}]""",
            tool.GetTagItem("anthropic.tool_result.content")
        );
    }

    [Fact]
    public void ToolCallArguments_OverTheSizeLimitByThemselves_AreLeftOutWithoutAResultToo()
    {
        // A tool that throws out of the runner makes no result, so the span starts within the
        // limit.
        var over = new Activity("test");
        Anthropic.Core.Telemetry.Content.SetToolCallArguments(over, """{"a":1}""", limit: 6);
        Assert.Null(over.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Equal(true, over.GetTagItem("anthropic.content.truncated"));

        var atTheLimit = new Activity("test");
        Anthropic.Core.Telemetry.Content.SetToolCallArguments(atTheLimit, """{"a":1}""", limit: 7);
        Assert.Equal("""{"a":1}""", atTheLimit.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Null(atTheLimit.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void ToolSpanContent_IsMeasuredInBytesOfUtf8()
    {
        // Arguments that hold a character as itself: ten characters, and fourteen bytes.
        var arguments = "{\"a\":\"\u20ac\u20ac\"}";
        Assert.Equal(14, Encoding.UTF8.GetByteCount(arguments));

        // One byte over the limit, and three characters under it.
        var over = new Activity("test");
        Anthropic.Core.Telemetry.Content.SetToolCallArguments(over, arguments, limit: 13);
        Assert.Null(over.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Equal(true, over.GetTagItem("anthropic.content.truncated"));

        // The limit exactly, in bytes, is not over it. The result then has no room.
        var block = new JsonObject { ["type"] = "text", ["text"] = "\u20ac\u20ac" };
        var atTheLimit = new Activity("test");
        Anthropic.Core.Telemetry.Content.SetToolCallArguments(atTheLimit, arguments, limit: 14);
        Assert.Equal(arguments, atTheLimit.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Null(atTheLimit.GetTagItem("anthropic.content.truncated"));
        Anthropic.Core.Telemetry.Content.SetToolResultContent(atTheLimit, [block], limit: 14);
        Assert.Equal("[]", atTheLimit.GetTagItem("anthropic.tool_result.content"));
        Assert.Equal(true, atTheLimit.GetTagItem("anthropic.content.truncated"));

        // The bytes of the result are counted with the bytes of the arguments: both are the limit
        // exactly, and one byte less removes the block although the characters are eight under it.
        var content = """[{"type":"text","text":"€€"}]""";
        var size = 14 + Encoding.UTF8.GetByteCount(content);
        Assert.Equal(arguments.Length + content.Length + 8, size);
        foreach (var (limit, expected) in new[] { (size, content), (size - 1, "[]") })
        {
            var span = new Activity("test");
            Anthropic.Core.Telemetry.Content.SetToolCallArguments(span, arguments, limit);
            Anthropic.Core.Telemetry.Content.SetToolResultContent(span, [block.DeepClone()], limit);
            Assert.Equal(arguments, span.GetTagItem("gen_ai.tool.call.arguments"));
            Assert.Equal(expected, span.GetTagItem("anthropic.tool_result.content"));
            Assert.Equal(
                expected == "[]" ? true : null,
                span.GetTagItem("anthropic.content.truncated")
            );
        }
    }

    /// <summary>
    /// The cases of the size limit of a tool span that every SDK has, as JSON. The arguments and
    /// the content blocks of a case's <c>input</c> and <c>expected</c> are in the form that the
    /// attributes hold, null is an absent attribute, and its sizes count the bytes of UTF-8 of
    /// their JSON.
    /// </summary>
    const string SizeLimitCases = """
        [
          {"name":"tool_span_blocks_go_from_the_end",
           "note":"Blocks are removed from the END of anthropic.tool_result.content, the last one first, whole; gen_ai.tool.call.arguments fits the bound by itself, so it stays whole and counts.",
           "bound":152,"size_before":222,"size_after":142,"expected_truncated":true,
           "input":{"tool_call_arguments":{"city":"Paris"},"tool_result_content":[{"type":"text","text":"first 111111111111111111111111111111"},{"type":"text","text":"second 222222222222222222222222222222"},{"type":"image"},{"type":"text","text":"fourth 444444444444444444444444444444"}]},
           "expected":{"tool_call_arguments":{"city":"Paris"},"tool_result_content":[{"type":"text","text":"first 111111111111111111111111111111"},{"type":"text","text":"second 222222222222222222222222222222"}]}},
          {"name":"tool_span_arguments_alone_over_the_bound",
           "note":"The arguments alone exceed the bound, so the attribute is removed whole and truncated is true. The result then has the whole bound, and stays.",
           "bound":100,"size_before":190,"size_after":29,"expected_truncated":true,
           "input":{"tool_call_arguments":{"text":"wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww"},"tool_result_content":[{"type":"text","text":"ok"}]},
           "expected":{"tool_call_arguments":null,"tool_result_content":[{"type":"text","text":"ok"}]}}
        ]
        """;

    [Theory]
    [InlineData("tool_span_blocks_go_from_the_end")]
    [InlineData("tool_span_arguments_alone_over_the_bound")]
    public void ToolResultContent_SizeLimitCase_IsWhatEverySdkGives(string name)
    {
        var item = JsonDocument
            .Parse(SizeLimitCases)
            .RootElement.EnumerateArray()
            .Single(item => item.GetProperty("name").GetString() == name);
        var input = item.GetProperty("input");
        var arguments = input.GetProperty("tool_call_arguments").GetRawText();
        var blocks = input.GetProperty("tool_result_content").GetRawText();
        Assert.Equal(
            item.GetProperty("size_before").GetInt32(),
            Encoding.UTF8.GetByteCount(arguments) + Encoding.UTF8.GetByteCount(blocks)
        );

        var bound = item.GetProperty("bound").GetInt32();
        var span = new Activity("test");
        Anthropic.Core.Telemetry.Content.SetToolCallArguments(span, arguments, bound);
        Anthropic.Core.Telemetry.Content.SetToolResultContent(
            span,
            Assert.IsType<JsonArray>(JsonNode.Parse(blocks)),
            bound
        );

        var expected = item.GetProperty("expected");
        var content = Assert.IsType<string>(span.GetTagItem("anthropic.tool_result.content"));
        Assert.Equal(expected.GetProperty("tool_result_content").GetRawText(), content);
        var expectedArguments = expected.GetProperty("tool_call_arguments");
        var held =
            expectedArguments.ValueKind == JsonValueKind.Null
                ? null
                : expectedArguments.GetRawText();
        Assert.Equal(held, span.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Equal(
            item.GetProperty("size_after").GetInt32(),
            (held == null ? 0 : Encoding.UTF8.GetByteCount(held))
                + Encoding.UTF8.GetByteCount(content)
        );
        Assert.Equal(
            item.GetProperty("expected_truncated").GetBoolean() ? true : null,
            span.GetTagItem("anthropic.content.truncated")
        );
    }

    [Fact]
    public async Task ToolRunner_ResultOverTheSizeLimit_OutsideContentMode_RecordsNoContent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [WeatherTool(_ => new string('a', Anthropic.Core.Telemetry.Content.ContentLimit))]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Null(tool.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Null(tool.GetTagItem("anthropic.tool_result.content"));
        Assert.Null(tool.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task ToolRunner_CanceledWhileAToolRuns_LeavesToolAndToolRunnerSpansUnset()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        using var cancellation = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );
        // The application cancels while the tool runs, and the tool honors the token.
        var tool = WeatherTool(_ => "rainy");
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [
                new BetaRunnableTool
                {
                    Name = tool.Name,
                    Definition = tool.Definition,
                    Run = (block, token) =>
                    {
                        cancellation.Cancel();
                        token.ThrowIfCancellationRequested();
                        return tool.Run(block, token);
                    },
                },
            ]
        );

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            runner.RunUntilDoneAsync(cancellation.Token)
        );

        var toolSpan = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(ActivityStatusCode.Unset, toolSpan.Status);
        Assert.Null(toolSpan.GetTagItem("error.type"));
        // A canceled run has no result, but its arguments are still the call's.
        AssertJson("""{"city":"Oslo"}""", toolSpan.GetTagItem("gen_ai.tool.call.arguments"));
        Assert.Null(toolSpan.GetTagItem("anthropic.tool_result.content"));
        Assert.Null(toolSpan.GetTagItem("gen_ai.tool.call.result"));
        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityStatusCode.Unset, toolRunnerSpan.Status);
        Assert.Null(toolRunnerSpan.GetTagItem("error.type"));
        Assert.Single(handler.Requests);
    }

    [Fact]
    public async Task ToolRunner_McpTool_EmitsAnMcpToolSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        var weather = WeatherTool(_ => "rainy", "Gets the weather of a city.");
        // The tool BetaMcp.Tool makes for one that an MCP server advertises.
        var mcpTool = new BetaRunnableTool
        {
            IsMcpTool = true,
            Name = weather.Name,
            Definition = weather.Definition,
            Run = weather.Run,
        };
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [mcpTool]);

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.mcp_tool_use get_weather");
        Assert.Equal(ActivityKind.Internal, tool.Kind);
        Assert.Equal(ActivityStatusCode.Ok, tool.Status);
        Assert.Equal("execute_tool", tool.GetTagItem("gen_ai.operation.name"));
        Assert.Equal("get_weather", tool.GetTagItem("gen_ai.tool.name"));
        Assert.Equal("function", tool.GetTagItem("gen_ai.tool.type"));
        // The description is metadata: the span has it outside content mode too.
        Assert.Equal("Gets the weather of a city.", tool.GetTagItem("gen_ai.tool.description"));
        Assert.DoesNotContain(
            trace.Spans,
            s => s.OperationName.StartsWith("anthropic.custom_tool_use", StringComparison.Ordinal)
        );
    }

    [Fact]
    public async Task ToolRunner_FailedCall_FailsTheToolRunnerSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(
            HttpStatusCode.BadRequest,
            Fixtures.ErrorJson,
            "req_err"
        );
        var client = Fixtures.Client(handler);
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "rainy")]);

        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            runner.RunUntilDoneAsync(TestContext.Current.CancellationToken)
        );

        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityStatusCode.Error, toolRunnerSpan.Status);
        Assert.Equal("invalid_request_error", toolRunnerSpan.GetTagItem("error.type"));
    }

    [Fact]
    public async Task ToolRunner_StoppedEarly_EndsTheToolRunnerSpanWithStatusUnset()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(ToolUseMessage);
        var client = Fixtures.Client(handler);
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "rainy")]);

        await foreach (var _ in runner.WithCancellation(TestContext.Current.CancellationToken))
        {
            break;
        }

        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityStatusCode.Unset, toolRunnerSpan.Status);
        Assert.Null(toolRunnerSpan.GetTagItem("error.type"));
        Assert.DoesNotContain(
            trace.Spans,
            s => s.OperationName.StartsWith("anthropic.custom_tool_use", StringComparison.Ordinal)
        );
    }

    [Fact]
    public async Task ToolRunner_Streaming_SendsRequestsUnderTheToolRunnerSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(
                Fixtures.MessageStart,
                (
                    "message_delta",
                    """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":1}}"""
                ),
                ("message_stop", """{"type":"message_stop"}""")
            )
        );
        var client = Fixtures.Client(handler);
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "rainy")]);

        await foreach (var events in runner.Streaming(TestContext.Current.CancellationToken))
        {
            await foreach (var _ in events) { }
        }

        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityStatusCode.Ok, toolRunnerSpan.Status);
        var callSpan = trace.Single("anthropic.messages.create");
        Assert.Equal(toolRunnerSpan.SpanId, callSpan.ParentSpanId);
        // The runner reads the turn's stream to its end, so the call completes.
        Assert.Equal(ActivityStatusCode.Ok, callSpan.Status);
    }

    [Fact]
    public async Task ToolRunner_Streaming_TurnEndedBeforeMessageStop_RecordsTheOutputBuiltSoFar()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse([.. Fixtures.StreamBody.Take(3)])
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "rainy")]);

        // The runner makes no Message of such a turn, and the turn's call span has what it read.
        await Assert.ThrowsAsync<AnthropicInvalidDataException>(async () =>
        {
            await foreach (var events in runner.Streaming(TestContext.Current.CancellationToken))
            {
                await foreach (var _ in events) { }
            }
        });

        var callSpan = trace.Single("anthropic.messages.create");
        Assert.Equal("api_error", callSpan.GetTagItem("error.type"));
        AssertJson(
            """[{"role":"assistant","parts":[{"type":"text","content":"Hello"}]}]""",
            callSpan.GetTagItem("gen_ai.output.messages")
        );
    }

    [Fact]
    public async Task ToolRunner_Streaming_FailedCall_FailsTheToolRunnerSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(
            HttpStatusCode.BadRequest,
            Fixtures.ErrorJson,
            "req_err"
        );
        var client = Fixtures.Client(handler);
        var runner = client.Beta.Messages.ToolRunner(BetaParams(), [WeatherTool(_ => "rainy")]);

        await Assert.ThrowsAsync<AnthropicBadRequestException>(async () =>
        {
            await foreach (var events in runner.Streaming(TestContext.Current.CancellationToken))
            {
                await foreach (var _ in events) { }
            }
        });

        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityStatusCode.Error, toolRunnerSpan.Status);
        Assert.Equal("invalid_request_error", toolRunnerSpan.GetTagItem("error.type"));
        Assert.Equal(toolRunnerSpan.SpanId, trace.Single("anthropic.messages.create").ParentSpanId);
    }

    const string ToolUseMessage = """
        {
          "id": "msg_t",
          "type": "message",
          "role": "assistant",
          "model": "claude-test-20260101",
          "content": [{"type": "tool_use", "id": "toolu_w", "name": "get_weather", "input": {"city": "Oslo"}}],
          "stop_reason": "tool_use",
          "stop_sequence": null,
          "usage": {"input_tokens": 10, "output_tokens": 5}
        }
        """;

    [Fact]
    public async Task ToolRunner_WhoseOutputConfigCannotBeRead_RunsAndTheSpanHasNoOutputType()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson.Replace("tool_use\"", "text\", \"text\": \"done\""));
        var noData = new Dictionary<string, JsonElement>();
        // Parameters that the application built from JSON, with a value that this SDK version
        // has no model for.
        var parameters = Beta.MessageCreateParams.FromRawUnchecked(
            rawHeaderData: noData,
            rawQueryData: noData,
            rawBodyData: JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                """
                {
                  "model": "claude-test",
                  "max_tokens": 64,
                  "messages": [{"role": "user", "content": "Weather?"}],
                  "output_config": "not an object"
                }
                """
            ) ?? []
        );

        var turns = 0;
        await foreach (
            var _ in Fixtures
                .Client(handler)
                .Beta.Messages.ToolRunner(parameters, [WeatherTool(_ => "rainy")])
                .WithCancellation(TestContext.Current.CancellationToken)
        )
        {
            turns++;
        }

        Assert.Equal(2, turns);
        var toolRunnerSpan = trace.Single("anthropic.messages.tool_runner");
        Assert.Equal(ActivityStatusCode.Ok, toolRunnerSpan.Status);
        Assert.Equal("claude-test", toolRunnerSpan.GetTagItem("gen_ai.request.model"));
        Assert.Null(toolRunnerSpan.GetTagItem("gen_ai.output.type"));
    }

    [Fact]
    public async Task ToolRunner_WhoseParametersSetAnOutputFormat_SetsTheOutputType()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        var format = new Beta.BetaJsonOutputFormat
        {
            Schema = new Dictionary<string, JsonElement>
            {
                ["type"] = JsonSerializer.SerializeToElement("object"),
            },
        };

        await client
            .Beta.Messages.ToolRunner(
                BetaParams() with
                {
                    OutputConfig = new() { Format = format },
                },
                [WeatherTool(_ => "rainy")]
            )
            .RunUntilDoneAsync(TestContext.Current.CancellationToken);
#pragma warning disable CS0618
        await client
            .Beta.Messages.ToolRunner(
                BetaParams() with
                {
                    OutputFormat = format,
                },
                [WeatherTool(_ => "rainy")]
            )
            .RunUntilDoneAsync(TestContext.Current.CancellationToken);
#pragma warning restore CS0618

        // The tool runner span has it, as the span of each of its requests has.
        var toolRunnerSpans = trace.Spans.Where(s =>
            s.OperationName == "anthropic.messages.tool_runner"
        );
        Assert.Equal(2, toolRunnerSpans.Count());
        Assert.All(
            toolRunnerSpans,
            toolRunnerSpan => Assert.Equal("json", toolRunnerSpan.GetTagItem("gen_ai.output.type"))
        );
        var calls = trace.Spans.Where(s => s.OperationName == "anthropic.messages.create");
        Assert.Equal(2, calls.Count());
        Assert.All(calls, call => Assert.Equal("json", call.GetTagItem("gen_ai.output.type")));
    }

    [Fact]
    public async Task ToolRunner_SpanStartedInsideATool_HasTheToolSpanAsParent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        Activity? inTool = null;
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [
                WeatherTool(_ =>
                {
                    // Stands in for whatever instrumented work the application's tool does.
                    inTool = new Activity("lookup").Start();
                    inTool.Stop();
                    return "rainy";
                }),
            ]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(tool.SpanId, inTool?.ParentSpanId);
        Assert.Equal(trace.Single("anthropic.messages.tool_runner").SpanId, tool.ParentSpanId);
        // The application's own span is the current one again once the loop is done.
        Assert.Same(trace.Root, Activity.Current);
    }

    [Fact]
    public async Task ToolRunner_ToolWithAnEmptyDescription_HasNoDescriptionAttribute()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(ToolUseMessage)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        var runner = client.Beta.Messages.ToolRunner(
            BetaParams(),
            [WeatherTool(_ => "rainy", description: "")]
        );

        await runner.RunUntilDoneAsync(TestContext.Current.CancellationToken);

        var tool = trace.Single("anthropic.custom_tool_use get_weather");
        Assert.Equal(ActivityStatusCode.Ok, tool.Status);
        Assert.Null(tool.GetTagItem("gen_ai.tool.description"));
    }

    static BetaRunnableTool WeatherTool(
        Func<Beta.BetaToolUseBlock, string> run,
        string? description = null
    ) =>
        new()
        {
            Name = "get_weather",
            Definition = new Beta.BetaTool
            {
                Name = "get_weather",
                Description = description,
                InputSchema = new()
                {
                    Properties = new Dictionary<string, JsonElement>
                    {
                        ["city"] = JsonSerializer.SerializeToElement(new { type = "string" }),
                    },
                },
            },
            Run = (block, _) => Task.FromResult<Beta.BetaToolResultBlockParamContent>(run(block)),
        };
}
