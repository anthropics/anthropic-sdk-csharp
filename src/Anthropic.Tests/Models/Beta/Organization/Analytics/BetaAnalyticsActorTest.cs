using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsActorTest : TestBase
{
    [Fact]
    public void ReportUserValidationWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsReportUserActor()
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        value.Validate();
    }

    [Fact]
    public void ServiceAccountValidationWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsServiceAccountActor(
            "svac_01Hk3R9TWxq7CfQak00OiVw4"
        );
        value.Validate();
    }

    [Fact]
    public void FederatedValidationWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsFederatedActor()
        {
            Provider = new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            },
            Subject = "subject",
        };
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsApiActor("apikey_01BcDeFgHjKmNpQrStUvWxYz");
        value.Validate();
    }

    [Fact]
    public void ReportUserSerializationRoundtripWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsReportUserActor()
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServiceAccountSerializationRoundtripWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsServiceAccountActor(
            "svac_01Hk3R9TWxq7CfQak00OiVw4"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FederatedSerializationRoundtripWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsFederatedActor()
        {
            Provider = new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            },
            Subject = "subject",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsApiActor("apikey_01BcDeFgHjKmNpQrStUvWxYz");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReportUserTypeWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsReportUserActor()
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        Assert.Equal(BetaAnalyticsActorTypeValue.UserActor, value.Type.Value());
    }

    [Fact]
    public void ServiceAccountTypeWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsServiceAccountActor(
            "svac_01Hk3R9TWxq7CfQak00OiVw4"
        );
        Assert.Equal(BetaAnalyticsActorTypeValue.ServiceAccountActor, value.Type.Value());
    }

    [Fact]
    public void FederatedTypeWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsFederatedActor()
        {
            Provider = new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            },
            Subject = "subject",
        };
        Assert.Equal(BetaAnalyticsActorTypeValue.FederatedActor, value.Type.Value());
    }

    [Fact]
    public void ApiTypeWorks()
    {
        BetaAnalyticsActor value = new BetaAnalyticsApiActor("apikey_01BcDeFgHjKmNpQrStUvWxYz");
        Assert.Equal(BetaAnalyticsActorTypeValue.ApiActor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaAnalyticsActor value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaAnalyticsActorTypeValue> expectedType =
            BetaAnalyticsActorTypeValue.UserActor;

        Assert.Equal(expectedType, value.Type);

        BetaAnalyticsActor emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaAnalyticsActorTypeValueTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsActorTypeValue.UserActor)]
    [InlineData(BetaAnalyticsActorTypeValue.ServiceAccountActor)]
    [InlineData(BetaAnalyticsActorTypeValue.FederatedActor)]
    [InlineData(BetaAnalyticsActorTypeValue.ApiActor)]
    public void Validation_Works(BetaAnalyticsActorTypeValue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsActorTypeValue> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsActorTypeValue>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsActorTypeValue.UserActor, 0, "user_actor")]
    [InlineData(BetaAnalyticsActorTypeValue.ServiceAccountActor, 1, "service_account_actor")]
    [InlineData(BetaAnalyticsActorTypeValue.FederatedActor, 2, "federated_actor")]
    [InlineData(BetaAnalyticsActorTypeValue.ApiActor, 3, "api_actor")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsActorTypeValue rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsActorTypeValue> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsActorTypeValue>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsActorTypeValue>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsActorTypeValue>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
