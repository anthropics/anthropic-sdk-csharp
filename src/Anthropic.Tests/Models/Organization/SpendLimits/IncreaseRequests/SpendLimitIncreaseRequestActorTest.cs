using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.SpendLimits;
using Anthropic.Models.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Organization.SpendLimits.IncreaseRequests;

public class SpendLimitIncreaseRequestActorTest : TestBase
{
    [Fact]
    public void UserValidationWorks()
    {
        SpendLimitIncreaseRequestActor value = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        value.Validate();
    }

    [Fact]
    public void ScopedApiKeyValidationWorks()
    {
        SpendLimitIncreaseRequestActor value = new SpendLimitScopedApiKeyActor("scoped_api_key_id");
        value.Validate();
    }

    [Fact]
    public void UserSerializationRoundtripWorks()
    {
        SpendLimitIncreaseRequestActor value = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitIncreaseRequestActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScopedApiKeySerializationRoundtripWorks()
    {
        SpendLimitIncreaseRequestActor value = new SpendLimitScopedApiKeyActor("scoped_api_key_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitIncreaseRequestActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserTypeWorks()
    {
        SpendLimitIncreaseRequestActor value = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        Assert.Equal(SpendLimitIncreaseRequestActorType.UserActor, value.Type.Value());
    }

    [Fact]
    public void ScopedApiKeyTypeWorks()
    {
        SpendLimitIncreaseRequestActor value = new SpendLimitScopedApiKeyActor("scoped_api_key_id");
        Assert.Equal(SpendLimitIncreaseRequestActorType.ScopedApiKeyActor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        SpendLimitIncreaseRequestActor value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, SpendLimitIncreaseRequestActorType> expectedType =
            SpendLimitIncreaseRequestActorType.UserActor;

        Assert.Equal(expectedType, value.Type);

        SpendLimitIncreaseRequestActor emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class SpendLimitIncreaseRequestActorTypeTest : TestBase
{
    [Theory]
    [InlineData(SpendLimitIncreaseRequestActorType.UserActor)]
    [InlineData(SpendLimitIncreaseRequestActorType.ScopedApiKeyActor)]
    public void Validation_Works(SpendLimitIncreaseRequestActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendLimitIncreaseRequestActorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpendLimitIncreaseRequestActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SpendLimitIncreaseRequestActorType.UserActor)]
    [InlineData(SpendLimitIncreaseRequestActorType.ScopedApiKeyActor)]
    public void SerializationRoundtrip_Works(SpendLimitIncreaseRequestActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendLimitIncreaseRequestActorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SpendLimitIncreaseRequestActorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpendLimitIncreaseRequestActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SpendLimitIncreaseRequestActorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
