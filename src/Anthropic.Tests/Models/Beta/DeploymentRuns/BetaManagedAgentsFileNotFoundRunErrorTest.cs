using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsFileNotFoundRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType> expectedType =
            BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileNotFoundRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsFileNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileNotFoundRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType> expectedType =
            BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsFileNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError,
        };

        BetaManagedAgentsFileNotFoundRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsFileNotFoundRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError)]
    public void Validation_Works(BetaManagedAgentsFileNotFoundRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsFileNotFoundRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
