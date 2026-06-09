using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsEnvironmentNotFoundRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType> expectedType =
            BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentNotFoundRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentNotFoundRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType> expectedType =
            BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError,
        };

        BetaManagedAgentsEnvironmentNotFoundRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsEnvironmentNotFoundRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError)]
    public void Validation_Works(BetaManagedAgentsEnvironmentNotFoundRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsEnvironmentNotFoundRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
