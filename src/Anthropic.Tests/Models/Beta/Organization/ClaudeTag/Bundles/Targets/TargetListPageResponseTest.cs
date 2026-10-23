using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

public class TargetListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TargetListPageResponse
        {
            Data =
            [
                new BetaClaudeTagSlackChannelBundleTarget()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SlackChannelID = "slack_channel_id",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaClaudeTagBundleTarget> expectedData =
        [
            new BetaClaudeTagSlackChannelBundleTarget()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SlackChannelID = "slack_channel_id",
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
        var model = new TargetListPageResponse
        {
            Data =
            [
                new BetaClaudeTagSlackChannelBundleTarget()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SlackChannelID = "slack_channel_id",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TargetListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TargetListPageResponse
        {
            Data =
            [
                new BetaClaudeTagSlackChannelBundleTarget()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SlackChannelID = "slack_channel_id",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TargetListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaClaudeTagBundleTarget> expectedData =
        [
            new BetaClaudeTagSlackChannelBundleTarget()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SlackChannelID = "slack_channel_id",
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
        var model = new TargetListPageResponse
        {
            Data =
            [
                new BetaClaudeTagSlackChannelBundleTarget()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SlackChannelID = "slack_channel_id",
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TargetListPageResponse
        {
            Data =
            [
                new BetaClaudeTagSlackChannelBundleTarget()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SlackChannelID = "slack_channel_id",
                },
            ],
            NextPage = "next_page",
        };

        TargetListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
