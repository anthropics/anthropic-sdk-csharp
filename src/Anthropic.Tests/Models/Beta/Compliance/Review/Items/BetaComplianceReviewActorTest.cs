using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class BetaComplianceReviewActorTest : TestBase
{
    [Fact]
    public void UserValidationWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewUserActor()
        {
            EmailAddress = "email_address",
            UserID = "user_id",
        };
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewApiActor("api_key_id");
        value.Validate();
    }

    [Fact]
    public void ServiceAccountValidationWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewServiceAccountActor(
            "service_account_id"
        );
        value.Validate();
    }

    [Fact]
    public void UserSerializationRoundtripWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewUserActor()
        {
            EmailAddress = "email_address",
            UserID = "user_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewApiActor("api_key_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServiceAccountSerializationRoundtripWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewServiceAccountActor(
            "service_account_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserTypeWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewUserActor()
        {
            EmailAddress = "email_address",
            UserID = "user_id",
        };
        Assert.Equal(BetaComplianceReviewActorType.UserActor, value.Type.Value());
    }

    [Fact]
    public void ApiTypeWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewApiActor("api_key_id");
        Assert.Equal(BetaComplianceReviewActorType.ApiActor, value.Type.Value());
    }

    [Fact]
    public void ServiceAccountTypeWorks()
    {
        BetaComplianceReviewActor value = new BetaComplianceReviewServiceAccountActor(
            "service_account_id"
        );
        Assert.Equal(BetaComplianceReviewActorType.ServiceAccountActor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaComplianceReviewActor value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaComplianceReviewActorType> expectedType =
            BetaComplianceReviewActorType.UserActor;

        Assert.Equal(expectedType, value.Type);

        BetaComplianceReviewActor emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaComplianceReviewActorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewActorType.UserActor)]
    [InlineData(BetaComplianceReviewActorType.ApiActor)]
    [InlineData(BetaComplianceReviewActorType.ServiceAccountActor)]
    public void Validation_Works(BetaComplianceReviewActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewActorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceReviewActorType.UserActor, 339255143, "user_actor")]
    [InlineData(BetaComplianceReviewActorType.ApiActor, 42160694, "api_actor")]
    [InlineData(
        BetaComplianceReviewActorType.ServiceAccountActor,
        1364373501,
        "service_account_actor"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewActorType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewActorType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewActorType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewActorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
