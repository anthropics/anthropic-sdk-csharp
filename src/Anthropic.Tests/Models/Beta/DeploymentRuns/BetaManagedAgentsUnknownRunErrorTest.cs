using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsUnknownRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUnknownRunError
        {
            Message = "message",
            Type = BetaManagedAgentsUnknownRunErrorType.UnknownError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsUnknownRunErrorType> expectedType =
            BetaManagedAgentsUnknownRunErrorType.UnknownError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUnknownRunError
        {
            Message = "message",
            Type = BetaManagedAgentsUnknownRunErrorType.UnknownError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUnknownRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUnknownRunError
        {
            Message = "message",
            Type = BetaManagedAgentsUnknownRunErrorType.UnknownError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUnknownRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsUnknownRunErrorType> expectedType =
            BetaManagedAgentsUnknownRunErrorType.UnknownError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUnknownRunError
        {
            Message = "message",
            Type = BetaManagedAgentsUnknownRunErrorType.UnknownError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUnknownRunError
        {
            Message = "message",
            Type = BetaManagedAgentsUnknownRunErrorType.UnknownError,
        };

        BetaManagedAgentsUnknownRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUnknownRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUnknownRunErrorType.UnknownError)]
    public void Validation_Works(BetaManagedAgentsUnknownRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUnknownRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnknownRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUnknownRunErrorType.UnknownError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsUnknownRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUnknownRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnknownRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnknownRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnknownRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
