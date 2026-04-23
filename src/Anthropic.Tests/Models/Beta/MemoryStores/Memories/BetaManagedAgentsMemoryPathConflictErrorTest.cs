using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsMemoryPathConflictErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };

        ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType> expectedType =
            BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError;
        string expectedConflictingMemoryID = "conflicting_memory_id";
        string expectedConflictingPath = "conflicting_path";
        string expectedMessage = "message";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedConflictingMemoryID, model.ConflictingMemoryID);
        Assert.Equal(expectedConflictingPath, model.ConflictingPath);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryPathConflictError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryPathConflictError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType> expectedType =
            BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError;
        string expectedConflictingMemoryID = "conflicting_memory_id";
        string expectedConflictingPath = "conflicting_path";
        string expectedMessage = "message";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedConflictingMemoryID, deserialized.ConflictingMemoryID);
        Assert.Equal(expectedConflictingPath, deserialized.ConflictingPath);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
        };

        Assert.Null(model.ConflictingMemoryID);
        Assert.False(model.RawData.ContainsKey("conflicting_memory_id"));
        Assert.Null(model.ConflictingPath);
        Assert.False(model.RawData.ContainsKey("conflicting_path"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,

            // Null should be interpreted as omitted for these properties
            ConflictingMemoryID = null,
            ConflictingPath = null,
            Message = null,
        };

        Assert.Null(model.ConflictingMemoryID);
        Assert.False(model.RawData.ContainsKey("conflicting_memory_id"));
        Assert.Null(model.ConflictingPath);
        Assert.False(model.RawData.ContainsKey("conflicting_path"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,

            // Null should be interpreted as omitted for these properties
            ConflictingMemoryID = null,
            ConflictingPath = null,
            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryPathConflictError
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };

        BetaManagedAgentsMemoryPathConflictError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryPathConflictErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError)]
    public void Validation_Works(BetaManagedAgentsMemoryPathConflictErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryPathConflictErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
