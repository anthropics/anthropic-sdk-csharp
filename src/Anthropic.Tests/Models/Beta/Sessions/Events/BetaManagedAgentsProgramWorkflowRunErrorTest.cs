using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsProgramWorkflowRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsProgramWorkflowRunError
        {
            Message = "The workflow run's plan failed.",
        };

        string expectedMessage = "The workflow run's plan failed.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("program_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsProgramWorkflowRunError
        {
            Message = "The workflow run's plan failed.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsProgramWorkflowRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsProgramWorkflowRunError
        {
            Message = "The workflow run's plan failed.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsProgramWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "The workflow run's plan failed.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("program_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsProgramWorkflowRunError
        {
            Message = "The workflow run's plan failed.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsProgramWorkflowRunError
        {
            Message = "The workflow run's plan failed.",
        };

        BetaManagedAgentsProgramWorkflowRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}
