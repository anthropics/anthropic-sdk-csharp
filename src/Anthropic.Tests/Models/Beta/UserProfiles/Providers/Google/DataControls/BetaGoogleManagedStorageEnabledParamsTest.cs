using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedStorageEnabledParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        Dictionary<string, BetaGoogleManagedBucketReference?> expectedBuckets = new()
        {
            {
                "foo",
                new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
            },
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Buckets);
        Assert.Equal(expectedBuckets.Count, model.Buckets.Count);
        foreach (var item in expectedBuckets)
        {
            Assert.True(model.Buckets.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Buckets[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageEnabledParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageEnabledParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        Dictionary<string, BetaGoogleManagedBucketReference?> expectedBuckets = new()
        {
            {
                "foo",
                new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
            },
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Buckets);
        Assert.Equal(expectedBuckets.Count, deserialized.Buckets.Count);
        foreach (var item in expectedBuckets)
        {
            Assert.True(deserialized.Buckets.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Buckets[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams { };

        Assert.Null(model.Buckets);
        Assert.False(model.RawData.ContainsKey("buckets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams
        {
            // Null should be interpreted as omitted for these properties
            Buckets = null,
        };

        Assert.Null(model.Buckets);
        Assert.False(model.RawData.ContainsKey("buckets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        } with
        {
            // Null should be interpreted as omitted for these properties
            Buckets = null,
        };

        Assert.Null(model.Buckets);
        Assert.False(model.RawData.ContainsKey("buckets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams
        {
            // Null should be interpreted as omitted for these properties
            Buckets = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        BetaGoogleManagedStorageEnabledParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
