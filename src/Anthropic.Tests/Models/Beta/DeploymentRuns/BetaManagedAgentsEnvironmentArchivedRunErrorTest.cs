using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsEnvironmentArchivedRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType> expectedType =
            BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentArchivedRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsEnvironmentArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentArchivedRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType> expectedType =
            BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEnvironmentArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
        };

        BetaManagedAgentsEnvironmentArchivedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsEnvironmentArchivedRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError)]
    public void Validation_Works(BetaManagedAgentsEnvironmentArchivedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsEnvironmentArchivedRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
