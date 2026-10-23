using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.SlackChannels;

public class SlackChannelListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SlackChannelListPageResponse
        {
            Data =
            [
                new()
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
                    Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
                    Sources = new()
                    {
                        Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        EnvironmentID = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        GuestPolicy = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        Instructions =
                        [
                            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        ],
                        Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        List<BetaClaudeTagSlackChannel> expectedData =
        [
            new()
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
                Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
                Sources = new()
                {
                    Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
                    Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SlackChannelListPageResponse
        {
            Data =
            [
                new()
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
                    Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
                    Sources = new()
                    {
                        Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        EnvironmentID = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        GuestPolicy = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        Instructions =
                        [
                            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        ],
                        Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SlackChannelListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SlackChannelListPageResponse
        {
            Data =
            [
                new()
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
                    Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
                    Sources = new()
                    {
                        Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        EnvironmentID = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        GuestPolicy = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        Instructions =
                        [
                            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        ],
                        Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SlackChannelListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaClaudeTagSlackChannel> expectedData =
        [
            new()
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
                Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
                Sources = new()
                {
                    Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
                    Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SlackChannelListPageResponse
        {
            Data =
            [
                new()
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
                    Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
                    Sources = new()
                    {
                        Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        EnvironmentID = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        GuestPolicy = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        Instructions =
                        [
                            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        ],
                        Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SlackChannelListPageResponse
        {
            Data =
            [
                new()
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
                    Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
                    Sources = new()
                    {
                        Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        EnvironmentID = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        GuestPolicy = new BetaClaudeTagSlackChannelSettingSource(
                            "slack_channel_id"
                        ),
                        Instructions =
                        [
                            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                        ],
                        Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        SlackChannelListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
