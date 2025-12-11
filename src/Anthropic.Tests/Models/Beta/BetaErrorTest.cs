using System.Text.Json;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaErrorTest : TestBase
{
    [Fact]
    public void invalid_requestValidation_Works()
    {
        BetaError value = new(new BetaInvalidRequestError("message"));
        value.Validate();
    }

    [Fact]
    public void authenticationValidation_Works()
    {
        BetaError value = new(new BetaAuthenticationError("message"));
        value.Validate();
    }

    [Fact]
    public void billingValidation_Works()
    {
        BetaError value = new(new BetaBillingError("message"));
        value.Validate();
    }

    [Fact]
    public void permissionValidation_Works()
    {
        BetaError value = new(new BetaPermissionError("message"));
        value.Validate();
    }

    [Fact]
    public void not_foundValidation_Works()
    {
        BetaError value = new(new BetaNotFoundError("message"));
        value.Validate();
    }

    [Fact]
    public void rate_limitValidation_Works()
    {
        BetaError value = new(new BetaRateLimitError("message"));
        value.Validate();
    }

    [Fact]
    public void gateway_timeoutValidation_Works()
    {
        BetaError value = new(new BetaGatewayTimeoutError("message"));
        value.Validate();
    }

    [Fact]
    public void apiValidation_Works()
    {
        BetaError value = new(new BetaAPIError("message"));
        value.Validate();
    }

    [Fact]
    public void overloadedValidation_Works()
    {
        BetaError value = new(new BetaOverloadedError("message"));
        value.Validate();
    }

    [Fact]
    public void invalid_requestSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaInvalidRequestError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void authenticationSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaAuthenticationError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void billingSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaBillingError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void permissionSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaPermissionError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void not_foundSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaNotFoundError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void rate_limitSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaRateLimitError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void gateway_timeoutSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaGatewayTimeoutError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void apiSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaAPIError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void overloadedSerializationRoundtrip_Works()
    {
        BetaError value = new(new BetaOverloadedError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaError>(json);

        Assert.Equal(value, deserialized);
    }
}
