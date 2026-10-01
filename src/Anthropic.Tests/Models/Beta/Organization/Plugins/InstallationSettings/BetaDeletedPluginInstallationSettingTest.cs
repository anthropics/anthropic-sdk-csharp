using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.InstallationSettings;

public class BetaDeletedPluginInstallationSettingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDeletedPluginInstallationSetting
        {
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF"),
        };

        string expectedPluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        Target expectedTarget = new BetaPluginTargetRbacGroup(
            "rbac_group_012rppKaSVsmTo6NqRDXQXNF"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "plugin_installation_setting_deleted"
        );

        Assert.Equal(expectedPluginID, model.PluginID);
        Assert.Equal(expectedTarget, model.Target);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDeletedPluginInstallationSetting
        {
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedPluginInstallationSetting>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDeletedPluginInstallationSetting
        {
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedPluginInstallationSetting>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        Target expectedTarget = new BetaPluginTargetRbacGroup(
            "rbac_group_012rppKaSVsmTo6NqRDXQXNF"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "plugin_installation_setting_deleted"
        );

        Assert.Equal(expectedPluginID, deserialized.PluginID);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDeletedPluginInstallationSetting
        {
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDeletedPluginInstallationSetting
        {
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF"),
        };

        BetaDeletedPluginInstallationSetting copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetTest : TestBase
{
    [Fact]
    public void BetaPluginTargetOrganizationValidationWorks()
    {
        Target value = new BetaPluginTargetOrganization();
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetRbacGroupValidationWorks()
    {
        Target value = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF");
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetOrganizationMemberValidationWorks()
    {
        Target value = new BetaPluginTargetOrganizationMember("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetOrganizationSerializationRoundtripWorks()
    {
        Target value = new BetaPluginTargetOrganization();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Target>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginTargetRbacGroupSerializationRoundtripWorks()
    {
        Target value = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Target>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginTargetOrganizationMemberSerializationRoundtripWorks()
    {
        Target value = new BetaPluginTargetOrganizationMember("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Target>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Target value = new(
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

        Target emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
