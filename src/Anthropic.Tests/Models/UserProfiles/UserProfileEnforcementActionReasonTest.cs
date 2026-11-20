using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileEnforcementActionReasonTest : TestBase
{
    [Theory]
    [InlineData(UserProfileEnforcementActionReason.UnsupportedRegion)]
    [InlineData(UserProfileEnforcementActionReason.FraudOrAbuse)]
    [InlineData(UserProfileEnforcementActionReason.HighHarm)]
    [InlineData(UserProfileEnforcementActionReason.UsagePolicyViolation)]
    [InlineData(UserProfileEnforcementActionReason.AccountCompromise)]
    [InlineData(UserProfileEnforcementActionReason.Unspecified)]
    public void Validation_Works(UserProfileEnforcementActionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementActionReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileEnforcementActionReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileEnforcementActionReason.UnsupportedRegion, 0, "unsupported_region")]
    [InlineData(UserProfileEnforcementActionReason.FraudOrAbuse, 1, "fraud_or_abuse")]
    [InlineData(UserProfileEnforcementActionReason.HighHarm, 2, "high_harm")]
    [InlineData(
        UserProfileEnforcementActionReason.UsagePolicyViolation,
        3,
        "usage_policy_violation"
    )]
    [InlineData(UserProfileEnforcementActionReason.AccountCompromise, 4, "account_compromise")]
    [InlineData(UserProfileEnforcementActionReason.Unspecified, 5, "unspecified")]
    public void EnumMemberSerializationRoundtrip_Works(
        UserProfileEnforcementActionReason rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementActionReason> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionReason>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileEnforcementActionReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
