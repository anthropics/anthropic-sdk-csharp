using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsVaultNotFoundRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsVaultNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType> expectedType =
            BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsVaultNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsVaultNotFoundRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsVaultNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsVaultNotFoundRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType> expectedType =
            BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsVaultNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsVaultNotFoundRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError,
        };

        BetaManagedAgentsVaultNotFoundRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsVaultNotFoundRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError)]
    public void Validation_Works(BetaManagedAgentsVaultNotFoundRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsVaultNotFoundRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
