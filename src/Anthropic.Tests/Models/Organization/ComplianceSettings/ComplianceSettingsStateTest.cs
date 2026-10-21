using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Organization.ComplianceSettings;

public class ComplianceSettingsStateTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateEnabled();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateDisabled();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateEnabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateEnabled();
        Assert.Equal(ComplianceSettingsStateType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateDisabled();
        Assert.Equal(ComplianceSettingsStateType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ComplianceSettingsState value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ComplianceSettingsStateType> expectedType =
            ComplianceSettingsStateType.Enabled;

        Assert.Equal(expectedType, value.Type);

        ComplianceSettingsState emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ComplianceSettingsStateTypeTest : TestBase
{
    [Theory]
    [InlineData(ComplianceSettingsStateType.Enabled)]
    [InlineData(ComplianceSettingsStateType.Disabled)]
    public void Validation_Works(ComplianceSettingsStateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComplianceSettingsStateType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComplianceSettingsStateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ComplianceSettingsStateType.Enabled)]
    [InlineData(ComplianceSettingsStateType.Disabled)]
    public void SerializationRoundtrip_Works(ComplianceSettingsStateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComplianceSettingsStateType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComplianceSettingsStateType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComplianceSettingsStateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComplianceSettingsStateType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
