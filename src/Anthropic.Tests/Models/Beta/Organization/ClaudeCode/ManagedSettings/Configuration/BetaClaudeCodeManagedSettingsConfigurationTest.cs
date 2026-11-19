using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

public class BetaClaudeCodeManagedSettingsConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsConfiguration
        {
            Mode = new BetaClaudeCodeManagedSettingsOrganizationMode(),
            ModeUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupOrder = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            RbacGroupOrderVersion = "rbac_group_order_version",
        };

        BetaClaudeCodeManagedSettingsMode expectedMode =
            new BetaClaudeCodeManagedSettingsOrganizationMode();
        DateTimeOffset expectedModeUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedRbacGroupOrder = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"];
        string expectedRbacGroupOrderVersion = "rbac_group_order_version";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "claude_code_managed_settings_configuration"
        );

        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedModeUpdatedAt, model.ModeUpdatedAt);
        Assert.Equal(expectedRbacGroupOrder.Count, model.RbacGroupOrder.Count);
        for (int i = 0; i < expectedRbacGroupOrder.Count; i++)
        {
            Assert.Equal(expectedRbacGroupOrder[i], model.RbacGroupOrder[i]);
        }
        Assert.Equal(expectedRbacGroupOrderVersion, model.RbacGroupOrderVersion);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsConfiguration
        {
            Mode = new BetaClaudeCodeManagedSettingsOrganizationMode(),
            ModeUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupOrder = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            RbacGroupOrderVersion = "rbac_group_order_version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsConfiguration
        {
            Mode = new BetaClaudeCodeManagedSettingsOrganizationMode(),
            ModeUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupOrder = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            RbacGroupOrderVersion = "rbac_group_order_version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaClaudeCodeManagedSettingsMode expectedMode =
            new BetaClaudeCodeManagedSettingsOrganizationMode();
        DateTimeOffset expectedModeUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedRbacGroupOrder = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"];
        string expectedRbacGroupOrderVersion = "rbac_group_order_version";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "claude_code_managed_settings_configuration"
        );

        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedModeUpdatedAt, deserialized.ModeUpdatedAt);
        Assert.Equal(expectedRbacGroupOrder.Count, deserialized.RbacGroupOrder.Count);
        for (int i = 0; i < expectedRbacGroupOrder.Count; i++)
        {
            Assert.Equal(expectedRbacGroupOrder[i], deserialized.RbacGroupOrder[i]);
        }
        Assert.Equal(expectedRbacGroupOrderVersion, deserialized.RbacGroupOrderVersion);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsConfiguration
        {
            Mode = new BetaClaudeCodeManagedSettingsOrganizationMode(),
            ModeUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupOrder = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            RbacGroupOrderVersion = "rbac_group_order_version",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsConfiguration
        {
            Mode = new BetaClaudeCodeManagedSettingsOrganizationMode(),
            ModeUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupOrder = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            RbacGroupOrderVersion = "rbac_group_order_version",
        };

        BetaClaudeCodeManagedSettingsConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}
