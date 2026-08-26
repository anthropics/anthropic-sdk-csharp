using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalKeys;

public class ExternalKeyListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Attachment = new BetaExternalKeyAttachedAttachment(),
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "prod-us-key",
                    Geo = "us",
                    ProviderConfig = new BetaAwsExternalKeyConfig()
                    {
                        KmsArn =
                            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                        Region = "us-east-1",
                        RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        List<BetaExternalKey> expectedData =
        [
            new()
            {
                ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                Attachment = new BetaExternalKeyAttachedAttachment(),
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                DisplayName = "prod-us-key",
                Geo = "us",
                ProviderConfig = new BetaAwsExternalKeyConfig()
                {
                    KmsArn =
                        "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                    Region = "us-east-1",
                    RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
                },
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
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
        var model = new ExternalKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Attachment = new BetaExternalKeyAttachedAttachment(),
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "prod-us-key",
                    Geo = "us",
                    ProviderConfig = new BetaAwsExternalKeyConfig()
                    {
                        KmsArn =
                            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                        Region = "us-east-1",
                        RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Attachment = new BetaExternalKeyAttachedAttachment(),
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "prod-us-key",
                    Geo = "us",
                    ProviderConfig = new BetaAwsExternalKeyConfig()
                    {
                        KmsArn =
                            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                        Region = "us-east-1",
                        RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaExternalKey> expectedData =
        [
            new()
            {
                ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                Attachment = new BetaExternalKeyAttachedAttachment(),
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                DisplayName = "prod-us-key",
                Geo = "us",
                ProviderConfig = new BetaAwsExternalKeyConfig()
                {
                    KmsArn =
                        "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                    Region = "us-east-1",
                    RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
                },
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
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
        var model = new ExternalKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Attachment = new BetaExternalKeyAttachedAttachment(),
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "prod-us-key",
                    Geo = "us",
                    ProviderConfig = new BetaAwsExternalKeyConfig()
                    {
                        KmsArn =
                            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                        Region = "us-east-1",
                        RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Attachment = new BetaExternalKeyAttachedAttachment(),
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "prod-us-key",
                    Geo = "us",
                    ProviderConfig = new BetaAwsExternalKeyConfig()
                    {
                        KmsArn =
                            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                        Region = "us-east-1",
                        RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        ExternalKeyListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
