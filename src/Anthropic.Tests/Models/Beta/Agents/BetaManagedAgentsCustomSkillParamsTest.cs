using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsCustomSkillParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };

        string expectedSkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx";
        JsonElement expectedType = JsonSerializer.SerializeToElement("custom");
        string expectedVersion = "2";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCustomSkillParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCustomSkillParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx";
        JsonElement expectedType = JsonSerializer.SerializeToElement("custom");
        string expectedVersion = "2";

        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
        };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",

            Version = null,
        };

        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",

            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCustomSkillParams
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };

        BetaManagedAgentsCustomSkillParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
