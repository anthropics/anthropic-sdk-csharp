using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAnthropicSkillParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams { SkillID = "xlsx", Version = "1" };

        string expectedSkillID = "xlsx";
        JsonElement expectedType = JsonSerializer.SerializeToElement("anthropic");
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams { SkillID = "xlsx", Version = "1" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAnthropicSkillParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams { SkillID = "xlsx", Version = "1" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAnthropicSkillParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSkillID = "xlsx";
        JsonElement expectedType = JsonSerializer.SerializeToElement("anthropic");
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams { SkillID = "xlsx", Version = "1" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams { SkillID = "xlsx" };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams { SkillID = "xlsx" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",

            Version = null,
        };

        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",

            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams { SkillID = "xlsx", Version = "1" };

        BetaManagedAgentsAnthropicSkillParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
