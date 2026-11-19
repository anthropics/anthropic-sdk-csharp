using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(ErrorType.InvalidRequestError)]
    [InlineData(ErrorType.AuthenticationError)]
    [InlineData(ErrorType.BillingError)]
    [InlineData(ErrorType.PermissionError)]
    [InlineData(ErrorType.NotFoundError)]
    [InlineData(ErrorType.RateLimitError)]
    [InlineData(ErrorType.TimeoutError)]
    [InlineData(ErrorType.ApiError)]
    [InlineData(ErrorType.OverloadedError)]
    [InlineData(ErrorType.MemoryPreconditionFailedError)]
    [InlineData(ErrorType.MemoryPathConflictError)]
    [InlineData(ErrorType.ConflictError)]
    public void Validation_Works(ErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ErrorType.InvalidRequestError, 0, "invalid_request_error")]
    [InlineData(ErrorType.AuthenticationError, 1, "authentication_error")]
    [InlineData(ErrorType.BillingError, 2, "billing_error")]
    [InlineData(ErrorType.PermissionError, 3, "permission_error")]
    [InlineData(ErrorType.NotFoundError, 4, "not_found_error")]
    [InlineData(ErrorType.RateLimitError, 5, "rate_limit_error")]
    [InlineData(ErrorType.TimeoutError, 6, "timeout_error")]
    [InlineData(ErrorType.ApiError, 7, "api_error")]
    [InlineData(ErrorType.OverloadedError, 8, "overloaded_error")]
    [InlineData(ErrorType.MemoryPreconditionFailedError, 9, "memory_precondition_failed_error")]
    [InlineData(ErrorType.MemoryPathConflictError, 10, "memory_path_conflict_error")]
    [InlineData(ErrorType.ConflictError, 11, "conflict_error")]
    public void EnumMemberSerializationRoundtrip_Works(
        ErrorType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
