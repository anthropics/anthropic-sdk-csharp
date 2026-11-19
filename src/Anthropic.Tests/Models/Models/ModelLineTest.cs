using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ModelLineTest : TestBase
{
    [Theory]
    [InlineData(ModelLine.Haiku)]
    [InlineData(ModelLine.Sonnet)]
    [InlineData(ModelLine.Opus)]
    [InlineData(ModelLine.Fable)]
    [InlineData(ModelLine.Mythos)]
    public void Validation_Works(ModelLine rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelLine> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelLine>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelLine.Haiku, 0, "haiku")]
    [InlineData(ModelLine.Sonnet, 1, "sonnet")]
    [InlineData(ModelLine.Opus, 2, "opus")]
    [InlineData(ModelLine.Fable, 3, "fable")]
    [InlineData(ModelLine.Mythos, 4, "mythos")]
    public void EnumMemberSerializationRoundtrip_Works(
        ModelLine rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelLine> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelLine>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelLine>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelLine>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
