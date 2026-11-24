using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageRegionActiveTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionActive
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
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("active");
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEffectiveBucket, model.EffectiveBucket);
        Assert.Equal(expectedFailedChecks.Count, model.FailedChecks.Count);
        for (int i = 0; i < expectedFailedChecks.Count; i++)
        {
            Assert.Equal(expectedFailedChecks[i], model.FailedChecks[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValidatedAt, model.ValidatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionActive
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
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionActive>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionActive
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
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionActive>(
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("active");
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEffectiveBucket, deserialized.EffectiveBucket);
        Assert.Equal(expectedFailedChecks.Count, deserialized.FailedChecks.Count);
        for (int i = 0; i < expectedFailedChecks.Count; i++)
        {
            Assert.Equal(expectedFailedChecks[i], deserialized.FailedChecks[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValidatedAt, deserialized.ValidatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionActive
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
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectStorageRegionActive
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
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaGoogleManagedProjectStorageRegionActive copied = new(model);

        Assert.Equal(model, copied);
    }
}
