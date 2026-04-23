using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsMemoryPreconditionFailedErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
            Message = "message",
        };

        ApiEnum<string, BetaManagedAgentsMemoryPreconditionFailedErrorType> expectedType =
            BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError;
        string expectedMessage = "message";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMemoryPreconditionFailedError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMemoryPreconditionFailedError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsMemoryPreconditionFailedErrorType> expectedType =
            BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError;
        string expectedMessage = "message";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,

            // Null should be interpreted as omitted for these properties
            Message = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,

            // Null should be interpreted as omitted for these properties
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryPreconditionFailedError
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
            Message = "message",
        };

        BetaManagedAgentsMemoryPreconditionFailedError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryPreconditionFailedErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError)]
    public void Validation_Works(BetaManagedAgentsMemoryPreconditionFailedErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryPreconditionFailedErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPreconditionFailedErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMemoryPreconditionFailedErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryPreconditionFailedErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPreconditionFailedErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPreconditionFailedErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPreconditionFailedErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
