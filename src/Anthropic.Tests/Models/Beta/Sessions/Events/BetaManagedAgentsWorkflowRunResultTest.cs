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
    public void CompletedTypeWorks()
    {
        BetaManagedAgentsWorkflowRunResult value =
            new BetaManagedAgentsWorkflowRunResultCompleted();
        Assert.Equal(BetaManagedAgentsWorkflowRunResultType.Completed, value.Type.Value());
    }

    [Fact]
    public void ErrorTypeWorks()
    {
        BetaManagedAgentsWorkflowRunResult value = new BetaManagedAgentsWorkflowRunResultError(
            new BetaManagedAgentsTimeoutWorkflowRunError("The workflow run reached its time limit.")
        );
        Assert.Equal(BetaManagedAgentsWorkflowRunResultType.Error, value.Type.Value());
    }

    [Fact]
    public void StoppedTypeWorks()
    {
        BetaManagedAgentsWorkflowRunResult value = new BetaManagedAgentsWorkflowRunResultStopped();
        Assert.Equal(BetaManagedAgentsWorkflowRunResultType.Stopped, value.Type.Value());
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

        ApiEnum<string, BetaManagedAgentsWorkflowRunResultType> expectedType =
            BetaManagedAgentsWorkflowRunResultType.Completed;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsWorkflowRunResult emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsWorkflowRunResultTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWorkflowRunResultType.Completed)]
    [InlineData(BetaManagedAgentsWorkflowRunResultType.Error)]
    [InlineData(BetaManagedAgentsWorkflowRunResultType.Stopped)]
    public void Validation_Works(BetaManagedAgentsWorkflowRunResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWorkflowRunResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkflowRunResultType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWorkflowRunResultType.Completed)]
    [InlineData(BetaManagedAgentsWorkflowRunResultType.Error)]
    [InlineData(BetaManagedAgentsWorkflowRunResultType.Stopped)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsWorkflowRunResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWorkflowRunResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkflowRunResultType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkflowRunResultType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkflowRunResultType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
