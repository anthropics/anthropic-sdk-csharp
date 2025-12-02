using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaJSONOutputFormatTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaJSONOutputFormat
        {
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = JsonSerializer.Deserialize<JsonElement>("\"json_schema\""),
        };

        Dictionary<string, JsonElement> expectedSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"json_schema\"");

        Assert.Equal(expectedSchema.Count, model.Schema.Count);
        foreach (var item in expectedSchema)
        {
            Assert.True(model.Schema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Schema[item.Key]));
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
