using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core;

public class OptionalCountsTest
{
    [Fact]
    public void GetLongReadsIntegers()
    {
        var usage = Parse("""{"web_fetch_requests": 3, "web_search_requests": 0}""");

        Assert.Equal(3L, OptionalCounts.GetLong(usage, "web_fetch_requests"));
        Assert.Equal(0L, OptionalCounts.GetLong(usage, "web_search_requests"));
    }

    [Fact]
    public void GetLongYieldsNullForAbsentNullOrNonIntegerFields()
    {
        var usage = Parse("""{"n": null, "s": "3", "d": 1.5, "o": {}}""");

        Assert.Null(OptionalCounts.GetLong(usage, "web_fetch_requests"));
        Assert.Null(OptionalCounts.GetLong(usage, "n"));
        Assert.Null(OptionalCounts.GetLong(usage, "s"));
        Assert.Null(OptionalCounts.GetLong(usage, "d"));
        Assert.Null(OptionalCounts.GetLong(usage, "o"));
    }

    [Fact]
    public void GetLongYieldsNullForNullModel()
    {
        Assert.Null(OptionalCounts.GetLong(null, "web_fetch_requests"));
    }

    static BetaServerToolUsage Parse(string json) =>
        BetaServerToolUsage.FromRawUnchecked(
            JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json)!
        );
}
