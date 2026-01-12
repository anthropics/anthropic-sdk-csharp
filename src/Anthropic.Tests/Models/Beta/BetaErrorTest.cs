using System.Text.Json;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaErrorTest : TestBase
{
    [Fact]
    public void InvalidRequestValidationWorks()
    {
        BetaError value = new(new BetaInvalidRequestError("message"));
        value.Validate();
    }

    [Fact]
    public void AuthenticationValidationWorks()
    {
        BetaError value = new(new BetaAuthenticationError("message"));
        value.Validate();
    }

    [Fact]
    public void BillingValidationWorks()
    {
        BetaError value = new(new BetaBillingError("message"));
        value.Validate();
    }

    [Fact]
    public void PermissionValidationWorks()
    {
        BetaError value = new(new BetaPermissionError("message"));
        value.Validate();
    }

    [Fact]
    public void NotFoundValidationWorks()
    {
        BetaError value = new(new BetaNotFoundError("message"));
        value.Validate();
    }

    [Fact]
    public void RateLimitValidationWorks()
    {
        BetaError value = new(new BetaRateLimitError("message"));
        value.Validate();
    }

    [Fact]
    public void GatewayTimeoutValidationWorks()
    {
        BetaError value = new(new BetaGatewayTimeoutError("message"));
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaError value = new(new BetaApiError("message"));
        value.Validate();
    }

    [Fact]
    public void OverloadedValidationWorks()
    {
        BetaError value = new(new BetaOverloadedError("message"));
        value.Validate();
    }

    [Fact]
    public void InvalidRequestSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaInvalidRequestError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaAuthenticationError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaBillingError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaPermissionError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaNotFoundError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaRateLimitError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaGatewayTimeoutError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaApiError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaOverloadedError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(element);

        Assert.Equal(value, deserialized);
    }
}
