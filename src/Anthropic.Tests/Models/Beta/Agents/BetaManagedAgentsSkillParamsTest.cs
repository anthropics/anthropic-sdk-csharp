using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsSkillParamsTest : TestBase
{
    [Fact]
    public void AnthropicValidationWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsAnthropicSkillParams()
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
            Version = "1",
        };
        value.Validate();
    }

    [Fact]
    public void CustomValidationWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsCustomSkillParams()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillParamsType.Custom,
            Version = "2",
        };
        value.Validate();
    }

    [Fact]
    public void AnthropicSerializationRoundtripWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsAnthropicSkillParams()
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
            Version = "1",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSkillParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CustomSerializationRoundtripWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsCustomSkillParams()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillParamsType.Custom,
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSkillParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
