using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles.ActionUrls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.ActionUrls;

public class BetaUserProfileActionTest : TestBase
{
    [Fact]
    public void EnrollEndUserValidationWorks()
    {
        BetaUserProfileAction value = new BetaUserProfileEnrollEndUserAction();
        value.Validate();
    }

    [Fact]
    public void EnrollEndUserSerializationRoundtripWorks()
    {
        BetaUserProfileAction value = new BetaUserProfileEnrollEndUserAction();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileAction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnrollEndUserTypeWorks()
    {
        BetaUserProfileAction value = new BetaUserProfileEnrollEndUserAction();
        Assert.Equal(BetaUserProfileActionType.EnrollEndUser, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaUserProfileAction value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enroll_end_user"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaUserProfileActionType> expectedType =
            BetaUserProfileActionType.EnrollEndUser;

        Assert.Equal(expectedType, value.Type);

        BetaUserProfileAction emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaUserProfileActionTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaUserProfileActionType.EnrollEndUser)]
    public void Validation_Works(BetaUserProfileActionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileActionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileActionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaUserProfileActionType.EnrollEndUser)]
    public void SerializationRoundtrip_Works(BetaUserProfileActionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileActionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileActionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileActionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileActionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
