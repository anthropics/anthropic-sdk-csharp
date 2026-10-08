using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserReadPageFilterTest : TestBase
{
    [Theory]
    [InlineData(BrowserReadPageFilter.All)]
    [InlineData(BrowserReadPageFilter.Interactive)]
    public void Validation_Works(BrowserReadPageFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrowserReadPageFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrowserReadPageFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BrowserReadPageFilter.All)]
    [InlineData(BrowserReadPageFilter.Interactive)]
    public void SerializationRoundtrip_Works(BrowserReadPageFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrowserReadPageFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrowserReadPageFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrowserReadPageFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrowserReadPageFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
