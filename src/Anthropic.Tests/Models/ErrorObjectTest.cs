using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ErrorObjectTest : TestBase
{
    [Fact]
    public void InvalidRequestErrorValidationWorks()
    {
        ErrorObject value = new(new InvalidRequestError("message"));
        value.Validate();
    }

    [Fact]
    public void AuthenticationErrorValidationWorks()
    {
        ErrorObject value = new(new AuthenticationError("message"));
        value.Validate();
    }

    [Fact]
    public void BillingErrorValidationWorks()
    {
        ErrorObject value = new(new BillingError("message"));
        value.Validate();
    }

    [Fact]
    public void PermissionErrorValidationWorks()
    {
        ErrorObject value = new(new PermissionError("message"));
        value.Validate();
    }

    [Fact]
    public void NotFoundErrorValidationWorks()
    {
        ErrorObject value = new(new NotFoundError("message"));
        value.Validate();
    }

    [Fact]
    public void RateLimitErrorValidationWorks()
    {
        ErrorObject value = new(new RateLimitError("message"));
        value.Validate();
    }

    [Fact]
    public void GatewayTimeoutErrorValidationWorks()
    {
        ErrorObject value = new(new GatewayTimeoutError("message"));
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        ErrorObject value = new(new ApiErrorObject("message"));
        value.Validate();
    }

    [Fact]
    public void OverloadedErrorValidationWorks()
    {
        ErrorObject value = new(new OverloadedError("message"));
        value.Validate();
    }

    [Fact]
    public void InvalidRequestErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new(new InvalidRequestError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new(new AuthenticationError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new(new BillingError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new(new PermissionError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new(new NotFoundError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new(new RateLimitError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new(new GatewayTimeoutError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        ErrorObject value = new(new ApiErrorObject("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new(new OverloadedError("message"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }
}
