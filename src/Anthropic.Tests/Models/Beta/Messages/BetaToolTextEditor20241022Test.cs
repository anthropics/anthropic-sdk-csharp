using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolTextEditor20241022Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolTextEditor20241022
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"str_replace_editor\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"text_editor_20241022\""),
            AllowedCallers = [AllowedCaller10.Direct],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"str_replace_editor\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_20241022\""
        );
        List<ApiEnum<string, AllowedCaller10>> expectedAllowedCallers = [AllowedCaller10.Direct];
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        bool expectedDeferLoading = true;
        List<Dictionary<string, JsonElement>> expectedInputExamples =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedInputExamples.Count, model.InputExamples.Count);
        for (int i = 0; i < expectedInputExamples.Count; i++)
        {
            Assert.Equal(expectedInputExamples[i].Count, model.InputExamples[i].Count);
            foreach (var item in expectedInputExamples[i])
            {
                Assert.True(model.InputExamples[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.InputExamples[i][item.Key]));
            }
        }
        Assert.Equal(expectedStrict, model.Strict);
    }
}
