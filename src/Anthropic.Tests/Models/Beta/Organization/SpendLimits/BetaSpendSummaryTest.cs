using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class BetaSpendSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendSummary
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            SpendLimitID = "spend_limit_id",
        };

        Actor expectedActor = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string expectedAmount = "50000";
        string expectedCurrency = "USD";
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Daily;
        string expectedPeriodToDateSpend = "12050.5";
        BetaSpendSummaryScope expectedScope = new BetaSpendLimitUserScope(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        Source expectedSource = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string expectedSpendLimitID = "spend_limit_id";

        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedPeriodToDateSpend, model.PeriodToDateSpend);
        Assert.Equal(expectedScope, model.Scope);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedSpendLimitID, model.SpendLimitID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSpendSummary
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            SpendLimitID = "spend_limit_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSpendSummary
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            SpendLimitID = "spend_limit_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Actor expectedActor = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string expectedAmount = "50000";
        string expectedCurrency = "USD";
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Daily;
        string expectedPeriodToDateSpend = "12050.5";
        BetaSpendSummaryScope expectedScope = new BetaSpendLimitUserScope(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        Source expectedSource = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string expectedSpendLimitID = "spend_limit_id";

        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedPeriodToDateSpend, deserialized.PeriodToDateSpend);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedSpendLimitID, deserialized.SpendLimitID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSpendSummary
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            SpendLimitID = "spend_limit_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSpendSummary
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            SpendLimitID = "spend_limit_id",
        };

        BetaSpendSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActorTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserValidationWorks()
    {
        Actor value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeyValidationWorks()
    {
        Actor value = new BetaSpendLimitScopedApiKeyActor("scoped_api_key_id");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserSerializationRoundtripWorks()
    {
        Actor value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Actor>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeySerializationRoundtripWorks()
    {
        Actor value = new BetaSpendLimitScopedApiKeyActor("scoped_api_key_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Actor>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitUserTypeWorks()
    {
        Actor value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        Assert.Equal(ActorType.UserActor, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeyTypeWorks()
    {
        Actor value = new BetaSpendLimitScopedApiKeyActor("scoped_api_key_id");
        Assert.Equal(ActorType.ScopedApiKeyActor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Actor value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ActorType> expectedType = ActorType.UserActor;

        Assert.Equal(expectedType, value.Type);

        Actor emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ActorTypeTest : TestBase
{
    [Theory]
    [InlineData(ActorType.UserActor)]
    [InlineData(ActorType.ScopedApiKeyActor)]
    public void Validation_Works(ActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ActorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ActorType.UserActor)]
    [InlineData(ActorType.ScopedApiKeyActor)]
    public void SerializationRoundtrip_Works(ActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ActorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ActorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ActorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaSpendSummaryScopeTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserValidationWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitSeatTierValidationWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitSeatTierScope("seat_tier");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitRbacGroupValidationWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitRbacGroupScope("rbac_group_id");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitOrganizationServiceValidationWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitOrganizationServiceScope("service");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitOrganizationValidationWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitWorkspaceValidationWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUsageTierValidationWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitUsageTierScope();
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserSerializationRoundtripWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitSeatTierSerializationRoundtripWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitSeatTierScope("seat_tier");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitRbacGroupSerializationRoundtripWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitRbacGroupScope("rbac_group_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitOrganizationServiceSerializationRoundtripWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitOrganizationServiceScope("service");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitOrganizationSerializationRoundtripWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitWorkspaceSerializationRoundtripWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitUsageTierSerializationRoundtripWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitUsageTierScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitUserTypeWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        Assert.Equal(BetaSpendSummaryScopeType.User, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitSeatTierTypeWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitSeatTierScope("seat_tier");
        Assert.Equal(BetaSpendSummaryScopeType.SeatTier, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitRbacGroupTypeWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitRbacGroupScope("rbac_group_id");
        Assert.Equal(BetaSpendSummaryScopeType.RbacGroup, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitOrganizationServiceTypeWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitOrganizationServiceScope("service");
        Assert.Equal(BetaSpendSummaryScopeType.OrganizationService, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitOrganizationTypeWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitOrganizationScope();
        Assert.Equal(BetaSpendSummaryScopeType.Organization, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitWorkspaceTypeWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        Assert.Equal(BetaSpendSummaryScopeType.Workspace, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitUsageTierTypeWorks()
    {
        BetaSpendSummaryScope value = new BetaSpendLimitUsageTierScope();
        Assert.Equal(BetaSpendSummaryScopeType.UsageTier, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaSpendSummaryScope value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaSpendSummaryScopeType> expectedType = BetaSpendSummaryScopeType.User;

        Assert.Equal(expectedType, value.Type);

        BetaSpendSummaryScope emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaSpendSummaryScopeTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaSpendSummaryScopeType.User)]
    [InlineData(BetaSpendSummaryScopeType.SeatTier)]
    [InlineData(BetaSpendSummaryScopeType.RbacGroup)]
    [InlineData(BetaSpendSummaryScopeType.OrganizationService)]
    [InlineData(BetaSpendSummaryScopeType.Organization)]
    [InlineData(BetaSpendSummaryScopeType.Workspace)]
    [InlineData(BetaSpendSummaryScopeType.UsageTier)]
    public void Validation_Works(BetaSpendSummaryScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendSummaryScopeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaSpendSummaryScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaSpendSummaryScopeType.User)]
    [InlineData(BetaSpendSummaryScopeType.SeatTier)]
    [InlineData(BetaSpendSummaryScopeType.RbacGroup)]
    [InlineData(BetaSpendSummaryScopeType.OrganizationService)]
    [InlineData(BetaSpendSummaryScopeType.Organization)]
    [InlineData(BetaSpendSummaryScopeType.Workspace)]
    [InlineData(BetaSpendSummaryScopeType.UsageTier)]
    public void SerializationRoundtrip_Works(BetaSpendSummaryScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendSummaryScopeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaSpendSummaryScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaSpendSummaryScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaSpendSummaryScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserScopeValidationWorks()
    {
        Source value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitSeatTierScopeValidationWorks()
    {
        Source value = new BetaSpendLimitSeatTierScope("seat_tier");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitRbacGroupScopeValidationWorks()
    {
        Source value = new BetaSpendLimitRbacGroupScope("rbac_group_id");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitOrganizationServiceScopeValidationWorks()
    {
        Source value = new BetaSpendLimitOrganizationServiceScope("service");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitOrganizationScopeValidationWorks()
    {
        Source value = new BetaSpendLimitOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitWorkspaceScopeValidationWorks()
    {
        Source value = new BetaSpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUsageTierScopeValidationWorks()
    {
        Source value = new BetaSpendLimitUsageTierScope();
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserScopeSerializationRoundtripWorks()
    {
        Source value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitSeatTierScopeSerializationRoundtripWorks()
    {
        Source value = new BetaSpendLimitSeatTierScope("seat_tier");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitRbacGroupScopeSerializationRoundtripWorks()
    {
        Source value = new BetaSpendLimitRbacGroupScope("rbac_group_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitOrganizationServiceScopeSerializationRoundtripWorks()
    {
        Source value = new BetaSpendLimitOrganizationServiceScope("service");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitOrganizationScopeSerializationRoundtripWorks()
    {
        Source value = new BetaSpendLimitOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitWorkspaceScopeSerializationRoundtripWorks()
    {
        Source value = new BetaSpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitUsageTierScopeSerializationRoundtripWorks()
    {
        Source value = new BetaSpendLimitUsageTierScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitUserScopeTypeWorks()
    {
        Source value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        Assert.Equal(SourceType.User, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitSeatTierScopeTypeWorks()
    {
        Source value = new BetaSpendLimitSeatTierScope("seat_tier");
        Assert.Equal(SourceType.SeatTier, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitRbacGroupScopeTypeWorks()
    {
        Source value = new BetaSpendLimitRbacGroupScope("rbac_group_id");
        Assert.Equal(SourceType.RbacGroup, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitOrganizationServiceScopeTypeWorks()
    {
        Source value = new BetaSpendLimitOrganizationServiceScope("service");
        Assert.Equal(SourceType.OrganizationService, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitOrganizationScopeTypeWorks()
    {
        Source value = new BetaSpendLimitOrganizationScope();
        Assert.Equal(SourceType.Organization, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitWorkspaceScopeTypeWorks()
    {
        Source value = new BetaSpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        Assert.Equal(SourceType.Workspace, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitUsageTierScopeTypeWorks()
    {
        Source value = new BetaSpendLimitUsageTierScope();
        Assert.Equal(SourceType.UsageTier, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Source value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, SourceType> expectedType = SourceType.User;

        Assert.Equal(expectedType, value.Type);

        Source emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class SourceTypeTest : TestBase
{
    [Theory]
    [InlineData(SourceType.User)]
    [InlineData(SourceType.SeatTier)]
    [InlineData(SourceType.RbacGroup)]
    [InlineData(SourceType.OrganizationService)]
    [InlineData(SourceType.Organization)]
    [InlineData(SourceType.Workspace)]
    [InlineData(SourceType.UsageTier)]
    public void Validation_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SourceType.User)]
    [InlineData(SourceType.SeatTier)]
    [InlineData(SourceType.RbacGroup)]
    [InlineData(SourceType.OrganizationService)]
    [InlineData(SourceType.Organization)]
    [InlineData(SourceType.Workspace)]
    [InlineData(SourceType.UsageTier)]
    public void SerializationRoundtrip_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
