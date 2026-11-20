using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSlackChannelIdentifiersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackChannelIdentifiers
        {
            ChannelID = "C0456EFGH",
            WorkspaceID = "T0123ABCD",
        };

        string expectedChannelID = "C0456EFGH";
        string expectedWorkspaceID = "T0123ABCD";

        Assert.Equal(expectedChannelID, model.ChannelID);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackChannelIdentifiers
        {
            ChannelID = "C0456EFGH",
            WorkspaceID = "T0123ABCD",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackChannelIdentifiers>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackChannelIdentifiers
        {
            ChannelID = "C0456EFGH",
            WorkspaceID = "T0123ABCD",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackChannelIdentifiers>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannelID = "C0456EFGH";
        string expectedWorkspaceID = "T0123ABCD";

        Assert.Equal(expectedChannelID, deserialized.ChannelID);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackChannelIdentifiers
        {
            ChannelID = "C0456EFGH",
            WorkspaceID = "T0123ABCD",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackChannelIdentifiers
        {
            ChannelID = "C0456EFGH",
            WorkspaceID = "T0123ABCD",
        };

        BetaClaudeTagSlackChannelIdentifiers copied = new(model);

        Assert.Equal(model, copied);
    }
}
