using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaStorageVerificationFailedErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
            Field = "inference_data_privacy.safeguards_storage",
        };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "storage_verification_failed"
        );
        List<BetaExternalStorageFailedCheck> expectedFailedChecks =
        [
            new()
            {
                Check = Check.AlreadyRegistered,
                Message = "message",
                Role = Role.Ingest,
            },
        ];
        string expectedField = "inference_data_privacy.safeguards_storage";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedFailedChecks.Count, model.FailedChecks.Count);
        for (int i = 0; i < expectedFailedChecks.Count; i++)
        {
            Assert.Equal(expectedFailedChecks[i], model.FailedChecks[i]);
        }
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
            Field = "inference_data_privacy.safeguards_storage",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageVerificationFailedErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
            Field = "inference_data_privacy.safeguards_storage",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageVerificationFailedErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "storage_verification_failed"
        );
        List<BetaExternalStorageFailedCheck> expectedFailedChecks =
        [
            new()
            {
                Check = Check.AlreadyRegistered,
                Message = "message",
                Role = Role.Ingest,
            },
        ];
        string expectedField = "inference_data_privacy.safeguards_storage";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedFailedChecks.Count, deserialized.FailedChecks.Count);
        for (int i = 0; i < expectedFailedChecks.Count; i++)
        {
            Assert.Equal(expectedFailedChecks[i], deserialized.FailedChecks[i]);
        }
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
            Field = "inference_data_privacy.safeguards_storage",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],

            Field = null,
        };

        Assert.Null(model.Field);
        Assert.True(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],

            Field = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaStorageVerificationFailedErrorDetails
        {
            FailedChecks =
            [
                new()
                {
                    Check = Check.AlreadyRegistered,
                    Message = "message",
                    Role = Role.Ingest,
                },
            ],
            Field = "inference_data_privacy.safeguards_storage",
        };

        BetaStorageVerificationFailedErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
