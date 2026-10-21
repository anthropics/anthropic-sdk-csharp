using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsFileResourceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
        };

        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");
        string expectedMountPath = "/uploads/receipt.pdf";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedMountPath, model.MountPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResourceParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResourceParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");
        string expectedMountPath = "/uploads/receipt.pdf";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedMountPath, deserialized.MountPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
        };

        Assert.Null(model.MountPath);
        Assert.False(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",

            MountPath = null,
        };

        Assert.Null(model.MountPath);
        Assert.True(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",

            MountPath = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
        };

        BetaManagedAgentsFileResourceParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
