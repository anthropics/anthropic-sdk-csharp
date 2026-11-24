using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectCmekRegionStatusTest : TestBase
{
    [Fact]
    public void NotConfiguredValidationWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id");
        value.Validate();
    }

    [Fact]
    public void PendingValidationWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionPending()
            {
                EffectiveExternalKeyID = "effective_external_key_id",
                Error = "error",
            };
        value.Validate();
    }

    [Fact]
    public void ActiveValidationWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionActive()
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
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionFailed()
            {
                EffectiveExternalKeyID = "effective_external_key_id",
                Error = "error",
            };
        value.Validate();
    }

    [Fact]
    public void SuspendedValidationWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionSuspended("effective_external_key_id");
        value.Validate();
    }

    [Fact]
    public void NotConfiguredSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PendingSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionPending()
            {
                EffectiveExternalKeyID = "effective_external_key_id",
                Error = "error",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActiveSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionActive()
            {
                EffectiveExternalKeyID = "effective_external_key_id",
                Error = "error",
                LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailedSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionFailed()
            {
                EffectiveExternalKeyID = "effective_external_key_id",
                Error = "error",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SuspendedSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionSuspended("effective_external_key_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotConfiguredTypeWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id");
        Assert.Equal(
            BetaGoogleManagedProjectCmekRegionStatusType.NotConfigured,
            value.Type.Value()
        );
    }

    [Fact]
    public void PendingTypeWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionPending()
            {
                EffectiveExternalKeyID = "effective_external_key_id",
                Error = "error",
            };
        Assert.Equal(BetaGoogleManagedProjectCmekRegionStatusType.Pending, value.Type.Value());
    }

    [Fact]
    public void ActiveTypeWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionActive()
            {
                EffectiveExternalKeyID = "effective_external_key_id",
                Error = "error",
                LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        Assert.Equal(BetaGoogleManagedProjectCmekRegionStatusType.Active, value.Type.Value());
    }

    [Fact]
    public void FailedTypeWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionFailed()
            {
                EffectiveExternalKeyID = "effective_external_key_id",
                Error = "error",
            };
        Assert.Equal(BetaGoogleManagedProjectCmekRegionStatusType.Failed, value.Type.Value());
    }

    [Fact]
    public void SuspendedTypeWorks()
    {
        BetaGoogleManagedProjectCmekRegionStatus value =
            new BetaGoogleManagedProjectCmekRegionSuspended("effective_external_key_id");
        Assert.Equal(BetaGoogleManagedProjectCmekRegionStatusType.Suspended, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedProjectCmekRegionStatus value = new(
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
        ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType> expectedType =
            BetaGoogleManagedProjectCmekRegionStatusType.NotConfigured;
        string expectedError = "error";

        Assert.Equal(expectedEffectiveExternalKeyID, value.EffectiveExternalKeyID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedError, value.Error);

        BetaGoogleManagedProjectCmekRegionStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.EffectiveExternalKeyID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Error);

        BetaGoogleManagedProjectCmekRegionStatus mismatchedValue = new(
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

public class BetaGoogleManagedProjectCmekRegionStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.NotConfigured)]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.Pending)]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.Active)]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.Failed)]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.Suspended)]
    public void Validation_Works(BetaGoogleManagedProjectCmekRegionStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaGoogleManagedProjectCmekRegionStatusType.NotConfigured,
        1232640842,
        "not_configured"
    )]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.Pending, 156685866, "pending")]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.Active, 1837619551, "active")]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.Failed, 434644459, "failed")]
    [InlineData(BetaGoogleManagedProjectCmekRegionStatusType.Suspended, 598628903, "suspended")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedProjectCmekRegionStatusType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType>
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
            ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
