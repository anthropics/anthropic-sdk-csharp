using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageRegionFailedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionFailed
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
            FailedChecks =
            [
                new()
                {
                    Check = Check.BucketSettings,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };

        BetaGoogleManagedProjectEffectiveBucket expectedEffectiveBucket = new()
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };
        List<BetaGoogleManagedProjectStorageFailedCheck> expectedFailedChecks =
        [
            new()
            {
                Check = Check.BucketSettings,
                Message = "message",
                Role = Role.Ingest,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("failed");

        Assert.Equal(expectedEffectiveBucket, model.EffectiveBucket);
        Assert.Equal(expectedFailedChecks.Count, model.FailedChecks.Count);
        for (int i = 0; i < expectedFailedChecks.Count; i++)
        {
            Assert.Equal(expectedFailedChecks[i], model.FailedChecks[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionFailed
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
            FailedChecks =
            [
                new()
                {
                    Check = Check.BucketSettings,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionFailed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionFailed
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
            FailedChecks =
            [
                new()
                {
                    Check = Check.BucketSettings,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionFailed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaGoogleManagedProjectEffectiveBucket expectedEffectiveBucket = new()
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };
        List<BetaGoogleManagedProjectStorageFailedCheck> expectedFailedChecks =
        [
            new()
            {
                Check = Check.BucketSettings,
                Message = "message",
                Role = Role.Ingest,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("failed");

        Assert.Equal(expectedEffectiveBucket, deserialized.EffectiveBucket);
        Assert.Equal(expectedFailedChecks.Count, deserialized.FailedChecks.Count);
        for (int i = 0; i < expectedFailedChecks.Count; i++)
        {
            Assert.Equal(expectedFailedChecks[i], deserialized.FailedChecks[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionFailed
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
            FailedChecks =
            [
                new()
                {
                    Check = Check.BucketSettings,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionFailed
        {
            EffectiveBucket = new()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            },
            FailedChecks =
            [
                new()
                {
                    Check = Check.BucketSettings,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };

        BetaGoogleManagedProjectStorageRegionFailed copied = new(model);

        Assert.Equal(model, copied);
    }
}
