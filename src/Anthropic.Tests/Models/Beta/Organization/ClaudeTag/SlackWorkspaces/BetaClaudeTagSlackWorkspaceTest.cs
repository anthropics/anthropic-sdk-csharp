using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

public class BetaClaudeTagSlackWorkspaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackWorkspace
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "environment_id",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "model",
            },
            Slack = new("workspace_id"),
            Sources = new()
            {
                Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
                Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaClaudeTagSettings expectedSettings = new()
        {
            Enabled = true,
            EnvironmentID = "environment_id",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "model",
        };
        BetaClaudeTagSlackWorkspaceIdentifiers expectedSlack = new("workspace_id");
        BetaClaudeTagSettingSources expectedSources = new()
        {
            Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
            Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_workspace");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedSettings, model.Settings);
        Assert.Equal(expectedSlack, model.Slack);
        Assert.Equal(expectedSources, model.Sources);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackWorkspace
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "environment_id",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "model",
            },
            Slack = new("workspace_id"),
            Sources = new()
            {
                Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
                Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspace>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackWorkspace
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "environment_id",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "model",
            },
            Slack = new("workspace_id"),
            Sources = new()
            {
                Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
                Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaClaudeTagSettings expectedSettings = new()
        {
            Enabled = true,
            EnvironmentID = "environment_id",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "model",
        };
        BetaClaudeTagSlackWorkspaceIdentifiers expectedSlack = new("workspace_id");
        BetaClaudeTagSettingSources expectedSources = new()
        {
            Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
            Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_workspace");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedSettings, deserialized.Settings);
        Assert.Equal(expectedSlack, deserialized.Slack);
        Assert.Equal(expectedSources, deserialized.Sources);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackWorkspace
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "environment_id",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "model",
            },
            Slack = new("workspace_id"),
            Sources = new()
            {
                Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
                Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackWorkspace
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "environment_id",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "model",
            },
            Slack = new("workspace_id"),
            Sources = new()
            {
                Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
                Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaClaudeTagSlackWorkspace copied = new(model);

        Assert.Equal(model, copied);
    }
}
