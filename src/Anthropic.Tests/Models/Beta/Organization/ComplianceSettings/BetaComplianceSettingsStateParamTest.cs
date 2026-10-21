using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ComplianceSettings;

public class BetaComplianceSettingsStateParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaComplianceSettingsStateParam value = new BetaComplianceSettingsStateEnabledParam();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaComplianceSettingsStateParam value = new BetaComplianceSettingsStateDisabledParam();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaComplianceSettingsStateParam value = new BetaComplianceSettingsStateEnabledParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettingsStateParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaComplianceSettingsStateParam value = new BetaComplianceSettingsStateDisabledParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettingsStateParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaComplianceSettingsStateParam value = new BetaComplianceSettingsStateEnabledParam();
        Assert.Equal(BetaComplianceSettingsStateParamType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaComplianceSettingsStateParam value = new BetaComplianceSettingsStateDisabledParam();
        Assert.Equal(BetaComplianceSettingsStateParamType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaComplianceSettingsStateParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaComplianceSettingsStateParamType> expectedType =
            BetaComplianceSettingsStateParamType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaComplianceSettingsStateParam emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaComplianceSettingsStateParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceSettingsStateParamType.Enabled)]
    [InlineData(BetaComplianceSettingsStateParamType.Disabled)]
    public void Validation_Works(BetaComplianceSettingsStateParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceSettingsStateParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceSettingsStateParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceSettingsStateParamType.Enabled)]
    [InlineData(BetaComplianceSettingsStateParamType.Disabled)]
    public void SerializationRoundtrip_Works(BetaComplianceSettingsStateParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceSettingsStateParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceSettingsStateParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceSettingsStateParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceSettingsStateParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
