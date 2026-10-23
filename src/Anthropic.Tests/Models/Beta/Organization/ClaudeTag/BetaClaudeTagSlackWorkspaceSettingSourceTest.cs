using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSlackWorkspaceSettingSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceSettingSource
        {
            SlackWorkspaceID = "slack_workspace_id",
        };

        string expectedSlackWorkspaceID = "slack_workspace_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_workspace");

        Assert.Equal(expectedSlackWorkspaceID, model.SlackWorkspaceID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceSettingSource
        {
            SlackWorkspaceID = "slack_workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceSettingSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceSettingSource
        {
            SlackWorkspaceID = "slack_workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceSettingSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSlackWorkspaceID = "slack_workspace_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_workspace");

        Assert.Equal(expectedSlackWorkspaceID, deserialized.SlackWorkspaceID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceSettingSource
        {
            SlackWorkspaceID = "slack_workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceSettingSource
        {
            SlackWorkspaceID = "slack_workspace_id",
        };

        BetaClaudeTagSlackWorkspaceSettingSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
