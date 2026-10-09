using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentWorkflowsDisabledParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsDisabledParams { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsDisabledParams { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsDisabledParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsDisabledParams { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsDisabledParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsDisabledParams { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentWorkflowsDisabledParams { };

        BetaManagedAgentsMultiagentWorkflowsDisabledParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
