using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class BetaManagedAgentsMemoryStoreResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };

        string expectedMemoryStoreID = "memory_store_id";
        ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType> expectedType =
            BetaManagedAgentsMemoryStoreResourceType.MemoryStore;
        ApiEnum<string, Access> expectedAccess = Access.ReadWrite;
        string expectedDescription = "description";
        string expectedInstructions = "instructions";
        string expectedMountPath = "mount_path";
        string expectedName = "name";

        Assert.Equal(expectedMemoryStoreID, model.MemoryStoreID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAccess, model.Access);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedMountPath, model.MountPath);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMemoryStoreID = "memory_store_id";
        ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType> expectedType =
            BetaManagedAgentsMemoryStoreResourceType.MemoryStore;
        ApiEnum<string, Access> expectedAccess = Access.ReadWrite;
        string expectedDescription = "description";
        string expectedInstructions = "instructions";
        string expectedMountPath = "mount_path";
        string expectedName = "name";

        Assert.Equal(expectedMemoryStoreID, deserialized.MemoryStoreID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAccess, deserialized.Access);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedMountPath, deserialized.MountPath);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Description = "description",
        };

        Assert.Null(model.Access);
        Assert.False(model.RawData.ContainsKey("access"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.MountPath);
        Assert.False(model.RawData.ContainsKey("mount_path"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Description = "description",

            Access = null,
            Instructions = null,
            MountPath = null,
            Name = null,
        };

        Assert.Null(model.Access);
        Assert.True(model.RawData.ContainsKey("access"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.MountPath);
        Assert.True(model.RawData.ContainsKey("mount_path"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Description = "description",

            Access = null,
            Instructions = null,
            MountPath = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryStoreResource
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };

        BetaManagedAgentsMemoryStoreResource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryStoreResourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryStoreResourceType.MemoryStore)]
    public void Validation_Works(BetaManagedAgentsMemoryStoreResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryStoreResourceType.MemoryStore)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryStoreResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType>
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
