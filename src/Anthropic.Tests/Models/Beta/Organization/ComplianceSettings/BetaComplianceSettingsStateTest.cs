using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ComplianceSettings;

public class BetaComplianceSettingsStateTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateEnabled();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateDisabled();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateEnabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettingsState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettingsState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateEnabled();
        Assert.Equal(BetaComplianceSettingsStateType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateDisabled();
        Assert.Equal(BetaComplianceSettingsStateType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaComplianceSettingsState value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaComplianceSettingsStateType> expectedType =
            BetaComplianceSettingsStateType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaComplianceSettingsState emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaComplianceSettingsStateTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceSettingsStateType.Enabled)]
    [InlineData(BetaComplianceSettingsStateType.Disabled)]
    public void Validation_Works(BetaComplianceSettingsStateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceSettingsStateType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceSettingsStateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceSettingsStateType.Enabled)]
    [InlineData(BetaComplianceSettingsStateType.Disabled)]
    public void SerializationRoundtrip_Works(BetaComplianceSettingsStateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceSettingsStateType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceSettingsStateType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceSettingsStateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceSettingsStateType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
