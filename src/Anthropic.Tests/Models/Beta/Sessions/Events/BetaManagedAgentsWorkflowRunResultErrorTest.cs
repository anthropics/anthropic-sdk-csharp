using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunResultError
        {
            Error = new BetaManagedAgentsTimeoutWorkflowRunError(
                "The workflow run reached its time limit."
            ),
        };

        BetaManagedAgentsWorkflowRunError expectedError =
            new BetaManagedAgentsTimeoutWorkflowRunError(
                "The workflow run reached its time limit."
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("error");

        Assert.Equal(expectedError, model.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunResultError
        {
            Error = new BetaManagedAgentsTimeoutWorkflowRunError(
                "The workflow run reached its time limit."
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunResultError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunResultError
        {
            Error = new BetaManagedAgentsTimeoutWorkflowRunError(
                "The workflow run reached its time limit."
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunResultError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsWorkflowRunError expectedError =
            new BetaManagedAgentsTimeoutWorkflowRunError(
                "The workflow run reached its time limit."
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("error");

        Assert.Equal(expectedError, deserialized.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunResultError
        {
            Error = new BetaManagedAgentsTimeoutWorkflowRunError(
                "The workflow run reached its time limit."
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunResultError
        {
            Error = new BetaManagedAgentsTimeoutWorkflowRunError(
                "The workflow run reached its time limit."
            ),
        };

        BetaManagedAgentsWorkflowRunResultError copied = new(model);

        Assert.Equal(model, copied);
    }
}
