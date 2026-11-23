using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaAnthropicHumanReviewParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnthropicHumanReviewParam
        {
            Type = BetaAnthropicHumanReviewParamType.Disabled,
        };

        ApiEnum<string, BetaAnthropicHumanReviewParamType> expectedType =
            BetaAnthropicHumanReviewParamType.Disabled;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnthropicHumanReviewParam
        {
            Type = BetaAnthropicHumanReviewParamType.Disabled,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnthropicHumanReviewParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnthropicHumanReviewParam
        {
            Type = BetaAnthropicHumanReviewParamType.Disabled,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnthropicHumanReviewParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaAnthropicHumanReviewParamType> expectedType =
            BetaAnthropicHumanReviewParamType.Disabled;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnthropicHumanReviewParam
        {
            Type = BetaAnthropicHumanReviewParamType.Disabled,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnthropicHumanReviewParam
        {
            Type = BetaAnthropicHumanReviewParamType.Disabled,
        };

        BetaAnthropicHumanReviewParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAnthropicHumanReviewParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaAnthropicHumanReviewParamType.Disabled)]
    [InlineData(BetaAnthropicHumanReviewParamType.Enabled)]
    public void Validation_Works(BetaAnthropicHumanReviewParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnthropicHumanReviewParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnthropicHumanReviewParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnthropicHumanReviewParamType.Disabled, 2068438255, "disabled")]
    [InlineData(BetaAnthropicHumanReviewParamType.Enabled, 924343854, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnthropicHumanReviewParamType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnthropicHumanReviewParamType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnthropicHumanReviewParamType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnthropicHumanReviewParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnthropicHumanReviewParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
