using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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

    [Fact]
    public void InvalidRequestTypeWorks()
    {
        BetaError value = new BetaInvalidRequestError("message");
        Assert.Equal(BetaErrorType.InvalidRequestError, value.Type.Value());
    }

    [Fact]
    public void AuthenticationTypeWorks()
    {
        BetaError value = new BetaAuthenticationError("message");
        Assert.Equal(BetaErrorType.AuthenticationError, value.Type.Value());
    }

    [Fact]
    public void BillingTypeWorks()
    {
        BetaError value = new BetaBillingError("message");
        Assert.Equal(BetaErrorType.BillingError, value.Type.Value());
    }

    [Fact]
    public void PermissionTypeWorks()
    {
        BetaError value = new BetaPermissionError("message");
        Assert.Equal(BetaErrorType.PermissionError, value.Type.Value());
    }

    [Fact]
    public void NotFoundTypeWorks()
    {
        BetaError value = new BetaNotFoundError("message");
        Assert.Equal(BetaErrorType.NotFoundError, value.Type.Value());
    }

    [Fact]
    public void RateLimitTypeWorks()
    {
        BetaError value = new BetaRateLimitError("message");
        Assert.Equal(BetaErrorType.RateLimitError, value.Type.Value());
    }

    [Fact]
    public void GatewayTimeoutTypeWorks()
    {
        BetaError value = new BetaGatewayTimeoutError("message");
        Assert.Equal(BetaErrorType.TimeoutError, value.Type.Value());
    }

    [Fact]
    public void ApiTypeWorks()
    {
        BetaError value = new BetaApiError("message");
        Assert.Equal(BetaErrorType.ApiError, value.Type.Value());
    }

    [Fact]
    public void OverloadedTypeWorks()
    {
        BetaError value = new BetaOverloadedError("message");
        Assert.Equal(BetaErrorType.OverloadedError, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaError value = new(
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
        ApiEnum<string, BetaErrorType> expectedType = BetaErrorType.InvalidRequestError;

        Assert.Equal(expectedMessage, value.Message);
        Assert.Equal(expectedType, value.Type);

        BetaError emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Message);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaError mismatchedValue = new(
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

public class BetaErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaErrorType.InvalidRequestError)]
    [InlineData(BetaErrorType.AuthenticationError)]
    [InlineData(BetaErrorType.BillingError)]
    [InlineData(BetaErrorType.PermissionError)]
    [InlineData(BetaErrorType.NotFoundError)]
    [InlineData(BetaErrorType.RateLimitError)]
    [InlineData(BetaErrorType.TimeoutError)]
    [InlineData(BetaErrorType.ApiError)]
    [InlineData(BetaErrorType.OverloadedError)]
    public void Validation_Works(BetaErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaErrorType.InvalidRequestError)]
    [InlineData(BetaErrorType.AuthenticationError)]
    [InlineData(BetaErrorType.BillingError)]
    [InlineData(BetaErrorType.PermissionError)]
    [InlineData(BetaErrorType.NotFoundError)]
    [InlineData(BetaErrorType.RateLimitError)]
    [InlineData(BetaErrorType.TimeoutError)]
    [InlineData(BetaErrorType.ApiError)]
    [InlineData(BetaErrorType.OverloadedError)]
    public void SerializationRoundtrip_Works(BetaErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
