using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

public class BetaClaudeCodeRbacGroupManagedSettingsSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettingsSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        BetaClaudeCodeRbacGroupStatus expectedRbacGroupStatus =
            new BetaClaudeCodeRbacGroupStatusActive();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_managed_settings_summary"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupStatus, model.RbacGroupStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettingsSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupManagedSettingsSummary>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettingsSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupManagedSettingsSummary>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        BetaClaudeCodeRbacGroupStatus expectedRbacGroupStatus =
            new BetaClaudeCodeRbacGroupStatusActive();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_managed_settings_summary"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupStatus, deserialized.RbacGroupStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettingsSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeCodeRbacGroupManagedSettingsSummary
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaClaudeCodeRbacGroupManagedSettingsSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}
