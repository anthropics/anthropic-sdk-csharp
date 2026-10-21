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
    [InlineData(UserProfileEnforcementActionReason.UnsupportedRegion)]
    [InlineData(UserProfileEnforcementActionReason.FraudOrAbuse)]
    [InlineData(UserProfileEnforcementActionReason.HighHarm)]
    [InlineData(UserProfileEnforcementActionReason.UsagePolicyViolation)]
    [InlineData(UserProfileEnforcementActionReason.AccountCompromise)]
    [InlineData(UserProfileEnforcementActionReason.Unspecified)]
    public void SerializationRoundtrip_Works(UserProfileEnforcementActionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementActionReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
