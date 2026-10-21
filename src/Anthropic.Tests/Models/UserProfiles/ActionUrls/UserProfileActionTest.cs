using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles.ActionUrls;

namespace Anthropic.Tests.Models.UserProfiles.ActionUrls;

public class UserProfileActionTest : TestBase
{
    [Fact]
    public void EnrollEndUserValidationWorks()
    {
        UserProfileAction value = new UserProfileEnrollEndUserAction();
        value.Validate();
    }

    [Fact]
    public void EnrollEndUserSerializationRoundtripWorks()
    {
        UserProfileAction value = new UserProfileEnrollEndUserAction();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileAction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrollEndUserTypeWorks()
    {
        UserProfileAction value = new UserProfileEnrollEndUserAction();
        Assert.Equal(UserProfileActionType.EnrollEndUser, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        UserProfileAction value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enroll_end_user"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, UserProfileActionType> expectedType = UserProfileActionType.EnrollEndUser;

        Assert.Equal(expectedType, value.Type);

        UserProfileAction emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class UserProfileActionTypeTest : TestBase
{
    [Theory]
    [InlineData(UserProfileActionType.EnrollEndUser)]
    public void Validation_Works(UserProfileActionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileActionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileActionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileActionType.EnrollEndUser)]
    public void SerializationRoundtrip_Works(UserProfileActionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileActionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfileActionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileActionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfileActionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
