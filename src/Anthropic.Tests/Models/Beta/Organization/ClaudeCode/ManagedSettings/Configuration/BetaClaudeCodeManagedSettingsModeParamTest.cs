using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

public class BetaClaudeCodeManagedSettingsModeParamTest : TestBase
{
    [Fact]
    public void OrganizationValidationWorks()
    {
        BetaClaudeCodeManagedSettingsModeParam value =
            new BetaClaudeCodeManagedSettingsOrganizationModeParam();
        value.Validate();
    }

    [Fact]
    public void RbacGroupsValidationWorks()
    {
        BetaClaudeCodeManagedSettingsModeParam value =
            new BetaClaudeCodeManagedSettingsRbacGroupsModeParam();
        value.Validate();
    }

    [Fact]
    public void OrganizationSerializationRoundtripWorks()
    {
        BetaClaudeCodeManagedSettingsModeParam value =
            new BetaClaudeCodeManagedSettingsOrganizationModeParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsModeParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RbacGroupsSerializationRoundtripWorks()
    {
        BetaClaudeCodeManagedSettingsModeParam value =
            new BetaClaudeCodeManagedSettingsRbacGroupsModeParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsModeParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationTypeWorks()
    {
        BetaClaudeCodeManagedSettingsModeParam value =
            new BetaClaudeCodeManagedSettingsOrganizationModeParam();
        Assert.Equal(BetaClaudeCodeManagedSettingsModeParamType.Organization, value.Type.Value());
    }

    [Fact]
    public void RbacGroupsTypeWorks()
    {
        BetaClaudeCodeManagedSettingsModeParam value =
            new BetaClaudeCodeManagedSettingsRbacGroupsModeParam();
        Assert.Equal(BetaClaudeCodeManagedSettingsModeParamType.RbacGroups, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaClaudeCodeManagedSettingsModeParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "organization"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType> expectedType =
            BetaClaudeCodeManagedSettingsModeParamType.Organization;

        Assert.Equal(expectedType, value.Type);

        BetaClaudeCodeManagedSettingsModeParam emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaClaudeCodeManagedSettingsModeParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaClaudeCodeManagedSettingsModeParamType.Organization)]
    [InlineData(BetaClaudeCodeManagedSettingsModeParamType.RbacGroups)]
    public void Validation_Works(BetaClaudeCodeManagedSettingsModeParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaClaudeCodeManagedSettingsModeParamType.Organization, 0, "organization")]
    [InlineData(BetaClaudeCodeManagedSettingsModeParamType.RbacGroups, 1, "rbac_groups")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaClaudeCodeManagedSettingsModeParamType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
