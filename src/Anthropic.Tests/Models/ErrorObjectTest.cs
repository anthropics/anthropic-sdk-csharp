using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ErrorObjectTest : TestBase
{
    [Fact]
    public void invalid_request_errorValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void authentication_errorValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void billing_errorValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void permission_errorValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void not_found_errorValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void rate_limit_errorValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void gateway_timeout_errorValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void apiValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void overloaded_errorValidation_Works()
    {
        ErrorObject value = new(new("message"));
        value.Validate();
    }

    [Fact]
    public void invalid_request_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void authentication_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void billing_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void permission_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void not_found_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void rate_limit_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void gateway_timeout_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void apiSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void overloaded_errorSerializationRoundtrip_Works()
    {
        ErrorObject value = new(new("message"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(json);

        Assert.Equal(value, deserialized);
    }
}
