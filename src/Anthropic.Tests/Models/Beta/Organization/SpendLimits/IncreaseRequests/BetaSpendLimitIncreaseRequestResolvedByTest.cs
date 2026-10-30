using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class BetaSpendLimitIncreaseRequestResolvedByTest : TestBase
{
    [Fact]
    public void UserActorValidationWorks()
    {
        BetaSpendLimitIncreaseRequestResolvedBy value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        value.Validate();
    }

    [Fact]
    public void ScopedApiKeyActorValidationWorks()
    {
        BetaSpendLimitIncreaseRequestResolvedBy value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        value.Validate();
    }

    [Fact]
    public void UserActorSerializationRoundtripWorks()
    {
        BetaSpendLimitIncreaseRequestResolvedBy value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitIncreaseRequestResolvedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScopedApiKeyActorSerializationRoundtripWorks()
    {
        BetaSpendLimitIncreaseRequestResolvedBy value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitIncreaseRequestResolvedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserActorTypeWorks()
    {
        BetaSpendLimitIncreaseRequestResolvedBy value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        Assert.Equal(BetaSpendLimitIncreaseRequestResolvedByType.UserActor, value.Type.Value());
    }

    [Fact]
    public void ScopedApiKeyActorTypeWorks()
    {
        BetaSpendLimitIncreaseRequestResolvedBy value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        Assert.Equal(
            BetaSpendLimitIncreaseRequestResolvedByType.ScopedApiKeyActor,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaSpendLimitIncreaseRequestResolvedBy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaSpendLimitIncreaseRequestResolvedByType> expectedType =
            BetaSpendLimitIncreaseRequestResolvedByType.UserActor;

        Assert.Equal(expectedType, value.Type);

        BetaSpendLimitIncreaseRequestResolvedBy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaSpendLimitIncreaseRequestResolvedByTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaSpendLimitIncreaseRequestResolvedByType.UserActor)]
    [InlineData(BetaSpendLimitIncreaseRequestResolvedByType.ScopedApiKeyActor)]
    public void Validation_Works(BetaSpendLimitIncreaseRequestResolvedByType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendLimitIncreaseRequestResolvedByType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestResolvedByType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaSpendLimitIncreaseRequestResolvedByType.UserActor)]
    [InlineData(BetaSpendLimitIncreaseRequestResolvedByType.ScopedApiKeyActor)]
    public void SerializationRoundtrip_Works(BetaSpendLimitIncreaseRequestResolvedByType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendLimitIncreaseRequestResolvedByType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestResolvedByType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestResolvedByType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestResolvedByType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
