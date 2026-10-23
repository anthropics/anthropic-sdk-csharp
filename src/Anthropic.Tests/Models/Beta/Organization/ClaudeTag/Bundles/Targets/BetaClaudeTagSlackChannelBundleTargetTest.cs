using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

public class BetaClaudeTagSlackChannelBundleTargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackChannelID = "slack_channel_id",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSlackChannelID = "slack_channel_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_channel");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedSlackChannelID, model.SlackChannelID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackChannelID = "slack_channel_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackChannelBundleTarget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackChannelID = "slack_channel_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackChannelBundleTarget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSlackChannelID = "slack_channel_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_channel");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedSlackChannelID, deserialized.SlackChannelID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackChannelID = "slack_channel_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackChannelID = "slack_channel_id",
        };

        BetaClaudeTagSlackChannelBundleTarget copied = new(model);

        Assert.Equal(model, copied);
    }
}
