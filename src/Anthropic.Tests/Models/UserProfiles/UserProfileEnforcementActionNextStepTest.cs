using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileEnforcementActionNextStepTest : TestBase
{
    [Theory]
    [InlineData(UserProfileEnforcementActionNextStep.Verify)]
    public void Validation_Works(UserProfileEnforcementActionNextStep rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementActionNextStep> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionNextStep>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileEnforcementActionNextStep.Verify)]
    public void SerializationRoundtrip_Works(UserProfileEnforcementActionNextStep rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileEnforcementActionNextStep> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionNextStep>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionNextStep>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileEnforcementActionNextStep>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
