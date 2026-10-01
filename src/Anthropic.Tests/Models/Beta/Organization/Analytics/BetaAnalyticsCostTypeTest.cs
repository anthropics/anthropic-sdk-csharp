using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsCostTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsCostType.CodeExecution)]
    [InlineData(BetaAnalyticsCostType.Tokens)]
    [InlineData(BetaAnalyticsCostType.WebSearch)]
    public void Validation_Works(BetaAnalyticsCostType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsCostType.CodeExecution)]
    [InlineData(BetaAnalyticsCostType.Tokens)]
    [InlineData(BetaAnalyticsCostType.WebSearch)]
    public void SerializationRoundtrip_Works(BetaAnalyticsCostType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
