using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class ExternalStorageListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalStorageListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    ProviderConfig = new BetaAwsExternalStorageConfig()
                    {
                        AccountID = "111122223333",
                        BucketName = "acme-safety-retention",
                        Region = "us-east-2",
                    },
                    SetupTemplateVersion = "2",
                    Status = new BetaPendingConfigurationExternalStorageStatus(),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaExternalStorage> expectedData =
        [
            new()
            {
                ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                DisplayName = "display_name",
                ProviderConfig = new BetaAwsExternalStorageConfig()
                {
                    AccountID = "111122223333",
                    BucketName = "acme-safety-retention",
                    Region = "us-east-2",
                },
                SetupTemplateVersion = "2",
                Status = new BetaPendingConfigurationExternalStorageStatus(),
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalStorageListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    ProviderConfig = new BetaAwsExternalStorageConfig()
                    {
                        AccountID = "111122223333",
                        BucketName = "acme-safety-retention",
                        Region = "us-east-2",
                    },
                    SetupTemplateVersion = "2",
                    Status = new BetaPendingConfigurationExternalStorageStatus(),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalStorageListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalStorageListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    ProviderConfig = new BetaAwsExternalStorageConfig()
                    {
                        AccountID = "111122223333",
                        BucketName = "acme-safety-retention",
                        Region = "us-east-2",
                    },
                    SetupTemplateVersion = "2",
                    Status = new BetaPendingConfigurationExternalStorageStatus(),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalStorageListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaExternalStorage> expectedData =
        [
            new()
            {
                ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                DisplayName = "display_name",
                ProviderConfig = new BetaAwsExternalStorageConfig()
                {
                    AccountID = "111122223333",
                    BucketName = "acme-safety-retention",
                    Region = "us-east-2",
                },
                SetupTemplateVersion = "2",
                Status = new BetaPendingConfigurationExternalStorageStatus(),
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalStorageListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    ProviderConfig = new BetaAwsExternalStorageConfig()
                    {
                        AccountID = "111122223333",
                        BucketName = "acme-safety-retention",
                        Region = "us-east-2",
                    },
                    SetupTemplateVersion = "2",
                    Status = new BetaPendingConfigurationExternalStorageStatus(),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalStorageListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    ProviderConfig = new BetaAwsExternalStorageConfig()
                    {
                        AccountID = "111122223333",
                        BucketName = "acme-safety-retention",
                        Region = "us-east-2",
                    },
                    SetupTemplateVersion = "2",
                    Status = new BetaPendingConfigurationExternalStorageStatus(),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                },
            ],
            NextPage = "next_page",
        };

        ExternalStorageListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
