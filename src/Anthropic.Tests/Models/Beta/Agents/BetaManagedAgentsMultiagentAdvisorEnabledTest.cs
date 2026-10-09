using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentAdvisorEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentAdvisorEnabled { Model = "claude-fable-5" };

        string expectedModel = "claude-fable-5";
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedModel, model.Model);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentAdvisorEnabled { Model = "claude-fable-5" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentAdvisorEnabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentAdvisorEnabled { Model = "claude-fable-5" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentAdvisorEnabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModel = "claude-fable-5";
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagentAdvisorEnabled { Model = "claude-fable-5" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentAdvisorEnabled { Model = "claude-fable-5" };

        BetaManagedAgentsMultiagentAdvisorEnabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
