using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

public class BetaClaudeCodeRbacGroupManagedSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettings
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        BetaClaudeCodeRbacGroupStatus expectedRbacGroupStatus =
            new BetaClaudeCodeRbacGroupStatusActive();
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_managed_settings"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupStatus, model.RbacGroupStatus);
        Assert.NotNull(model.Settings);
        Assert.Equal(expectedSettings.Count, model.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(model.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Settings[item.Key]));
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettings
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupManagedSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettings
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupManagedSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        BetaClaudeCodeRbacGroupStatus expectedRbacGroupStatus =
            new BetaClaudeCodeRbacGroupStatusActive();
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_managed_settings"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupStatus, deserialized.RbacGroupStatus);
        Assert.NotNull(deserialized.Settings);
        Assert.Equal(expectedSettings.Count, deserialized.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(deserialized.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Settings[item.Key]));
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettings
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettings
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaClaudeCodeRbacGroupManagedSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}
