using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaModelLineTest : TestBase
{
    [Theory]
    [InlineData(BetaModelLine.Haiku)]
    [InlineData(BetaModelLine.Sonnet)]
    [InlineData(BetaModelLine.Opus)]
    [InlineData(BetaModelLine.Fable)]
    [InlineData(BetaModelLine.Mythos)]
    public void Validation_Works(BetaModelLine rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaModelLine> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaModelLine>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaModelLine.Haiku, 0, "haiku")]
    [InlineData(BetaModelLine.Sonnet, 1, "sonnet")]
    [InlineData(BetaModelLine.Opus, 2, "opus")]
    [InlineData(BetaModelLine.Fable, 3, "fable")]
    [InlineData(BetaModelLine.Mythos, 4, "mythos")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaModelLine rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaModelLine> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaModelLine>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaModelLine>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaModelLine>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
