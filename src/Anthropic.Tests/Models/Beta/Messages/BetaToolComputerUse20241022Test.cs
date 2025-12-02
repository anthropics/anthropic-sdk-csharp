using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolComputerUse20241022Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            Name = JsonSerializer.Deserialize<JsonElement>("\"computer\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"computer_20241022\""),
            AllowedCallers = [AllowedCaller5.Direct],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };

        long expectedDisplayHeightPx = 1;
        long expectedDisplayWidthPx = 1;
        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"computer\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"computer_20241022\"");
        List<ApiEnum<string, AllowedCaller5>> expectedAllowedCallers = [AllowedCaller5.Direct];
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        bool expectedDeferLoading = true;
        long expectedDisplayNumber = 0;
        List<Dictionary<string, JsonElement>> expectedInputExamples =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedStrict = true;

        Assert.Equal(expectedDisplayHeightPx, model.DisplayHeightPx);
        Assert.Equal(expectedDisplayWidthPx, model.DisplayWidthPx);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedDisplayNumber, model.DisplayNumber);
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
