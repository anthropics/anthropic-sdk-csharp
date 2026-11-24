using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedStorageRegionSuspendedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedStorageRegionSuspended
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
        };

        BetaGoogleManagedBucketReference expectedEffectiveBucket = new()
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("suspended");

        Assert.Equal(expectedEffectiveBucket, model.EffectiveBucket);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedStorageRegionSuspended
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionSuspended>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedStorageRegionSuspended
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionSuspended>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaGoogleManagedBucketReference expectedEffectiveBucket = new()
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("suspended");

        Assert.Equal(expectedEffectiveBucket, deserialized.EffectiveBucket);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedStorageRegionSuspended
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedStorageRegionSuspended
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
        };

        BetaGoogleManagedStorageRegionSuspended copied = new(model);

        Assert.Equal(model, copied);
    }
}
