using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

public class ContentModeTest : TracingTestBase
{
    [Fact]
    public async Task MetadataOnly_RecordsNoContent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.MetadataOnly } }
        );

        await client.Messages.Create(
            MessageParams() with
            {
                StopSequences = ["END"],
            },
            TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.messages.create");
        Assert.Null(span.GetTagItem("gen_ai.input.messages"));
        Assert.Null(span.GetTagItem("gen_ai.output.messages"));
        Assert.Null(span.GetTagItem("gen_ai.system_instructions"));
        Assert.Null(span.GetTagItem("gen_ai.request.stop_sequences"));
        Assert.Null(span.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task ContentMode_RecordsRequestAndResponseContent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var parameters = MessageParams() with
        {
            StopSequences = ["END", "STOP"],
            Messages =
            [
                new UserMessageParam { Content = "What is the weather?" },
                new AssistantMessageParam
                {
                    Content = new List<ContentBlockParam>
                    {
                        new ToolUseBlockParam
                        {
                            ID = "toolu_0",
                            Name = "get_weather",
                            Input = new Dictionary<string, JsonElement>
                            {
                                ["city"] = JsonSerializer.SerializeToElement("Paris"),
                            },
                        },
                    },
                },
                new UserMessageParam
                {
                    Content = new List<ContentBlockParam>
                    {
                        new ToolResultBlockParam("toolu_0") { Content = "sunny" },
                        new ImageBlockParam(
                            new Base64ImageSource { Data = "AAAA", MediaType = MediaType.ImagePng }
                        ),
                        new DocumentBlockParam(new Base64PdfSource("AAAA")),
                    },
                },
            ],
        };

        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        AssertJson(
            """[{"type":"text","content":"Be brief."}]""",
            span.GetTagItem("gen_ai.system_instructions")
        );
        Assert.Equal(
            ["END", "STOP"],
            Assert.IsType<string[]>(span.GetTagItem("gen_ai.request.stop_sequences"))
        );
        AssertJson(
            """
            [
              {"role":"user","parts":[{"type":"text","content":"What is the weather?"}]},
              {"role":"assistant","parts":[{"type":"tool_call","id":"toolu_0","name":"get_weather","arguments":{"city":"Paris"}}]},
              {"role":"user","parts":[{"type":"tool_call_response","id":"toolu_0","response":[{"type":"text","text":"sunny"}]},{"type":"anthropic_image"},{"type":"anthropic_document"}]}
            ]
            """,
            span.GetTagItem("gen_ai.input.messages")
        );
        AssertJson(
            """
            [{"role":"assistant","parts":[{"type":"text","content":"Hi there"},{"type":"tool_call","id":"toolu_1","name":"get_weather","arguments":{"city":"Paris"}}]}]
            """,
            span.GetTagItem("gen_ai.output.messages")
        );
        Assert.Null(span.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task ContentMode_ToolResultPart_HoldsTheContentBlocksOfTheResult()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var parameters = MessageParams() with
        {
            Messages =
            [
                new UserMessageParam
                {
                    Content = new List<ContentBlockParam>
                    {
                        new ToolResultBlockParam("toolu_0")
                        {
                            Content = new ToolResultBlockParamContent(
                                JsonSerializer.Deserialize<JsonElement>(
                                    """
                                    [
                                      {"type":"text","text":"sunny","citations":[{"type":"char_location","cited_text":"sun","document_index":0,"document_title":"Almanac","start_char_index":0,"end_char_index":3},{"type":"web_search_result_location","cited_text":"sun","encrypted_index":"enc_index","title":"Weather","url":"https://example.com"}],"cache_control":{"type":"ephemeral"}},
                                      {"type":"search_result","source":"https://example.com","title":"Weather","content":[{"type":"text","text":"Sunny all day"}]},
                                      {"type":"image","source":{"type":"base64","media_type":"image/png","data":"AAAA"}}
                                    ]
                                    """
                                )
                            ),
                        },
                        new ToolResultBlockParam("toolu_1"),
                    },
                },
            ],
        };

        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);

        // A text block and a search result block keep all their fields, except those whose name
        // starts with `encrypted_`. Any other block has only its type, without a prefix. A result
        // without content is an empty list.
        AssertJson(
            """
            [
              {"role":"user","parts":[
                {"type":"tool_call_response","id":"toolu_0","response":[
                  {"type":"text","text":"sunny","citations":[{"type":"char_location","cited_text":"sun","document_index":0,"document_title":"Almanac","start_char_index":0,"end_char_index":3},{"type":"web_search_result_location","cited_text":"sun","title":"Weather","url":"https://example.com"}],"cache_control":{"type":"ephemeral"}},
                  {"type":"search_result","source":"https://example.com","title":"Weather","content":[{"type":"text","text":"Sunny all day"}]},
                  {"type":"image"}
                ]},
                {"type":"tool_call_response","id":"toolu_1","response":[]}
              ]}
            ]
            """,
            trace.Single("anthropic.messages.create").GetTagItem("gen_ai.input.messages")
        );
    }

    const string ServerToolBlocks = """
        {"type":"server_tool_use","id":"srvtoolu_1","name":"web_search","toolset_name":"computer","input":{"query":"weather"}},
        {"type":"web_search_tool_result","tool_use_id":"srvtoolu_1","content":[
          {"type":"web_search_result","title":"Weather","url":"https://example.com","encrypted_content":"enc_page","page_age":null},
          {"type":"image","source":{"type":"base64","media_type":"image/png","data":"AAAA"}}
        ]},
        {"type":"mcp_tool_use","id":"mcptoolu_1","name":"lookup","server_name":"almanac","toolset_name":"computer","input":{"q":"x"}},
        {"type":"mcp_tool_result","tool_use_id":"mcptoolu_1","is_error":false,"content":"sunny"}
        """;

    const string ServerToolParts = """
        {"type":"tool_call","id":"srvtoolu_1","name":"web_search","arguments":{"query":"weather"}},
        {"type":"tool_call_response","id":"srvtoolu_1","response":[
          {"type":"web_search_result","title":"Weather","url":"https://example.com","page_age":null},
          {"type":"image"}
        ]},
        {"type":"tool_call","id":"mcptoolu_1","name":"lookup","arguments":{"q":"x"},"anthropic_mcp_server_name":"almanac"},
        {"type":"tool_call_response","id":"mcptoolu_1","response":[{"type":"text","text":"sunny"}]}
        """;

    [Fact]
    public async Task ContentMode_RecordsServerAndMcpToolBlocksAsToolCallsAndResponses()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(
            Fixtures.MessageJson.Replace(
                """{"type": "text", "text": "Hi there"},""",
                ServerToolBlocks
                    + """
                    ,
                    {"type":"code_execution_tool_result","tool_use_id":"srvtoolu_2","content":{"type":"code_execution_result","stdout":"4\n","stderr":"","return_code":0,"content":[{"type":"code_execution_output","file_id":"file_1"}]}},
                    {"type":"code_execution_tool_result","tool_use_id":"srvtoolu_3","content":{"type":"encrypted_code_execution_result","encrypted_stdout":"enc_stdout","stderr":"","return_code":0,"content":[]}},
                    {"type":"web_search_tool_result","tool_use_id":"srvtoolu_4","content":{"type":"web_search_tool_result_error","error_code":"max_uses_exceeded"}},
                    {"type":"web_fetch_tool_result","tool_use_id":"srvtoolu_5","content":{"type":"web_fetch_result","url":"https://example.com","retrieved_at":null,"content":{"type":"document","source":{"type":"base64","media_type":"application/pdf","data":"AAAA"},"title":"Weather"}}},
                    {"type":"text_editor_code_execution_tool_result","tool_use_id":"srvtoolu_6","content":{"type":"text_editor_code_execution_view_result","file_type":"image","content":"AAAA","num_lines":null,"start_line":null,"total_lines":null}},
                    {"type":"mcp_tool_result","tool_use_id":"mcptoolu_2","is_error":true,"content":[{"type":"text","text":"no such city"}]},
                    {"type":"mcp_tool_result","tool_use_id":"mcptoolu_3","is_error":false},
                    """
            )
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var parameters = BetaParams() with
        {
            Messages = JsonSerializer.Deserialize<List<Beta.BetaMessageParam>>(
                """
                [
                  {"role":"user","content":"Weather?"},
                  {"role":"assistant","content":[BLOCKS]},
                  {"role":"user","content":"And tomorrow?"}
                ]
                """.Replace("BLOCKS", ServerToolBlocks),
                ModelBase.SerializerOptions
            )!,
        };

        await client.Beta.Messages.Create(parameters, TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        AssertJson(
            """
            [
              {"role":"user","parts":[{"type":"text","content":"Weather?"}]},
              {"role":"assistant","parts":[PARTS]},
              {"role":"user","parts":[{"type":"text","content":"And tomorrow?"}]}
            ]
            """.Replace("PARTS", ServerToolParts),
            span.GetTagItem("gen_ai.input.messages")
        );
        // A result's one object is kept, without a field whose name starts with `encrypted_` and
        // without image or document data. A result without content is an empty list.
        AssertJson(
            """
            [{"role":"assistant","parts":[
              PARTS,
              {"type":"tool_call_response","id":"srvtoolu_2","response":{"type":"code_execution_result","stdout":"4\n","stderr":"","return_code":0,"content":[{"type":"code_execution_output","file_id":"file_1"}]}},
              {"type":"tool_call_response","id":"srvtoolu_3","response":{"type":"encrypted_code_execution_result","stderr":"","return_code":0,"content":[]}},
              {"type":"tool_call_response","id":"srvtoolu_4","response":{"type":"web_search_tool_result_error","error_code":"max_uses_exceeded"}},
              {"type":"tool_call_response","id":"srvtoolu_5","response":{"type":"web_fetch_result","url":"https://example.com","retrieved_at":null,"content":{"type":"document"}}},
              {"type":"tool_call_response","id":"srvtoolu_6","response":{"type":"text_editor_code_execution_view_result","file_type":"image","num_lines":null,"start_line":null,"total_lines":null}},
              {"type":"tool_call_response","id":"mcptoolu_2","response":[{"type":"text","text":"no such city"}]},
              {"type":"tool_call_response","id":"mcptoolu_3","response":[]},
              {"type":"tool_call","id":"toolu_1","name":"get_weather","arguments":{"city":"Paris"}}
            ]}]
            """.Replace("PARTS", ServerToolParts),
            span.GetTagItem("gen_ai.output.messages")
        );
        Assert.DoesNotContain(span.TagObjects, tag => $"{tag.Value}".Contains("enc_"));
        Assert.DoesNotContain(span.TagObjects, tag => $"{tag.Value}".Contains("AAAA"));
    }

    [Fact]
    public async Task ContentMode_BetaStream_RecordsServerAndMcpToolBlocks()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(
                Fixtures.MessageStart,
                (
                    "content_block_start",
                    """{"type":"content_block_start","index":0,"content_block":{"type":"server_tool_use","id":"srvtoolu_1","name":"web_search","toolset_name":"computer","input":{}}}"""
                ),
                (
                    "content_block_delta",
                    """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"query\":"}}"""
                ),
                (
                    "content_block_delta",
                    """{"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"\"weather\"}"}}"""
                ),
                ("content_block_stop", """{"type":"content_block_stop","index":0}"""),
                (
                    "content_block_start",
                    """{"type":"content_block_start","index":1,"content_block":{"type":"web_search_tool_result","tool_use_id":"srvtoolu_1","content":[{"type":"web_search_result","title":"Weather","url":"https://example.com","encrypted_content":"enc_page","page_age":null},{"type":"image","source":{"type":"base64","media_type":"image/png","data":"AAAA"}}]}}"""
                ),
                ("content_block_stop", """{"type":"content_block_stop","index":1}"""),
                (
                    "content_block_start",
                    """{"type":"content_block_start","index":2,"content_block":{"type":"mcp_tool_use","id":"mcptoolu_1","name":"lookup","server_name":"almanac","toolset_name":"computer","input":{}}}"""
                ),
                (
                    "content_block_delta",
                    """{"type":"content_block_delta","index":2,"delta":{"type":"input_json_delta","partial_json":"{\"q\":\"x\"}"}}"""
                ),
                ("content_block_stop", """{"type":"content_block_stop","index":2}"""),
                (
                    "content_block_start",
                    """{"type":"content_block_start","index":3,"content_block":{"type":"mcp_tool_result","tool_use_id":"mcptoolu_1","is_error":false,"content":"sunny"}}"""
                ),
                ("content_block_stop", """{"type":"content_block_stop","index":3}"""),
                (
                    "message_delta",
                    """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":12}}"""
                ),
                ("message_stop", """{"type":"message_stop"}""")
            )
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                BetaParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        AssertJson(
            """[{"role":"assistant","parts":[PARTS]}]""".Replace("PARTS", ServerToolParts),
            span.GetTagItem("gen_ai.output.messages")
        );
        Assert.DoesNotContain(span.TagObjects, tag => $"{tag.Value}".Contains("enc_page"));
    }

    const string ToolUses = """
        {"type":"tool_use","id":"toolu_3","name":"screenshot","toolset_name":"computer","input":{}},
        {"type":"tool_use","id":"toolu_4","name":"get_time","toolset_name":null,"input":{}},
        {"type":"tool_use","id":"toolu_5","name":"get_date","input":{"zone":"UTC"}}
        """;

    const string ToolResults = """
        {"type":"tool_result","tool_use_id":"toolu_3","toolset_name":"computer","content":"ok"},
        {"type":"tool_result","tool_use_id":"toolu_4","content":"noon"},
        {"type":"tool_result","tool_use_id":"toolu_5","content":"Monday"}
        """;

    const string ToolUseMessages = """
        [
          {"role":"user","content":"What is on the screen?"},
          {"role":"assistant","content":[TOOL_USES]},
          {"role":"user","content":[TOOL_RESULTS]}
        ]
        """;

    // Only the tool use whose `toolset_name` is a string has the name, after `arguments`.
    const string ToolCalls = """
        {"type":"tool_call","id":"toolu_3","name":"screenshot","arguments":{},"anthropic_toolset_name":"computer"},
        {"type":"tool_call","id":"toolu_4","name":"get_time","arguments":{}},
        {"type":"tool_call","id":"toolu_5","name":"get_date","arguments":{"zone":"UTC"}}
        """;

    // The response of a tool result with a `toolset_name` does not have the name.
    const string ToolUseInputMessages = """
        [
          {"role":"user","parts":[{"type":"text","content":"What is on the screen?"}]},
          {"role":"assistant","parts":[TOOL_CALLS]},
          {"role":"user","parts":[
            {"type":"tool_call_response","id":"toolu_3","response":[{"type":"text","text":"ok"}]},
            {"type":"tool_call_response","id":"toolu_4","response":[{"type":"text","text":"noon"}]},
            {"type":"tool_call_response","id":"toolu_5","response":[{"type":"text","text":"Monday"}]}
          ]}
        ]
        """;

    [Fact]
    public async Task ContentMode_ToolCallOfAToolUse_HasItsToolsetNameOnlyWhenThatIsAString()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(
            Fixtures.MessageJson.Replace(
                """{"type": "text", "text": "Hi there"},""",
                ToolUses + ","
            )
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var parameters = MessageParams() with
        {
            Messages = JsonSerializer.Deserialize<List<MessageParam>>(
                ToolUseMessages.Replace("TOOL_USES", ToolUses).Replace("TOOL_RESULTS", ToolResults),
                ModelBase.SerializerOptions
            )!,
        };

        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        AssertJson(
            ToolUseInputMessages.Replace("TOOL_CALLS", ToolCalls),
            span.GetTagItem("gen_ai.input.messages")
        );
        AssertJson(
            """
            [{"role":"assistant","parts":[
              TOOL_CALLS,
              {"type":"tool_call","id":"toolu_1","name":"get_weather","arguments":{"city":"Paris"}}
            ]}]
            """.Replace("TOOL_CALLS", ToolCalls),
            span.GetTagItem("gen_ai.output.messages")
        );
    }

    [Fact]
    public async Task ContentMode_BetaStream_ToolCallOfAToolUse_HasItsToolsetNameOnlyWhenThatIsAString()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(
                Fixtures.MessageStart,
                (
                    "content_block_start",
                    """{"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"toolu_3","name":"screenshot","toolset_name":"computer","input":{}}}"""
                ),
                ("content_block_stop", """{"type":"content_block_stop","index":0}"""),
                (
                    "content_block_start",
                    """{"type":"content_block_start","index":1,"content_block":{"type":"tool_use","id":"toolu_4","name":"get_time","toolset_name":null,"input":{}}}"""
                ),
                ("content_block_stop", """{"type":"content_block_stop","index":1}"""),
                (
                    "content_block_start",
                    """{"type":"content_block_start","index":2,"content_block":{"type":"tool_use","id":"toolu_5","name":"get_date","input":{}}}"""
                ),
                (
                    "content_block_delta",
                    """{"type":"content_block_delta","index":2,"delta":{"type":"input_json_delta","partial_json":"{\"zone\":\"UTC\"}"}}"""
                ),
                ("content_block_stop", """{"type":"content_block_stop","index":2}"""),
                (
                    "message_delta",
                    """{"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":12}}"""
                ),
                ("message_stop", """{"type":"message_stop"}""")
            )
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var parameters = BetaParams() with
        {
            Messages = JsonSerializer.Deserialize<List<Beta.BetaMessageParam>>(
                ToolUseMessages.Replace("TOOL_USES", ToolUses).Replace("TOOL_RESULTS", ToolResults),
                ModelBase.SerializerOptions
            )!,
        };

        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                parameters,
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        AssertJson(
            ToolUseInputMessages.Replace("TOOL_CALLS", ToolCalls),
            span.GetTagItem("gen_ai.input.messages")
        );
        AssertJson(
            """[{"role":"assistant","parts":[TOOL_CALLS]}]""".Replace("TOOL_CALLS", ToolCalls),
            span.GetTagItem("gen_ai.output.messages")
        );
    }

    [Fact]
    public async Task ContentMode_RecordsThinkingAsReasoningParts_WithoutSignaturesOrRedactedData()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(
            Fixtures.MessageJson.Replace(
                """{"type": "text", "text": "Hi there"},""",
                """
                {"type": "thinking", "thinking": "Paris again", "signature": "sig_out"},
                {"type": "thinking", "thinking": "", "signature": "sig_hidden"},
                {"type": "redacted_thinking", "data": "enc_out"},
                {"type": "text", "text": "Hi there"},
                """
            )
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var parameters = MessageParams() with
        {
            Messages =
            [
                new UserMessageParam { Content = "What is the weather?" },
                new AssistantMessageParam
                {
                    Content = new List<ContentBlockParam>
                    {
                        new ThinkingBlockParam { Thinking = "Which city?", Signature = "sig_in" },
                        new RedactedThinkingBlockParam { Data = "enc_in" },
                        new TextBlockParam { Text = "Which city?" },
                    },
                },
                new UserMessageParam { Content = "Paris" },
            ],
        };

        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        AssertJson(
            """
            [
              {"role":"user","parts":[{"type":"text","content":"What is the weather?"}]},
              {"role":"assistant","parts":[{"type":"reasoning","content":"Which city?"},{"type":"anthropic_redacted_thinking"},{"type":"text","content":"Which city?"}]},
              {"role":"user","parts":[{"type":"text","content":"Paris"}]}
            ]
            """,
            span.GetTagItem("gen_ai.input.messages")
        );
        // A hidden thinking block has no thinking text, and keeps its part.
        AssertJson(
            """
            [{"role":"assistant","parts":[{"type":"reasoning","content":"Paris again"},{"type":"reasoning","content":""},{"type":"anthropic_redacted_thinking"},{"type":"text","content":"Hi there"},{"type":"tool_call","id":"toolu_1","name":"get_weather","arguments":{"city":"Paris"}}]}]
            """,
            span.GetTagItem("gen_ai.output.messages")
        );
        Assert.DoesNotContain(span.TagObjects, tag => $"{tag.Value}".Contains("sig_"));
        Assert.DoesNotContain(span.TagObjects, tag => $"{tag.Value}".Contains("enc_"));
    }

    [Fact]
    public async Task MetadataOnly_RecordsNoThinking()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(
            Fixtures.MessageJson.Replace(
                """{"type": "text", "text": "Hi there"},""",
                """{"type": "thinking", "thinking": "Paris again", "signature": "sig_out"},"""
            )
        );
        var client = Fixtures.Client(handler);

        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        Assert.Null(span.GetTagItem("gen_ai.output.messages"));
        Assert.DoesNotContain(span.TagObjects, tag => $"{tag.Value}".Contains("Paris again"));
    }

    [Fact]
    public async Task ContentMode_Stream_BuildsOutputFromEvents_AndOtherBlocksKeepTheirTypeOnly()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        AssertJson(
            """
            [{"role":"assistant","parts":[{"type":"text","content":"Hello world"},{"type":"tool_call","id":"toolu_9","name":"lookup","arguments":{"q":"x"}},{"type":"reasoning","content":"Let me think"},{"type":"anthropic_redacted_thinking"}]}]
            """,
            span.GetTagItem("gen_ai.output.messages")
        );
        // The span leaves out the thinking block's signature and the redacted thinking's data.
        Assert.DoesNotContain(span.TagObjects, tag => $"{tag.Value}".Contains("sig_stream"));
        Assert.DoesNotContain(span.TagObjects, tag => $"{tag.Value}".Contains("enc_stream"));
        AssertJson(
            """[{"role":"user","parts":[{"type":"text","content":"Hello"}]}]""",
            span.GetTagItem("gen_ai.input.messages")
        );
    }

    [Fact]
    public async Task ContentMode_Stream_RecordsTheSameOutputAsTheMessageReadWhole()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        var events = new List<RawMessageStreamEvent>();
        await foreach (
            var streamEvent in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        )
        {
            events.Add(streamEvent);
        }
        // The same Message, as the application's own `Aggregate()` gives it, read whole.
        var message = await Replay(events).Aggregate();
        handler.RespondJson(JsonSerializer.Serialize(message, ModelBase.SerializerOptions));
        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        Assert.Equal(2, trace.Spans.Count);
        AssertJson(
            """
            [{"role":"assistant","parts":[{"type":"text","content":"Hello world"},{"type":"tool_call","id":"toolu_9","name":"lookup","arguments":{"q":"x"}},{"type":"reasoning","content":"Let me think"},{"type":"anthropic_redacted_thinking"}]}]
            """,
            trace.Spans[0].GetTagItem("gen_ai.output.messages")
        );
        Assert.Equal(
            trace.Spans[1].GetTagItem("gen_ai.output.messages"),
            trace.Spans[0].GetTagItem("gen_ai.output.messages")
        );
    }

    [Fact]
    public async Task ContentMode_BetaStream_RecordsTheSameOutputAsTheMessageReadWhole()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        var events = new List<Beta.BetaRawMessageStreamEvent>();
        await foreach (
            var streamEvent in client.Beta.Messages.CreateStreaming(
                BetaParams(),
                TestContext.Current.CancellationToken
            )
        )
        {
            events.Add(streamEvent);
        }
        var message = await Replay(events).Aggregate();
        handler.RespondJson(JsonSerializer.Serialize(message, ModelBase.SerializerOptions));
        await client.Beta.Messages.Create(BetaParams(), TestContext.Current.CancellationToken);

        Assert.Equal(2, trace.Spans.Count);
        AssertJson(
            """
            [{"role":"assistant","parts":[{"type":"text","content":"Hello world"},{"type":"tool_call","id":"toolu_9","name":"lookup","arguments":{"q":"x"}},{"type":"reasoning","content":"Let me think"},{"type":"anthropic_redacted_thinking"}]}]
            """,
            trace.Spans[0].GetTagItem("gen_ai.output.messages")
        );
        Assert.Equal(
            trace.Spans[1].GetTagItem("gen_ai.output.messages"),
            trace.Spans[0].GetTagItem("gen_ai.output.messages")
        );
        AssertJson(
            """[{"role":"user","parts":[{"type":"text","content":"Weather?"}]}]""",
            trace.Spans[0].GetTagItem("gen_ai.input.messages")
        );
    }

    [Fact]
    public async Task MetadataOnly_Stream_RecordsNoContent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(handler);

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.Null(span.GetTagItem("gen_ai.input.messages"));
        Assert.Null(span.GetTagItem("gen_ai.output.messages"));
        Assert.Null(span.GetTagItem("gen_ai.system_instructions"));
    }

    [Theory]
    // A text delta without its text: taking the event in fails.
    [InlineData("""{"type":"content_block_delta","index":0,"delta":{"type":"text_delta"}}""")]
    // A delta of a block that never started: making the Message fails at the end.
    [InlineData(
        """{"type":"content_block_delta","index":7,"delta":{"type":"text_delta","text":"x"}}"""
    )]
    public async Task ContentMode_Stream_EventsThatMakeNoMessage_RecordNoOutput(string malformed)
    {
        using var trace = new RecordedTrace();
        (string, string)[] body =
        [
            .. Fixtures.StreamBody.Take(3),
            ("content_block_delta", malformed),
            .. Fixtures.StreamBody.Skip(3),
        ];
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(body));
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        var read = 0;
        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        )
        {
            read++;
        }

        // The application reads every event, and the span keeps all but the output content.
        Assert.Equal(body.Length, read);
        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
        Assert.Equal(12L, span.GetTagItem("gen_ai.usage.output_tokens"));
        Assert.Equal("tool_use", span.GetTagItem("anthropic.message.stop_reason"));
        Assert.Null(span.GetTagItem("gen_ai.response.finish_reasons"));
        Assert.NotNull(span.GetTagItem("gen_ai.input.messages"));
        Assert.Null(span.GetTagItem("gen_ai.output.messages"));
    }

    [Theory]
    // After a text delta.
    [InlineData(3, """[{"type":"text","content":"Hello"}]""")]
    // Inside a tool use block, which has the input that it started with until all of it arrived.
    [InlineData(
        7,
        """[{"type":"text","content":"Hello world"},{"type":"tool_call","id":"toolu_9","name":"lookup","arguments":{}}]"""
    )]
    // After `message_delta`.
    [InlineData(
        17,
        """[{"type":"text","content":"Hello world"},{"type":"tool_call","id":"toolu_9","name":"lookup","arguments":{"q":"x"}},{"type":"reasoning","content":"Let me think"},{"type":"anthropic_redacted_thinking"}]"""
    )]
    public async Task ContentMode_StreamEndedBeforeMessageStop_RecordsTheOutputBuiltSoFar(
        int events,
        string parts
    )
    {
        using var trace = new RecordedTrace();
        var body = Fixtures.Sse([.. Fixtures.StreamBody.Take(events)]);
        var handler = new ScriptedHandler().RespondStream(body).RespondStream(body);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }
        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                BetaParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        Assert.Equal(2, trace.Spans.Count);
        Assert.All(
            trace.Spans,
            span =>
            {
                Assert.Equal(ActivityStatusCode.Error, span.Status);
                Assert.Equal("api_error", span.GetTagItem("error.type"));
                Assert.Equal("msg_s", span.GetTagItem("gen_ai.response.id"));
                // Only `message_delta`, the 17th event, says how the output went.
                var afterMessageDelta = events >= 17;
                Assert.Equal(
                    afterMessageDelta ? "tool_use" : null,
                    span.GetTagItem("anthropic.message.stop_reason")
                );
                Assert.Equal(
                    afterMessageDelta ? 12L : null,
                    span.GetTagItem("gen_ai.usage.output_tokens")
                );
                Assert.NotNull(span.GetTagItem("gen_ai.input.messages"));
                AssertJson(AssistantMessage(parts), span.GetTagItem("gen_ai.output.messages"));
            }
        );
    }

    [Fact]
    public async Task ContentMode_StreamEndedBeforeMessageStart_RecordsRequestContentOnly()
    {
        using var trace = new RecordedTrace();
        var body = Fixtures.Sse([.. Fixtures.StreamBody.Skip(1).Take(2)]);
        var handler = new ScriptedHandler().RespondStream(body).RespondStream(body);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }
        await foreach (
            var _ in client.Beta.Messages.CreateStreaming(
                BetaParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        Assert.Equal(2, trace.Spans.Count);
        Assert.All(
            trace.Spans,
            span =>
            {
                Assert.Equal("api_error", span.GetTagItem("error.type"));
                Assert.NotNull(span.GetTagItem("gen_ai.input.messages"));
                Assert.Null(span.GetTagItem("gen_ai.output.messages"));
            }
        );
    }

    [Fact]
    public async Task ContentMode_StreamEndedByAnErrorEvent_RecordsTheOutputBuiltSoFar()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse([.. Fixtures.StreamBody.Take(4), ("error", Fixtures.ErrorJson.Trim())])
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

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
        AssertJson(
            AssistantMessage("""[{"type":"text","content":"Hello world"}]"""),
            span.GetTagItem("gen_ai.output.messages")
        );
    }

    [Fact]
    public async Task ContentMode_StreamWhoseReadFails_RecordsTheOutputBuiltSoFar()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondTornStream(
            Fixtures.Sse([.. Fixtures.StreamBody.Take(3)])
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await Assert.ThrowsAnyAsync<Exception>(async () =>
        {
            await foreach (
                var _ in client.Beta.Messages.CreateStreaming(
                    BetaParams(),
                    TestContext.Current.CancellationToken
                )
            ) { }
        });

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("connection_error", span.GetTagItem("error.type"));
        AssertJson(
            AssistantMessage("""[{"type":"text","content":"Hello"}]"""),
            span.GetTagItem("gen_ai.output.messages")
        );
    }

    [Fact]
    public async Task ContentMode_StreamClosedEarlyByTheApplication_RecordsTheOutputBuiltSoFar()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(Fixtures.Sse(Fixtures.StreamBody));
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await foreach (
            var streamEvent in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        )
        {
            if (streamEvent.TryPickContentBlockDelta(out _))
            {
                break;
            }
        }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
        Assert.NotNull(span.GetTagItem("gen_ai.input.messages"));
        AssertJson(
            AssistantMessage("""[{"type":"text","content":"Hello"}]"""),
            span.GetTagItem("gen_ai.output.messages")
        );
    }

    [Fact]
    public async Task ContentMode_StreamCanceledWhileReading_RecordsTheOutputBuiltSoFar()
    {
        using var trace = new RecordedTrace();
        // The body holds no more than the events below: the read for more finds the cancellation.
        var handler = new ScriptedHandler().RespondTornStream(
            Fixtures.Sse([.. Fixtures.StreamBody.Take(3)])
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );

        await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
        {
            await foreach (
                var streamEvent in client.Messages.CreateStreaming(MessageParams(), cts.Token)
            )
            {
                if (streamEvent.TryPickContentBlockDelta(out _))
                {
                    cts.Cancel();
                }
            }
        });

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(ActivityStatusCode.Unset, span.Status);
        Assert.Null(span.GetTagItem("error.type"));
        AssertJson(
            AssistantMessage("""[{"type":"text","content":"Hello"}]"""),
            span.GetTagItem("gen_ai.output.messages")
        );
    }

    // Outside content mode nothing builds a Message from the events of a stream.
    [Fact]
    public async Task MetadataOnly_StreamEndedBeforeMessageStop_RecordsNoContent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse([.. Fixtures.StreamBody.Take(3)])
        );
        var client = Fixtures.Client(handler);

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        Assert.Equal("api_error", span.GetTagItem("error.type"));
        Assert.Null(span.GetTagItem("gen_ai.input.messages"));
        Assert.Null(span.GetTagItem("gen_ai.output.messages"));
    }

    [Fact]
    public async Task ContentMode_ErrorResponse_RecordsRequestContentOnly()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(
            HttpStatusCode.BadRequest,
            Fixtures.ErrorJson,
            "req_err"
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken)
        );

        var span = trace.Single("anthropic.messages.create");
        Assert.NotNull(span.GetTagItem("gen_ai.input.messages"));
        Assert.Null(span.GetTagItem("gen_ai.output.messages"));
    }

    [Fact]
    public async Task ContentMode_RemovesTheOldestPartsOverTheSizeBound()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var big = new string('x', 225_000);
        var parameters = MessageParams() with
        {
            Messages =
            [
                new UserMessageParam { Content = "1" + big },
                new AssistantMessageParam { Content = "2" + big },
                new UserMessageParam { Content = "3" + big },
                new AssistantMessageParam { Content = "4" + big },
                new UserMessageParam { Content = "5" },
            ],
        };

        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        var input = JsonDocument
            .Parse((string)span.GetTagItem("gen_ai.input.messages")!)
            .RootElement;
        // Four messages of 225 kB exceed 0.75 MB; removing the system instructions and the part of
        // the oldest message is enough. The emptied list and the message without parts stay, the
        // span says that it was reduced, and no message holds a marker.
        Assert.Equal("[]", span.GetTagItem("gen_ai.system_instructions"));
        Assert.Equal(5, input.GetArrayLength());
        Assert.Equal("user", input[0].GetProperty("role").GetString());
        Assert.Equal(0, input[0].GetProperty("parts").GetArrayLength());
        var secondParts = input[1].GetProperty("parts");
        Assert.Equal(1, secondParts.GetArrayLength());
        Assert.Equal("2" + big, secondParts[0].GetProperty("content").GetString());
        Assert.Equal("5", input[4].GetProperty("parts")[0].GetProperty("content").GetString());
        Assert.True(
            ((string)span.GetTagItem("gen_ai.input.messages")!).Length
                <= Anthropic.Core.Telemetry.Content.ContentLimit
        );
        Assert.Equal(true, span.GetTagItem("anthropic.content.truncated"));
        // The response is small, and whole.
        AssertJson(
            """
            [{"role":"assistant","parts":[{"type":"text","content":"Hi there"},{"type":"tool_call","id":"toolu_1","name":"get_weather","arguments":{"city":"Paris"}}]}]
            """,
            span.GetTagItem("gen_ai.output.messages")
        );
    }

    [Fact]
    public async Task ContentMode_RemovesOutputPartsFromTheStartWhenNoRequestPartIsLeftOverTheSizeBound()
    {
        using var trace = new RecordedTrace();
        var big = new string('y', 350_000);
        var handler = new ScriptedHandler().RespondJson(
            MessageJsonOfTextBlocks("1" + big, "2" + big, "3" + big)
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var parameters = MessageParams() with
        {
            Messages =
            [
                new UserMessageParam { Content = "1" },
                new AssistantMessageParam { Content = "2" },
                new UserMessageParam { Content = new string('x', 300_000) },
            ],
        };

        await client.Messages.Create(parameters, TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        // The output of three parts of 350 kB alone exceeds 0.75 MB: the system instructions and
        // every input part go first, the emptied list and messages stay in their attributes, and
        // then the first output part goes, whole. The newest parts stay whole.
        Assert.Equal("[]", span.GetTagItem("gen_ai.system_instructions"));
        AssertJson(
            """[{"role":"user","parts":[]},{"role":"assistant","parts":[]},{"role":"user","parts":[]}]""",
            span.GetTagItem("gen_ai.input.messages")
        );
        var output = Assert.IsType<string>(span.GetTagItem("gen_ai.output.messages"));
        var outputMessages = JsonDocument.Parse(output).RootElement;
        Assert.Equal(1, outputMessages.GetArrayLength());
        var outputParts = outputMessages[0].GetProperty("parts");
        Assert.Equal(2, outputParts.GetArrayLength());
        Assert.Equal("2" + big, outputParts[0].GetProperty("content").GetString());
        Assert.Equal("3" + big, outputParts[1].GetProperty("content").GetString());
        Assert.True(output.Length <= Anthropic.Core.Telemetry.Content.ContentLimit);
        Assert.Equal(true, span.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task ContentMode_OneOutputPartOverTheSizeBound_KeepsItsStart()
    {
        using var trace = new RecordedTrace();
        var huge = new string('y', Anthropic.Core.Telemetry.Content.ContentLimit + 10);
        var handler = new ScriptedHandler().RespondJson(MessageJsonOfTextBlocks(huge));
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        // The one output part alone is over the limit: the system instructions and the input
        // part go, and it is the one part left, a text part, which keeps the start that fits. The
        // emptied list and the message without parts stay in their attributes.
        var system = Assert.IsType<string>(span.GetTagItem("gen_ai.system_instructions"));
        Assert.Equal("[]", system);
        var input = Assert.IsType<string>(span.GetTagItem("gen_ai.input.messages"));
        Assert.Equal("""[{"role":"user","parts":[]}]""", input);
        var output = Assert.IsType<string>(span.GetTagItem("gen_ai.output.messages"));
        var outputParts = JsonDocument.Parse(output).RootElement[0].GetProperty("parts");
        Assert.Equal(1, outputParts.GetArrayLength());
        var kept = outputParts[0].GetProperty("content").GetString()!;
        Assert.NotEmpty(kept);
        Assert.StartsWith(kept, huge);
        Assert.Equal(
            Anthropic.Core.Telemetry.Content.ContentLimit,
            output.Length + system.Length + input.Length
        );
        Assert.Equal(true, span.GetTagItem("anthropic.content.truncated"));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task MaxContentBytes_ThatTheOptionsSet_IsTheSizeBoundInPlaceOfTheDefault(
        bool streaming
    )
    {
        using var trace = new RecordedTrace();
        var text = new string('y', 3000);
        var handler = streaming
            ? new ScriptedHandler().RespondStream(Fixtures.Sse(TextBlocksStream(text)))
            : new ScriptedHandler().RespondJson(MessageJsonOfTextBlocks(text));
        var client = Fixtures.Client(
            handler,
            new()
            {
                Traces = new()
                {
                    ContentMode = OpenTelemetryContentMode.Content,
                    MaxContentBytes = 2000,
                },
            }
        );

        if (streaming)
        {
            await foreach (
                var _ in client.Messages.CreateStreaming(
                    MessageParams(),
                    TestContext.Current.CancellationToken
                )
            ) { }
        }
        else
        {
            await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);
        }

        var span = trace.Single("anthropic.messages.create");
        // The one output part alone is over 2000, far under the default: it keeps the start that
        // fits, and the content is exactly at the bound.
        var system = Assert.IsType<string>(span.GetTagItem("gen_ai.system_instructions"));
        var input = Assert.IsType<string>(span.GetTagItem("gen_ai.input.messages"));
        var output = Assert.IsType<string>(span.GetTagItem("gen_ai.output.messages"));
        Assert.Equal("[]", system);
        Assert.Equal("""[{"role":"user","parts":[]}]""", input);
        var kept = JsonDocument
            .Parse(output)
            .RootElement[0]
            .GetProperty("parts")[0]
            .GetProperty("content")
            .GetString()!;
        Assert.NotEmpty(kept);
        Assert.StartsWith(kept, text);
        Assert.Equal(2000, output.Length + system.Length + input.Length);
        Assert.Equal(true, span.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task MaxContentBytes_CountsTheBytesOfUtf8OfTextThatIsWrittenAsItIsTyped()
    {
        using var trace = new RecordedTrace();
        var text = new string('\u00e9', 3000);
        var handler = new ScriptedHandler().RespondJson(MessageJsonOfTextBlocks(text));
        var client = Fixtures.Client(
            handler,
            new()
            {
                Traces = new()
                {
                    ContentMode = OpenTelemetryContentMode.Content,
                    MaxContentBytes = 2000,
                },
            }
        );

        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        var system = Assert.IsType<string>(span.GetTagItem("gen_ai.system_instructions"));
        var input = Assert.IsType<string>(span.GetTagItem("gen_ai.input.messages"));
        var output = Assert.IsType<string>(span.GetTagItem("gen_ai.output.messages"));
        var kept = JsonDocument
            .Parse(output)
            .RootElement[0]
            .GetProperty("parts")[0]
            .GetProperty("content")
            .GetString()!;
        Assert.StartsWith(kept, text);
        // Each character is two bytes as itself, so the next one may not fit in the last byte.
        Assert.InRange(new[] { system, input, output }.Sum(Encoding.UTF8.GetByteCount), 1999, 2000);
        // Escaped, each character would be six bytes, and a third as many would fit.
        Assert.InRange(kept.Length, 900, 1000);
        Assert.Equal(true, span.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task ContentMode_WritesTextAsItIsTyped_ApartFromWhatTheJsonWriterEscapes()
    {
        using var trace = new RecordedTrace();
        var text = "<b> & 'x' + ` caf\u00e9 \u6f22\u5b57 \ud83d\ude00";
        var handler = new ScriptedHandler().RespondJson(MessageJsonOfTextBlocks(text));
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await client.Messages.Create(MessageParams(text), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        // A character outside the basic plane is the one that the writer still escapes here.
        var part =
            "{\"type\":\"text\",\"content\":\"<b> & 'x' + ` caf\u00e9 \u6f22\u5b57 \\uD83D\\uDE00\"}";
        Assert.Equal(
            "[{\"role\":\"user\",\"parts\":[" + part + "]}]",
            span.GetTagItem("gen_ai.input.messages")
        );
        Assert.Contains(part, Assert.IsType<string>(span.GetTagItem("gen_ai.output.messages")));
    }

    [Fact]
    public async Task MaxContentBytes_ThatTheOptionsLeaveUnset_IsTheDefaultSizeBound()
    {
        using var trace = new RecordedTrace();
        var text = new string('y', 3000);
        var handler = new ScriptedHandler().RespondJson(MessageJsonOfTextBlocks(text));
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await client.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        var span = trace.Single("anthropic.messages.create");
        var output = Assert.IsType<string>(span.GetTagItem("gen_ai.output.messages"));
        Assert.Contains(text, output, StringComparison.Ordinal);
        Assert.Null(span.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public async Task ContentMode_Stream_RemovesOutputPartsFromTheStartOverTheSizeBound()
    {
        using var trace = new RecordedTrace();
        var big = new string('y', 350_000);
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(TextBlocksStream("1" + big, "2" + big, "3" + big, "4"))
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );

        await foreach (
            var _ in client.Messages.CreateStreaming(
                MessageParams(),
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        // The system instructions and the one input part go first, and then the first of the
        // four output parts, whole. The parts after it stay whole.
        Assert.Equal("[]", span.GetTagItem("gen_ai.system_instructions"));
        Assert.Equal("""[{"role":"user","parts":[]}]""", span.GetTagItem("gen_ai.input.messages"));
        var output = Assert.IsType<string>(span.GetTagItem("gen_ai.output.messages"));
        var outputParts = JsonDocument.Parse(output).RootElement[0].GetProperty("parts");
        Assert.Equal(3, outputParts.GetArrayLength());
        Assert.Equal("2" + big, outputParts[0].GetProperty("content").GetString());
        Assert.Equal("3" + big, outputParts[1].GetProperty("content").GetString());
        Assert.Equal("4", outputParts[2].GetProperty("content").GetString());
        Assert.Equal(true, span.GetTagItem("anthropic.content.truncated"));
    }

    /// <summary>
    /// A Message whose content is one text block for each of <paramref name="texts"/>.
    /// </summary>
    static string MessageJsonOfTextBlocks(params string[] texts) =>
        JsonSerializer.Serialize(
            new
            {
                id = "msg_1",
                type = "message",
                role = "assistant",
                model = "claude-test-20260101",
                content = texts.Select(text => new { type = "text", text }),
                stop_reason = "end_turn",
                stop_sequence = (string?)null,
                usage = new { input_tokens = 10, output_tokens = 5 },
            }
        );

    [Fact]
    public async Task ContentMode_Stream_OutputCountsTowardTheSizeBound()
    {
        using var trace = new RecordedTrace();
        var delta = new string('y', 75_000);
        var handler = new ScriptedHandler().RespondStream(
            Fixtures.Sse(TextStream(delta, delta, delta, delta, delta))
        );
        var client = Fixtures.Client(
            handler,
            new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
        );
        var big = new string('x', 150_000);
        var parameters = MessageParams() with
        {
            Messages =
            [
                new UserMessageParam { Content = "1" + big },
                new AssistantMessageParam { Content = "2" + big },
                new UserMessageParam { Content = "3" + big },
                new AssistantMessageParam { Content = "4" + big },
                new UserMessageParam { Content = "5" },
            ],
        };

        await foreach (
            var _ in client.Messages.CreateStreaming(
                parameters,
                TestContext.Current.CancellationToken
            )
        ) { }

        var span = trace.Single("anthropic.messages.create");
        // The whole output is recorded, as for a Message read whole.
        var output = Assert.IsType<string>(span.GetTagItem("gen_ai.output.messages"));
        var outputParts = JsonDocument.Parse(output).RootElement[0].GetProperty("parts");
        Assert.Equal(1, outputParts.GetArrayLength());
        Assert.Equal(new string('y', 375_000), outputParts[0].GetProperty("content").GetString());
        var input = JsonDocument
            .Parse((string)span.GetTagItem("gen_ai.input.messages")!)
            .RootElement;
        // The input of 600 kB is under 0.75 MB, and with the output of 375 kB it is not: the system
        // instructions and the parts of the two oldest messages are removed to make room for the
        // output, with no marker in their place. Their messages stay, without parts.
        Assert.Equal("[]", span.GetTagItem("gen_ai.system_instructions"));
        Assert.Equal(5, input.GetArrayLength());
        Assert.Equal(0, input[0].GetProperty("parts").GetArrayLength());
        Assert.Equal(0, input[1].GetProperty("parts").GetArrayLength());
        var thirdParts = input[2].GetProperty("parts");
        Assert.Equal(1, thirdParts.GetArrayLength());
        Assert.Equal("3" + big, thirdParts[0].GetProperty("content").GetString());
        Assert.Equal("5", input[4].GetProperty("parts")[0].GetProperty("content").GetString());
        Assert.True(
            output.Length + ((string)span.GetTagItem("gen_ai.input.messages")!).Length
                <= Anthropic.Core.Telemetry.Content.ContentLimit
        );
        Assert.Equal(true, span.GetTagItem("anthropic.content.truncated"));
    }

    /// <summary>
    /// The <c>gen_ai.output.messages</c> of a response whose message has <paramref name="parts"/>.
    /// </summary>
    static string AssistantMessage(string parts) =>
        $$"""[{"role":"assistant","parts":{{parts}}}]""";

    /// <summary>
    /// The events of a Message of one text block that streams <paramref name="deltas"/>.
    /// </summary>
    static (string, string)[] TextStream(params string[] deltas) =>
        [
            Fixtures.MessageStart,
            (
                "content_block_start",
                """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}"""
            ),
            .. deltas.Select(text =>
                (
                    "content_block_delta",
                    JsonSerializer.Serialize(
                        new
                        {
                            type = "content_block_delta",
                            index = 0,
                            delta = new { type = "text_delta", text },
                        }
                    )
                )
            ),
            ("content_block_stop", """{"type":"content_block_stop","index":0}"""),
            (
                "message_delta",
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":12}}"""
            ),
            ("message_stop", """{"type":"message_stop"}"""),
        ];

    /// <summary>
    /// The events of a Message of one text block for each of <paramref name="texts"/>, each
    /// streamed in one delta.
    /// </summary>
    static (string, string)[] TextBlocksStream(params string[] texts) =>
        [
            Fixtures.MessageStart,
            .. texts.SelectMany(
                (text, index) =>
                    new[]
                    {
                        (
                            "content_block_start",
                            JsonSerializer.Serialize(
                                new
                                {
                                    type = "content_block_start",
                                    index,
                                    content_block = new { type = "text", text = "" },
                                }
                            )
                        ),
                        (
                            "content_block_delta",
                            JsonSerializer.Serialize(
                                new
                                {
                                    type = "content_block_delta",
                                    index,
                                    delta = new { type = "text_delta", text },
                                }
                            )
                        ),
                        (
                            "content_block_stop",
                            JsonSerializer.Serialize(new { type = "content_block_stop", index })
                        ),
                    }
            ),
            (
                "message_delta",
                """{"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":12}}"""
            ),
            ("message_stop", """{"type":"message_stop"}"""),
        ];

    static async IAsyncEnumerable<T> Replay<T>(IEnumerable<T> events)
    {
        foreach (var streamEvent in events)
        {
            yield return streamEvent;
        }
        await Task.CompletedTask;
    }
}
