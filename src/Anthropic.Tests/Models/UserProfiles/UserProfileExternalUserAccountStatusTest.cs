using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileExternalUserAccountStatusTest : TestBase
{
    [Theory]
    [InlineData(UserProfileExternalUserAccountStatus.Active)]
    [InlineData(UserProfileExternalUserAccountStatus.Suspended)]
    [InlineData(UserProfileExternalUserAccountStatus.Blocked)]
    public void Validation_Works(UserProfileExternalUserAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileExternalUserAccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileExternalUserAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileExternalUserAccountStatus.Active)]
    [InlineData(UserProfileExternalUserAccountStatus.Suspended)]
    [InlineData(UserProfileExternalUserAccountStatus.Blocked)]
    public void SerializationRoundtrip_Works(UserProfileExternalUserAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileExternalUserAccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileExternalUserAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileExternalUserAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileExternalUserAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
