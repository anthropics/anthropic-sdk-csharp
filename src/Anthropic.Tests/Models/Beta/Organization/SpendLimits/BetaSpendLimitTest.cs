using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class BetaSpendLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = BetaSpendLimitPeriod.Daily,
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedAmount = "50000";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "USD";
        bool expectedIsEnabled = true;
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Daily;
        BetaSpendLimitScope expectedScope = new BetaSpendLimitUserScope(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
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
        var model = new BetaSpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = BetaSpendLimitPeriod.Daily,
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = BetaSpendLimitPeriod.Daily,
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "50000";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "USD";
        bool expectedIsEnabled = true;
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Daily;
        BetaSpendLimitScope expectedScope = new BetaSpendLimitUserScope(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
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
        var model = new BetaSpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = BetaSpendLimitPeriod.Daily,
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSpendLimit
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = BetaSpendLimitPeriod.Daily,
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaSpendLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaSpendLimitScopeTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserValidationWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitSeatTierValidationWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitSeatTierScope("seat_tier");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitRbacGroupValidationWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitRbacGroupScope("rbac_group_id");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitOrganizationServiceValidationWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitOrganizationServiceScope("service");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitOrganizationValidationWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitWorkspaceValidationWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserSerializationRoundtripWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitSeatTierSerializationRoundtripWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitSeatTierScope("seat_tier");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitRbacGroupSerializationRoundtripWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitRbacGroupScope("rbac_group_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitOrganizationServiceSerializationRoundtripWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitOrganizationServiceScope("service");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitOrganizationSerializationRoundtripWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitWorkspaceSerializationRoundtripWorks()
    {
        BetaSpendLimitScope value = new BetaSpendLimitWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaSpendLimitScope value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("user");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaSpendLimitScope emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
