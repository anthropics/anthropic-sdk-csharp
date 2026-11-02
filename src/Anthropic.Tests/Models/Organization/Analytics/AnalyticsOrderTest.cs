using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsOrderTest : TestBase
{
    [Theory]
    [InlineData(AnalyticsOrder.Asc)]
    [InlineData(AnalyticsOrder.Desc)]
    public void Validation_Works(AnalyticsOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnalyticsOrder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AnalyticsOrder.Asc)]
    [InlineData(AnalyticsOrder.Desc)]
    public void SerializationRoundtrip_Works(AnalyticsOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnalyticsOrder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnalyticsOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
