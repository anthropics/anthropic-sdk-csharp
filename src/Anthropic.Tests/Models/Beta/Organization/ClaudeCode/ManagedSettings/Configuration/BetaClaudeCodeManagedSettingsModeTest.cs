using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

public class BetaClaudeCodeManagedSettingsModeTest : TestBase
{
    [Fact]
    public void OrganizationValidationWorks()
    {
        BetaClaudeCodeManagedSettingsMode value =
            new BetaClaudeCodeManagedSettingsOrganizationMode();
        value.Validate();
    }

    [Fact]
    public void RbacGroupsValidationWorks()
    {
        BetaClaudeCodeManagedSettingsMode value = new BetaClaudeCodeManagedSettingsRbacGroupsMode();
        value.Validate();
    }

    [Fact]
    public void OrganizationSerializationRoundtripWorks()
    {
        BetaClaudeCodeManagedSettingsMode value =
            new BetaClaudeCodeManagedSettingsOrganizationMode();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsMode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RbacGroupsSerializationRoundtripWorks()
    {
        BetaClaudeCodeManagedSettingsMode value = new BetaClaudeCodeManagedSettingsRbacGroupsMode();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsMode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationTypeWorks()
    {
        BetaClaudeCodeManagedSettingsMode value =
            new BetaClaudeCodeManagedSettingsOrganizationMode();
        Assert.Equal(BetaClaudeCodeManagedSettingsModeType.Organization, value.Type.Value());
    }

    [Fact]
    public void RbacGroupsTypeWorks()
    {
        BetaClaudeCodeManagedSettingsMode value = new BetaClaudeCodeManagedSettingsRbacGroupsMode();
        Assert.Equal(BetaClaudeCodeManagedSettingsModeType.RbacGroups, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaClaudeCodeManagedSettingsMode value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "organization"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaClaudeCodeManagedSettingsModeType> expectedType =
            BetaClaudeCodeManagedSettingsModeType.Organization;

        Assert.Equal(expectedType, value.Type);

        BetaClaudeCodeManagedSettingsMode emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaClaudeCodeManagedSettingsModeTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaClaudeCodeManagedSettingsModeType.Organization)]
    [InlineData(BetaClaudeCodeManagedSettingsModeType.RbacGroups)]
    public void Validation_Works(BetaClaudeCodeManagedSettingsModeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeCodeManagedSettingsModeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeManagedSettingsModeType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaClaudeCodeManagedSettingsModeType.Organization)]
    [InlineData(BetaClaudeCodeManagedSettingsModeType.RbacGroups)]
    public void SerializationRoundtrip_Works(BetaClaudeCodeManagedSettingsModeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeCodeManagedSettingsModeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeManagedSettingsModeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeManagedSettingsModeType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeManagedSettingsModeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
