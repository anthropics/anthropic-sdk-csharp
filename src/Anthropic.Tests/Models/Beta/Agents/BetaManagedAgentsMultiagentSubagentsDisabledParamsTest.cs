using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentSubagentsDisabledParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentSubagentsDisabledParams { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentSubagentsDisabledParams { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagentsDisabledParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentSubagentsDisabledParams { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSubagentsDisabledParams>(
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
        var model = new BetaManagedAgentsMultiagentSubagentsDisabledParams { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentSubagentsDisabledParams { };

        BetaManagedAgentsMultiagentSubagentsDisabledParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
