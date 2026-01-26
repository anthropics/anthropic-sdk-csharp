using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaErrorTest : TestBase
{
    [Fact]
    public void InvalidRequestValidationWorks()
    {
        BetaError value = new BetaInvalidRequestError("message");
        value.Validate();
    }

    [Fact]
    public void AuthenticationValidationWorks()
    {
        BetaError value = new BetaAuthenticationError("message");
        value.Validate();
    }

    [Fact]
    public void BillingValidationWorks()
    {
        BetaError value = new BetaBillingError("message");
        value.Validate();
    }

    [Fact]
    public void PermissionValidationWorks()
    {
        BetaError value = new BetaPermissionError("message");
        value.Validate();
    }

    [Fact]
    public void NotFoundValidationWorks()
    {
        BetaError value = new BetaNotFoundError("message");
        value.Validate();
    }

    [Fact]
    public void RateLimitValidationWorks()
    {
        BetaError value = new BetaRateLimitError("message");
        value.Validate();
    }

    [Fact]
    public void GatewayTimeoutValidationWorks()
    {
        BetaError value = new BetaGatewayTimeoutError("message");
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaError value = new BetaApiError("message");
        value.Validate();
    }

    [Fact]
    public void OverloadedValidationWorks()
    {
        BetaError value = new BetaOverloadedError("message");
        value.Validate();
    }

    [Fact]
    public void InvalidRequestSerializationRoundtripWorks()
    {
        BetaError value = new BetaInvalidRequestError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationSerializationRoundtripWorks()
    {
        BetaError value = new BetaAuthenticationError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingSerializationRoundtripWorks()
    {
        BetaError value = new BetaBillingError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionSerializationRoundtripWorks()
    {
        BetaError value = new BetaPermissionError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundSerializationRoundtripWorks()
    {
        BetaError value = new BetaNotFoundError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitSerializationRoundtripWorks()
    {
        BetaError value = new BetaRateLimitError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutSerializationRoundtripWorks()
    {
        BetaError value = new BetaGatewayTimeoutError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        BetaError value = new BetaApiError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedSerializationRoundtripWorks()
    {
        BetaError value = new BetaOverloadedError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
