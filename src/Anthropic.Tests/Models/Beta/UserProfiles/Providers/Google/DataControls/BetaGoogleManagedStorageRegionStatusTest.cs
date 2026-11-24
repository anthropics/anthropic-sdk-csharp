using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedStorageRegionStatusTest : TestBase
{
    [Fact]
    public void NotConfiguredValidationWorks()
    {
        BetaGoogleManagedStorageRegionStatus value =
            new BetaGoogleManagedStorageRegionNotConfigured(
                new BetaGoogleManagedBucketReference()
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
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionPending()
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
                    Check = Check.LabelMismatch,
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
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionActive()
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
                    Check = Check.LabelMismatch,
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
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionFailed()
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
                    Check = Check.LabelMismatch,
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
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionSuspended(
            new BetaGoogleManagedBucketReference()
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
        BetaGoogleManagedStorageRegionStatus value =
            new BetaGoogleManagedStorageRegionNotConfigured(
                new BetaGoogleManagedBucketReference()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                }
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PendingSerializationRoundtripWorks()
    {
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionPending()
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
                    Check = Check.LabelMismatch,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActiveSerializationRoundtripWorks()
    {
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionActive()
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
                    Check = Check.LabelMismatch,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailedSerializationRoundtripWorks()
    {
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionFailed()
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
                    Check = Check.LabelMismatch,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SuspendedSerializationRoundtripWorks()
    {
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionSuspended(
            new BetaGoogleManagedBucketReference()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotConfiguredTypeWorks()
    {
        BetaGoogleManagedStorageRegionStatus value =
            new BetaGoogleManagedStorageRegionNotConfigured(
                new BetaGoogleManagedBucketReference()
                {
                    BucketName = "bucket_name",
                    ProjectNumber = "project_number",
                }
            );
        Assert.Equal(BetaGoogleManagedStorageRegionStatusType.NotConfigured, value.Type.Value());
    }

    [Fact]
    public void PendingTypeWorks()
    {
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionPending()
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
                    Check = Check.LabelMismatch,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };
        Assert.Equal(BetaGoogleManagedStorageRegionStatusType.Pending, value.Type.Value());
    }

    [Fact]
    public void ActiveTypeWorks()
    {
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionActive()
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
                    Check = Check.LabelMismatch,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaGoogleManagedStorageRegionStatusType.Active, value.Type.Value());
    }

    [Fact]
    public void FailedTypeWorks()
    {
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionFailed()
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
                    Check = Check.LabelMismatch,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };
        Assert.Equal(BetaGoogleManagedStorageRegionStatusType.Failed, value.Type.Value());
    }

    [Fact]
    public void SuspendedTypeWorks()
    {
        BetaGoogleManagedStorageRegionStatus value = new BetaGoogleManagedStorageRegionSuspended(
            new BetaGoogleManagedBucketReference()
            {
                BucketName = "bucket_name",
                ProjectNumber = "project_number",
            }
        );
        Assert.Equal(BetaGoogleManagedStorageRegionStatusType.Suspended, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedStorageRegionStatus value = new(
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
                      "check": "label_mismatch",
                      "message": "message",
                      "role": "ingest"
                    }
                  ]
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        BetaGoogleManagedBucketReference expectedEffectiveBucket = new()
        {
            BucketName = "bucket_name",
            ProjectNumber = "project_number",
        };
        ApiEnum<string, BetaGoogleManagedStorageRegionStatusType> expectedType =
            BetaGoogleManagedStorageRegionStatusType.NotConfigured;
        List<BetaGoogleManagedStorageFailedCheck> expectedFailedChecks =
        [
            new()
            {
                Check = Check.LabelMismatch,
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

        BetaGoogleManagedStorageRegionStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.EffectiveBucket);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.FailedChecks);

        BetaGoogleManagedStorageRegionStatus mismatchedValue = new(
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

public class BetaGoogleManagedStorageRegionStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.NotConfigured)]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.Pending)]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.Active)]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.Failed)]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.Suspended)]
    public void Validation_Works(BetaGoogleManagedStorageRegionStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedStorageRegionStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageRegionStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaGoogleManagedStorageRegionStatusType.NotConfigured,
        1232640842,
        "not_configured"
    )]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.Pending, 156685866, "pending")]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.Active, 1837619551, "active")]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.Failed, 434644459, "failed")]
    [InlineData(BetaGoogleManagedStorageRegionStatusType.Suspended, 598628903, "suspended")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedStorageRegionStatusType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedStorageRegionStatusType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageRegionStatusType>
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
            ApiEnum<string, BetaGoogleManagedStorageRegionStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageRegionStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
