using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class SpendLimitSetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SpendLimitSetParams
        {
            Amount = "50000",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Period = BetaSpendLimitPeriod.Monthly,
        };

        string expectedAmount = "50000";
        Scope expectedScope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Monthly;

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedScope, parameters.Scope);
        Assert.Equal(expectedPeriod, parameters.Period);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SpendLimitSetParams
        {
            Amount = "50000",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
        };

        Assert.Null(parameters.Period);
        Assert.False(parameters.RawBodyData.ContainsKey("period"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SpendLimitSetParams
        {
            Amount = "50000",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),

            // Null should be interpreted as omitted for these properties
            Period = null,
        };

        Assert.Null(parameters.Period);
        Assert.False(parameters.RawBodyData.ContainsKey("period"));
    }

    [Fact]
    public void Url_Works()
    {
        SpendLimitSetParams parameters = new()
        {
            Amount = "50000",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/spend_limits?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SpendLimitSetParams
        {
            Amount = "50000",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Period = BetaSpendLimitPeriod.Monthly,
        };

        SpendLimitSetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ScopeTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserValidationWorks()
    {
        Scope value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitOrganizationValidationWorks()
    {
        Scope value = new BetaSpendLimitOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitWorkspaceValidationWorks()
    {
        Scope value = new BetaSpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserSerializationRoundtripWorks()
    {
        Scope value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitOrganizationSerializationRoundtripWorks()
    {
        Scope value = new BetaSpendLimitOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitWorkspaceSerializationRoundtripWorks()
    {
        Scope value = new BetaSpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scope>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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

        JsonElement expectedType = JsonSerializer.SerializeToElement("user");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        Scope emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
