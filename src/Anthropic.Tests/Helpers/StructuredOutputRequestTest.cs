using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Services;
using Anthropic.Services.Beta;
using BetaMessages = Anthropic.Models.Beta.Messages;
using Stable = Anthropic.Models.Messages;

namespace Anthropic.Tests.Helpers;

public class StructuredOutputRequestTest
{
    [Theory]
    [InlineData(false, null)]
    [InlineData(true, null)]
    [InlineData(false, "null")]
    [InlineData(true, "null")]
    [InlineData(false, "{}")]
    [InlineData(true, "{}")]
    [InlineData(false, """{"effort":"low"}""")]
    [InlineData(true, """{"effort":"low"}""")]
    [InlineData(
        false,
        """{"effort":"future-effort","future_option":{"enabled":true},"nullable_option":null}"""
    )]
    [InlineData(
        true,
        """{"effort":"future-effort","future_option":{"enabled":true},"nullable_option":null}"""
    )]
    [InlineData(
        false,
        """{"effort":"high","format":{"type":"json_schema","schema":{"type":"string"}}}"""
    )]
    [InlineData(
        true,
        """{"effort":"high","format":{"type":"json_schema","schema":{"type":"string"}}}"""
    )]
    [InlineData(
        true,
        """{"effort":"low","task_budget":{"type":"tokens","total":10000,"remaining":9000}}"""
    )]
    public async Task Create_PreservesOutputConfigAndCallerParameters(bool beta, string? config)
    {
        using var handler = new CaptureHandler { VerifyPassthrough = true };
        using var client = new AnthropicClient(
            new ClientOptions
            {
                ApiKey = "test-key",
                AuthToken = null,
                HttpClient = new HttpClient(handler),
                BaseUrl = "https://example.invalid",
                MaxRetries = 0,
            }
        );
        var rawBody = new Dictionary<string, JsonElement>
        {
            ["model"] = JsonSerializer.SerializeToElement("claude-sonnet-4-5"),
            ["max_tokens"] = JsonSerializer.SerializeToElement(1024),
            ["future_body_option"] = JsonSerializer.SerializeToElement("preserved"),
            ["messages"] = JsonSerializer.SerializeToElement(
                new[] { new { role = "user", content = "Hello" } }
            ),
        };
        if (config is not null)
        {
            rawBody["output_config"] = JsonSerializer.Deserialize<JsonElement>(config);
        }

        var originalBody = JsonSerializer.Serialize(rawBody);
        if (beta)
        {
            var parameters = BetaMessages.MessageCreateParams.FromRawUnchecked(
                new Dictionary<string, JsonElement>
                {
                    ["x-structured-test"] = JsonSerializer.SerializeToElement("preserved"),
                },
                new Dictionary<string, JsonElement>
                {
                    ["test_query"] = JsonSerializer.SerializeToElement("preserved"),
                },
                rawBody
            );
            var originalConfig = JsonSerializer.Serialize(parameters.OutputConfig);
            await client.Beta.Messages.Create(parameters, TestContext.Current.CancellationToken);
            await client.Beta.Messages.Create<SimpleModel>(
                parameters,
                TestContext.Current.CancellationToken
            );
            Assert.Equal(originalBody, JsonSerializer.Serialize(parameters.RawBodyData));
            Assert.Equal(originalConfig, JsonSerializer.Serialize(parameters.OutputConfig));
        }
        else
        {
            var parameters = Stable.MessageCreateParams.FromRawUnchecked(
                new Dictionary<string, JsonElement>
                {
                    ["x-structured-test"] = JsonSerializer.SerializeToElement("preserved"),
                },
                new Dictionary<string, JsonElement>
                {
                    ["test_query"] = JsonSerializer.SerializeToElement("preserved"),
                },
                rawBody
            );
            var originalConfig = JsonSerializer.Serialize(parameters.OutputConfig);
            await client.Messages.Create(parameters, TestContext.Current.CancellationToken);
            await client.Messages.Create<SimpleModel>(
                parameters,
                TestContext.Current.CancellationToken
            );
            Assert.Equal(originalBody, JsonSerializer.Serialize(parameters.RawBodyData));
            Assert.Equal(originalConfig, JsonSerializer.Serialize(parameters.OutputConfig));
        }

        Assert.Equal(2, handler.Bodies.Count);
        Assert.True(JsonNode.DeepEquals(JsonNode.Parse(originalBody), handler.Bodies[0]));
        var expectedBody = JsonNode.Parse(originalBody)!.AsObject();
        var expectedConfig = config is null
            ? new JsonObject()
            : JsonNode.Parse(config)?.AsObject() ?? new JsonObject();
        expectedConfig["format"] = JsonNode.Parse(
            """
            {"type":"json_schema","schema":{"type":"object","properties":{"name":{"type":"string"},"age":{"type":"integer"},"score":{"type":"number"},"active":{"type":"boolean"}},"required":["name","age","score","active"],"additionalProperties":false}}
            """
        );
        expectedBody["output_config"] = expectedConfig;
        Assert.True(
            JsonNode.DeepEquals(expectedBody, handler.Bodies[1]),
            $"Expected {expectedBody}, got {handler.Bodies[1]}"
        );
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Create_PreservesTypedOutputConfig(bool beta)
    {
        using var handler = new CaptureHandler();
        using var client = new AnthropicClient(
            new ClientOptions
            {
                ApiKey = "test-key",
                AuthToken = null,
                HttpClient = new HttpClient(handler),
                BaseUrl = "https://example.invalid",
                MaxRetries = 0,
            }
        );
        if (beta)
        {
            var config = new BetaMessages.BetaOutputConfig
            {
                Effort = BetaMessages.Effort.Low,
                TaskBudget = new() { Total = 10000, Remaining = 9000 },
            };
            var parameters = new BetaMessages.MessageCreateParams
            {
                Model = "claude-sonnet-4-5",
                MaxTokens = 1024,
                Messages = [new() { Role = BetaMessages.Role.User, Content = "Hello" }],
                OutputConfig = config,
            };
            var original = JsonSerializer.Serialize(parameters.RawBodyData);
            var originalConfig = JsonSerializer.Serialize(config);
            await client.Beta.Messages.Create<SimpleModel>(
                parameters,
                TestContext.Current.CancellationToken
            );
            Assert.Equal(original, JsonSerializer.Serialize(parameters.RawBodyData));
            Assert.Equal(originalConfig, JsonSerializer.Serialize(config));
            Assert.Equal(
                10000,
                handler.Bodies[0]["output_config"]!["task_budget"]!["total"]!.GetValue<int>()
            );
            Assert.Equal(
                9000,
                handler.Bodies[0]["output_config"]!["task_budget"]!["remaining"]!.GetValue<int>()
            );
        }
        else
        {
            var config = new Stable.OutputConfig { Effort = Stable.Effort.Low };
            var parameters = new Stable.MessageCreateParams
            {
                Model = "claude-sonnet-4-5",
                MaxTokens = 1024,
                Messages = [new() { Role = Stable.Role.User, Content = "Hello" }],
                OutputConfig = config,
            };
            var original = JsonSerializer.Serialize(parameters.RawBodyData);
            var originalConfig = JsonSerializer.Serialize(config);
            await client.Messages.Create<SimpleModel>(
                parameters,
                TestContext.Current.CancellationToken
            );
            Assert.Equal(original, JsonSerializer.Serialize(parameters.RawBodyData));
            Assert.Equal(originalConfig, JsonSerializer.Serialize(config));
        }

        var body = Assert.Single(handler.Bodies);
        Assert.Equal("low", body["output_config"]!["effort"]!.GetValue<string>());
        Assert.Equal("json_schema", body["output_config"]!["format"]!["type"]!.GetValue<string>());
    }

    sealed class CaptureHandler : HttpMessageHandler
    {
        public List<JsonNode> Bodies { get; } = [];

        public bool VerifyPassthrough { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            if (VerifyPassthrough)
            {
                Assert.Equal(
                    "preserved",
                    Assert.Single(request.Headers.GetValues("x-structured-test"))
                );
                Assert.NotNull(request.RequestUri);
                Assert.Contains("test_query=preserved", request.RequestUri.Query);
            }
            Assert.NotNull(request.Content);
            var body = await request.Content.ReadAsStringAsync(cancellationToken);
            Bodies.Add(JsonNode.Parse(body)!);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    """
                    {"id":"msg_test","type":"message","role":"assistant","content":[],"model":"claude-sonnet-4-5","stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":1,"output_tokens":1}}
                    """,
                    Encoding.UTF8,
                    "application/json"
                ),
            };
        }
    }
}
