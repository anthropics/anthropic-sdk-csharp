using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

public class BetaClaudeTagSlackWorkspaceBundleTargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackWorkspaceID = "slack_workspace_id",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSlackWorkspaceID = "slack_workspace_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_workspace");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedSlackWorkspaceID, model.SlackWorkspaceID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackWorkspaceID = "slack_workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceBundleTarget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackWorkspaceID = "slack_workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceBundleTarget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSlackWorkspaceID = "slack_workspace_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_workspace");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedSlackWorkspaceID, deserialized.SlackWorkspaceID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackWorkspaceID = "slack_workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackWorkspaceBundleTarget
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackWorkspaceID = "slack_workspace_id",
        };

        BetaClaudeTagSlackWorkspaceBundleTarget copied = new(model);

        Assert.Equal(model, copied);
    }
}
