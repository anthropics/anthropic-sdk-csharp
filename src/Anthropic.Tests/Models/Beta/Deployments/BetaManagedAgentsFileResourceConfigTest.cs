using System.Text.Json;
using Anthropic.Core;
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
            MountPath = "mount_path",
        };

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");
        string expectedMountPath = "mount_path";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedMountPath, model.MountPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
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
            MountPath = "mount_path",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResourceConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");
        string expectedMountPath = "mount_path";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedMountPath, deserialized.MountPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",
            MountPath = "mount_path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig { FileID = "file_id" };

        Assert.Null(model.MountPath);
        Assert.False(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig { FileID = "file_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsFileResourceConfig
        {
            FileID = "file_id",

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
            MountPath = "mount_path",
        };

        BetaManagedAgentsFileResourceConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
