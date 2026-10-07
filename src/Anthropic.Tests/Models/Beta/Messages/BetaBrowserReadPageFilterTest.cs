using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserReadPageFilterTest : TestBase
{
    [Theory]
    [InlineData(BetaBrowserReadPageFilter.All)]
    [InlineData(BetaBrowserReadPageFilter.Interactive)]
    public void Validation_Works(BetaBrowserReadPageFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserReadPageFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserReadPageFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaBrowserReadPageFilter.All)]
    [InlineData(BetaBrowserReadPageFilter.Interactive)]
    public void SerializationRoundtrip_Works(BetaBrowserReadPageFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserReadPageFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserReadPageFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserReadPageFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserReadPageFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
