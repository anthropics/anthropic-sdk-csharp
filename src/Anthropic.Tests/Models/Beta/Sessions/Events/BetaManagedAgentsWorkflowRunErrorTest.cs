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
    public void TimeoutTypeWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsTimeoutWorkflowRunError(
            "The workflow run reached its time limit."
        );
        Assert.Equal(BetaManagedAgentsWorkflowRunErrorType.TimeoutError, value.Type.Value());
    }

    [Fact]
    public void ProgramTypeWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsProgramWorkflowRunError(
            "The workflow run's plan failed."
        );
        Assert.Equal(BetaManagedAgentsWorkflowRunErrorType.ProgramError, value.Type.Value());
    }

    [Fact]
    public void UnknownTypeWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsUnknownWorkflowRunError(
            "The workflow run failed."
        );
        Assert.Equal(BetaManagedAgentsWorkflowRunErrorType.UnknownError, value.Type.Value());
    }

    [Fact]
    public void ThreadLimitTypeWorks()
    {
        BetaManagedAgentsWorkflowRunError value = new BetaManagedAgentsThreadLimitWorkflowRunError(
            "The workflow run exceeded its limit of threads."
        );
        Assert.Equal(BetaManagedAgentsWorkflowRunErrorType.ThreadLimitError, value.Type.Value());
    }

    [Fact]
    public void MaxWorkflowRunsTypeWorks()
    {
        BetaManagedAgentsWorkflowRunError value =
            new BetaManagedAgentsMaxWorkflowRunsWorkflowRunError(
                "The session is at its limit of open workflow runs."
            );
        Assert.Equal(
            BetaManagedAgentsWorkflowRunErrorType.MaxWorkflowRunsError,
            value.Type.Value()
        );
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
        ApiEnum<string, BetaManagedAgentsWorkflowRunErrorType> expectedType =
            BetaManagedAgentsWorkflowRunErrorType.TimeoutError;

        Assert.Equal(expectedMessage, value.Message);
        Assert.Equal(expectedType, value.Type);

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

public class BetaManagedAgentsWorkflowRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.TimeoutError)]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.ProgramError)]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.UnknownError)]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.ThreadLimitError)]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.MaxWorkflowRunsError)]
    public void Validation_Works(BetaManagedAgentsWorkflowRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWorkflowRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkflowRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.TimeoutError)]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.ProgramError)]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.UnknownError)]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.ThreadLimitError)]
    [InlineData(BetaManagedAgentsWorkflowRunErrorType.MaxWorkflowRunsError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsWorkflowRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWorkflowRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkflowRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkflowRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkflowRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
