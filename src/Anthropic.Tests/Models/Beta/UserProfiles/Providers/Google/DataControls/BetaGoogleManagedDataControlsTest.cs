using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedDataControlsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedDataControls
        {
            BucketLabelValue = "2f6d8c3a-91b4-4e57-8a0c-d5e1f7b3a924",
            Cmek = new BetaGoogleManagedCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2026-09-29T09:14:03Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            Storage = new BetaGoogleManagedStorageDisabled([]),
            UpdatedAt = DateTimeOffset.Parse("2026-08-30T09:14:03Z"),
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        string expectedBucketLabelValue = "2f6d8c3a-91b4-4e57-8a0c-d5e1f7b3a924";
        BetaGoogleManagedCmekControl expectedCmek = new BetaGoogleManagedCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2026-09-29T09:14:03Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ]
        );
        BetaGoogleManagedStorageControl expectedStorage = new BetaGoogleManagedStorageDisabled([]);
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "google_managed_data_controls"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-08-30T09:14:03Z");
        string expectedUserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";

        Assert.Equal(expectedBucketLabelValue, model.BucketLabelValue);
        Assert.Equal(expectedCmek, model.Cmek);
        Assert.Equal(expectedStorage, model.Storage);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserProfileID, model.UserProfileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedDataControls
        {
            BucketLabelValue = "2f6d8c3a-91b4-4e57-8a0c-d5e1f7b3a924",
            Cmek = new BetaGoogleManagedCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2026-09-29T09:14:03Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            Storage = new BetaGoogleManagedStorageDisabled([]),
            UpdatedAt = DateTimeOffset.Parse("2026-08-30T09:14:03Z"),
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedDataControls>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedDataControls
        {
            BucketLabelValue = "2f6d8c3a-91b4-4e57-8a0c-d5e1f7b3a924",
            Cmek = new BetaGoogleManagedCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2026-09-29T09:14:03Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            Storage = new BetaGoogleManagedStorageDisabled([]),
            UpdatedAt = DateTimeOffset.Parse("2026-08-30T09:14:03Z"),
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedDataControls>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucketLabelValue = "2f6d8c3a-91b4-4e57-8a0c-d5e1f7b3a924";
        BetaGoogleManagedCmekControl expectedCmek = new BetaGoogleManagedCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2026-09-29T09:14:03Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ]
        );
        BetaGoogleManagedStorageControl expectedStorage = new BetaGoogleManagedStorageDisabled([]);
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "google_managed_data_controls"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-08-30T09:14:03Z");
        string expectedUserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";

        Assert.Equal(expectedBucketLabelValue, deserialized.BucketLabelValue);
        Assert.Equal(expectedCmek, deserialized.Cmek);
        Assert.Equal(expectedStorage, deserialized.Storage);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserProfileID, deserialized.UserProfileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedDataControls
        {
            BucketLabelValue = "2f6d8c3a-91b4-4e57-8a0c-d5e1f7b3a924",
            Cmek = new BetaGoogleManagedCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2026-09-29T09:14:03Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            Storage = new BetaGoogleManagedStorageDisabled([]),
            UpdatedAt = DateTimeOffset.Parse("2026-08-30T09:14:03Z"),
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedDataControls
        {
            BucketLabelValue = "2f6d8c3a-91b4-4e57-8a0c-d5e1f7b3a924",
            Cmek = new BetaGoogleManagedCmekDisabled(
                [
                    new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2026-09-29T09:14:03Z"),
                        ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                        Region = "us",
                    },
                ]
            ),
            Storage = new BetaGoogleManagedStorageDisabled([]),
            UpdatedAt = DateTimeOffset.Parse("2026-08-30T09:14:03Z"),
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        BetaGoogleManagedDataControls copied = new(model);

        Assert.Equal(model, copied);
    }
}
