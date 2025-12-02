using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMCPToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMCPToolUseBlock
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
            Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\""),
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        string expectedServerName = "server_name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedServerName, model.ServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
