using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileListOrderTest : TestBase
{
    [Theory]
    [InlineData(UserProfileListOrder.Asc)]
    [InlineData(UserProfileListOrder.Desc)]
    public void Validation_Works(UserProfileListOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileListOrder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileListOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileListOrder.Asc)]
    [InlineData(UserProfileListOrder.Desc)]
    public void SerializationRoundtrip_Works(UserProfileListOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileListOrder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfileListOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileListOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfileListOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
