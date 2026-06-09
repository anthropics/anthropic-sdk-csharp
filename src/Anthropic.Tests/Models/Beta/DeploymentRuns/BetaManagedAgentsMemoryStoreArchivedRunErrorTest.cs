using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsMemoryStoreArchivedRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType> expectedType =
            BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreArchivedRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreArchivedRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType> expectedType =
            BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreArchivedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError,
        };

        BetaManagedAgentsMemoryStoreArchivedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryStoreArchivedRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError)]
    public void Validation_Works(BetaManagedAgentsMemoryStoreArchivedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMemoryStoreArchivedRunErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
