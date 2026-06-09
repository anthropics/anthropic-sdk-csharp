using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsVaultArchivedRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType> expectedType =
            BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsVaultArchivedRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsVaultArchivedRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType> expectedType =
            BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError,
        };

        BetaManagedAgentsVaultArchivedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsVaultArchivedRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError)]
    public void Validation_Works(BetaManagedAgentsVaultArchivedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsVaultArchivedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
