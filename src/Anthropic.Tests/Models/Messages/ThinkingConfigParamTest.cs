using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigDisabled();
        value.Validate();
    }

    [Fact]
    public void BetweenToolsValidationWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigBetweenTools();
        value.Validate();
    }

    [Fact]
    public void AdaptiveValidationWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigAdaptive() { Display = Display.Summarized };
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetweenToolsSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigBetweenTools();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdaptiveSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigAdaptive() { Display = Display.Summarized };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };
        Assert.Equal(ThinkingConfigParamType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigDisabled();
        Assert.Equal(ThinkingConfigParamType.Disabled, value.Type.Value());
    }

    [Fact]
    public void BetweenToolsTypeWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigBetweenTools();
        Assert.Equal(ThinkingConfigParamType.BetweenTools, value.Type.Value());
    }

    [Fact]
    public void AdaptiveTypeWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigAdaptive() { Display = Display.Summarized };
        Assert.Equal(ThinkingConfigParamType.Adaptive, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ThinkingConfigParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "adaptive"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ThinkingConfigParamType> expectedType = ThinkingConfigParamType.Adaptive;

        Assert.Equal(expectedType, value.Type);

        ThinkingConfigParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ThinkingConfigParamTypeTest : TestBase
{
    [Theory]
    [InlineData(ThinkingConfigParamType.Enabled)]
    [InlineData(ThinkingConfigParamType.Disabled)]
    [InlineData(ThinkingConfigParamType.BetweenTools)]
    [InlineData(ThinkingConfigParamType.Adaptive)]
    public void Validation_Works(ThinkingConfigParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingConfigParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingConfigParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThinkingConfigParamType.Enabled)]
    [InlineData(ThinkingConfigParamType.Disabled)]
    [InlineData(ThinkingConfigParamType.BetweenTools)]
    [InlineData(ThinkingConfigParamType.Adaptive)]
    public void SerializationRoundtrip_Works(ThinkingConfigParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingConfigParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThinkingConfigParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingConfigParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThinkingConfigParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
