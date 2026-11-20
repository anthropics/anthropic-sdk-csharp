using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

public class BetaClaudeTagSlackChannelBundleTargetCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTargetCreate
        {
            SlackChannelID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
        };

        string expectedSlackChannelID = "slch_01SvpyRQK3nN6eH9uhRA7n1q";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_channel");

        Assert.Equal(expectedSlackChannelID, model.SlackChannelID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTargetCreate
        {
            SlackChannelID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackChannelBundleTargetCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTargetCreate
        {
            SlackChannelID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackChannelBundleTargetCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSlackChannelID = "slch_01SvpyRQK3nN6eH9uhRA7n1q";
        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_channel");

        Assert.Equal(expectedSlackChannelID, deserialized.SlackChannelID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTargetCreate
        {
            SlackChannelID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackChannelBundleTargetCreate
        {
            SlackChannelID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
        };

        BetaClaudeTagSlackChannelBundleTargetCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}
