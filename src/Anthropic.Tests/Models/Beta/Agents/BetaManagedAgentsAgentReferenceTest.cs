using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };

        string expectedID = "agent_011CZkYqphY8vELVzwCUpqiQ";
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        int expectedVersion = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "agent_011CZkYqphY8vELVzwCUpqiQ";
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent");
        int expectedVersion = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };

        BetaManagedAgentsAgentReference copied = new(model);

        Assert.Equal(model, copied);
    }
}
