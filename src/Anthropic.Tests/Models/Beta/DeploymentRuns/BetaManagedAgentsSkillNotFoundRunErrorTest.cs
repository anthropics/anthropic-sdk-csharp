using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsSkillNotFoundRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSkillNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType> expectedType =
            BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSkillNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSkillNotFoundRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSkillNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSkillNotFoundRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType> expectedType =
            BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSkillNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSkillNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError,
        };

        BetaManagedAgentsSkillNotFoundRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSkillNotFoundRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError)]
    public void Validation_Works(BetaManagedAgentsSkillNotFoundRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSkillNotFoundRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
