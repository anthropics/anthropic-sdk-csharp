using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class BetaSpendLimitIncreaseRequestActorTest : TestBase
{
    [Fact]
    public void UserValidationWorks()
    {
        BetaSpendLimitIncreaseRequestActor value = new BetaSpendLimitUserActor()
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
        BetaSpendLimitIncreaseRequestActor value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        value.Validate();
    }

    [Fact]
    public void UserSerializationRoundtripWorks()
    {
        BetaSpendLimitIncreaseRequestActor value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitIncreaseRequestActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScopedApiKeySerializationRoundtripWorks()
    {
        BetaSpendLimitIncreaseRequestActor value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitIncreaseRequestActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserTypeWorks()
    {
        BetaSpendLimitIncreaseRequestActor value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        Assert.Equal(BetaSpendLimitIncreaseRequestActorType.UserActor, value.Type.Value());
    }

    [Fact]
    public void ScopedApiKeyTypeWorks()
    {
        BetaSpendLimitIncreaseRequestActor value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        Assert.Equal(BetaSpendLimitIncreaseRequestActorType.ScopedApiKeyActor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaSpendLimitIncreaseRequestActor value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaSpendLimitIncreaseRequestActorType> expectedType =
            BetaSpendLimitIncreaseRequestActorType.UserActor;

        Assert.Equal(expectedType, value.Type);

        BetaSpendLimitIncreaseRequestActor emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaSpendLimitIncreaseRequestActorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaSpendLimitIncreaseRequestActorType.UserActor)]
    [InlineData(BetaSpendLimitIncreaseRequestActorType.ScopedApiKeyActor)]
    public void Validation_Works(BetaSpendLimitIncreaseRequestActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendLimitIncreaseRequestActorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestActorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaSpendLimitIncreaseRequestActorType.UserActor)]
    [InlineData(BetaSpendLimitIncreaseRequestActorType.ScopedApiKeyActor)]
    public void SerializationRoundtrip_Works(BetaSpendLimitIncreaseRequestActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendLimitIncreaseRequestActorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestActorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestActorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestActorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
