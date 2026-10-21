using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileEnforcementActionTest : TestBase
{
    [Fact]
    public void RestrictionValidationWorks()
    {
        UserProfileEnforcementAction value = new UserProfileEnforcementActionRestriction()
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = UserProfileEnforcementActionNextStep.Verify,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
        };
        value.Validate();
    }

    [Fact]
    public void BanValidationWorks()
    {
        UserProfileEnforcementAction value = new UserProfileEnforcementActionBan()
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = null,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.UsagePolicyViolation,
        };
        value.Validate();
    }

    [Fact]
    public void RestrictionSerializationRoundtripWorks()
    {
        UserProfileEnforcementAction value = new UserProfileEnforcementActionRestriction()
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = UserProfileEnforcementActionNextStep.Verify,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEnforcementAction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BanSerializationRoundtripWorks()
    {
        UserProfileEnforcementAction value = new UserProfileEnforcementActionBan()
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = null,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.UsagePolicyViolation,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEnforcementAction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RestrictionTypeWorks()
    {
        UserProfileEnforcementAction value = new UserProfileEnforcementActionRestriction()
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = UserProfileEnforcementActionNextStep.Verify,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
        };
        Assert.Equal(UserProfileEnforcementActionType.Restriction, value.Type.Value());
    }

    [Fact]
    public void BanTypeWorks()
    {
        UserProfileEnforcementAction value = new UserProfileEnforcementActionBan()
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = null,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.UsagePolicyViolation,
        };
        Assert.Equal(UserProfileEnforcementActionType.Ban, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        UserProfileEnforcementAction value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "enac_011CZkZCu8hGbp5mYRQgUmz9",
                  "action": "verify",
                  "expires_at": null,
                  "opened_at": "2026-10-02T19:30:00Z",
                  "reason": "fraud_or_abuse",
                  "type": "restriction"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "enac_011CZkZCu8hGbp5mYRQgUmz9";
        ApiEnum<string, UserProfileEnforcementActionNextStep> expectedAction =
            UserProfileEnforcementActionNextStep.Verify;
        DateTimeOffset expectedOpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z");
        ApiEnum<string, UserProfileEnforcementActionReason> expectedReason =
            UserProfileEnforcementActionReason.FraudOrAbuse;
        ApiEnum<string, UserProfileEnforcementActionType> expectedType =
            UserProfileEnforcementActionType.Restriction;

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedAction, value.Action);
        Assert.Null(value.ExpiresAt);
        Assert.Equal(expectedOpenedAt, value.OpenedAt);
        Assert.Equal(expectedReason, value.Reason);
        Assert.Equal(expectedType, value.Type);

        UserProfileEnforcementAction emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Null(emptyValue.Action);
        Assert.Null(emptyValue.ExpiresAt);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.OpenedAt);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Reason);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        UserProfileEnforcementAction mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ],
                  "expires_at": [
                    "invalid"
                  ],
                  "opened_at": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ID);
        Assert.Null(mismatchedValue.ExpiresAt);
        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.OpenedAt);
    }
}

public class UserProfileEnforcementActionTypeTest : TestBase
{
    [Theory]
    [InlineData(UserProfileEnforcementActionType.Restriction)]
    [InlineData(UserProfileEnforcementActionType.Ban)]
    public void Validation_Works(UserProfileEnforcementActionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementActionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileEnforcementActionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileEnforcementActionType.Restriction)]
    [InlineData(UserProfileEnforcementActionType.Ban)]
    public void SerializationRoundtrip_Works(UserProfileEnforcementActionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementActionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileEnforcementActionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
