using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageEnabledParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        Dictionary<string, BetaGoogleManagedProjectBucketReference?> expectedBuckets = new()
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
        var model = new BetaGoogleManagedProjectStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageEnabledParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageEnabledParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        Dictionary<string, BetaGoogleManagedProjectBucketReference?> expectedBuckets = new()
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
        var model = new BetaGoogleManagedProjectStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
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
        var model = new BetaGoogleManagedProjectStorageEnabledParams { };

        Assert.Null(model.Buckets);
        Assert.False(model.RawData.ContainsKey("buckets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabledParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabledParams
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
        var model = new BetaGoogleManagedProjectStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
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
        var model = new BetaGoogleManagedProjectStorageEnabledParams
        {
            // Null should be interpreted as omitted for these properties
            Buckets = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectStorageEnabledParams
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };

        BetaGoogleManagedProjectStorageEnabledParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
