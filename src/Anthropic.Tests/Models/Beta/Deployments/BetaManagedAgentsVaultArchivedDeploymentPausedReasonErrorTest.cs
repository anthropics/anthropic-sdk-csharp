using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError,
        };

        ApiEnum<
            string,
            BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsVaultArchivedDeploymentPausedReasonError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsVaultArchivedDeploymentPausedReasonError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError,
        };

        BetaManagedAgentsVaultArchivedDeploymentPausedReasonError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError)]
    public void Validation_Works(
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
