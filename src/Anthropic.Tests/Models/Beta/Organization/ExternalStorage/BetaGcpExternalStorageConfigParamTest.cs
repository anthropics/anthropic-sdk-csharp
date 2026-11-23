using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaGcpExternalStorageConfigParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGcpExternalStorageConfigParam
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };

        string expectedBucketName = "acme-safety-retention";
        string expectedProjectNumber = "123456789012";
        string expectedRegion = "us-east5";
        JsonElement expectedType = JsonSerializer.SerializeToElement("gcp");

        Assert.Equal(expectedBucketName, model.BucketName);
        Assert.Equal(expectedProjectNumber, model.ProjectNumber);
        Assert.Equal(expectedRegion, model.Region);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGcpExternalStorageConfigParam
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGcpExternalStorageConfigParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGcpExternalStorageConfigParam
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGcpExternalStorageConfigParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucketName = "acme-safety-retention";
        string expectedProjectNumber = "123456789012";
        string expectedRegion = "us-east5";
        JsonElement expectedType = JsonSerializer.SerializeToElement("gcp");

        Assert.Equal(expectedBucketName, deserialized.BucketName);
        Assert.Equal(expectedProjectNumber, deserialized.ProjectNumber);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGcpExternalStorageConfigParam
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGcpExternalStorageConfigParam
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };

        BetaGcpExternalStorageConfigParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
