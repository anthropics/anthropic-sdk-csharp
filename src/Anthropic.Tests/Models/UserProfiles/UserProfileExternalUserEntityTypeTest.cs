using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileExternalUserEntityTypeTest : TestBase
{
    [Theory]
    [InlineData(UserProfileExternalUserEntityType.Individual)]
    [InlineData(UserProfileExternalUserEntityType.Business)]
    [InlineData(UserProfileExternalUserEntityType.NonProfit)]
    [InlineData(UserProfileExternalUserEntityType.Government)]
    public void Validation_Works(UserProfileExternalUserEntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileExternalUserEntityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileExternalUserEntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileExternalUserEntityType.Individual, 0, "individual")]
    [InlineData(UserProfileExternalUserEntityType.Business, 1, "business")]
    [InlineData(UserProfileExternalUserEntityType.NonProfit, 2, "non_profit")]
    [InlineData(UserProfileExternalUserEntityType.Government, 3, "government")]
    public void EnumMemberSerializationRoundtrip_Works(
        UserProfileExternalUserEntityType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileExternalUserEntityType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileExternalUserEntityType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileExternalUserEntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileExternalUserEntityType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
