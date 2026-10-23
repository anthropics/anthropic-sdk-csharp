using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

public class BetaClaudeTagSlackWorkspaceBundleTargetCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTargetCreate
        {
            SlackWorkspaceID = "xxxxxxxx",
        };

        string expectedSlackWorkspaceID = "xxxxxxxx";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_workspace");

        Assert.Equal(expectedSlackWorkspaceID, model.SlackWorkspaceID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTargetCreate
        {
            SlackWorkspaceID = "xxxxxxxx",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceBundleTargetCreate>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTargetCreate
        {
            SlackWorkspaceID = "xxxxxxxx",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceBundleTargetCreate>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedSlackWorkspaceID = "xxxxxxxx";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_workspace");

        Assert.Equal(expectedSlackWorkspaceID, deserialized.SlackWorkspaceID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTargetCreate
        {
            SlackWorkspaceID = "xxxxxxxx",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTargetCreate
        {
            SlackWorkspaceID = "xxxxxxxx",
        };

        BetaClaudeTagSlackWorkspaceBundleTargetCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}
