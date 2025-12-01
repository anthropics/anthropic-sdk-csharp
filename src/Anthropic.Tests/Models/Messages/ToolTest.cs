using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Description = "Get the current weather in a given location",
            Type = Type.Custom,
        };

        InputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };
        string expectedName = "name";
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        string expectedDescription = "Get the current weather in a given location";
        ApiEnum<string, Type> expectedType = Type.Custom;

        Assert.Equal(expectedInputSchema, model.InputSchema);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedType, model.Type);
    }
}

public class InputSchemaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputSchema
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"object\""),
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"object\"");
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "location", JsonSerializer.SerializeToElement("bar") },
            { "unit", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequired = ["location"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.Equal(expectedRequired.Count, model.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], model.Required[i]);
        }
    }
}
