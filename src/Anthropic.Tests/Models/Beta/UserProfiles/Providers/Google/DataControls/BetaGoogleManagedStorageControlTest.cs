using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedStorageControlTest : TestBase
{
    [Fact]
    public void DisabledValidationWorks()
    {
        BetaGoogleManagedStorageControl value = new BetaGoogleManagedStorageDisabled(
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "region",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void EnabledValidationWorks()
    {
        BetaGoogleManagedStorageControl value = new BetaGoogleManagedStorageEnabled()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedStorageBucket>()
            {
                {
                    "foo",
                    new()
                    {
                        BucketName = "bucket_name",
                        KmsKeyName = "kms_key_name",
                        Location = "location",
                        ProjectID = "project_id",
                        ProjectNumber = "project_number",
                    }
                },
            },
            RetiredBuckets =
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "region",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedStorageRegionNotConfigured(
                        new BetaGoogleManagedBucketReference()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };
        value.Validate();
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedStorageControl value = new BetaGoogleManagedStorageDisabled(
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "region",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageControl>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedStorageControl value = new BetaGoogleManagedStorageEnabled()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedStorageBucket>()
            {
                {
                    "foo",
                    new()
                    {
                        BucketName = "bucket_name",
                        KmsKeyName = "kms_key_name",
                        Location = "location",
                        ProjectID = "project_id",
                        ProjectNumber = "project_number",
                    }
                },
            },
            RetiredBuckets =
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "region",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedStorageRegionNotConfigured(
                        new BetaGoogleManagedBucketReference()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageControl>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaGoogleManagedStorageControl value = new BetaGoogleManagedStorageDisabled(
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "region",
                },
            ]
        );
        Assert.Equal(BetaGoogleManagedStorageControlType.Disabled, value.Type.Value());
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaGoogleManagedStorageControl value = new BetaGoogleManagedStorageEnabled()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedStorageBucket>()
            {
                {
                    "foo",
                    new()
                    {
                        BucketName = "bucket_name",
                        KmsKeyName = "kms_key_name",
                        Location = "location",
                        ProjectID = "project_id",
                        ProjectNumber = "project_number",
                    }
                },
            },
            RetiredBuckets =
            [
                new()
                {
                    BucketName = "bucket_name",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ProjectNumber = "project_number",
                    Region = "region",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedStorageRegionNotConfigured(
                        new BetaGoogleManagedBucketReference()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };
        Assert.Equal(BetaGoogleManagedStorageControlType.Enabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedStorageControl value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "retired_buckets": [
                    {
                      "bucket_name": "bucket_name",
                      "expires_at": "2019-12-27T18:11:19.117+00:00",
                      "project_number": "project_number",
                      "region": "region"
                    }
                  ],
                  "type": "disabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        List<BetaGoogleManagedRetiredBucket> expectedRetiredBuckets =
        [
            new()
            {
                BucketName = "bucket_name",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                ProjectNumber = "project_number",
                Region = "region",
            },
        ];
        ApiEnum<string, BetaGoogleManagedStorageControlType> expectedType =
            BetaGoogleManagedStorageControlType.Disabled;

        Assert.Equal(expectedRetiredBuckets.Count, value.RetiredBuckets.Count);
        for (int i = 0; i < expectedRetiredBuckets.Count; i++)
        {
            Assert.Equal(expectedRetiredBuckets[i], value.RetiredBuckets[i]);
        }
        Assert.Equal(expectedType, value.Type);

        BetaGoogleManagedStorageControl emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.RetiredBuckets);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaGoogleManagedStorageControlTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedStorageControlType.Disabled)]
    [InlineData(BetaGoogleManagedStorageControlType.Enabled)]
    public void Validation_Works(BetaGoogleManagedStorageControlType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedStorageControlType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageControlType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaGoogleManagedStorageControlType.Disabled, 2068438255, "disabled")]
    [InlineData(BetaGoogleManagedStorageControlType.Enabled, 924343854, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedStorageControlType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedStorageControlType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageControlType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageControlType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageControlType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
