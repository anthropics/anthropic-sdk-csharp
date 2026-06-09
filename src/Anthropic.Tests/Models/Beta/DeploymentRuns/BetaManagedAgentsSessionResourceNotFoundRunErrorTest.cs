using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsSessionResourceNotFoundRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType> expectedType =
            BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceNotFoundRunError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceNotFoundRunError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType> expectedType =
            BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundRunError
        {
            Message = "message",
            Type =
                BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError,
        };

        BetaManagedAgentsSessionResourceNotFoundRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionResourceNotFoundRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError)]
    public void Validation_Works(BetaManagedAgentsSessionResourceNotFoundRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionResourceNotFoundRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
