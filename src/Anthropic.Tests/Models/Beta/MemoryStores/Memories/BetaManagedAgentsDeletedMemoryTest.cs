using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsDeletedMemoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedMemory
        {
            ID = "id",
            Type = BetaManagedAgentsDeletedMemoryType.MemoryDeleted,
        };

        string expectedID = "id";
        ApiEnum<string, BetaManagedAgentsDeletedMemoryType> expectedType =
            BetaManagedAgentsDeletedMemoryType.MemoryDeleted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedMemory
        {
            ID = "id",
            Type = BetaManagedAgentsDeletedMemoryType.MemoryDeleted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedMemory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeletedMemory
        {
            ID = "id",
            Type = BetaManagedAgentsDeletedMemoryType.MemoryDeleted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedMemory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, BetaManagedAgentsDeletedMemoryType> expectedType =
            BetaManagedAgentsDeletedMemoryType.MemoryDeleted;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeletedMemory
        {
            ID = "id",
            Type = BetaManagedAgentsDeletedMemoryType.MemoryDeleted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeletedMemory
        {
            ID = "id",
            Type = BetaManagedAgentsDeletedMemoryType.MemoryDeleted,
        };

        BetaManagedAgentsDeletedMemory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsDeletedMemoryTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeletedMemoryType.MemoryDeleted)]
    public void Validation_Works(BetaManagedAgentsDeletedMemoryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeletedMemoryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDeletedMemoryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeletedMemoryType.MemoryDeleted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDeletedMemoryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeletedMemoryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedMemoryType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDeletedMemoryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedMemoryType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
