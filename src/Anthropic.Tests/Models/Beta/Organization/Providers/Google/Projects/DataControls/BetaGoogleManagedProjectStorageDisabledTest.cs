using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageDisabled
        {
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.Equal(expectedRetiredBuckets.Count, model.RetiredBuckets.Count);
        for (int i = 0; i < expectedRetiredBuckets.Count; i++)
        {
            Assert.Equal(expectedRetiredBuckets[i], model.RetiredBuckets[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageDisabled
        {
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageDisabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectStorageDisabled
        {
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageDisabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.Equal(expectedRetiredBuckets.Count, deserialized.RetiredBuckets.Count);
        for (int i = 0; i < expectedRetiredBuckets.Count; i++)
        {
            Assert.Equal(expectedRetiredBuckets[i], deserialized.RetiredBuckets[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectStorageDisabled
        {
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectStorageDisabled
        {
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
        };

        BetaGoogleManagedProjectStorageDisabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
