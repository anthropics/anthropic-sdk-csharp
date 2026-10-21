using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMcpToolListingBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMcpToolListingBlock
        {
            McpServerName = "mcp_server_name",
            Tools =
            [
                new()
                {
                    InputSchema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Description = "description",
                },
            ],
        };

        string expectedMcpServerName = "mcp_server_name";
        List<BetaMcpTool> expectedTools =
        [
            new()
            {
                InputSchema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Description = "description",
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_tool_listing");

        Assert.Equal(expectedMcpServerName, model.McpServerName);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMcpToolListingBlock
        {
            McpServerName = "mcp_server_name",
            Tools =
            [
                new()
                {
                    InputSchema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Description = "description",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolListingBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMcpToolListingBlock
        {
            McpServerName = "mcp_server_name",
            Tools =
            [
                new()
                {
                    InputSchema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Description = "description",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolListingBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMcpServerName = "mcp_server_name";
        List<BetaMcpTool> expectedTools =
        [
            new()
            {
                InputSchema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Description = "description",
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_tool_listing");

        Assert.Equal(expectedMcpServerName, deserialized.McpServerName);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMcpToolListingBlock
        {
            McpServerName = "mcp_server_name",
            Tools =
            [
                new()
                {
                    InputSchema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Description = "description",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMcpToolListingBlock
        {
            McpServerName = "mcp_server_name",
            Tools =
            [
                new()
                {
                    InputSchema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Description = "description",
                },
            ],
        };

        BetaMcpToolListingBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
