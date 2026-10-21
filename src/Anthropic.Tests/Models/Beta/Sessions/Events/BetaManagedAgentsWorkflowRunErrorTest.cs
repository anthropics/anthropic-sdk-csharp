using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunErrorTest : TestBase
{
    [Fact]
    public void TimeoutValidationWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsTimeoutWorkflowRunError(
            "The workflow run reached its time limit."
        );
        value.Validate();
    }

    [Fact]
    public void ProgramValidationWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsProgramWorkflowRunError(
            "The workflow run's plan failed."
        );
        value.Validate();
    }

    [Fact]
    public void UnknownValidationWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsUnknownWorkflowRunError(
            "The workflow run failed."
        );
        value.Validate();
    }

    [Fact]
    public void ThreadLimitValidationWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsThreadLimitWorkflowRunError(
            "The workflow run exceeded its limit of threads."
        );
        value.Validate();
    }

    [Fact]
    public void MaxWorkflowRunsValidationWorks()
    {
        BetaManagedAgentsWorkflowRunError value =
            new BetaManagedAgentsMaxWorkflowRunsWorkflowRunError(
                "The session is at its limit of open workflow runs."
            );
        value.Validate();
    }

    [Fact]
    public void TimeoutSerializationRoundtripWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsTimeoutWorkflowRunError(
            "The workflow run reached its time limit."
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ProgramSerializationRoundtripWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsProgramWorkflowRunError(
            "The workflow run's plan failed."
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownSerializationRoundtripWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsUnknownWorkflowRunError(
            "The workflow run failed."
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadLimitSerializationRoundtripWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsThreadLimitWorkflowRunError(
            "The workflow run exceeded its limit of threads."
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MaxWorkflowRunsSerializationRoundtripWorks()
    {
        BetaManagedAgentsWorkflowRunError value =
            new BetaManagedAgentsMaxWorkflowRunsWorkflowRunError(
                "The session is at its limit of open workflow runs."
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsWorkflowRunError value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "message": "The workflow run reached its time limit.",
                  "type": "timeout_error"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedMessage = "The workflow run reached its time limit.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("timeout_error");

        Assert.Equal(expectedMessage, value.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaManagedAgentsWorkflowRunError emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Message);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaManagedAgentsWorkflowRunError mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "message": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Message);
    }
}
