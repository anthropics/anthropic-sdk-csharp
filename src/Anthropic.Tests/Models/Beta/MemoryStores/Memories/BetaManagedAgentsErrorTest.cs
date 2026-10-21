using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsErrorTest : TestBase
{
    [Fact]
    public void InvalidRequestValidationWorks()
    {
        BetaManagedAgentsError value = new BetaInvalidRequestError("message");
        value.Validate();
    }

    [Fact]
    public void AuthenticationValidationWorks()
    {
        BetaManagedAgentsError value = new BetaAuthenticationError("message");
        value.Validate();
    }

    [Fact]
    public void BillingValidationWorks()
    {
        BetaManagedAgentsError value = new BetaBillingError("message");
        value.Validate();
    }

    [Fact]
    public void PermissionValidationWorks()
    {
        BetaManagedAgentsError value = new BetaPermissionError("message");
        value.Validate();
    }

    [Fact]
    public void NotFoundValidationWorks()
    {
        BetaManagedAgentsError value = new BetaNotFoundError("message");
        value.Validate();
    }

    [Fact]
    public void RateLimitValidationWorks()
    {
        BetaManagedAgentsError value = new BetaRateLimitError("message");
        value.Validate();
    }

    [Fact]
    public void GatewayTimeoutValidationWorks()
    {
        BetaManagedAgentsError value = new BetaGatewayTimeoutError("message");
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaManagedAgentsError value = new BetaApiError("message");
        value.Validate();
    }

    [Fact]
    public void OverloadedValidationWorks()
    {
        BetaManagedAgentsError value = new BetaOverloadedError("message");
        value.Validate();
    }

    [Fact]
    public void MemoryPreconditionFailedValidationWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPreconditionFailedError()
        {
            Message = "message",
        };
        value.Validate();
    }

    [Fact]
    public void MemoryPathConflictValidationWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPathConflictError()
        {
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };
        value.Validate();
    }

    [Fact]
    public void ConflictValidationWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsConflictError() { Message = "message" };
        value.Validate();
    }

    [Fact]
    public void InvalidRequestSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaInvalidRequestError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaAuthenticationError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaBillingError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaPermissionError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaNotFoundError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaRateLimitError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaGatewayTimeoutError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaApiError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaOverloadedError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryPreconditionFailedSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPreconditionFailedError()
        {
            Message = "message",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryPathConflictSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPathConflictError()
        {
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ConflictSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsConflictError() { Message = "message" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidRequestTypeWorks()
    {
        BetaManagedAgentsError value = new BetaInvalidRequestError("message");
        Assert.Equal(BetaManagedAgentsErrorType.InvalidRequestError, value.Type.Value());
    }

    [Fact]
    public void AuthenticationTypeWorks()
    {
        BetaManagedAgentsError value = new BetaAuthenticationError("message");
        Assert.Equal(BetaManagedAgentsErrorType.AuthenticationError, value.Type.Value());
    }

    [Fact]
    public void BillingTypeWorks()
    {
        BetaManagedAgentsError value = new BetaBillingError("message");
        Assert.Equal(BetaManagedAgentsErrorType.BillingError, value.Type.Value());
    }

    [Fact]
    public void PermissionTypeWorks()
    {
        BetaManagedAgentsError value = new BetaPermissionError("message");
        Assert.Equal(BetaManagedAgentsErrorType.PermissionError, value.Type.Value());
    }

    [Fact]
    public void NotFoundTypeWorks()
    {
        BetaManagedAgentsError value = new BetaNotFoundError("message");
        Assert.Equal(BetaManagedAgentsErrorType.NotFoundError, value.Type.Value());
    }

    [Fact]
    public void RateLimitTypeWorks()
    {
        BetaManagedAgentsError value = new BetaRateLimitError("message");
        Assert.Equal(BetaManagedAgentsErrorType.RateLimitError, value.Type.Value());
    }

    [Fact]
    public void GatewayTimeoutTypeWorks()
    {
        BetaManagedAgentsError value = new BetaGatewayTimeoutError("message");
        Assert.Equal(BetaManagedAgentsErrorType.TimeoutError, value.Type.Value());
    }

    [Fact]
    public void ApiTypeWorks()
    {
        BetaManagedAgentsError value = new BetaApiError("message");
        Assert.Equal(BetaManagedAgentsErrorType.ApiError, value.Type.Value());
    }

    [Fact]
    public void OverloadedTypeWorks()
    {
        BetaManagedAgentsError value = new BetaOverloadedError("message");
        Assert.Equal(BetaManagedAgentsErrorType.OverloadedError, value.Type.Value());
    }

    [Fact]
    public void MemoryPreconditionFailedTypeWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPreconditionFailedError()
        {
            Message = "message",
        };
        Assert.Equal(BetaManagedAgentsErrorType.MemoryPreconditionFailedError, value.Type.Value());
    }

    [Fact]
    public void MemoryPathConflictTypeWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPathConflictError()
        {
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };
        Assert.Equal(BetaManagedAgentsErrorType.MemoryPathConflictError, value.Type.Value());
    }

    [Fact]
    public void ConflictTypeWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsConflictError() { Message = "message" };
        Assert.Equal(BetaManagedAgentsErrorType.ConflictError, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsError value = new(
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
        ApiEnum<string, BetaManagedAgentsErrorType> expectedType =
            BetaManagedAgentsErrorType.InvalidRequestError;

        Assert.Equal(expectedMessage, value.Message);
        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsError emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.Message);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaManagedAgentsError mismatchedValue = new(
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

public class BetaManagedAgentsErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsErrorType.InvalidRequestError)]
    [InlineData(BetaManagedAgentsErrorType.AuthenticationError)]
    [InlineData(BetaManagedAgentsErrorType.BillingError)]
    [InlineData(BetaManagedAgentsErrorType.PermissionError)]
    [InlineData(BetaManagedAgentsErrorType.NotFoundError)]
    [InlineData(BetaManagedAgentsErrorType.RateLimitError)]
    [InlineData(BetaManagedAgentsErrorType.TimeoutError)]
    [InlineData(BetaManagedAgentsErrorType.ApiError)]
    [InlineData(BetaManagedAgentsErrorType.OverloadedError)]
    [InlineData(BetaManagedAgentsErrorType.MemoryPreconditionFailedError)]
    [InlineData(BetaManagedAgentsErrorType.MemoryPathConflictError)]
    [InlineData(BetaManagedAgentsErrorType.ConflictError)]
    public void Validation_Works(BetaManagedAgentsErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsErrorType.InvalidRequestError)]
    [InlineData(BetaManagedAgentsErrorType.AuthenticationError)]
    [InlineData(BetaManagedAgentsErrorType.BillingError)]
    [InlineData(BetaManagedAgentsErrorType.PermissionError)]
    [InlineData(BetaManagedAgentsErrorType.NotFoundError)]
    [InlineData(BetaManagedAgentsErrorType.RateLimitError)]
    [InlineData(BetaManagedAgentsErrorType.TimeoutError)]
    [InlineData(BetaManagedAgentsErrorType.ApiError)]
    [InlineData(BetaManagedAgentsErrorType.OverloadedError)]
    [InlineData(BetaManagedAgentsErrorType.MemoryPreconditionFailedError)]
    [InlineData(BetaManagedAgentsErrorType.MemoryPathConflictError)]
    [InlineData(BetaManagedAgentsErrorType.ConflictError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
