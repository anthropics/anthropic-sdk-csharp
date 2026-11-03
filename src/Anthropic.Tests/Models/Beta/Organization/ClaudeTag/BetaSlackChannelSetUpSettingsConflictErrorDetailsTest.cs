using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaSlackChannelSetUpSettingsConflictErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSlackChannelSetUpSettingsConflictErrorDetails
        {
            SlackChannelID = "slack_channel_id",
        };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "slack_channel_set_up_settings_conflict"
        );
        string expectedSlackChannelID = "slack_channel_id";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedSlackChannelID, model.SlackChannelID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSlackChannelSetUpSettingsConflictErrorDetails
        {
            SlackChannelID = "slack_channel_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaSlackChannelSetUpSettingsConflictErrorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSlackChannelSetUpSettingsConflictErrorDetails
        {
            SlackChannelID = "slack_channel_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaSlackChannelSetUpSettingsConflictErrorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "slack_channel_set_up_settings_conflict"
        );
        string expectedSlackChannelID = "slack_channel_id";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedSlackChannelID, deserialized.SlackChannelID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSlackChannelSetUpSettingsConflictErrorDetails
        {
            SlackChannelID = "slack_channel_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSlackChannelSetUpSettingsConflictErrorDetails
        {
            SlackChannelID = "slack_channel_id",
        };

        BetaSlackChannelSetUpSettingsConflictErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
