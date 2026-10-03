using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Beta = Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Helpers;

public class StreamStopFieldPresenceTest
{
    [Theory]
    [InlineData(false, 0)]
    [InlineData(true, 0)]
    [InlineData(false, 1)]
    [InlineData(true, 1)]
    [InlineData(false, 2)]
    [InlineData(true, 2)]
    [InlineData(false, 3)]
    [InlineData(true, 3)]
    [InlineData(false, 4)]
    [InlineData(true, 4)]
    [InlineData(false, 5)]
    [InlineData(true, 5)]
    public async Task LaterDeltasRespectStopFieldPresence(bool beta, int scenario)
    {
        string first = scenario switch
        {
            0 => """{"stop_reason":"tool_use","stop_sequence":null,"stop_details":null}""",
            1 or 5 =>
                """{"stop_reason":"stop_sequence","stop_sequence":"STOP","stop_details":null}""",
            _ =>
                """{"stop_reason":"refusal","stop_sequence":null,"stop_details":{"type":"refusal","category":null,"explanation":"Declined"}}""",
        };
        string last = scenario switch
        {
            3 => """{"stop_reason":null,"stop_sequence":null,"stop_details":null}""",
            4 => """{"stop_reason":"end_turn","stop_sequence":null,"stop_details":null}""",
            5 => """{"stop_sequence":""}""",
            _ => "{}",
        };
        var expected = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(first);
        var overrides = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(last);
        Assert.NotNull(expected);
        Assert.NotNull(overrides);
        foreach (var entry in overrides)
            expected[entry.Key] = entry.Value;
        string[] events =
        [
            """{"type":"message_start","message":{"id":"msg_test","type":"message","role":"assistant","model":"claude-opus-4-6","content":[],"stop_reason":null,"stop_sequence":null,"stop_details":null,"usage":{"input_tokens":7,"output_tokens":1}}}""",
            """{"type":"content_block_start","index":0,"content_block":{"type":"text","text":"Complete"}}""",
            """{"type":"content_block_stop","index":0}""",
            "{\"type\":\"message_delta\",\"delta\":" + first + ",\"usage\":{\"output_tokens\":4}}",
            "{\"type\":\"message_delta\",\"delta\":" + last + ",\"usage\":{\"output_tokens\":9}}",
            """{"type":"message_stop"}""",
        ];
        var wire = new StringBuilder();
        foreach (var item in events)
        {
            using var json = JsonDocument.Parse(item);
            wire.Append("event: ")
                .Append(json.RootElement.GetProperty("type").GetString())
                .Append("\ndata: ")
                .Append(item)
                .Append("\n\n");
        }
        using var handler = new ResponseHandler(wire.ToString());
        using AnthropicClient client = new() { ApiKey = "test-key", HttpClient = new(handler) };
        string result;
        if (beta)
        {
            var message = await client
                .Beta.Messages.CreateStreaming(
                    new Beta::MessageCreateParams
                    {
                        Model = Messages.Model.ClaudeOpus4_6,
                        MaxTokens = 32,
                        Messages = [new() { Role = Beta::Role.User, Content = "hello" }],
                    },
                    TestContext.Current.CancellationToken
                )
                .Aggregate();
            result = JsonSerializer.Serialize(message, ModelBase.SerializerOptions);
        }
        else
        {
            var message = await client
                .Messages.CreateStreaming(
                    new Messages.MessageCreateParams
                    {
                        Model = Messages.Model.ClaudeOpus4_6,
                        MaxTokens = 32,
                        Messages = [new() { Role = Messages.Role.User, Content = "hello" }],
                    },
                    TestContext.Current.CancellationToken
                )
                .Aggregate();
            result = JsonSerializer.Serialize(message, ModelBase.SerializerOptions);
        }
        using var output = JsonDocument.Parse(result);
        foreach (var entry in expected)
            Assert.True(
                JsonElement.DeepEquals(entry.Value, output.RootElement.GetProperty(entry.Key)),
                entry.Key
            );
        Assert.Equal(
            9,
            output.RootElement.GetProperty("usage").GetProperty("output_tokens").GetInt32()
        );
        Assert.Equal(
            7,
            output.RootElement.GetProperty("usage").GetProperty("input_tokens").GetInt32()
        );
        Assert.Equal(
            "Complete",
            output.RootElement.GetProperty("content")[0].GetProperty("text").GetString()
        );
        Assert.Equal(1, handler.Requests);
    }

    private sealed class ResponseHandler(string body) : HttpMessageHandler
    {
        public int Requests { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Requests++;
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.EndsWith("/v1/messages", request.RequestUri?.AbsolutePath);
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(body, Encoding.UTF8, "text/event-stream"),
                }
            );
        }
    }
}
