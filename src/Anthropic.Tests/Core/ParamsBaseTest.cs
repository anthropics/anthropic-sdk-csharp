using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Tests.Core;

public class ParamsBaseTest : TestBase
{
    [Theory]
    [InlineData("", "")]
    [InlineData("abc-123_x.y~z", "abc-123_x.y~z")]
    [InlineData("card:1@x+y,z;w=v", "card%3A1%40x%2By%2Cz%3Bw%3Dv")]
    [InlineData("..;", "..%3B")]
    [InlineData("it's(*)!", "it%27s%28%2A%29%21")]
    [InlineData("a/b", "a%2Fb")]
    [InlineData("a\\b", "a%5Cb")]
    [InlineData("../secrets", "..%2Fsecrets")]
    [InlineData("what?", "what%3F")]
    [InlineData("item#123", "item%23123")]
    [InlineData("more%stuff", "more%25stuff")]
    [InlineData("%2e%2e", "%252e%252e")]
    [InlineData("a b", "a%20b")]
    [InlineData("café", "caf%C3%A9")]
    [InlineData("😃", "%F0%9F%98%83")]
    public void EncodePathSegment_Works(string value, string expected)
    {
        Assert.Equal(expected, ParamsBase.EncodePathSegment(value, "id"));
    }

    [Theory]
    [InlineData("\"a/b\"", "a%2Fb")]
    [InlineData("12.5", "12.5")]
    [InlineData("true", "true")]
    [InlineData("null", "")]
    [InlineData("{\"a\":[1]}", "%7B%22a%22%3A%5B1%5D%7D")]
    public void EncodePathSegment_JsonElementWorks(string json, string expected)
    {
        Assert.Equal(
            expected,
            ParamsBase.EncodePathSegment(JsonSerializer.Deserialize<JsonElement>(json), "id")
        );
    }

    [Theory]
    [InlineData(".")]
    [InlineData("..")]
    public void EncodePathSegment_RejectsDotSegments(string value)
    {
        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ParamsBase.EncodePathSegment(value, "id")
        );
        Assert.Contains("'id'", exception.Message);
    }
}
