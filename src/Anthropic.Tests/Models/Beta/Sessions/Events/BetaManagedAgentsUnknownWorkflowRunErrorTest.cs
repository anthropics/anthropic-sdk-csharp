using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUnknownWorkflowRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUnknownWorkflowRunError
        {
            Message = "The workflow run failed.",
        };

        string expectedMessage = "The workflow run failed.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("unknown_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUnknownWorkflowRunError
        {
            Message = "The workflow run failed.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUnknownWorkflowRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUnknownWorkflowRunError
        {
            Message = "The workflow run failed.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUnknownWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "The workflow run failed.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("unknown_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUnknownWorkflowRunError
        {
            Message = "The workflow run failed.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUnknownWorkflowRunError
        {
            Message = "The workflow run failed.",
        };

        BetaManagedAgentsUnknownWorkflowRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}
