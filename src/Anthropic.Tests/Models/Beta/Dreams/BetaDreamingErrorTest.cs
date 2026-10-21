using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamingErrorTest : TestBase
{
    [Fact]
    public void InvalidRequestValidationWorks()
    {
        BetaDreamingError value = new BetaInvalidRequestError("message");
        value.Validate();
    }

    [Fact]
    public void AuthenticationValidationWorks()
    {
        BetaDreamingError value = new BetaAuthenticationError("message");
        value.Validate();
    }

    [Fact]
    public void BillingValidationWorks()
    {
        BetaDreamingError value = new BetaBillingError("message");
        value.Validate();
    }

    [Fact]
    public void PermissionValidationWorks()
    {
        BetaDreamingError value = new BetaPermissionError("message");
        value.Validate();
    }

    [Fact]
    public void NotFoundValidationWorks()
    {
        BetaDreamingError value = new BetaNotFoundError("message");
        value.Validate();
    }

    [Fact]
    public void RateLimitValidationWorks()
    {
        BetaDreamingError value = new BetaRateLimitError("message");
        value.Validate();
    }

    [Fact]
    public void GatewayTimeoutValidationWorks()
    {
        BetaDreamingError value = new BetaGatewayTimeoutError("message");
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaDreamingError value = new BetaApiError("message");
        value.Validate();
    }

    [Fact]
    public void OverloadedValidationWorks()
    {
        BetaDreamingError value = new BetaOverloadedError("message");
        value.Validate();
    }

    [Fact]
    public void TargetStoreHeldValidationWorks()
    {
        BetaDreamingError value = new BetaTargetStoreHeldError() { Message = "message" };
        value.Validate();
    }

    [Fact]
    public void InvalidRequestSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaInvalidRequestError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaAuthenticationError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaBillingError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaPermissionError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaNotFoundError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaRateLimitError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaGatewayTimeoutError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaApiError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaOverloadedError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TargetStoreHeldSerializationRoundtripWorks()
    {
        BetaDreamingError value = new BetaTargetStoreHeldError() { Message = "message" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamingError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidRequestTypeWorks()
    {
        BetaDreamingError value = new BetaInvalidRequestError("message");
        Assert.Equal(BetaDreamingErrorType.InvalidRequestError, value.Type.Value());
    }

    [Fact]
    public void AuthenticationTypeWorks()
    {
        BetaDreamingError value = new BetaAuthenticationError("message");
        Assert.Equal(BetaDreamingErrorType.AuthenticationError, value.Type.Value());
    }

    [Fact]
    public void BillingTypeWorks()
    {
        BetaDreamingError value = new BetaBillingError("message");
        Assert.Equal(BetaDreamingErrorType.BillingError, value.Type.Value());
    }

    [Fact]
    public void PermissionTypeWorks()
    {
        BetaDreamingError value = new BetaPermissionError("message");
        Assert.Equal(BetaDreamingErrorType.PermissionError, value.Type.Value());
    }

    [Fact]
    public void NotFoundTypeWorks()
    {
        BetaDreamingError value = new BetaNotFoundError("message");
        Assert.Equal(BetaDreamingErrorType.NotFoundError, value.Type.Value());
    }

    [Fact]
    public void RateLimitTypeWorks()
    {
        BetaDreamingError value = new BetaRateLimitError("message");
        Assert.Equal(BetaDreamingErrorType.RateLimitError, value.Type.Value());
    }

    [Fact]
    public void GatewayTimeoutTypeWorks()
    {
        BetaDreamingError value = new BetaGatewayTimeoutError("message");
        Assert.Equal(BetaDreamingErrorType.TimeoutError, value.Type.Value());
    }

    [Fact]
    public void ApiTypeWorks()
    {
        BetaDreamingError value = new BetaApiError("message");
        Assert.Equal(BetaDreamingErrorType.ApiError, value.Type.Value());
    }

    [Fact]
    public void OverloadedTypeWorks()
    {
        BetaDreamingError value = new BetaOverloadedError("message");
        Assert.Equal(BetaDreamingErrorType.OverloadedError, value.Type.Value());
    }

    [Fact]
    public void TargetStoreHeldTypeWorks()
    {
        BetaDreamingError value = new BetaTargetStoreHeldError() { Message = "message" };
        Assert.Equal(BetaDreamingErrorType.ConflictError, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaDreamingError value = new(
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
        ApiEnum<string, BetaDreamingErrorType> expectedType =
            BetaDreamingErrorType.InvalidRequestError;

        Assert.Equal(expectedMessage, value.Message);
        Assert.Equal(expectedType, value.Type);

        BetaDreamingError emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.Message);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaDreamingError mismatchedValue = new(
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

        Assert.Null(mismatchedValue.Message);
    }
}

public class BetaDreamingErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaDreamingErrorType.InvalidRequestError)]
    [InlineData(BetaDreamingErrorType.AuthenticationError)]
    [InlineData(BetaDreamingErrorType.BillingError)]
    [InlineData(BetaDreamingErrorType.PermissionError)]
    [InlineData(BetaDreamingErrorType.NotFoundError)]
    [InlineData(BetaDreamingErrorType.RateLimitError)]
    [InlineData(BetaDreamingErrorType.TimeoutError)]
    [InlineData(BetaDreamingErrorType.ApiError)]
    [InlineData(BetaDreamingErrorType.OverloadedError)]
    [InlineData(BetaDreamingErrorType.ConflictError)]
    public void Validation_Works(BetaDreamingErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamingErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamingErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDreamingErrorType.InvalidRequestError)]
    [InlineData(BetaDreamingErrorType.AuthenticationError)]
    [InlineData(BetaDreamingErrorType.BillingError)]
    [InlineData(BetaDreamingErrorType.PermissionError)]
    [InlineData(BetaDreamingErrorType.NotFoundError)]
    [InlineData(BetaDreamingErrorType.RateLimitError)]
    [InlineData(BetaDreamingErrorType.TimeoutError)]
    [InlineData(BetaDreamingErrorType.ApiError)]
    [InlineData(BetaDreamingErrorType.OverloadedError)]
    [InlineData(BetaDreamingErrorType.ConflictError)]
    public void SerializationRoundtrip_Works(BetaDreamingErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamingErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamingErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamingErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamingErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
