using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsOrganizationDisabledRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsOrganizationDisabledRunError
        {
            Message = "message",
            Type = BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType> expectedType =
            BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsOrganizationDisabledRunError
        {
            Message = "message",
            Type = BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsOrganizationDisabledRunError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsOrganizationDisabledRunError
        {
            Message = "message",
            Type = BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsOrganizationDisabledRunError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType> expectedType =
            BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsOrganizationDisabledRunError
        {
            Message = "message",
            Type = BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsOrganizationDisabledRunError
        {
            Message = "message",
            Type = BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError,
        };

        BetaManagedAgentsOrganizationDisabledRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsOrganizationDisabledRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError)]
    public void Validation_Works(BetaManagedAgentsOrganizationDisabledRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsOrganizationDisabledRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
