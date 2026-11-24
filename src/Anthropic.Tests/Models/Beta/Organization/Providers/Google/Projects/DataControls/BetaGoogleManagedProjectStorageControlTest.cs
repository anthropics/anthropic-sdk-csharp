using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageControlTest : TestBase
{
    [Fact]
    public void DisabledValidationWorks()
    {
        BetaGoogleManagedProjectStorageControl value = new BetaGoogleManagedProjectStorageDisabled(
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
        value.Validate();
    }

    [Fact]
    public void EnabledValidationWorks()
    {
        BetaGoogleManagedProjectStorageControl value = new BetaGoogleManagedProjectStorageEnabled()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectStorageBucket>()
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
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectStorageRegionNotConfigured(
                        new BetaGoogleManagedProjectEffectiveBucket()
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
        BetaGoogleManagedProjectStorageControl value = new BetaGoogleManagedProjectStorageDisabled(
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageControl>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectStorageControl value = new BetaGoogleManagedProjectStorageEnabled()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectStorageBucket>()
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
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectStorageRegionNotConfigured(
                        new BetaGoogleManagedProjectEffectiveBucket()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageControl>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaGoogleManagedProjectStorageControl value = new BetaGoogleManagedProjectStorageDisabled(
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
        Assert.Equal(BetaGoogleManagedProjectStorageControlType.Disabled, value.Type.Value());
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaGoogleManagedProjectStorageControl value = new BetaGoogleManagedProjectStorageEnabled()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedProjectStorageBucket>()
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
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectStorageRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectStorageRegionNotConfigured(
                        new BetaGoogleManagedProjectEffectiveBucket()
                        {
                            BucketName = "bucket_name",
                            ProjectNumber = "project_number",
                        }
                    )
                },
            },
        };
        Assert.Equal(BetaGoogleManagedProjectStorageControlType.Enabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedProjectStorageControl value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "retired_buckets": [
                    {
                      "bucket_name": "bucket_name",
                      "expires_at": "2019-12-27T18:11:19.117+00:00",
                      "project_number": "project_number",
                      "region": "us"
                    }
                  ],
                  "type": "disabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        List<BetaGoogleManagedProjectRetiredBucket> expectedRetiredBuckets =
        [
            new()
            {
                BucketName = "bucket_name",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                ProjectNumber = "project_number",
                Region = "us",
            },
        ];
        ApiEnum<string, BetaGoogleManagedProjectStorageControlType> expectedType =
            BetaGoogleManagedProjectStorageControlType.Disabled;

        Assert.Equal(expectedRetiredBuckets.Count, value.RetiredBuckets.Count);
        for (int i = 0; i < expectedRetiredBuckets.Count; i++)
        {
            Assert.Equal(expectedRetiredBuckets[i], value.RetiredBuckets[i]);
        }
        Assert.Equal(expectedType, value.Type);

        BetaGoogleManagedProjectStorageControl emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.RetiredBuckets);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaGoogleManagedProjectStorageControlTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedProjectStorageControlType.Disabled)]
    [InlineData(BetaGoogleManagedProjectStorageControlType.Enabled)]
    public void Validation_Works(BetaGoogleManagedProjectStorageControlType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectStorageControlType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageControlType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaGoogleManagedProjectStorageControlType.Disabled, 2068438255, "disabled")]
    [InlineData(BetaGoogleManagedProjectStorageControlType.Enabled, 924343854, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedProjectStorageControlType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectStorageControlType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageControlType>
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
            ApiEnum<string, BetaGoogleManagedProjectStorageControlType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageControlType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
