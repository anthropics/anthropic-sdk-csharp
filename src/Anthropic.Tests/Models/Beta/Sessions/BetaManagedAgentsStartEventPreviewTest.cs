using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsStartEventPreviewTest : TestBase
{
    [Fact]
    public void AgentMessageValidationWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentMessagePreview()
        {
            ID = "id",
            Type = Type.AgentMessage,
        };
        value.Validate();
    }

    [Fact]
    public void AgentThinkingValidationWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentThinkingPreview()
        {
            ID = "id",
            Type = BetaManagedAgentsAgentThinkingPreviewType.AgentThinking,
        };
        value.Validate();
    }

    [Fact]
    public void AgentMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentMessagePreview()
        {
            ID = "id",
            Type = Type.AgentMessage,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStartEventPreview>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThinkingSerializationRoundtripWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentThinkingPreview()
        {
            ID = "id",
            Type = BetaManagedAgentsAgentThinkingPreviewType.AgentThinking,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStartEventPreview>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
