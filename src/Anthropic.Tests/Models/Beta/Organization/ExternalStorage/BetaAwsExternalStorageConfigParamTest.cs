using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaAwsExternalStorageConfigParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAwsExternalStorageConfigParam
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };

        string expectedAccountID = "111122223333";
        string expectedBucketName = "acme-safety-retention";
        string expectedRegion = "us-east-2";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws");

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedBucketName, model.BucketName);
        Assert.Equal(expectedRegion, model.Region);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAwsExternalStorageConfigParam
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAwsExternalStorageConfigParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAwsExternalStorageConfigParam
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAwsExternalStorageConfigParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "111122223333";
        string expectedBucketName = "acme-safety-retention";
        string expectedRegion = "us-east-2";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws");

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedBucketName, deserialized.BucketName);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAwsExternalStorageConfigParam
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAwsExternalStorageConfigParam
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };

        BetaAwsExternalStorageConfigParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
