using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSkillParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": "xlsx",
                  "version": "1"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedSkillID = "xlsx";
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, value.SkillID);
        Assert.Equal(expectedVersion, value.Version);

        BetaManagedAgentsSkillParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.SkillID);
        Assert.Null(emptyValue.Version);

        BetaManagedAgentsSkillParams mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": [
                    "invalid"
                  ],
                  "version": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.SkillID);
        Assert.Null(mismatchedValue.Version);
    }
}
