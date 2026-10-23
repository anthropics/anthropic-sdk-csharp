using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSlackParentChannelSettingSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackParentChannelSettingSource
        {
            SlackChannelID = "slack_channel_id",
        };

        string expectedSlackChannelID = "slack_channel_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_parent_channel");

        Assert.Equal(expectedSlackChannelID, model.SlackChannelID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackParentChannelSettingSource
        {
            SlackChannelID = "slack_channel_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackParentChannelSettingSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackParentChannelSettingSource
        {
            SlackChannelID = "slack_channel_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackParentChannelSettingSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSlackChannelID = "slack_channel_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_parent_channel");

        Assert.Equal(expectedSlackChannelID, deserialized.SlackChannelID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackParentChannelSettingSource
        {
            SlackChannelID = "slack_channel_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackParentChannelSettingSource
        {
            SlackChannelID = "slack_channel_id",
        };

        BetaClaudeTagSlackParentChannelSettingSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
