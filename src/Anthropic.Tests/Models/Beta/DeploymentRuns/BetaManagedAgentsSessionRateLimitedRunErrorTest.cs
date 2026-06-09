using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsSessionRateLimitedRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionRateLimitedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType> expectedType =
            BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionRateLimitedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionRateLimitedRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionRateLimitedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionRateLimitedRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType> expectedType =
            BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionRateLimitedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionRateLimitedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError,
        };

        BetaManagedAgentsSessionRateLimitedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionRateLimitedRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError)]
    public void Validation_Works(BetaManagedAgentsSessionRateLimitedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionRateLimitedRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
