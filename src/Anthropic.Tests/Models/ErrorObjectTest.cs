using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ErrorObjectTest : TestBase
{
    [Fact]
    public void invalid_request_errorValidation_Works()
    {
        ErrorObject value = new(new InvalidRequestError("message"));
        value.Validate();
    }

    [Fact]
    public void authentication_errorValidation_Works()
    {
        ErrorObject value = new(new AuthenticationError("message"));
        value.Validate();
    }

    [Fact]
    public void billing_errorValidation_Works()
    {
        ErrorObject value = new(new BillingError("message"));
        value.Validate();
    }

    [Fact]
    public void permission_errorValidation_Works()
    {
        ErrorObject value = new(new PermissionError("message"));
        value.Validate();
    }

    [Fact]
    public void not_found_errorValidation_Works()
    {
        ErrorObject value = new(new NotFoundError("message"));
        value.Validate();
    }

    [Fact]
    public void rate_limit_errorValidation_Works()
    {
        ErrorObject value = new(new RateLimitError("message"));
        value.Validate();
    }

    [Fact]
    public void gateway_timeout_errorValidation_Works()
    {
        ErrorObject value = new(new GatewayTimeoutError("message"));
        value.Validate();
    }

    [Fact]
    public void apiValidation_Works()
    {
        ErrorObject value = new(new APIErrorObject("message"));
        value.Validate();
    }

    [Fact]
    public void overloaded_errorValidation_Works()
    {
        ErrorObject value = new(new OverloadedError("message"));
        value.Validate();
    }

    [Fact]
    public void invalid_request_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new InvalidRequestError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void authentication_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new AuthenticationError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void billing_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new BillingError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void permission_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new PermissionError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void not_found_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new NotFoundError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void rate_limit_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new RateLimitError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void gateway_timeout_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new GatewayTimeoutError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void apiSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new APIErrorObject("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void overloaded_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new OverloadedError("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }
}
