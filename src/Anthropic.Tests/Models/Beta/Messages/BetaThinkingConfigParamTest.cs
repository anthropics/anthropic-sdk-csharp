using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingConfigParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            BlockBinding = new()
            {
                PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
            },
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigDisabled();
        value.Validate();
    }

    [Fact]
    public void BetweenToolsValidationWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigBetweenTools();
        value.Validate();
    }

    [Fact]
    public void AdaptiveValidationWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigAdaptive()
        {
            BlockBinding = new()
            {
                PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
            },
            Display = Display.Summarized,
        };
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            BlockBinding = new()
            {
                PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
            },
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetweenToolsSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigBetweenTools();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdaptiveSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigAdaptive()
        {
            BlockBinding = new()
            {
                PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
            },
            Display = Display.Summarized,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            BlockBinding = new()
            {
                PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
            },
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };
        Assert.Equal(BetaThinkingConfigParamType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigDisabled();
        Assert.Equal(BetaThinkingConfigParamType.Disabled, value.Type.Value());
    }

    [Fact]
    public void BetweenToolsTypeWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigBetweenTools();
        Assert.Equal(BetaThinkingConfigParamType.BetweenTools, value.Type.Value());
    }

    [Fact]
    public void AdaptiveTypeWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigAdaptive()
        {
            BlockBinding = new()
            {
                PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
            },
            Display = Display.Summarized,
        };
        Assert.Equal(BetaThinkingConfigParamType.Adaptive, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaThinkingConfigParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "adaptive",
                  "block_binding": {
                    "prefix_mismatch_behavior": "error"
                  }
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaThinkingConfigParamType> expectedType =
            BetaThinkingConfigParamType.Adaptive;
        BetaThinkingBlockBinding expectedBlockBinding = new()
        {
            PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
        };

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedBlockBinding, value.BlockBinding);

        BetaThinkingConfigParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.BlockBinding);

        BetaThinkingConfigParam mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "block_binding": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.BlockBinding);
    }
}

public class BetaThinkingConfigParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaThinkingConfigParamType.Enabled)]
    [InlineData(BetaThinkingConfigParamType.Disabled)]
    [InlineData(BetaThinkingConfigParamType.BetweenTools)]
    [InlineData(BetaThinkingConfigParamType.Adaptive)]
    public void Validation_Works(BetaThinkingConfigParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaThinkingConfigParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaThinkingConfigParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaThinkingConfigParamType.Enabled)]
    [InlineData(BetaThinkingConfigParamType.Disabled)]
    [InlineData(BetaThinkingConfigParamType.BetweenTools)]
    [InlineData(BetaThinkingConfigParamType.Adaptive)]
    public void SerializationRoundtrip_Works(BetaThinkingConfigParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaThinkingConfigParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaThinkingConfigParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaThinkingConfigParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaThinkingConfigParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
