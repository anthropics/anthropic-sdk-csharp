using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsSessionCreationRejectedRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionCreationRejectedRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType> expectedType =
            BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionCreationRejectedRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionCreationRejectedRunError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionCreationRejectedRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionCreationRejectedRunError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType> expectedType =
            BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionCreationRejectedRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionCreationRejectedRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError,
        };

        BetaManagedAgentsSessionCreationRejectedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionCreationRejectedRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError)]
    public void Validation_Works(BetaManagedAgentsSessionCreationRejectedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionCreationRejectedRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
