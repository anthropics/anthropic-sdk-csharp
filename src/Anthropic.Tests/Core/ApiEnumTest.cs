using Anthropic.Core;

namespace Anthropic.Tests.Core;

public class ApiEnumTest : TestBase
{
    enum Color
    {
        Red,
    }

    [Fact]
    public void ImplicitRawConversion_OfNull_ReturnsNull()
    {
        ApiEnum<string, Color>? value = null;

        string? raw = value;

        Assert.Null(raw);
    }

    [Fact]
    public void ImplicitRawConversion_OfValue_ReturnsRaw()
    {
        ApiEnum<string, Color> value = "red";

        string raw = value;

        Assert.Equal("red", raw);
    }
}
