using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ServerToolUseBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\""),
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string expectedID = "srvtoolu_SQfNkl1n_JR_";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }
}
