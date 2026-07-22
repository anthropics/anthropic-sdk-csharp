using System.Text.Json.Nodes;
using Anthropic.Core;

namespace Anthropic.Tests.Core;

public class JsonNodesTest
{
    [Fact]
    public void GetStringReadsStringsAndYieldsNullOtherwise()
    {
        var obj = (JsonObject)JsonNode.Parse("""{"s": "v", "n": null, "i": 1, "o": {}}""")!;

        Assert.Equal("v", JsonNodes.GetString(obj["s"]));
        Assert.Null(JsonNodes.GetString(obj["n"]));
        Assert.Null(JsonNodes.GetString(obj["i"]));
        Assert.Null(JsonNodes.GetString(obj["o"]));
        Assert.Null(JsonNodes.GetString(obj["absent"]));
    }

    [Fact]
    public void GetLongReadsIntegersOnly()
    {
        var obj = (JsonObject)JsonNode.Parse("""{"i": 12, "s": "12", "n": null, "d": 1.5}""")!;

        Assert.Equal(12L, JsonNodes.GetLong(obj["i"]));
        Assert.Null(JsonNodes.GetLong(obj["s"]));
        Assert.Null(JsonNodes.GetLong(obj["n"]));
        Assert.Null(JsonNodes.GetLong(obj["d"]));
    }

    [Fact]
    public void GetIntDefaultsToZero()
    {
        var obj = (JsonObject)JsonNode.Parse("""{"i": 7, "s": "7"}""")!;

        Assert.Equal(7, JsonNodes.GetInt(obj["i"]));
        Assert.Equal(0, JsonNodes.GetInt(obj["s"]));
        Assert.Equal(0, JsonNodes.GetInt(obj["absent"]));
    }

    [Fact]
    public void ParseObjectReturnsNullForNonObjectsAndInvalidJson()
    {
        Assert.NotNull(JsonNodes.ParseObject("""{"a": 1}"""));
        Assert.Null(JsonNodes.ParseObject("[1, 2]"));
        Assert.Null(JsonNodes.ParseObject("\"a string\""));
        Assert.Null(JsonNodes.ParseObject("null"));
        Assert.Null(JsonNodes.ParseObject("{not json"));
    }
}
