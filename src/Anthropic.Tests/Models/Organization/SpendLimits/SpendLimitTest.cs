using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Organization.SpendLimits;

public class SpendLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = SpendLimitPeriod.Daily,
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedAmount = "50000";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "USD";
        bool expectedIsEnabled = true;
        ApiEnum<string, SpendLimitPeriod> expectedPeriod = SpendLimitPeriod.Daily;
        Scope expectedScope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        JsonElement expectedType = JsonSerializer.SerializeToElement("spend_limit");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedIsEnabled, model.IsEnabled);
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedScope, model.Scope);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = SpendLimitPeriod.Daily,
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = SpendLimitPeriod.Daily,
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "50000";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "USD";
        bool expectedIsEnabled = true;
        ApiEnum<string, SpendLimitPeriod> expectedPeriod = SpendLimitPeriod.Daily;
        Scope expectedScope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        JsonElement expectedType = JsonSerializer.SerializeToElement("spend_limit");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedIsEnabled, deserialized.IsEnabled);
        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = SpendLimitPeriod.Daily,
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = SpendLimitPeriod.Daily,
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SpendLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScopeTest : TestBase
{
    [Fact]
    public void SpendLimitUserValidationWorks()
    {
        Scope value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        value.Validate();
    }

    [Fact]
    public void SpendLimitSeatTierValidationWorks()
    {
        Scope value = new SpendLimitSeatTierScope("seat_tier");
        value.Validate();
    }

    [Fact]
    public void SpendLimitRbacGroupValidationWorks()
    {
        Scope value = new SpendLimitRbacGroupScope("rbac_group_id");
        value.Validate();
    }

    [Fact]
    public void SpendLimitOrganizationServiceValidationWorks()
    {
        Scope value = new SpendLimitOrganizationServiceScope("service");
        value.Validate();
    }

    [Fact]
    public void SpendLimitOrganizationValidationWorks()
    {
        Scope value = new SpendLimitOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void SpendLimitWorkspaceValidationWorks()
    {
        Scope value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        value.Validate();
    }

    [Fact]
    public void SpendLimitUsageTierValidationWorks()
    {
        Scope value = new SpendLimitUsageTierScope();
        value.Validate();
    }

    [Fact]
    public void SpendLimitUserSerializationRoundtripWorks()
    {
        Scope value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitSeatTierSerializationRoundtripWorks()
    {
        Scope value = new SpendLimitSeatTierScope("seat_tier");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitRbacGroupSerializationRoundtripWorks()
    {
        Scope value = new SpendLimitRbacGroupScope("rbac_group_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitOrganizationServiceSerializationRoundtripWorks()
    {
        Scope value = new SpendLimitOrganizationServiceScope("service");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitOrganizationSerializationRoundtripWorks()
    {
        Scope value = new SpendLimitOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitWorkspaceSerializationRoundtripWorks()
    {
        Scope value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitUsageTierSerializationRoundtripWorks()
    {
        Scope value = new SpendLimitUsageTierScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpendLimitUserTypeWorks()
    {
        Scope value = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu");
        Assert.Equal(ScopeType.User, value.Type.Value());
    }

    [Fact]
    public void SpendLimitSeatTierTypeWorks()
    {
        Scope value = new SpendLimitSeatTierScope("seat_tier");
        Assert.Equal(ScopeType.SeatTier, value.Type.Value());
    }

    [Fact]
    public void SpendLimitRbacGroupTypeWorks()
    {
        Scope value = new SpendLimitRbacGroupScope("rbac_group_id");
        Assert.Equal(ScopeType.RbacGroup, value.Type.Value());
    }

    [Fact]
    public void SpendLimitOrganizationServiceTypeWorks()
    {
        Scope value = new SpendLimitOrganizationServiceScope("service");
        Assert.Equal(ScopeType.OrganizationService, value.Type.Value());
    }

    [Fact]
    public void SpendLimitOrganizationTypeWorks()
    {
        Scope value = new SpendLimitOrganizationScope();
        Assert.Equal(ScopeType.Organization, value.Type.Value());
    }

    [Fact]
    public void SpendLimitWorkspaceTypeWorks()
    {
        Scope value = new SpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        Assert.Equal(ScopeType.Workspace, value.Type.Value());
    }

    [Fact]
    public void SpendLimitUsageTierTypeWorks()
    {
        Scope value = new SpendLimitUsageTierScope();
        Assert.Equal(ScopeType.UsageTier, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Scope value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ScopeType> expectedType = ScopeType.User;

        Assert.Equal(expectedType, value.Type);

        Scope emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ScopeTypeTest : TestBase
{
    [Theory]
    [InlineData(ScopeType.User)]
    [InlineData(ScopeType.SeatTier)]
    [InlineData(ScopeType.RbacGroup)]
    [InlineData(ScopeType.OrganizationService)]
    [InlineData(ScopeType.Organization)]
    [InlineData(ScopeType.Workspace)]
    [InlineData(ScopeType.UsageTier)]
    public void Validation_Works(ScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScopeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScopeType.User)]
    [InlineData(ScopeType.SeatTier)]
    [InlineData(ScopeType.RbacGroup)]
    [InlineData(ScopeType.OrganizationService)]
    [InlineData(ScopeType.Organization)]
    [InlineData(ScopeType.Workspace)]
    [InlineData(ScopeType.UsageTier)]
    public void SerializationRoundtrip_Works(ScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScopeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
