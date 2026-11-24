using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectRetiredBucketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "us",
        };

        string expectedBucketName = "bucket_name";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProjectNumber = "project_number";
        string expectedRegion = "us";

        Assert.Equal(expectedBucketName, model.BucketName);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedProjectNumber, model.ProjectNumber);
        Assert.Equal(expectedRegion, model.Region);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "us",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectRetiredBucket>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "us",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectRetiredBucket>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucketName = "bucket_name";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProjectNumber = "project_number";
        string expectedRegion = "us";

        Assert.Equal(expectedBucketName, deserialized.BucketName);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedProjectNumber, deserialized.ProjectNumber);
        Assert.Equal(expectedRegion, deserialized.Region);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "us",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredBucket
        {
            BucketName = "bucket_name",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProjectNumber = "project_number",
            Region = "us",
        };

        BetaGoogleManagedProjectRetiredBucket copied = new(model);

        Assert.Equal(model, copied);
    }
}
