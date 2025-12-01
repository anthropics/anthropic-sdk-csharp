using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ServerToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServerToolUseBlock
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\""),
        };

        string expectedID = "srvtoolu_SQfNkl1n_JR_";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
