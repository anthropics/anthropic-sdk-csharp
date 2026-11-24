using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageRegionStatusTest : TestBase
{
    [Fact]
    public void NotConfiguredValidationWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionNotConfigured(
                new BetaGoogleManagedProjectEffectiveBucket()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                }
            );
        value.Validate();
    }

    [Fact]
    public void PendingValidationWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionPending()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
            };
        value.Validate();
    }

    [Fact]
    public void ActiveValidationWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionActive()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
                ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void FailedValidationWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionFailed()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
            };
        value.Validate();
    }

    [Fact]
    public void SuspendedValidationWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionSuspended(
                new BetaGoogleManagedProjectEffectiveBucket()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                }
            );
        value.Validate();
    }

    [Fact]
    public void NotConfiguredSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionNotConfigured(
                new BetaGoogleManagedProjectEffectiveBucket()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                }
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PendingSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionPending()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActiveSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionActive()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
                ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailedSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionFailed()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SuspendedSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionSuspended(
                new BetaGoogleManagedProjectEffectiveBucket()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                }
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotConfiguredTypeWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionNotConfigured(
                new BetaGoogleManagedProjectEffectiveBucket()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                }
            );
        Assert.Equal(
            BetaGoogleManagedProjectStorageRegionStatusType.NotConfigured,
            value.Type.Value()
        );
    }

    [Fact]
    public void PendingTypeWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionPending()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
            };
        Assert.Equal(BetaGoogleManagedProjectStorageRegionStatusType.Pending, value.Type.Value());
    }

    [Fact]
    public void ActiveTypeWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionActive()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
                ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        Assert.Equal(BetaGoogleManagedProjectStorageRegionStatusType.Active, value.Type.Value());
    }

    [Fact]
    public void FailedTypeWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionFailed()
            {
                EffectiveBucket = new()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                },
                FailedChecks =
                [
                    new()
                    {
                        Check = Check.BucketSettings,
                        Message = "message",
                        Role = Role.Ingest,
                    },
                ],
            };
        Assert.Equal(BetaGoogleManagedProjectStorageRegionStatusType.Failed, value.Type.Value());
    }

    [Fact]
    public void SuspendedTypeWorks()
    {
        BetaGoogleManagedProjectStorageRegionStatus value =
            new BetaGoogleManagedProjectStorageRegionSuspended(
                new BetaGoogleManagedProjectEffectiveBucket()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                }
            );
        Assert.Equal(BetaGoogleManagedProjectStorageRegionStatusType.Suspended, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedProjectStorageRegionStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "effective_bucket": {
                    "bucket_name": "bucket_name",
                    "project_number": "project_number"
                  },
                  "type": "not_configured",
                  "failed_checks": [
                    {
                      "check": "bucket_settings",
                      "message": "message",
                      "role": "ingest"
                    }
                  ]
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        BetaGoogleManagedProjectEffectiveBucket expectedEffectiveBucket = new()
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };
        ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType> expectedType =
            BetaGoogleManagedProjectStorageRegionStatusType.NotConfigured;
        List<BetaGoogleManagedProjectStorageFailedCheck> expectedFailedChecks =
        [
            new()
            {
                Check = Check.BucketSettings,
                Message = "message",
                Role = Role.Ingest,
            },
        ];

        Assert.Equal(expectedEffectiveBucket, value.EffectiveBucket);
        Assert.Equal(expectedType, value.Type);
        Assert.NotNull(value.FailedChecks);
        Assert.Equal(expectedFailedChecks.Count, value.FailedChecks.Count);
        for (int i = 0; i < expectedFailedChecks.Count; i++)
        {
            Assert.Equal(expectedFailedChecks[i], value.FailedChecks[i]);
        }

        BetaGoogleManagedProjectStorageRegionStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.EffectiveBucket);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.FailedChecks);

        BetaGoogleManagedProjectStorageRegionStatus mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "effective_bucket": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.EffectiveBucket);
    }
}

public class BetaGoogleManagedProjectStorageRegionStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.NotConfigured)]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.Pending)]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.Active)]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.Failed)]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.Suspended)]
    public void Validation_Works(BetaGoogleManagedProjectStorageRegionStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaGoogleManagedProjectStorageRegionStatusType.NotConfigured,
        1232640842,
        "not_configured"
    )]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.Pending, 156685866, "pending")]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.Active, 1837619551, "active")]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.Failed, 434644459, "failed")]
    [InlineData(BetaGoogleManagedProjectStorageRegionStatusType.Suspended, 598628903, "suspended")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedProjectStorageRegionStatusType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType>
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
            ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
