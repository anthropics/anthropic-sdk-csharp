using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.InstallationSettings;

public class BetaPluginInstallationSettingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginInstallationSetting
        {
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            InstallationPreference = BetaPluginInstallationSettingInstallationPreference.Required,
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
            UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");
        ApiEnum<
            string,
            BetaPluginInstallationSettingInstallationPreference
        > expectedInstallationPreference =
            BetaPluginInstallationSettingInstallationPreference.Required;
        string expectedPluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        BetaPluginInstallationSettingTarget expectedTarget = new BetaPluginTargetOrganization();
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_installation_setting");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedInstallationPreference, model.InstallationPreference);
        Assert.Equal(expectedPluginID, model.PluginID);
        Assert.Equal(expectedTarget, model.Target);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginInstallationSetting
        {
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            InstallationPreference = BetaPluginInstallationSettingInstallationPreference.Required,
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
            UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginInstallationSetting>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginInstallationSetting
        {
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            InstallationPreference = BetaPluginInstallationSettingInstallationPreference.Required,
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
            UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginInstallationSetting>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");
        ApiEnum<
            string,
            BetaPluginInstallationSettingInstallationPreference
        > expectedInstallationPreference =
            BetaPluginInstallationSettingInstallationPreference.Required;
        string expectedPluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        BetaPluginInstallationSettingTarget expectedTarget = new BetaPluginTargetOrganization();
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_installation_setting");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedInstallationPreference, deserialized.InstallationPreference);
        Assert.Equal(expectedPluginID, deserialized.PluginID);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginInstallationSetting
        {
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            InstallationPreference = BetaPluginInstallationSettingInstallationPreference.Required,
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
            UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginInstallationSetting
        {
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            InstallationPreference = BetaPluginInstallationSettingInstallationPreference.Required,
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
            UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
        };

        BetaPluginInstallationSetting copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaPluginInstallationSettingInstallationPreferenceTest : TestBase
{
    [Theory]
    [InlineData(BetaPluginInstallationSettingInstallationPreference.AutoInstall)]
    [InlineData(BetaPluginInstallationSettingInstallationPreference.Available)]
    [InlineData(BetaPluginInstallationSettingInstallationPreference.NotAvailable)]
    [InlineData(BetaPluginInstallationSettingInstallationPreference.Required)]
    public void Validation_Works(BetaPluginInstallationSettingInstallationPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaPluginInstallationSettingInstallationPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaPluginInstallationSettingInstallationPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaPluginInstallationSettingInstallationPreference.AutoInstall)]
    [InlineData(BetaPluginInstallationSettingInstallationPreference.Available)]
    [InlineData(BetaPluginInstallationSettingInstallationPreference.NotAvailable)]
    [InlineData(BetaPluginInstallationSettingInstallationPreference.Required)]
    public void SerializationRoundtrip_Works(
        BetaPluginInstallationSettingInstallationPreference rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaPluginInstallationSettingInstallationPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaPluginInstallationSettingInstallationPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaPluginInstallationSettingInstallationPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaPluginInstallationSettingInstallationPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaPluginInstallationSettingTargetTest : TestBase
{
    [Fact]
    public void BetaPluginTargetOrganizationValidationWorks()
    {
        BetaPluginInstallationSettingTarget value = new BetaPluginTargetOrganization();
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetRbacGroupValidationWorks()
    {
        BetaPluginInstallationSettingTarget value = new BetaPluginTargetRbacGroup(
            "rbac_group_012rppKaSVsmTo6NqRDXQXNF"
        );
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetOrganizationMemberValidationWorks()
    {
        BetaPluginInstallationSettingTarget value = new BetaPluginTargetOrganizationMember(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetOrganizationSerializationRoundtripWorks()
    {
        BetaPluginInstallationSettingTarget value = new BetaPluginTargetOrganization();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginInstallationSettingTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginTargetRbacGroupSerializationRoundtripWorks()
    {
        BetaPluginInstallationSettingTarget value = new BetaPluginTargetRbacGroup(
            "rbac_group_012rppKaSVsmTo6NqRDXQXNF"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginInstallationSettingTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginTargetOrganizationMemberSerializationRoundtripWorks()
    {
        BetaPluginInstallationSettingTarget value = new BetaPluginTargetOrganizationMember(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginInstallationSettingTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaPluginInstallationSettingTarget value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "organization"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaPluginInstallationSettingTarget emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
