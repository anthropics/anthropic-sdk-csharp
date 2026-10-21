using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunResultTest : TestBase
{
    [Fact]
    public void CompletedValidationWorks()
    {
        BetaManagedAgentsWorkflowRunResult value =
            new BetaManagedAgentsWorkflowRunResultCompleted();
        value.Validate();
    }

    [Fact]
    public void ErrorValidationWorks()
    {
        BetaManagedAgentsWorkflowRunResult value = new BetaManagedAgentsWorkflowRunResultError(
            new BetaManagedAgentsTimeoutWorkflowRunError("The workflow run reached its time limit.")
        );
        value.Validate();
    }

    [Fact]
    public void StoppedValidationWorks()
    {
        BetaManagedAgentsWorkflowRunResult value = new BetaManagedAgentsWorkflowRunResultStopped();
        value.Validate();
    }

    [Fact]
    public void CompletedSerializationRoundtripWorks()
    {
        BetaManagedAgentsWorkflowRunResult value =
            new BetaManagedAgentsWorkflowRunResultCompleted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        BetaManagedAgentsWorkflowRunResult value = new BetaManagedAgentsWorkflowRunResultError(
            new BetaManagedAgentsTimeoutWorkflowRunError("The workflow run reached its time limit.")
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StoppedSerializationRoundtripWorks()
    {
        BetaManagedAgentsWorkflowRunResult value = new BetaManagedAgentsWorkflowRunResultStopped();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsWorkflowRunResult value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "completed"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("completed");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaManagedAgentsWorkflowRunResult emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
