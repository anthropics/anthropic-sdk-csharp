using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectDataControlsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectDataControls
        {
            Cmek = new BetaGoogleManagedProjectCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            ProjectNumber = "123456789012",
            Storage = new BetaGoogleManagedProjectStorageDisabled(
                [
                    new()
                    {
                        BucketName = "bucket_name",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ProjectNumber = "project_number",
                        Region = "us",
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaGoogleManagedProjectCmekControl expectedCmek = new BetaGoogleManagedProjectCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ]
        );
        string expectedProjectNumber = "123456789012";
        BetaGoogleManagedProjectStorageControl expectedStorage =
            new BetaGoogleManagedProjectStorageDisabled(
                [
                    new()
                    {
                        BucketName = "bucket_name",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ProjectNumber = "project_number",
                        Region = "us",
                    },
                ]
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "google_managed_project_data_controls"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCmek, model.Cmek);
        Assert.Equal(expectedProjectNumber, model.ProjectNumber);
        Assert.Equal(expectedStorage, model.Storage);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectDataControls
        {
            Cmek = new BetaGoogleManagedProjectCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            ProjectNumber = "123456789012",
            Storage = new BetaGoogleManagedProjectStorageDisabled(
                [
                    new()
                    {
                        BucketName = "bucket_name",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ProjectNumber = "project_number",
                        Region = "us",
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectDataControls>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectDataControls
        {
            Cmek = new BetaGoogleManagedProjectCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            ProjectNumber = "123456789012",
            Storage = new BetaGoogleManagedProjectStorageDisabled(
                [
                    new()
                    {
                        BucketName = "bucket_name",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ProjectNumber = "project_number",
                        Region = "us",
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectDataControls>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaGoogleManagedProjectCmekControl expectedCmek = new BetaGoogleManagedProjectCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ]
        );
        string expectedProjectNumber = "123456789012";
        BetaGoogleManagedProjectStorageControl expectedStorage =
            new BetaGoogleManagedProjectStorageDisabled(
                [
                    new()
                    {
                        BucketName = "bucket_name",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ProjectNumber = "project_number",
                        Region = "us",
                    },
                ]
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "google_managed_project_data_controls"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCmek, deserialized.Cmek);
        Assert.Equal(expectedProjectNumber, deserialized.ProjectNumber);
        Assert.Equal(expectedStorage, deserialized.Storage);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectDataControls
        {
            Cmek = new BetaGoogleManagedProjectCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            ProjectNumber = "123456789012",
            Storage = new BetaGoogleManagedProjectStorageDisabled(
                [
                    new()
                    {
                        BucketName = "bucket_name",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ProjectNumber = "project_number",
                        Region = "us",
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectDataControls
        {
            Cmek = new BetaGoogleManagedProjectCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            ProjectNumber = "123456789012",
            Storage = new BetaGoogleManagedProjectStorageDisabled(
                [
                    new()
                    {
                        BucketName = "bucket_name",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ProjectNumber = "project_number",
                        Region = "us",
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaGoogleManagedProjectDataControls copied = new(model);

        Assert.Equal(model, copied);
    }
}
