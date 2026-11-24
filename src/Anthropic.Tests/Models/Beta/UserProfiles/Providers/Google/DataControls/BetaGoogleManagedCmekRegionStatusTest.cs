using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedCmekRegionStatusTest : TestBase
{
    [Fact]
    public void NotConfiguredValidationWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionNotConfigured(
            "effective_external_key_id"
        );
        value.Validate();
    }

    [Fact]
    public void PendingValidationWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionPending()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };
        value.Validate();
    }

    [Fact]
    public void ActiveValidationWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionActive()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
            LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void FailedValidationWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionFailed()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };
        value.Validate();
    }

    [Fact]
    public void SuspendedValidationWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionSuspended(
            "effective_external_key_id"
        );
        value.Validate();
    }

    [Fact]
    public void NotConfiguredSerializationRoundtripWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionNotConfigured(
            "effective_external_key_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PendingSerializationRoundtripWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionPending()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActiveSerializationRoundtripWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionActive()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
            LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailedSerializationRoundtripWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionFailed()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SuspendedSerializationRoundtripWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionSuspended(
            "effective_external_key_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotConfiguredTypeWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionNotConfigured(
            "effective_external_key_id"
        );
        Assert.Equal(BetaGoogleManagedCmekRegionStatusType.NotConfigured, value.Type.Value());
    }

    [Fact]
    public void PendingTypeWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionPending()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };
        Assert.Equal(BetaGoogleManagedCmekRegionStatusType.Pending, value.Type.Value());
    }

    [Fact]
    public void ActiveTypeWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionActive()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
            LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaGoogleManagedCmekRegionStatusType.Active, value.Type.Value());
    }

    [Fact]
    public void FailedTypeWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionFailed()
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };
        Assert.Equal(BetaGoogleManagedCmekRegionStatusType.Failed, value.Type.Value());
    }

    [Fact]
    public void SuspendedTypeWorks()
    {
        BetaGoogleManagedCmekRegionStatus value = new BetaGoogleManagedCmekRegionSuspended(
            "effective_external_key_id"
        );
        Assert.Equal(BetaGoogleManagedCmekRegionStatusType.Suspended, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedCmekRegionStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "effective_external_key_id": "effective_external_key_id",
                  "type": "not_configured",
                  "error": "error"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedEffectiveExternalKeyID = "effective_external_key_id";
        ApiEnum<string, BetaGoogleManagedCmekRegionStatusType> expectedType =
            BetaGoogleManagedCmekRegionStatusType.NotConfigured;
        string expectedError = "error";

        Assert.Equal(expectedEffectiveExternalKeyID, value.EffectiveExternalKeyID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedError, value.Error);

        BetaGoogleManagedCmekRegionStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.EffectiveExternalKeyID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Error);

        BetaGoogleManagedCmekRegionStatus mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "effective_external_key_id": [
                    "invalid"
                  ],
                  "error": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.EffectiveExternalKeyID);
        Assert.Null(mismatchedValue.Error);
    }
}

public class BetaGoogleManagedCmekRegionStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.NotConfigured)]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.Pending)]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.Active)]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.Failed)]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.Suspended)]
    public void Validation_Works(BetaGoogleManagedCmekRegionStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedCmekRegionStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedCmekRegionStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.NotConfigured, 1232640842, "not_configured")]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.Pending, 156685866, "pending")]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.Active, 1837619551, "active")]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.Failed, 434644459, "failed")]
    [InlineData(BetaGoogleManagedCmekRegionStatusType.Suspended, 598628903, "suspended")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedCmekRegionStatusType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedCmekRegionStatusType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedCmekRegionStatusType>
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
            ApiEnum<string, BetaGoogleManagedCmekRegionStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedCmekRegionStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
