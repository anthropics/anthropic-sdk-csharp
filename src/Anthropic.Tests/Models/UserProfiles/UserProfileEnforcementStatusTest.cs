using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileEnforcementStatusTest : TestBase
{
    [Theory]
    [InlineData(UserProfileEnforcementStatus.Unrestricted)]
    [InlineData(UserProfileEnforcementStatus.Pending)]
    [InlineData(UserProfileEnforcementStatus.Restricted)]
    [InlineData(UserProfileEnforcementStatus.Banned)]
    public void Validation_Works(UserProfileEnforcementStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileEnforcementStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileEnforcementStatus.Unrestricted)]
    [InlineData(UserProfileEnforcementStatus.Pending)]
    [InlineData(UserProfileEnforcementStatus.Restricted)]
    [InlineData(UserProfileEnforcementStatus.Banned)]
    public void SerializationRoundtrip_Works(UserProfileEnforcementStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileEnforcementStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
