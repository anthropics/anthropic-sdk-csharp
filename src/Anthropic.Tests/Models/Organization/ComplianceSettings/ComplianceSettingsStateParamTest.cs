using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Organization.ComplianceSettings;

public class ComplianceSettingsStateParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateEnabledParam();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateDisabledParam();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateEnabledParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsStateParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateDisabledParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsStateParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateEnabledParam();
        Assert.Equal(ComplianceSettingsStateParamType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateDisabledParam();
        Assert.Equal(ComplianceSettingsStateParamType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ComplianceSettingsStateParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ComplianceSettingsStateParamType> expectedType =
            ComplianceSettingsStateParamType.Enabled;

        Assert.Equal(expectedType, value.Type);

        ComplianceSettingsStateParam emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ComplianceSettingsStateParamTypeTest : TestBase
{
    [Theory]
    [InlineData(ComplianceSettingsStateParamType.Enabled)]
    [InlineData(ComplianceSettingsStateParamType.Disabled)]
    public void Validation_Works(ComplianceSettingsStateParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComplianceSettingsStateParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComplianceSettingsStateParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ComplianceSettingsStateParamType.Enabled)]
    [InlineData(ComplianceSettingsStateParamType.Disabled)]
    public void SerializationRoundtrip_Works(ComplianceSettingsStateParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComplianceSettingsStateParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ComplianceSettingsStateParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComplianceSettingsStateParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ComplianceSettingsStateParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
