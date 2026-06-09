using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
        };

        ApiEnum<
            string,
            BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
        };

        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError
    )]
    public void Validation_Works(
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError
    )]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
