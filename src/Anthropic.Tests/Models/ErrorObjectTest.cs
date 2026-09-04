using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new AuthenticationError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new BillingError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new PermissionError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new NotFoundError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new RateLimitError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new GatewayTimeoutError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        ErrorObject value = new ApiErrorObject("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedErrorSerializationRoundtripWorks()
    {
        ErrorObject value = new OverloadedError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorObject>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ErrorObject value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "message": "message",
                  "type": "invalid_request_error"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.SerializeToElement("invalid_request_error");

        Assert.Equal(expectedMessage, value.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ErrorObject emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Message);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        ErrorObject mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "message": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Message);
    }
}
