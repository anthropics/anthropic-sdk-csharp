using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedAmount = "50000";
        Scope expectedScope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Monthly;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedScope, parameters.Scope);
        Assert.Equal(expectedPeriod, parameters.Period);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
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
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
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
            Betas = null,
        };

        Assert.Null(parameters.Period);
        Assert.False(parameters.RawBodyData.ContainsKey("period"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new SpendLimitSetParams
        {
            Amount = "50000",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Period = BetaSpendLimitPeriod.Monthly,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Period = null,
            Betas = null,
        };

        Assert.Null(parameters.Period);
        Assert.False(parameters.RawBodyData.ContainsKey("period"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
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
                new Uri("https://api.anthropic.com/v1/organizations/spend_limits"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SpendLimitSetParams parameters = new()
        {
            Amount = "50000",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
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
    public void BetaSpendLimitUserTypeWorks()
    {
        Scope value = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q");
        Assert.Equal(ScopeTypeValue.User, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitOrganizationTypeWorks()
    {
        Scope value = new BetaSpendLimitOrganizationScope();
        Assert.Equal(ScopeTypeValue.Organization, value.Type.Value());
    }

    [Fact]
    public void BetaSpendLimitWorkspaceTypeWorks()
    {
        Scope value = new BetaSpendLimitWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        Assert.Equal(ScopeTypeValue.Workspace, value.Type.Value());
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

        ApiEnum<string, ScopeTypeValue> expectedType = ScopeTypeValue.User;

        Assert.Equal(expectedType, value.Type);

        Scope emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ScopeTypeValueTest : TestBase
{
    [Theory]
    [InlineData(ScopeTypeValue.User)]
    [InlineData(ScopeTypeValue.Organization)]
    [InlineData(ScopeTypeValue.Workspace)]
    public void Validation_Works(ScopeTypeValue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScopeTypeValue> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScopeTypeValue>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScopeTypeValue.User)]
    [InlineData(ScopeTypeValue.Organization)]
    [InlineData(ScopeTypeValue.Workspace)]
    public void SerializationRoundtrip_Works(ScopeTypeValue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScopeTypeValue> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScopeTypeValue>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScopeTypeValue>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScopeTypeValue>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
