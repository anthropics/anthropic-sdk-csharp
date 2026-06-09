using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            Type =
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType> expectedType =
            BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError,
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
            Type =
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSelfHostedResourcesUnsupportedRunError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType> expectedType =
            BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError,
        };

        BetaManagedAgentsSelfHostedResourcesUnsupportedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError
    )]
    public void Validation_Works(
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError
    )]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
