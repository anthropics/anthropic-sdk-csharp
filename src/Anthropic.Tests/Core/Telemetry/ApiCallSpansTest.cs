using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

public class ApiCallSpansTest : TracingTestBase
{
    [Fact]
    public async Task MessagesCreate_RecordsCallSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);

        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityKind.Client, span.Kind);
        Assert.Equal(trace.Root.SpanId, span.ParentSpanId);
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal("chat", span.GetTagItem("gen_ai.operation.name"));
        Assert.Equal("anthropic", span.GetTagItem("gen_ai.provider.name"));
        Assert.Equal("claude-test", span.GetTagItem("gen_ai.request.model"));
        Assert.Equal(64L, span.GetTagItem("gen_ai.request.max_tokens"));
        Assert.Equal(0.5, span.GetTagItem("gen_ai.request.temperature"));
        Assert.Null(span.GetTagItem("gen_ai.request.stream"));
        Assert.Null(span.GetTagItem("gen_ai.output.type"));
        Assert.Equal("api.example.test", span.GetTagItem("server.address"));
        Assert.Equal(443, span.GetTagItem("server.port"));
        Assert.Equal(200, span.GetTagItem("http.response.status_code"));
        Assert.Equal("req_1", span.GetTagItem("anthropic.request.id"));
        Assert.Equal("org_1", span.GetTagItem("anthropic.organization.id"));
        Assert.Null(span.GetTagItem("anthropic.workspace.id"));
        Assert.Equal("msg_1", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal("claude-test-20260101", span.GetTagItem("gen_ai.response.model"));
        Assert.Equal("end_turn", span.GetTagItem("anthropic.message.stop_reason"));
        Assert.Null(span.GetTagItem("gen_ai.response.finish_reasons"));
        Assert.Equal(15L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.Equal(5L, span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.Equal(2L, span.GetTagItem("gen_ai.usage.cache_write.input_tokens"));
        Assert.Equal(3L, span.GetTagItem("gen_ai.usage.cache_read.input_tokens"));
        Assert.Equal(
            2L,
            span.GetTagItem("anthropic.usage.cache_creation.ephemeral_5m_input_tokens")
        );
        Assert.Equal(1L, span.GetTagItem("gen_ai.usage.reasoning.output_tokens"));
        Assert.Equal("standard", span.GetTagItem("anthropic.response.service_tier"));
        Assert.Equal("POST", span.GetTagItem("http.request.method"));
        Assert.Equal("/v1/messages", span.GetTagItem("http.route"));
        Assert.Equal("https://api.example.test/v1/messages", span.GetTagItem("url.full"));
        Assert.Null(span.GetTagItem("http.request.resend_count"));
        Assert.Null(span.GetTagItem("gen_ai.input.messages"));
        Assert.Null(span.GetTagItem("error.type"));
    }

    /// <summary>
    /// <see cref="Fixtures.MessageJson"/> with <paramref name="usage"/> for its usage.
    /// </summary>
    static string MessageJson(string usage)
    {
        var message = JsonNode.Parse(Fixtures.MessageJson)!;
        message["usage"] = JsonNode.Parse(usage);
        return message.ToJsonString();
    }

    [Theory]
    [InlineData(OpenTelemetryContentMode.MetadataOnly)]
    [InlineData(OpenTelemetryContentMode.Content)]
    public async Task MessagesCreate_WithCompactions_HasTheirTokensApartFromItsOwn(
        OpenTelemetryContentMode contentMode
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(
            MessageJson(
                """
                {
                  "input_tokens": 10, "output_tokens": 5,
                  "cache_read_input_tokens": 3, "cache_creation_input_tokens": 2,
                  "iterations": [
                    {"type": "compaction", "input_tokens": 100, "output_tokens": 30, "cache_read_input_tokens": 20, "cache_creation_input_tokens": 5, "cache_creation": null},
                    {"type": "message", "input_tokens": 10, "output_tokens": 5, "cache_read_input_tokens": 3, "cache_creation_input_tokens": 2, "cache_creation": null},
                    {"type": "compaction", "input_tokens": 200, "output_tokens": 40, "cache_read_input_tokens": 0, "cache_creation_input_tokens": 0, "cache_creation": null}
                  ]
                }
                """
            )
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = contentMode } }
        );

        await client.Beta.Messages.Create(BetaParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(325L, span.GetTagItem("anthropic.usage.compaction.input_tokens"));
        Assert.Equal(70L, span.GetTagItem("anthropic.usage.compaction.output_tokens"));
        Assert.Equal(15L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.Equal(5L, span.GetTagItem("gen_ai.usage.output_tokens"));
    }

    [Fact]
    public async Task MessagesCreate_ThatOnlyCompacted_HasTheCompactionTokens()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(
            MessageJson(
                """
                {
                  "input_tokens": 0, "output_tokens": 0,
                  "iterations": [
                    {"type": "compaction", "input_tokens": 100, "output_tokens": 30, "cache_read_input_tokens": 20, "cache_creation_input_tokens": 5, "cache_creation": null}
                  ]
                }
                """
            )
        );
        var client = Fixtures.Client(handler);

        await client.Beta.Messages.Create(BetaParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(125L, span.GetTagItem("anthropic.usage.compaction.input_tokens"));
        Assert.Equal(30L, span.GetTagItem("anthropic.usage.compaction.output_tokens"));
        Assert.Equal(0L, span.GetTagItem("gen_ai.usage.input_tokens"));
        Assert.Equal(0L, span.GetTagItem("gen_ai.usage.output_tokens"));
    }

    [Theory]
    [InlineData("""{"input_tokens": 10, "output_tokens": 5}""")]
    [InlineData("""{"input_tokens": 10, "output_tokens": 5, "iterations": null}""")]
    [InlineData("""{"input_tokens": 10, "output_tokens": 5, "iterations": []}""")]
    [InlineData(
        """{"input_tokens": 10, "output_tokens": 5, "iterations": [{"type": "message", "input_tokens": 10, "output_tokens": 5, "cache_read_input_tokens": 0, "cache_creation_input_tokens": 0, "cache_creation": null}]}"""
    )]
    public async Task MessagesCreate_WithoutACompaction_HasNoCompactionTokens(string usage)
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(MessageJson(usage))
            .RespondJson(MessageJson(usage));
        var client = Fixtures.Client(handler);

        await client.Beta.Messages.Create(BetaParams(), TestContext.Current.CancellationToken);
        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        Assert.Equal(2, trace.Spans.Count);
        Assert.All(
            trace.Spans,
            span =>
            {
                Assert.Equal(10L, span.GetTagItem("gen_ai.usage.input_tokens"));
                Assert.Null(span.GetTagItem("anthropic.usage.compaction.input_tokens"));
                Assert.Null(span.GetTagItem("anthropic.usage.compaction.output_tokens"));
            }
        );
    }

    [Fact]
    public async Task UnreadResponses_EndTheirSpanOnce()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);

        var response = await client.WithRawResponse.Messages.Create(
            MessageParams(),
            TestContext.Current.CancellationToken
        );
        response.Dispose();
        response.Dispose();
        var stream = await client.WithRawResponse.Messages.CreateStreaming(
            MessageParams(),
            TestContext.Current.CancellationToken
        );
        stream.Dispose();

        Assert.Equal(2, trace.Spans.Count);
        // A response dropped unread has completed; a stream dropped unread was canceled.
        Assert.Equal(ActivityStatusCode.Ok, trace.Spans[0].Status);
        Assert.Equal(ActivityStatusCode.Unset, trace.Spans[1].Status);
        // Both ended at the headers: the response attributes, and none of the body's.
        Assert.All(trace.Spans, s => Assert.Equal(200, s.GetTagItem("http.response.status_code")));
        Assert.Equal("req_1", trace.Spans[0].GetTagItem("anthropic.request.id"));
        Assert.Equal("claude-test", trace.Spans[0].GetTagItem("gen_ai.request.model"));
        Assert.All(trace.Spans, s => Assert.Null(s.GetTagItem("gen_ai.response.id")));
    }

    [Fact]
    public async Task RawResponse_Deserialized_RecordsTheBody()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);

        using var response = await client.WithRawResponse.Messages.Create(
            MessageParams(),
            TestContext.Current.CancellationToken
        );
        // The span stays open until the body has been read.
        Assert.Empty(trace.Spans);
        await response.Deserialize(TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal("msg_1", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal(5L, span.GetTagItem("gen_ai.usage.output_tokens"));
    }

    [Fact]
    public async Task CallSpans_StartWithTheAttributesThatASamplerDecidesOn()
    {
        using var trace = new RecordedTrace();
        // What a sampler sees of each span, in the order the spans start.
        var atStart = new List<Dictionary<string, object?>>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "com.anthropic.sdk.csharp",
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
            {
                if (options.Parent.TraceId == trace.Root.TraceId)
                {
                    lock (atStart)
                    {
                        atStart.Add(
                            (options.Tags ?? []).ToDictionary(tag => tag.Key, tag => tag.Value)
                        );
                    }
                }
                return ActivitySamplingResult.AllDataAndRecorded;
            },
        };
        ActivitySource.AddActivityListener(listener);
        const string Batch = """
            {"id":"msgbatch_1","type":"message_batch","processing_status":"in_progress","request_counts":{"processing":1,"succeeded":0,"errored":0,"canceled":0,"expired":0},"created_at":"2026-01-01T00:00:00Z","expires_at":"2026-01-02T00:00:00Z","ended_at":null,"archived_at":null,"cancel_initiated_at":null,"results_url":null}
            """;
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondStream(Fixtures.Sse(Fixtures.StreamBody))
            .RespondJson("""{"input_tokens": 21}""")
            .RespondJson(Batch)
            .RespondJson("""{"data":[],"has_more":true,"first_id":"a","last_id":"b"}""")
            .RespondJson("""{"data":[],"has_more":false,"first_id":null,"last_id":null}""");
        var client = Fixtures
            .Client(handler)
            .WithOptions(options =>
                options with
                {
                    OpenTelemetryRequest = new() { ConversationId = "conv_42" },
                }
            );
        var parameters = BetaParams() with
        {
            Betas = [Anthropic.Models.Beta.AnthropicBeta.FilesApi2025_04_14],
        };

        await client.Beta.Messages.Create(parameters, TestContext.Current.CancellationToken);
        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                parameters,
                TestContext.Current.CancellationToken
            )
        ) { }
        await client.Messages.CountTokens(
            new()
            {
                Messages = [new() { Role = Role.User, Content = "Hi" }],
                Model = "claude-test",
            },
            TestContext.Current.CancellationToken
        );
        await client.Messages.Batches.Retrieve(
            "msgbatch_1",
            cancellationToken: TestContext.Current.CancellationToken
        );
        var page = await client.Models.List(
            cancellationToken: TestContext.Current.CancellationToken
        );
        await page.Next(TestContext.Current.CancellationToken);

        Assert.Equal(6, atStart.Count);
        Assert.All(
            atStart,
            tags =>
            {
                Assert.Equal("anthropic", tags["gen_ai.provider.name"]);
                Assert.Equal("conv_42", tags["gen_ai.conversation.id"]);
                Assert.Equal("api.example.test", tags["server.address"]);
                Assert.Equal(443, tags["server.port"]);
            }
        );
        Assert.Equal(
            ["POST", "POST", "POST", "GET", "GET", "GET"],
            atStart.Select(tags => tags["http.request.method"])
        );
        Assert.Equal(
            [
                "/v1/messages",
                "/v1/messages",
                "/v1/messages/count_tokens",
                "/v1/messages/batches/{message_batch_id}",
                "/v1/models",
                "/v1/models",
            ],
            atStart.Select(tags => tags["http.route"])
        );
        Assert.All(
            atStart.Take(2),
            tags =>
            {
                Assert.Equal("chat", tags["gen_ai.operation.name"]);
                Assert.Equal("claude-test", tags["gen_ai.request.model"]);
                Assert.Equal(64L, tags["gen_ai.request.max_tokens"]);
                Assert.Equal(
                    "files-api-2025-04-14",
                    Assert.Single(Assert.IsType<string[]>(tags["anthropic.beta"]))
                );
            }
        );
        Assert.False(atStart[0].ContainsKey("gen_ai.request.stream"));
        Assert.True(Assert.IsType<bool>(atStart[1]["gen_ai.request.stream"]));
        Assert.Equal("claude-test", atStart[2]["gen_ai.request.model"]);
        Assert.Equal("msgbatch_1", atStart[3]["anthropic.message.batch.id"]);
        // The calls ran one after the other, so their spans ended in the order they started.
        Assert.Equal(6, trace.Spans.Count);
        Assert.All(
            trace.Spans.Zip(atStart, (span, tags) => (span, tags)),
            pair =>
            {
                // The span has each attribute once.
                Assert.Equal(
                    pair.span.TagObjects.Select(tag => tag.Key).Distinct().Count(),
                    pair.span.TagObjects.Count()
                );
                // What the span started with is unchanged when it ends.
                Assert.All(
                    pair.tags,
                    tag => Assert.Equal(tag.Value, pair.span.GetTagItem(tag.Key))
                );
                // Only what the response tells is set after the start.
                Assert.All(
                    pair.span.TagObjects.Where(tag => !pair.tags.ContainsKey(tag.Key)),
                    tag =>
                        Assert.Contains(
                            SetAfterStart,
                            prefix => tag.Key.StartsWith(prefix, StringComparison.Ordinal)
                        )
                );
            }
        );
    }

    /// <summary>
    /// The prefixes of the attributes that a call span gets after it started: those of the URL
    /// that the first request is sent to, and those of the response.
    /// </summary>
    static readonly string[] SetAfterStart =
    [
        "url.",
        "http.response.",
        "gen_ai.response.",
        "gen_ai.usage.",
        "anthropic.usage.",
        "anthropic.response.",
        "anthropic.request.id",
        "anthropic.organization.id",
        "anthropic.message.stop_reason",
        "anthropic.message.count_tokens.",
    ];

    [Fact]
    public async Task RawResponse_CanceledThroughItsOwnToken_LeavesStatusUnset()
    {
        using var cancellation = new CancellationTokenSource();
        using var span = new Activity("anthropic.messages.create").Start();
        var response = new HttpResponse<string>(
            new HttpResponse
            {
                RawMessage = new HttpResponseMessage(HttpStatusCode.OK),
                CancellationToken = cancellation.Token,
                Span = span,
            },
            token =>
            {
                cancellation.Cancel();
                token.ThrowIfCancellationRequested();
                return Task.FromResult("");
            }
        );

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            response.Deserialize(TestContext.Current.CancellationToken)
        );

        Assert.True(span.IsStopped);
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
    }

    [Fact]
    public async Task BinaryDownload_EndsWhenTheResponseIsDisposed()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(HttpStatusCode.OK, "file contents", "req_f");
        var client = Fixtures.Client(handler);

        using (
            var response = await client.Beta.Files.Download(
                "file_1",
                cancellationToken: TestContext.Current.CancellationToken
            )
        )
        {
            Assert.Equal(
                "file contents",
                await response.ReadAsString(TestContext.Current.CancellationToken)
            );
            Assert.Empty(trace.Spans);
        }

        var span = trace.Single("anthropic.files.download");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal(200, span.GetTagItem("http.response.status_code"));
        Assert.Equal("req_f", span.GetTagItem("anthropic.request.id"));
    }

    [Fact]
    public async Task OutputFormat_OfTheOutputConfig_SetsTheOutputType()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);
        var parameters = MessageParams() with
        {
            OutputConfig = new()
            {
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>
                    {
                        ["type"] = JsonSerializer.SerializeToElement("object"),
                    },
                },
            },
        };

        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);
        await foreach (
            var _ in client.Messages.CreateStreaming(
                parameters,
                TestContext.Current.CancellationToken
            )
        ) { }

        // In every content mode, and for a streamed Message too.
        Assert.Equal(2, trace.Spans.Count);
        Assert.All(
            trace.Spans,
            span => Assert.Equal("json", span.GetTagItem("gen_ai.output.type"))
        );
    }

    [Fact]
    public async Task OutputFormat_OfTheDeprecatedBetaParameter_SetsTheOutputType()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
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

#pragma warning disable CS0618
        await client.Beta.Messages.Create(
            BetaParams() with
            {
                OutputFormat = format,
            },
            TestContext.Current.CancellationToken
        );
#pragma warning restore CS0618
        await client.Beta.Messages.Create(
            BetaParams() with
            {
                OutputConfig = new() { Format = format },
            },
            TestContext.Current.CancellationToken
        );
        await client.Beta.Messages.Create(BetaParams(), TestContext.Current.CancellationToken);

        Assert.Equal(3, trace.Spans.Count);
        Assert.Equal("json", trace.Spans[0].GetTagItem("gen_ai.output.type"));
        Assert.Equal("json", trace.Spans[1].GetTagItem("gen_ai.output.type"));
        Assert.Null(trace.Spans[2].GetTagItem("gen_ai.output.type"));
    }

    [Fact]
    public async Task BetaHeaders_OfTheParamsAndTheClient_AreRecorded()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var client = Fixtures
            .Client(handler)
            .WithOptions(options =>
                options with
                {
                    ExtraHeaders = new Dictionary<string, string>
                    {
                        ["anthropic-beta"] = "extended-cache-ttl-2025-04-11",
                    },
                }
            );

        await client.Beta.Messages.Create(
            BetaParams() with
            {
                Betas = [Anthropic.Models.Beta.AnthropicBeta.FilesApi2025_04_14],
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(
            "files-api-2025-04-14,extended-cache-ttl-2025-04-11",
            string.Join(
                ",",
                Assert.IsType<string[]>(
                    trace.Single("anthropic.messages.create").GetTagItem("anthropic.beta")
                )
            )
        );
    }

    [Fact]
    public async Task ErrorResponse_RecordsEnvelopeType()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(
            HttpStatusCode.BadRequest,
            Fixtures.ErrorJson,
            "req_err"
        );
        var client = Fixtures.Client(handler);

        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken)
        );

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("invalid_request_error", span.GetTagItem("error.type"));
        Assert.Equal(400, span.GetTagItem("http.response.status_code"));
        Assert.Equal("req_err", span.GetTagItem("anthropic.request.id"));
        Assert.Equal("claude-test", span.GetTagItem("gen_ai.request.model"));
        Assert.Null(span.GetTagItem("gen_ai.response.id"));
        Assert.Null(span.GetTagItem("anthropic.message.stop_reason"));
    }

    [Fact]
    public async Task RequestRefusedBeforeItIsSent_StartsNoSpan()
    {
        using var trace = new RecordedTrace();
        var started = new List<string>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "com.anthropic.sdk.csharp",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity =>
            {
                if (activity.TraceId == trace.Root.TraceId)
                {
                    lock (started)
                    {
                        started.Add(activity.OperationName);
                    }
                }
            },
        };
        ActivitySource.AddActivityListener(listener);
        var client = Fixtures.Client(new ScriptedHandler());

        // The client refuses a request that needs streaming. A span that started before would
        // never end.
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            client.Messages.Create(
                MessageParams() with
                {
                    Model = "claude-opus-4-0",
                    MaxTokens = 10_000,
                },
                TestContext.Current.CancellationToken
            )
        );

        Assert.Empty(started);
        Assert.Empty(trace.Spans);
    }

    [Fact]
    public async Task ErrorResponseWithoutEnvelope_RecordsStatusCode()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(HttpStatusCode.BadGateway, "upstream", null);
        var client = Fixtures.Client(handler, maxRetries: 0);

        await Assert.ThrowsAsync<Anthropic5xxException>(() =>
            client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken)
        );

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("502", span.GetTagItem("error.type"));
        Assert.Null(span.GetTagItem("anthropic.request.id"));
    }

    [Fact]
    public async Task StreamErrorEvent_RecordsEnvelopeType()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(Fixtures.MessageStart, ("error", Fixtures.ErrorJson.Trim()))
        );
        var client = Fixtures.Client(handler);

        await Assert.ThrowsAsync<AnthropicSseException>(async () =>
        {
            await foreach (
                var _ in client.Messages.CreateStreaming(
                    MessageParams(),
                    TestContext.Current.CancellationToken
                )
            ) { }
        });

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("invalid_request_error", span.GetTagItem("error.type"));
        Assert.Null(span.GetTagItem("anthropic.message.stop_reason"));
    }

    [Theory]
    // A type that the SDK's ErrorType enum does not have is recorded as the server sent it.
    [InlineData(
        """{"type": "error", "error": {"type": "brand_new_error", "message": "bad"}}""",
        "brand_new_error"
    )]
    [InlineData("""{"type": "error", "error": {"message": "bad"}}""", "client_error")]
    [InlineData("not json", "client_error")]
    public async Task StreamErrorEvent_WithUnknownOrNoEnvelopeType(
        string eventData,
        string expectedErrorType
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(Fixtures.MessageStart, ("error", eventData))
        );
        var client = Fixtures.Client(handler);

        await Assert.ThrowsAsync<AnthropicSseException>(async () =>
        {
            await foreach (
                var _ in client.Messages.CreateStreaming(
                    MessageParams(),
                    TestContext.Current.CancellationToken
                )
            ) { }
        });

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal(expectedErrorType, span.GetTagItem("error.type"));
    }

    [Fact]
    public async Task ConnectionError_RecordsConnectionError()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Throw(() => new HttpRequestException("refused"));
        var client = Fixtures.Client(handler, maxRetries: 0);

        await Assert.ThrowsAsync<AnthropicIOException>(() =>
            client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken)
        );

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("connection_error", span.GetTagItem("error.type"));
        Assert.Equal("api.example.test", span.GetTagItem("server.address"));
        Assert.Equal(443, span.GetTagItem("server.port"));
        Assert.Null(span.GetTagItem("http.response.status_code"));
    }

    [Fact]
    public async Task Retries_EmitOneCallSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .Respond(_ =>
            {
                var response = ScriptedHandler.Response((HttpStatusCode)503, "{}", "req_a");
                response.Headers.TryAddWithoutValidation("Retry-After-Ms", "1");
                return response;
            })
            .RespondJson(Fixtures.MessageJson, "req_b");
        var client = Fixtures.Client(handler);

        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(2, handler.Requests.Count);
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal(200, span.GetTagItem("http.response.status_code"));
        Assert.Equal("req_b", span.GetTagItem("anthropic.request.id"));
        // Every attempt carries the call span's context.
        Assert.All(
            handler.Requests,
            r => Assert.Contains(span.SpanId.ToHexString(), r.Header("traceparent"))
        );
    }

    [Fact]
    public async Task FailureBeforeARetryIsSent_DoesNotRecordTheEarlierResponse()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(_ =>
        {
            var response = ScriptedHandler.Response((HttpStatusCode)503, "{}", "req_a");
            response.Headers.TryAddWithoutValidation("Retry-After-Ms", "1");
            return response;
        });
        var client = new FailingSecondAttemptClient(
            new ClientOptions
            {
                HttpClient = new HttpClient(handler),
                BaseUrl = Fixtures.BaseUrl,
                ApiKey = "test-key",
            }
        );

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            client.Execute(
                new HttpRequest<PingParams>
                {
                    Method = HttpMethod.Post,
                    Params = new(),
                    SpanName = "anthropic.messages.create",
                },
                TestContext.Current.CancellationToken
            )
        );

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("client_error", span.GetTagItem("error.type"));
        // The retried 503 is not the final response: the call failed before its second attempt
        // was sent, so no response attributes are recorded.
        Assert.Null(span.GetTagItem("http.response.status_code"));
        Assert.Null(span.GetTagItem("anthropic.request.id"));
    }

    [Fact]
    public async Task ConversationId_ComesFromTheRequestOption_AndConcurrentCallsGetSeparateSpans()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures
            .Client(handler)
            .WithOptions(options =>
                options with
                {
                    OpenTelemetryRequest = new() { ConversationId = "conv_42" },
                }
            );

        await Task.WhenAll(
            client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken),
            client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken)
        );

        Assert.Equal(2, trace.Spans.Count);
        Assert.NotEqual(trace.Spans[0].SpanId, trace.Spans[1].SpanId);
        Assert.All(
            trace.Spans,
            s => Assert.Equal("conv_42", s.GetTagItem("gen_ai.conversation.id"))
        );
        Assert.All(trace.Spans, s => Assert.Equal(trace.Root.SpanId, s.ParentSpanId));
    }

    [Fact]
    public async Task CountTokens_RecordsInputTokens()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("""{"input_tokens": 21}""");
        var client = Fixtures.Client(handler);

        await client.Messages.CountTokens(
            new()
            {
                Messages = [new() { Role = Role.User, Content = "Hi" }],
                Model = "claude-test",
            },
            TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.messages.count_tokens");
        Assert.Equal("claude-test", span.GetTagItem("gen_ai.request.model"));
        Assert.Equal(21L, span.GetTagItem("anthropic.message.count_tokens.input_tokens"));
        Assert.Null(span.GetTagItem("gen_ai.operation.name"));
        Assert.Null(span.GetTagItem("gen_ai.usage.input_tokens"));
    }

    [Fact]
    public async Task Batches_RecordBatchId()
    {
        using var trace = new RecordedTrace();
        const string Batch = """
            {"id":"msgbatch_1","type":"message_batch","processing_status":"in_progress","request_counts":{"processing":1,"succeeded":0,"errored":0,"canceled":0,"expired":0},"created_at":"2026-01-01T00:00:00Z","expires_at":"2026-01-02T00:00:00Z","ended_at":null,"archived_at":null,"cancel_initiated_at":null,"results_url":null}
            """;
        var handler = new ScriptedHandler().RespondJson(Batch).RespondJson(Batch);
        var client = Fixtures.Client(handler);

        await client.Messages.Batches.Retrieve(
            "msgbatch_1",
            cancellationToken: TestContext.Current.CancellationToken
        );
        await client.Beta.Messages.Batches.Create(
            new()
            {
                Requests =
                [
                    new()
                    {
                        CustomID = "a",
                        Params = new()
                        {
                            MaxTokens = 1,
                            Messages = [new() { Role = Beta.Role.User, Content = "x" }],
                            Model = "claude-test",
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(
            "msgbatch_1",
            trace
                .Single("anthropic.messages.batches.retrieve")
                .GetTagItem("anthropic.message.batch.id")
        );
        // The beta namespace is not part of the span name.
        Assert.Equal(
            "msgbatch_1",
            trace
                .Single("anthropic.messages.batches.create")
                .GetTagItem("anthropic.message.batch.id")
        );
    }

    /// <summary>
    /// Collects in <paramref name="atStart"/> what a sampler sees of each span of
    /// <paramref name="trace"/>, by the span's name: the attributes that it starts with.
    /// </summary>
    static ActivityListener ListenToStarts(
        RecordedTrace trace,
        Dictionary<string, Dictionary<string, object?>> atStart
    )
    {
        var listener = new ActivityListener
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
        return listener;
    }

    static Anthropic.Models.Messages.Batches.Params BatchParams() =>
        new()
        {
            MaxTokens = 1,
            Messages = [new() { Role = Role.User, Content = "x" }],
            Model = "claude-test",
        };

    [Fact]
    public async Task BatchesCreateSpans_StartWithTheBatchRequestCount()
    {
        using var trace = new RecordedTrace();
        var atStart = new Dictionary<string, Dictionary<string, object?>>();
        using var listener = ListenToStarts(trace, atStart);
        var handler = new ScriptedHandler();
        foreach (
            var body in new[]
            {
                Fixtures.MessageJson,
                """{"id":"msgbatch_1"}""",
                """{"id":"msgbatch_2"}""",
                """{"id":"sesn_1"}""",
                """{"data":[],"next_page":null}""",
                """{"input_tokens": 21}""",
                """{"id":"msgbatch_1"}""",
                """{"data":[],"has_more":false,"first_id":null,"last_id":null}""",
                """{"data":[],"has_more":false,"first_id":null,"last_id":null}""",
                """{"id":"agent_1"}""",
            }
        )
        {
            handler.RespondJson(body);
        }
        var client = Fixtures.Client(handler);
        var cancellationToken = TestContext.Current.CancellationToken;

        await client.Messages.Create(MessageParams(), cancellationToken);
        await client.Messages.Batches.Create(
            new()
            {
                Requests =
                [
                    new() { CustomID = "a", Params = BatchParams() },
                    new() { CustomID = "b", Params = BatchParams() },
                ],
            },
            cancellationToken
        );
        await client.Beta.Messages.Batches.Create(
            new()
            {
                Requests =
                [
                    new()
                    {
                        CustomID = "a",
                        Params = new()
                        {
                            MaxTokens = 1,
                            Messages = [new() { Role = Beta.Role.User, Content = "x" }],
                            Model = "claude-test",
                        },
                    },
                ],
            },
            cancellationToken
        );
        await client.Beta.Sessions.Retrieve("sesn_1", cancellationToken: cancellationToken);
        await client.Beta.Sessions.Threads.Events.List(
            "sthr_1",
            new() { SessionID = "sesn_1" },
            cancellationToken
        );
        await client.Messages.CountTokens(
            new()
            {
                Messages = [new() { Role = Role.User, Content = "Hi" }],
                Model = "claude-test",
            },
            cancellationToken
        );
        await client.Messages.Batches.Retrieve("msgbatch_1", cancellationToken: cancellationToken);
        await client.Messages.Batches.List(cancellationToken: cancellationToken);
        await client.Models.List(cancellationToken: cancellationToken);
        await client.Beta.Agents.Retrieve("agent_1", cancellationToken: cancellationToken);

        // The beta call started last, and the beta namespace is not part of the span name.
        var batchesCreate = atStart["anthropic.messages.batches.create"];
        Assert.Equal(1, batchesCreate["anthropic.message.batch.request_count"]);
        Assert.Equal(
            [2, 1],
            trace
                .Spans.Where(span => span.OperationName == "anthropic.messages.batches.create")
                .Select(span => span.GetTagItem("anthropic.message.batch.request_count"))
        );
        Assert.All(
            [
                "anthropic.messages.create",
                "anthropic.sessions.retrieve",
                "anthropic.sessions.threads.events.list",
                "anthropic.messages.count_tokens",
                "anthropic.messages.batches.retrieve",
                "anthropic.messages.batches.list",
                "anthropic.models.list",
                "anthropic.agents.retrieve",
            ],
            name =>
                Assert.DoesNotContain("anthropic.message.batch.request_count", atStart[name].Keys)
        );
    }

    [Fact]
    public async Task BatchResults_SpanCoversTheDownload()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(
            HttpStatusCode.OK,
            BatchResult("a") + "\n" + BatchResult("b") + "\n",
            "req_r"
        );
        var client = Fixtures.Client(handler);

        var results = 0;
        await foreach (
            var _ in client.Messages.Batches.ResultsStreaming(
                "msgbatch_1",
                cancellationToken: TestContext.Current.CancellationToken
            )
        )
        {
            results++;
            // The span stays open while the results are read.
            Assert.Empty(trace.Spans);
        }

        Assert.Equal(2, results);
        var span = trace.Single("anthropic.messages.batches.results");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal(200, span.GetTagItem("http.response.status_code"));
        Assert.Equal("msgbatch_1", span.GetTagItem("anthropic.message.batch.id"));
        Assert.Equal("req_r", span.GetTagItem("anthropic.request.id"));
    }

    [Fact]
    public async Task BatchResults_FailureWhileReading_FailsTheSpan()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(_ => new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(
                new TornStream(Encoding.UTF8.GetBytes(BatchResult("a") + "\n"))
            ),
        });
        var client = Fixtures.Client(handler);

        var results = 0;
        await Assert.ThrowsAnyAsync<Exception>(async () =>
        {
            await foreach (
                var _ in client.Messages.Batches.ResultsStreaming(
                    "msgbatch_1",
                    cancellationToken: TestContext.Current.CancellationToken
                )
            )
            {
                results++;
            }
        });

        Assert.Equal(1, results);
        var span = trace.Single("anthropic.messages.batches.results");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("connection_error", span.GetTagItem("error.type"));
    }

    [Fact]
    public async Task BatchResults_DisposedUnread_LeaveTheStatusUnset()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(
            HttpStatusCode.OK,
            BatchResult("a") + "\n",
            "req_r"
        );
        var client = Fixtures.Client(handler);

        var results = await client.WithRawResponse.Messages.Batches.ResultsStreaming(
            "msgbatch_1",
            cancellationToken: TestContext.Current.CancellationToken
        );
        results.Dispose();

        var span = trace.Single("anthropic.messages.batches.results");
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Equal("msgbatch_1", span.GetTagItem("anthropic.message.batch.id"));
    }

    static string BatchResult(string customID) =>
        "{\"custom_id\":\"" + customID + "\",\"result\":{\"type\":\"expired\"}}";

    [Fact]
    public async Task ListenerRegisteredAfterTheClientWasCreated_StillGetsSpans()
    {
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(handler);
        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        using var trace = new RecordedTrace();
        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        trace.Single("anthropic.messages.create");
    }

    [Fact]
    public async Task ProviderName_ComesFromTheClient()
    {
        using var trace = new RecordedTrace();

        async Task<object?> ProviderName(AnthropicClient client)
        {
            var handler = new ScriptedHandler().RespondJson("{}");
            var configured = (AnthropicClient)
                client.WithOptions(options =>
                    options with
                    {
                        HttpClient = new HttpClient(handler),
                    }
                );
            var response = await configured.WithRawResponse.Execute(
                new HttpRequest<PingParams>
                {
                    Method = HttpMethod.Post,
                    Params = new(),
                    SpanName = "anthropic.messages.create",
                },
                TestContext.Current.CancellationToken
            );
            response.Dispose();
            return trace.Spans[trace.Spans.Count - 1].GetTagItem("gen_ai.provider.name");
        }

        Assert.Equal("anthropic", await ProviderName(new AnthropicClient { ApiKey = "k" }));
        Assert.Equal(
            "aws.bedrock",
            await ProviderName(
                new Anthropic.Bedrock.AnthropicBedrockClient(new BedrockCredentials())
            )
        );
        Assert.Equal(
            "gcp.vertex_ai",
            await ProviderName(new Anthropic.Vertex.AnthropicVertexClient(new VertexCredentials()))
        );
        Assert.Equal(
            "anthropic",
            await ProviderName(
                new Anthropic.Foundry.AnthropicFoundryClient(
                    new Anthropic.Foundry.AnthropicFoundryApiKeyCredentials("key", "resource")
                )
            )
        );
    }

    /// <summary>
    /// A client whose second attempt fails before it is sent, as a failed token exchange would.
    /// </summary>
    sealed class FailingSecondAttemptClient(ClientOptions options)
        : AnthropicClientWithRawResponse(options)
    {
        int _attempts;

        protected override ValueTask BeforeSend<T>(
            HttpRequest<T> request,
            HttpRequestMessage requestMessage,
            System.Threading.CancellationToken cancellationToken
        )
        {
            if (System.Threading.Interlocked.Increment(ref _attempts) == 2)
            {
                throw new InvalidOperationException("token exchange failed");
            }
            return base.BeforeSend(request, requestMessage, cancellationToken);
        }
    }

    sealed class BedrockCredentials : Anthropic.Bedrock.IAnthropicBedrockCredentials
    {
        public string Region => "us-east-1";

        public Task Apply(HttpRequestMessage requestMessage) => Task.CompletedTask;
    }

    sealed class VertexCredentials : Anthropic.Vertex.IAnthropicVertexCredentials
    {
        public string Region => "us-east5";
        public string Project => "test-project";

        public ValueTask ApplyAsync(HttpRequestMessage requestMessage) => default;
    }
}
