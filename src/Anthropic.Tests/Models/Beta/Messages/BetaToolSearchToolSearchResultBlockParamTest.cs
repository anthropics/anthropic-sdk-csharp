using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolSearchResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolSearchResultBlockParam
        {
            ToolReferences =
            [
                new()
                {
                    ToolName = "tool_name",
                    CacheControl = new() { TTL = TTL.TTL5m },
                },
            ],
        };

        List<BetaToolReferenceBlockParam> expectedToolReferences =
        [
            new()
            {
                ToolName = "tool_name",
                CacheControl = new() { TTL = TTL.TTL5m },
            },
        ];
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_search_result\""
        );

        Assert.Equal(expectedToolReferences.Count, model.ToolReferences.Count);
        for (int i = 0; i < expectedToolReferences.Count; i++)
        {
            Assert.Equal(expectedToolReferences[i], model.ToolReferences[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolSearchToolSearchResultBlockParam
        {
            ToolReferences =
            [
                new()
                {
                    ToolName = "tool_name",
                    CacheControl = new() { TTL = TTL.TTL5m },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolSearchResultBlockParam>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolSearchToolSearchResultBlockParam
        {
            ToolReferences =
            [
                new()
                {
                    ToolName = "tool_name",
                    CacheControl = new() { TTL = TTL.TTL5m },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolSearchResultBlockParam>(
            json
        );
        Assert.NotNull(deserialized);

        List<BetaToolReferenceBlockParam> expectedToolReferences =
        [
            new()
            {
                ToolName = "tool_name",
                CacheControl = new() { TTL = TTL.TTL5m },
            },
        ];
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_search_result\""
        );

        Assert.Equal(expectedToolReferences.Count, deserialized.ToolReferences.Count);
        for (int i = 0; i < expectedToolReferences.Count; i++)
        {
            Assert.Equal(expectedToolReferences[i], deserialized.ToolReferences[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolSearchToolSearchResultBlockParam
        {
            ToolReferences =
            [
                new()
                {
                    ToolName = "tool_name",
                    CacheControl = new() { TTL = TTL.TTL5m },
                },
            ],
        };

        model.Validate();
    }
}
