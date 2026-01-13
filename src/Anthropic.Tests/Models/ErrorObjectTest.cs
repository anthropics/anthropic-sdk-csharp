using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ErrorObjectTest : TestBase
{
    [Fact]
    public void InvalidRequestErrorValidationWorks()
    {
        ErrorObject value = new InvalidRequestError("message");
        value.Validate();
    }

    [Fact]
    public void AuthenticationErrorValidationWorks()
    {
        ErrorObject value = new AuthenticationError("message");
        value.Validate();
    }

    [Fact]
    public void BillingErrorValidationWorks()
    {
        ErrorObject value = new BillingError("message");
        value.Validate();
    }

    [Fact]
    public void PermissionErrorValidationWorks()
    {
        ErrorObject value = new PermissionError("message");
        value.Validate();
    }

    [Fact]
    public void NotFoundErrorValidationWorks()
    {
        ErrorObject value = new NotFoundError("message");
        value.Validate();
    }

    [Fact]
    public void RateLimitErrorValidationWorks()
    {
        ErrorObject value = new RateLimitError("message");
        value.Validate();
    }

    [Fact]
    public void GatewayTimeoutErrorValidationWorks()
    {
        ErrorObject value = new GatewayTimeoutError("message");
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        ErrorObject value = new ApiErrorObject("message");
        value.Validate();
    }

    [Fact]
    public void OverloadedErrorValidationWorks()
    {
        ErrorObject value = new OverloadedError("message");
        value.Validate();
    }

    [Fact]
    public void InvalidRequestErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new InvalidRequestError("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new AuthenticationError("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new BillingError("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new PermissionError("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new NotFoundError("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new RateLimitError("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new GatewayTimeoutError("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        ErrorObject value = new ApiErrorObject("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new OverloadedError("message");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(element);

        Assert.Equal(value, deserialized);
    }
}
