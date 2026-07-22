using System.Collections.Generic;
using Anthropic.Core;
using Anthropic.Helpers;
using Xunit;

namespace Anthropic.Tests.Helpers;

public class StainlessHelperHeaderTest
{
    [Fact]
    public void MergedValue_Empty_ReturnsValue()
    {
        var merged = StainlessHelperHeader.MergedValue([], StainlessHelperHeader.BetaToolRunner);
        Assert.Equal("BetaToolRunner", merged);
    }

    [Fact]
    public void MergedValue_AppendsToExisting()
    {
        var merged = StainlessHelperHeader.MergedValue(
            [new KeyValuePair<string, string[]>(StainlessHelperHeader.Name, ["mcp_tool"])],
            StainlessHelperHeader.BetaToolRunner
        );
        Assert.Equal("mcp_tool, BetaToolRunner", merged);
    }

    [Fact]
    public void MergedValue_Dedups()
    {
        var merged = StainlessHelperHeader.MergedValue(
            [new KeyValuePair<string, string[]>(StainlessHelperHeader.Name, ["BetaToolRunner"])],
            StainlessHelperHeader.BetaToolRunner
        );
        Assert.Equal("BetaToolRunner", merged);
    }

    [Fact]
    public void MergedValue_CollapsesMultipleLinesAndCasings()
    {
        var merged = StainlessHelperHeader.MergedValue(
            [
                new KeyValuePair<string, string[]>("X-Stainless-Helper", ["a"]),
                new KeyValuePair<string, string[]>(StainlessHelperHeader.Name, ["b, c"]),
            ],
            StainlessHelperHeader.FallbackRefusalMiddleware
        );
        Assert.Equal("a, b, c, fallback-refusal-middleware", merged);
    }
}
