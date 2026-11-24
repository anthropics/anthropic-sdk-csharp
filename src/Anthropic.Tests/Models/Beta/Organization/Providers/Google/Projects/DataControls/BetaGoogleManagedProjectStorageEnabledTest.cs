using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabled
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectStorageBucket>()
            {
                {
                    "foo",
                    new()
                    {
                        BucketName = "bucket_name",
                        KmsKeyName = "kms_key_name",
                        Location = "location",
                        ProjectID = "project_id",
                        ProjectNumber = "project_number",
                    }
                },
            },
            RetiredBuckets =
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectStorageRegionNotConfigured(
                        new BetaGoogleManagedProjectEffectiveBucket()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };

        Dictionary<string, BetaGoogleManagedProjectStorageBucket> expectedBuckets = new()
        {
            {
                "foo",
                new()
                {
                    BucketName = "bucket_name",
                    KmsKeyName = "kms_key_name",
                    Location = "location",
                    ProjectID = "project_id",
                    ProjectNumber = "project_number",
                }
            },
        };
        List<BetaGoogleManagedProjectRetiredBucket> expectedRetiredBuckets =
        [
            new()
            {
                BucketName = "bucket_name",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProjectNumber = "project_number",
                Region = "us",
            },
        ];
        Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus> expectedStatus = new()
        {
            {
                "foo",
                new BetaGoogleManagedProjectStorageRegionNotConfigured(
                    new BetaGoogleManagedProjectEffectiveBucket()
                    {
                        BucketName = "bucket_name",
                        ProjectNumber = "project_number",
                    }
                )
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedBuckets.Count, model.Buckets.Count);
        foreach (var item in expectedBuckets)
        {
            Assert.True(model.Buckets.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Buckets[item.Key]);
        }
        Assert.Equal(expectedRetiredBuckets.Count, model.RetiredBuckets.Count);
        for (int i = 0; i < expectedRetiredBuckets.Count; i++)
        {
            Assert.Equal(expectedRetiredBuckets[i], model.RetiredBuckets[i]);
        }
        Assert.Equal(expectedStatus.Count, model.Status.Count);
        foreach (var item in expectedStatus)
        {
            Assert.True(model.Status.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Status[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabled
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectStorageBucket>()
            {
                {
                    "foo",
                    new()
                    {
                        BucketName = "bucket_name",
                        KmsKeyName = "kms_key_name",
                        Location = "location",
                        ProjectID = "project_id",
                        ProjectNumber = "project_number",
                    }
                },
            },
            RetiredBuckets =
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectStorageRegionNotConfigured(
                        new BetaGoogleManagedProjectEffectiveBucket()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageEnabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabled
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectStorageBucket>()
            {
                {
                    "foo",
                    new()
                    {
                        BucketName = "bucket_name",
                        KmsKeyName = "kms_key_name",
                        Location = "location",
                        ProjectID = "project_id",
                        ProjectNumber = "project_number",
                    }
                },
            },
            RetiredBuckets =
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectStorageRegionNotConfigured(
                        new BetaGoogleManagedProjectEffectiveBucket()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageEnabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, BetaGoogleManagedProjectStorageBucket> expectedBuckets = new()
        {
            {
                "foo",
                new()
                {
                    BucketName = "bucket_name",
                    KmsKeyName = "kms_key_name",
                    Location = "location",
                    ProjectID = "project_id",
                    ProjectNumber = "project_number",
                }
            },
        };
        List<BetaGoogleManagedProjectRetiredBucket> expectedRetiredBuckets =
        [
            new()
            {
                BucketName = "bucket_name",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProjectNumber = "project_number",
                Region = "us",
            },
        ];
        Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus> expectedStatus = new()
        {
            {
                "foo",
                new BetaGoogleManagedProjectStorageRegionNotConfigured(
                    new BetaGoogleManagedProjectEffectiveBucket()
                    {
                        BucketName = "bucket_name",
                        ProjectNumber = "project_number",
                    }
                )
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedBuckets.Count, deserialized.Buckets.Count);
        foreach (var item in expectedBuckets)
        {
            Assert.True(deserialized.Buckets.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Buckets[item.Key]);
        }
        Assert.Equal(expectedRetiredBuckets.Count, deserialized.RetiredBuckets.Count);
        for (int i = 0; i < expectedRetiredBuckets.Count; i++)
        {
            Assert.Equal(expectedRetiredBuckets[i], deserialized.RetiredBuckets[i]);
        }
        Assert.Equal(expectedStatus.Count, deserialized.Status.Count);
        foreach (var item in expectedStatus)
        {
            Assert.True(deserialized.Status.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Status[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabled
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectStorageBucket>()
            {
                {
                    "foo",
                    new()
                    {
                        BucketName = "bucket_name",
                        KmsKeyName = "kms_key_name",
                        Location = "location",
                        ProjectID = "project_id",
                        ProjectNumber = "project_number",
                    }
                },
            },
            RetiredBuckets =
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectStorageRegionNotConfigured(
                        new BetaGoogleManagedProjectEffectiveBucket()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabled
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectStorageBucket>()
            {
                {
                    "foo",
                    new()
                    {
                        BucketName = "bucket_name",
                        KmsKeyName = "kms_key_name",
                        Location = "location",
                        ProjectID = "project_id",
                        ProjectNumber = "project_number",
                    }
                },
            },
            RetiredBuckets =
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectStorageRegionNotConfigured(
                        new BetaGoogleManagedProjectEffectiveBucket()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };

        BetaGoogleManagedProjectStorageEnabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
