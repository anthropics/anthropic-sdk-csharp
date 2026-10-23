using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSettingSourcesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSettingSources
        {
            Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
            Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        };

        BetaClaudeTagSettingSource expectedEnabled = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );
        BetaClaudeTagSettingSource expectedEnvironmentID =
            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id");
        BetaClaudeTagSettingSource expectedGuestPolicy = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );
        List<BetaClaudeTagSettingSource> expectedInstructions =
        [
            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        ];
        BetaClaudeTagSettingSource expectedModel = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedEnvironmentID, model.EnvironmentID);
        Assert.Equal(expectedGuestPolicy, model.GuestPolicy);
        Assert.Equal(expectedInstructions.Count, model.Instructions.Count);
        for (int i = 0; i < expectedInstructions.Count; i++)
        {
            Assert.Equal(expectedInstructions[i], model.Instructions[i]);
        }
        Assert.Equal(expectedModel, model.Model);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSettingSources
        {
            Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
            Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingSources>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSettingSources
        {
            Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
            Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingSources>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaClaudeTagSettingSource expectedEnabled = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );
        BetaClaudeTagSettingSource expectedEnvironmentID =
            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id");
        BetaClaudeTagSettingSource expectedGuestPolicy = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );
        List<BetaClaudeTagSettingSource> expectedInstructions =
        [
            new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        ];
        BetaClaudeTagSettingSource expectedModel = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedEnvironmentID, deserialized.EnvironmentID);
        Assert.Equal(expectedGuestPolicy, deserialized.GuestPolicy);
        Assert.Equal(expectedInstructions.Count, deserialized.Instructions.Count);
        for (int i = 0; i < expectedInstructions.Count; i++)
        {
            Assert.Equal(expectedInstructions[i], deserialized.Instructions[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSettingSources
        {
            Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
            Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSettingSources
        {
            Enabled = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            EnvironmentID = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            GuestPolicy = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
            Instructions = [new BetaClaudeTagSlackChannelSettingSource("slack_channel_id")],
            Model = new BetaClaudeTagSlackChannelSettingSource("slack_channel_id"),
        };

        BetaClaudeTagSettingSources copied = new(model);

        Assert.Equal(model, copied);
    }
}
