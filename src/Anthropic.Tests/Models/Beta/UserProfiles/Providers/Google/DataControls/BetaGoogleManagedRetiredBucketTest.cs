using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedRetiredBucketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "region",
        };

        string expectedBucketName = "bucket_name";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProjectNumber = "project_number";
        string expectedRegion = "region";

        Assert.Equal(expectedBucketName, model.BucketName);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedProjectNumber, model.ProjectNumber);
        Assert.Equal(expectedRegion, model.Region);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "region",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedRetiredBucket>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "region",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedRetiredBucket>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucketName = "bucket_name";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProjectNumber = "project_number";
        string expectedRegion = "region";

        Assert.Equal(expectedBucketName, deserialized.BucketName);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedProjectNumber, deserialized.ProjectNumber);
        Assert.Equal(expectedRegion, deserialized.Region);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "region",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "region",
        };

        BetaGoogleManagedRetiredBucket copied = new(model);

        Assert.Equal(model, copied);
    }
}
