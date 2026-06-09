using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsFileResourceConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
            MountPath = "mount_path",
        };

        string expectedFileID = "file_id";
        ApiEnum<string, BetaManagedAgentsFileResourceConfigType> expectedType =
            BetaManagedAgentsFileResourceConfigType.File;
        string expectedMountPath = "mount_path";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedMountPath, model.MountPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
            MountPath = "mount_path",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResourceConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
            MountPath = "mount_path",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResourceConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";
        ApiEnum<string, BetaManagedAgentsFileResourceConfigType> expectedType =
            BetaManagedAgentsFileResourceConfigType.File;
        string expectedMountPath = "mount_path";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedMountPath, deserialized.MountPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
            MountPath = "mount_path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
        };

        Assert.Null(model.MountPath);
        Assert.False(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,

            MountPath = null,
        };

        Assert.Null(model.MountPath);
        Assert.True(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,

            MountPath = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
            MountPath = "mount_path",
        };

        BetaManagedAgentsFileResourceConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsFileResourceConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsFileResourceConfigType.File)]
    public void Validation_Works(BetaManagedAgentsFileResourceConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileResourceConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileResourceConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsFileResourceConfigType.File)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsFileResourceConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileResourceConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileResourceConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileResourceConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileResourceConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
