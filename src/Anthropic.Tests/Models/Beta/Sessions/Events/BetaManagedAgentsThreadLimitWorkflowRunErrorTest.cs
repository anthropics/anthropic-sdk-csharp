using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsThreadLimitWorkflowRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsThreadLimitWorkflowRunError
        {
            Message = "The workflow run exceeded its limit of threads.",
        };

        string expectedMessage = "The workflow run exceeded its limit of threads.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("thread_limit_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsThreadLimitWorkflowRunError
        {
            Message = "The workflow run exceeded its limit of threads.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsThreadLimitWorkflowRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsThreadLimitWorkflowRunError
        {
            Message = "The workflow run exceeded its limit of threads.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsThreadLimitWorkflowRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "The workflow run exceeded its limit of threads.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("thread_limit_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsThreadLimitWorkflowRunError
        {
            Message = "The workflow run exceeded its limit of threads.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsThreadLimitWorkflowRunError
        {
            Message = "The workflow run exceeded its limit of threads.",
        };

        BetaManagedAgentsThreadLimitWorkflowRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}
