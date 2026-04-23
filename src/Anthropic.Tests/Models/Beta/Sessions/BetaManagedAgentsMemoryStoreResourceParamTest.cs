using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsMemoryStoreResourceParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
        };

        string expectedMemoryStoreID = "memory_store_id";
        ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType> expectedType =
            BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore;
        ApiEnum<string, Access> expectedAccess = Access.ReadWrite;
        string expectedInstructions = "instructions";

        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAccess, model.Access);
        Assert.Equal(expectedInstructions, model.Instructions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreResourceParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreResourceParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMemoryStoreID = "memory_store_id";
        ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType> expectedType =
            BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore;
        ApiEnum<string, Access> expectedAccess = Access.ReadWrite;
        string expectedInstructions = "instructions";

        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAccess, deserialized.Access);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
        };

        Assert.Null(model.Access);
        Assert.False(model.RawData.ContainsKey("access"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,

            Access = null,
            Instructions = null,
        };

        Assert.Null(model.Access);
        Assert.True(model.RawData.ContainsKey("access"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,

            Access = null,
            Instructions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResourceParam
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
        };

        BetaManagedAgentsMemoryStoreResourceParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryStoreResourceParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore)]
    public void Validation_Works(BetaManagedAgentsMemoryStoreResourceParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryStoreResourceParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccessTest : TestBase
{
    [Theory]
    [InlineData(Access.ReadWrite)]
    [InlineData(Access.ReadOnly)]
    public void Validation_Works(Access rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Access> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Access>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Access.ReadWrite)]
    [InlineData(Access.ReadOnly)]
    public void SerializationRoundtrip_Works(Access rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Access> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Access>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Access>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Access>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
