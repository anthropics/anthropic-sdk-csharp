using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileProgramStatusTest : TestBase
{
    [Theory]
    [InlineData(UserProfileProgramStatus.Active)]
    [InlineData(UserProfileProgramStatus.Pending)]
    [InlineData(UserProfileProgramStatus.Rejected)]
    public void Validation_Works(UserProfileProgramStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileProgramStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileProgramStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileProgramStatus.Active)]
    [InlineData(UserProfileProgramStatus.Pending)]
    [InlineData(UserProfileProgramStatus.Rejected)]
    public void SerializationRoundtrip_Works(UserProfileProgramStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileProgramStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfileProgramStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileProgramStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfileProgramStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
