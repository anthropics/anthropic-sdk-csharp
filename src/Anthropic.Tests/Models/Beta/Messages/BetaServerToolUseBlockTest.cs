using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaServerToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServerToolUseBlock
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = Name.WebSearch,
            Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\""),
        };

        string expectedID = "srvtoolu_SQfNkl1n_JR_";
        Caller expectedCaller = new BetaDirectCaller();
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Name> expectedName = Name.WebSearch;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCaller, model.Caller);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
