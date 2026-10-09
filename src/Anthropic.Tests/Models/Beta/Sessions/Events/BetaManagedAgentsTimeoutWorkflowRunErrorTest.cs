using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsTimeoutWorkflowRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTimeoutWorkflowRunError
        {
            Message = "The workflow run reached its time limit.",
        };

        string expectedMessage = "The workflow run reached its time limit.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("timeout_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTimeoutWorkflowRunError
        {
            Message = "The workflow run reached its time limit.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTimeoutWorkflowRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTimeoutWorkflowRunError
        {
            Message = "The workflow run reached its time limit.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTimeoutWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "The workflow run reached its time limit.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("timeout_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTimeoutWorkflowRunError
        {
            Message = "The workflow run reached its time limit.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTimeoutWorkflowRunError
        {
            Message = "The workflow run reached its time limit.",
        };

        BetaManagedAgentsTimeoutWorkflowRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}
