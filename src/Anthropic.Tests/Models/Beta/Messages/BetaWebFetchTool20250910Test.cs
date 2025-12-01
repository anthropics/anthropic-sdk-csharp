using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchTool20250910Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchTool20250910
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"web_fetch\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_20250910\""),
            AllowedCallers = [AllowedCaller14.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"web_fetch\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_fetch_20250910\""
        );
        List<ApiEnum<string, AllowedCaller14>> expectedAllowedCallers = [AllowedCaller14.Direct];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        BetaCitationsConfigParam expectedCitations = new() { Enabled = true };
        bool expectedDeferLoading = true;
        long expectedMaxContentTokens = 1;
        long expectedMaxUses = 1;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedAllowedDomains.Count, model.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], model.AllowedDomains[i]);
        }
        Assert.Equal(expectedBlockedDomains.Count, model.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], model.BlockedDomains[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedMaxContentTokens, model.MaxContentTokens);
        Assert.Equal(expectedMaxUses, model.MaxUses);
        Assert.Equal(expectedStrict, model.Strict);
    }
}
