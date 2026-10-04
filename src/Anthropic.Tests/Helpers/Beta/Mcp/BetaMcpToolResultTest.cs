using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Helpers.Beta;
using Anthropic.Helpers.Beta.Mcp;
using Anthropic.Models.Beta.Messages;
using ModelContextProtocol;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;
using Moq;
using McpTool = ModelContextProtocol.Protocol.Tool;

namespace Anthropic.Tests.Helpers.Beta.Mcp;

public class BetaMcpToolResultTest
{
    private static async Task<BetaToolResultBlockParamContent> Execute(CallToolResult result)
    {
        var client = new Mock<McpClient>();
        client
            .SetupGet(c => c.ServerInfo)
            .Returns(new Implementation { Name = "test", Version = "1" });
        client.SetupGet(c => c.ServerCapabilities).Returns(new ServerCapabilities());
        client
            .Setup(c =>
                c.SendRequestAsync(It.IsAny<JsonRpcRequest>(), It.IsAny<CancellationToken>())
            )
            .Returns(
                (JsonRpcRequest request, CancellationToken _) =>
                {
                    Assert.Equal("tools/call", request.Method);
                    return Task.FromResult(
                        new JsonRpcResponse
                        {
                            Id = request.Id,
                            Result = JsonSerializer.SerializeToNode(
                                result,
                                McpJsonUtilities.DefaultOptions
                            ),
                        }
                    );
                }
            );
        var protocolTool = new McpTool
        {
            Name = "capture",
            InputSchema = JsonSerializer.SerializeToElement(new { type = "object" }),
        };
        var runnable = BetaMcp.Tool(new McpClientTool(client.Object, protocolTool, null));
        var call = JsonSerializer.Deserialize<BetaToolUseBlock>(
            """{"type":"tool_use","id":"toolu_test","name":"capture","input":{}}"""
        );
        Assert.NotNull(call);
        return await runnable.ExecuteAsync(call, TestContext.Current.CancellationToken);
    }

    [Theory]
    [InlineData(false, "{}")]
    [InlineData(true, "{}")]
    [InlineData(
        false,
        "{\"message\":\"try again\",\"retry\":false,\"details\":{\"code\":429,\"value\":null}}"
    )]
    [InlineData(
        true,
        "{\"message\":\"try again\",\"retry\":false,\"details\":{\"code\":429,\"value\":null}}"
    )]
    public async Task StructuredOnlyResultPreservesPayload(bool isError, string payload)
    {
        var result = new CallToolResult
        {
            IsError = isError,
            StructuredContent = JsonSerializer.Deserialize<JsonElement>(payload),
        };
        var content = isError
            ? (await Assert.ThrowsAsync<BetaToolError>(() => Execute(result))).Content
            : await Execute(result);
        Assert.True(content.TryPickString(out var text));
        Assert.NotNull(text);
        Assert.True(
            JsonElement.DeepEquals(
                JsonSerializer.Deserialize<JsonElement>(payload),
                JsonSerializer.Deserialize<JsonElement>(text)
            )
        );
        Assert.Empty(result.Content);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ExplicitContentKeepsPrecedence(bool isError)
    {
        var result = new CallToolResult
        {
            IsError = isError,
            Content = [new TextContentBlock { Text = "original message" }],
            StructuredContent = JsonSerializer.Deserialize<JsonElement>(
                "{\"message\":\"alternate\"}"
            ),
        };
        var content = isError
            ? (await Assert.ThrowsAsync<BetaToolError>(() => Execute(result))).Content
            : await Execute(result);
        Assert.True(content.TryPickBlocks(out var blocks));
        Assert.NotNull(blocks);
        var block = Assert.Single(blocks);
        Assert.True(block.TryPickBetaTextBlockParam(out var text));
        Assert.NotNull(text);
        Assert.Equal("original message", text.Text);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task EmptyResultWithoutStructuredContentStaysEmpty(bool isError)
    {
        var result = new CallToolResult { IsError = isError };
        var content = isError
            ? (await Assert.ThrowsAsync<BetaToolError>(() => Execute(result))).Content
            : await Execute(result);
        Assert.True(content.TryPickBlocks(out var blocks));
        Assert.NotNull(blocks);
        Assert.Empty(blocks);
    }
}
