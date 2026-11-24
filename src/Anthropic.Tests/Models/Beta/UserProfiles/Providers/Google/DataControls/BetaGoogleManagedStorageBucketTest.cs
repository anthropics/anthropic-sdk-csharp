using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedStorageBucketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedStorageBucket
        {
            BucketName = "bucket_name",
            KmsKeyName = "kms_key_name",
            Location = "location",
            ProjectID = "project_id",
            ProjectNumber = "project_number",
        };

        string expectedBucketName = "bucket_name";
        string expectedKmsKeyName = "kms_key_name";
        string expectedLocation = "location";
        string expectedProjectID = "project_id";
        string expectedProjectNumber = "project_number";

        Assert.Equal(expectedBucketName, model.BucketName);
        Assert.Equal(expectedKmsKeyName, model.KmsKeyName);
        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedProjectNumber, model.ProjectNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedStorageBucket
        {
            BucketName = "bucket_name",
            KmsKeyName = "kms_key_name",
            Location = "location",
            ProjectID = "project_id",
            ProjectNumber = "project_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageBucket>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedStorageBucket
        {
            BucketName = "bucket_name",
            KmsKeyName = "kms_key_name",
            Location = "location",
            ProjectID = "project_id",
            ProjectNumber = "project_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageBucket>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucketName = "bucket_name";
        string expectedKmsKeyName = "kms_key_name";
        string expectedLocation = "location";
        string expectedProjectID = "project_id";
        string expectedProjectNumber = "project_number";

        Assert.Equal(expectedBucketName, deserialized.BucketName);
        Assert.Equal(expectedKmsKeyName, deserialized.KmsKeyName);
        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedProjectNumber, deserialized.ProjectNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedStorageBucket
        {
            BucketName = "bucket_name",
            KmsKeyName = "kms_key_name",
            Location = "location",
            ProjectID = "project_id",
            ProjectNumber = "project_number",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedStorageBucket
        {
            BucketName = "bucket_name",
            KmsKeyName = "kms_key_name",
            Location = "location",
            ProjectID = "project_id",
            ProjectNumber = "project_number",
        };

        BetaGoogleManagedStorageBucket copied = new(model);

        Assert.Equal(model, copied);
    }
}
