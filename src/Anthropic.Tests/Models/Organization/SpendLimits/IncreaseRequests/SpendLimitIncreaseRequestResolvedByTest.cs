using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.SpendLimits;
using Anthropic.Models.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Organization.SpendLimits.IncreaseRequests;

public class SpendLimitIncreaseRequestResolvedByTest : TestBase
{
    [Fact]
    public void UserActorValidationWorks()
    {
        SpendLimitIncreaseRequestResolvedBy value = new SpendLimitUserActor()
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
        SpendLimitIncreaseRequestResolvedBy value = new SpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        value.Validate();
    }

    [Fact]
    public void UserActorSerializationRoundtripWorks()
    {
        SpendLimitIncreaseRequestResolvedBy value = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitIncreaseRequestResolvedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScopedApiKeyActorSerializationRoundtripWorks()
    {
        SpendLimitIncreaseRequestResolvedBy value = new SpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitIncreaseRequestResolvedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserActorTypeWorks()
    {
        SpendLimitIncreaseRequestResolvedBy value = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        Assert.Equal(SpendLimitIncreaseRequestResolvedByType.UserActor, value.Type.Value());
    }

    [Fact]
    public void ScopedApiKeyActorTypeWorks()
    {
        SpendLimitIncreaseRequestResolvedBy value = new SpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        Assert.Equal(SpendLimitIncreaseRequestResolvedByType.ScopedApiKeyActor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        SpendLimitIncreaseRequestResolvedBy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, SpendLimitIncreaseRequestResolvedByType> expectedType =
            SpendLimitIncreaseRequestResolvedByType.UserActor;

        Assert.Equal(expectedType, value.Type);

        SpendLimitIncreaseRequestResolvedBy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class SpendLimitIncreaseRequestResolvedByTypeTest : TestBase
{
    [Theory]
    [InlineData(SpendLimitIncreaseRequestResolvedByType.UserActor)]
    [InlineData(SpendLimitIncreaseRequestResolvedByType.ScopedApiKeyActor)]
    public void Validation_Works(SpendLimitIncreaseRequestResolvedByType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendLimitIncreaseRequestResolvedByType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SpendLimitIncreaseRequestResolvedByType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SpendLimitIncreaseRequestResolvedByType.UserActor)]
    [InlineData(SpendLimitIncreaseRequestResolvedByType.ScopedApiKeyActor)]
    public void SerializationRoundtrip_Works(SpendLimitIncreaseRequestResolvedByType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendLimitIncreaseRequestResolvedByType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SpendLimitIncreaseRequestResolvedByType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SpendLimitIncreaseRequestResolvedByType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SpendLimitIncreaseRequestResolvedByType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
