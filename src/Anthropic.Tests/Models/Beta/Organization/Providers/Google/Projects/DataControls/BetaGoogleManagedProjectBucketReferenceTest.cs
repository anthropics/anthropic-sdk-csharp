using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectBucketReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectBucketReference
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };

        string expectedBucketName = "bucket_name";
        string expectedProjectNumber = "project_number";

        Assert.Equal(expectedBucketName, model.BucketName);
        Assert.Equal(expectedProjectNumber, model.ProjectNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectBucketReference
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectBucketReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectBucketReference
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectBucketReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucketName = "bucket_name";
        string expectedProjectNumber = "project_number";

        Assert.Equal(expectedBucketName, deserialized.BucketName);
        Assert.Equal(expectedProjectNumber, deserialized.ProjectNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectBucketReference
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectBucketReference
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };

        BetaGoogleManagedProjectBucketReference copied = new(model);

        Assert.Equal(model, copied);
    }
}
