using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSlackGridChannelSettingSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackGridChannelSettingSource
        {
            Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
        };

        BetaClaudeTagSlackChannelIdentifiers expectedSlack = new()
        {
            ChannelID = "xx",
            WorkspaceID = "xx",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_grid_channel");

        Assert.Equal(expectedSlack, model.Slack);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackGridChannelSettingSource
        {
            Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackGridChannelSettingSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackGridChannelSettingSource
        {
            Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackGridChannelSettingSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaClaudeTagSlackChannelIdentifiers expectedSlack = new()
        {
            ChannelID = "xx",
            WorkspaceID = "xx",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_grid_channel");

        Assert.Equal(expectedSlack, deserialized.Slack);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackGridChannelSettingSource
        {
            Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackGridChannelSettingSource
        {
            Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
        };

        BetaClaudeTagSlackGridChannelSettingSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
