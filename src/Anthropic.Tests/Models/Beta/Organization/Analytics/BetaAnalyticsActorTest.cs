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
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
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
        BetaAnalyticsActor value = new BetaAnalyticsApiActor("apikey_01Rj2N8SVvo6BePZj99NhmiT");
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
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
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
        BetaAnalyticsActor value = new BetaAnalyticsApiActor("apikey_01Rj2N8SVvo6BePZj99NhmiT");
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
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
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
        BetaAnalyticsActor value = new BetaAnalyticsApiActor("apikey_01Rj2N8SVvo6BePZj99NhmiT");
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
    [InlineData(BetaAnalyticsActorTypeValue.UserActor)]
    [InlineData(BetaAnalyticsActorTypeValue.ServiceAccountActor)]
    [InlineData(BetaAnalyticsActorTypeValue.FederatedActor)]
    [InlineData(BetaAnalyticsActorTypeValue.ApiActor)]
    public void SerializationRoundtrip_Works(BetaAnalyticsActorTypeValue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsActorTypeValue> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsActorTypeValue>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
