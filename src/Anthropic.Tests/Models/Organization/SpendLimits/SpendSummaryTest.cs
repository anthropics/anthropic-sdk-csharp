using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Organization.SpendLimits;

public class SpendSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpendSummary
        {
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            SpendLimitID = "spend_limit_id",
        };

        Actor expectedActor = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        string expectedAmount = "50000";
        string expectedCurrency = "USD";
        ApiEnum<string, SpendLimitPeriod> expectedPeriod = SpendLimitPeriod.Daily;
        string expectedPeriodToDateSpend = "12050.5";
        SpendSummaryScope expectedScope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        Source expectedSource = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
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
        var model = new SpendSummary
        {
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            SpendLimitID = "spend_limit_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpendSummary
        {
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            SpendLimitID = "spend_limit_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Actor expectedActor = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        string expectedAmount = "50000";
        string expectedCurrency = "USD";
        ApiEnum<string, SpendLimitPeriod> expectedPeriod = SpendLimitPeriod.Daily;
        string expectedPeriodToDateSpend = "12050.5";
        SpendSummaryScope expectedScope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        Source expectedSource = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
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
        var model = new SpendSummary
        {
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            SpendLimitID = "spend_limit_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SpendSummary
        {
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            SpendLimitID = "spend_limit_id",
        };

        SpendSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActorTest : TestBase
{
    [Fact]
    public void SpendLimitUserValidationWorks()
    {
        Actor value = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        value.Validate();
    }

    [Fact]
    public void SpendLimitScopedApiKeyValidationWorks()
    {
        Actor value = new SpendLimitScopedApiKeyActor("scoped_api_key_id");
        value.Validate();
    }

    [Fact]
    public void SpendLimitUserSerializationRoundtripWorks()
    {
        Actor value = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Actor>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitScopedApiKeySerializationRoundtripWorks()
    {
        Actor value = new SpendLimitScopedApiKeyActor("scoped_api_key_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Actor>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitUserTypeWorks()
    {
        Actor value = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        Assert.Equal(ActorType.UserActor, value.Type.Value());
    }

    [Fact]
    public void SpendLimitScopedApiKeyTypeWorks()
    {
        Actor value = new SpendLimitScopedApiKeyActor("scoped_api_key_id");
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

public class SpendSummaryScopeTest : TestBase
{
    [Fact]
    public void SpendLimitUserValidationWorks()
    {
        SpendSummaryScope value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        value.Validate();
    }

    [Fact]
    public void SpendLimitSeatTierValidationWorks()
    {
        SpendSummaryScope value = new SpendLimitSeatTierScope("seat_tier");
        value.Validate();
    }

    [Fact]
    public void SpendLimitRbacGroupValidationWorks()
    {
        SpendSummaryScope value = new SpendLimitRbacGroupScope("rbac_group_id");
        value.Validate();
    }

    [Fact]
    public void SpendLimitOrganizationServiceValidationWorks()
    {
        SpendSummaryScope value = new SpendLimitOrganizationServiceScope("service");
        value.Validate();
    }

    [Fact]
    public void SpendLimitOrganizationValidationWorks()
    {
        SpendSummaryScope value = new SpendLimitOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void SpendLimitWorkspaceValidationWorks()
    {
        SpendSummaryScope value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        value.Validate();
    }

    [Fact]
    public void SpendLimitUsageTierValidationWorks()
    {
        SpendSummaryScope value = new SpendLimitUsageTierScope();
        value.Validate();
    }

    [Fact]
    public void SpendLimitUserSerializationRoundtripWorks()
    {
        SpendSummaryScope value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitSeatTierSerializationRoundtripWorks()
    {
        SpendSummaryScope value = new SpendLimitSeatTierScope("seat_tier");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitRbacGroupSerializationRoundtripWorks()
    {
        SpendSummaryScope value = new SpendLimitRbacGroupScope("rbac_group_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitOrganizationServiceSerializationRoundtripWorks()
    {
        SpendSummaryScope value = new SpendLimitOrganizationServiceScope("service");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitOrganizationSerializationRoundtripWorks()
    {
        SpendSummaryScope value = new SpendLimitOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitWorkspaceSerializationRoundtripWorks()
    {
        SpendSummaryScope value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitUsageTierSerializationRoundtripWorks()
    {
        SpendSummaryScope value = new SpendLimitUsageTierScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendSummaryScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitUserTypeWorks()
    {
        SpendSummaryScope value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        Assert.Equal(SpendSummaryScopeType.User, value.Type.Value());
    }

    [Fact]
    public void SpendLimitSeatTierTypeWorks()
    {
        SpendSummaryScope value = new SpendLimitSeatTierScope("seat_tier");
        Assert.Equal(SpendSummaryScopeType.SeatTier, value.Type.Value());
    }

    [Fact]
    public void SpendLimitRbacGroupTypeWorks()
    {
        SpendSummaryScope value = new SpendLimitRbacGroupScope("rbac_group_id");
        Assert.Equal(SpendSummaryScopeType.RbacGroup, value.Type.Value());
    }

    [Fact]
    public void SpendLimitOrganizationServiceTypeWorks()
    {
        SpendSummaryScope value = new SpendLimitOrganizationServiceScope("service");
        Assert.Equal(SpendSummaryScopeType.OrganizationService, value.Type.Value());
    }

    [Fact]
    public void SpendLimitOrganizationTypeWorks()
    {
        SpendSummaryScope value = new SpendLimitOrganizationScope();
        Assert.Equal(SpendSummaryScopeType.Organization, value.Type.Value());
    }

    [Fact]
    public void SpendLimitWorkspaceTypeWorks()
    {
        SpendSummaryScope value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        Assert.Equal(SpendSummaryScopeType.Workspace, value.Type.Value());
    }

    [Fact]
    public void SpendLimitUsageTierTypeWorks()
    {
        SpendSummaryScope value = new SpendLimitUsageTierScope();
        Assert.Equal(SpendSummaryScopeType.UsageTier, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        SpendSummaryScope value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, SpendSummaryScopeType> expectedType = SpendSummaryScopeType.User;

        Assert.Equal(expectedType, value.Type);

        SpendSummaryScope emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class SpendSummaryScopeTypeTest : TestBase
{
    [Theory]
    [InlineData(SpendSummaryScopeType.User)]
    [InlineData(SpendSummaryScopeType.SeatTier)]
    [InlineData(SpendSummaryScopeType.RbacGroup)]
    [InlineData(SpendSummaryScopeType.OrganizationService)]
    [InlineData(SpendSummaryScopeType.Organization)]
    [InlineData(SpendSummaryScopeType.Workspace)]
    [InlineData(SpendSummaryScopeType.UsageTier)]
    public void Validation_Works(SpendSummaryScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendSummaryScopeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpendSummaryScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SpendSummaryScopeType.User)]
    [InlineData(SpendSummaryScopeType.SeatTier)]
    [InlineData(SpendSummaryScopeType.RbacGroup)]
    [InlineData(SpendSummaryScopeType.OrganizationService)]
    [InlineData(SpendSummaryScopeType.Organization)]
    [InlineData(SpendSummaryScopeType.Workspace)]
    [InlineData(SpendSummaryScopeType.UsageTier)]
    public void SerializationRoundtrip_Works(SpendSummaryScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendSummaryScopeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SpendSummaryScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpendSummaryScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SpendSummaryScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void SpendLimitUserScopeValidationWorks()
    {
        Source value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        value.Validate();
    }

    [Fact]
    public void SpendLimitSeatTierScopeValidationWorks()
    {
        Source value = new SpendLimitSeatTierScope("seat_tier");
        value.Validate();
    }

    [Fact]
    public void SpendLimitRbacGroupScopeValidationWorks()
    {
        Source value = new SpendLimitRbacGroupScope("rbac_group_id");
        value.Validate();
    }

    [Fact]
    public void SpendLimitOrganizationServiceScopeValidationWorks()
    {
        Source value = new SpendLimitOrganizationServiceScope("service");
        value.Validate();
    }

    [Fact]
    public void SpendLimitOrganizationScopeValidationWorks()
    {
        Source value = new SpendLimitOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void SpendLimitWorkspaceScopeValidationWorks()
    {
        Source value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        value.Validate();
    }

    [Fact]
    public void SpendLimitUsageTierScopeValidationWorks()
    {
        Source value = new SpendLimitUsageTierScope();
        value.Validate();
    }

    [Fact]
    public void SpendLimitUserScopeSerializationRoundtripWorks()
    {
        Source value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitSeatTierScopeSerializationRoundtripWorks()
    {
        Source value = new SpendLimitSeatTierScope("seat_tier");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitRbacGroupScopeSerializationRoundtripWorks()
    {
        Source value = new SpendLimitRbacGroupScope("rbac_group_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitOrganizationServiceScopeSerializationRoundtripWorks()
    {
        Source value = new SpendLimitOrganizationServiceScope("service");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitOrganizationScopeSerializationRoundtripWorks()
    {
        Source value = new SpendLimitOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitWorkspaceScopeSerializationRoundtripWorks()
    {
        Source value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitUsageTierScopeSerializationRoundtripWorks()
    {
        Source value = new SpendLimitUsageTierScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitUserScopeTypeWorks()
    {
        Source value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        Assert.Equal(SourceType.User, value.Type.Value());
    }

    [Fact]
    public void SpendLimitSeatTierScopeTypeWorks()
    {
        Source value = new SpendLimitSeatTierScope("seat_tier");
        Assert.Equal(SourceType.SeatTier, value.Type.Value());
    }

    [Fact]
    public void SpendLimitRbacGroupScopeTypeWorks()
    {
        Source value = new SpendLimitRbacGroupScope("rbac_group_id");
        Assert.Equal(SourceType.RbacGroup, value.Type.Value());
    }

    [Fact]
    public void SpendLimitOrganizationServiceScopeTypeWorks()
    {
        Source value = new SpendLimitOrganizationServiceScope("service");
        Assert.Equal(SourceType.OrganizationService, value.Type.Value());
    }

    [Fact]
    public void SpendLimitOrganizationScopeTypeWorks()
    {
        Source value = new SpendLimitOrganizationScope();
        Assert.Equal(SourceType.Organization, value.Type.Value());
    }

    [Fact]
    public void SpendLimitWorkspaceScopeTypeWorks()
    {
        Source value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        Assert.Equal(SourceType.Workspace, value.Type.Value());
    }

    [Fact]
    public void SpendLimitUsageTierScopeTypeWorks()
    {
        Source value = new SpendLimitUsageTierScope();
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
