using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsMaxWorkflowRunsWorkflowRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMaxWorkflowRunsWorkflowRunError
        {
            Message = "The session is at its limit of open workflow runs.",
        };

        string expectedMessage = "The session is at its limit of open workflow runs.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("max_workflow_runs_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMaxWorkflowRunsWorkflowRunError
        {
            Message = "The session is at its limit of open workflow runs.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMaxWorkflowRunsWorkflowRunError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMaxWorkflowRunsWorkflowRunError
        {
            Message = "The session is at its limit of open workflow runs.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMaxWorkflowRunsWorkflowRunError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMessage = "The session is at its limit of open workflow runs.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("max_workflow_runs_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMaxWorkflowRunsWorkflowRunError
        {
            Message = "The session is at its limit of open workflow runs.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMaxWorkflowRunsWorkflowRunError
        {
            Message = "The session is at its limit of open workflow runs.",
        };

        BetaManagedAgentsMaxWorkflowRunsWorkflowRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}
