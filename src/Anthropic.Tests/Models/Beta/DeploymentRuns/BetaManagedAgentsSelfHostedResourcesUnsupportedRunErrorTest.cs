using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError
        {
            Message = "message",
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "self_hosted_resources_unsupported_error"
        );

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError
        {
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSelfHostedResourcesUnsupportedRunError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError
        {
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSelfHostedResourcesUnsupportedRunError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "self_hosted_resources_unsupported_error"
        );

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError
        {
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError
        {
            Message = "message",
        };

        BetaManagedAgentsSelfHostedResourcesUnsupportedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}
