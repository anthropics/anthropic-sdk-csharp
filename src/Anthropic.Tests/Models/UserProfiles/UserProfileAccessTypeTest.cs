using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileAccessTypeTest : TestBase
{
    [Theory]
    [InlineData(UserProfileAccessType.Application)]
    [InlineData(UserProfileAccessType.Passthrough)]
    public void Validation_Works(UserProfileAccessType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileAccessType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileAccessType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileAccessType.Application)]
    [InlineData(UserProfileAccessType.Passthrough)]
    public void SerializationRoundtrip_Works(UserProfileAccessType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileAccessType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfileAccessType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileAccessType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfileAccessType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
