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
    public void InvalidRequestErrorTypeWorks()
    {
        ErrorObject value = new InvalidRequestError("message");
        Assert.Equal(ErrorObjectType.InvalidRequestError, value.Type.Value());
    }

    [Fact]
    public void AuthenticationErrorTypeWorks()
    {
        ErrorObject value = new AuthenticationError("message");
        Assert.Equal(ErrorObjectType.AuthenticationError, value.Type.Value());
    }

    [Fact]
    public void BillingErrorTypeWorks()
    {
        ErrorObject value = new BillingError("message");
        Assert.Equal(ErrorObjectType.BillingError, value.Type.Value());
    }

    [Fact]
    public void PermissionErrorTypeWorks()
    {
        ErrorObject value = new PermissionError("message");
        Assert.Equal(ErrorObjectType.PermissionError, value.Type.Value());
    }

    [Fact]
    public void NotFoundErrorTypeWorks()
    {
        ErrorObject value = new NotFoundError("message");
        Assert.Equal(ErrorObjectType.NotFoundError, value.Type.Value());
    }

    [Fact]
    public void RateLimitErrorTypeWorks()
    {
        ErrorObject value = new RateLimitError("message");
        Assert.Equal(ErrorObjectType.RateLimitError, value.Type.Value());
    }

    [Fact]
    public void GatewayTimeoutErrorTypeWorks()
    {
        ErrorObject value = new GatewayTimeoutError("message");
        Assert.Equal(ErrorObjectType.TimeoutError, value.Type.Value());
    }

    [Fact]
    public void ApiTypeWorks()
    {
        ErrorObject value = new ApiErrorObject("message");
        Assert.Equal(ErrorObjectType.ApiError, value.Type.Value());
    }

    [Fact]
    public void OverloadedErrorTypeWorks()
    {
        ErrorObject value = new OverloadedError("message");
        Assert.Equal(ErrorObjectType.OverloadedError, value.Type.Value());
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
        ApiEnum<string, ErrorObjectType> expectedType = ErrorObjectType.InvalidRequestError;

        Assert.Equal(expectedMessage, value.Message);
        Assert.Equal(expectedType, value.Type);

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

public class ErrorObjectTypeTest : TestBase
{
    [Theory]
    [InlineData(ErrorObjectType.InvalidRequestError)]
    [InlineData(ErrorObjectType.AuthenticationError)]
    [InlineData(ErrorObjectType.BillingError)]
    [InlineData(ErrorObjectType.PermissionError)]
    [InlineData(ErrorObjectType.NotFoundError)]
    [InlineData(ErrorObjectType.RateLimitError)]
    [InlineData(ErrorObjectType.TimeoutError)]
    [InlineData(ErrorObjectType.ApiError)]
    [InlineData(ErrorObjectType.OverloadedError)]
    public void Validation_Works(ErrorObjectType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorObjectType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorObjectType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ErrorObjectType.InvalidRequestError)]
    [InlineData(ErrorObjectType.AuthenticationError)]
    [InlineData(ErrorObjectType.BillingError)]
    [InlineData(ErrorObjectType.PermissionError)]
    [InlineData(ErrorObjectType.NotFoundError)]
    [InlineData(ErrorObjectType.RateLimitError)]
    [InlineData(ErrorObjectType.TimeoutError)]
    [InlineData(ErrorObjectType.ApiError)]
    [InlineData(ErrorObjectType.OverloadedError)]
    public void SerializationRoundtrip_Works(ErrorObjectType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorObjectType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorObjectType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorObjectType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorObjectType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
