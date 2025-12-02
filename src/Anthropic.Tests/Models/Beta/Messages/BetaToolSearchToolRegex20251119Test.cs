using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolRegex20251119Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_regex\""),
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [AllowedCaller9.Direct],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_regex\""
        );
        ApiEnum<string, BetaToolSearchToolRegex20251119Type> expectedType =
            BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119;
        List<ApiEnum<string, AllowedCaller9>> expectedAllowedCallers = [AllowedCaller9.Direct];
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedStrict, model.Strict);
    }
}
