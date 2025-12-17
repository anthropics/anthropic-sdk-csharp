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
    public void APIValidationWorks()
    {
        BetaError value = new(new BetaAPIError("message"));
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaAuthenticationError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaBillingError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaPermissionError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaNotFoundError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaRateLimitError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaGatewayTimeoutError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void APISerializationRoundtripWorks()
    {
        BetaError value = new(new BetaAPIError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedSerializationRoundtripWorks()
    {
        BetaError value = new(new BetaOverloadedError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }
}
