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
    [InlineData(ErrorType.PermissionError)]
    [InlineData(ErrorType.NotFoundError)]
    [InlineData(ErrorType.RateLimitError)]
    [InlineData(ErrorType.TimeoutError)]
    [InlineData(ErrorType.OverloadedError)]
    [InlineData(ErrorType.ApiError)]
    [InlineData(ErrorType.BillingError)]
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
    [InlineData(ErrorType.InvalidRequestError)]
    [InlineData(ErrorType.AuthenticationError)]
    [InlineData(ErrorType.PermissionError)]
    [InlineData(ErrorType.NotFoundError)]
    [InlineData(ErrorType.RateLimitError)]
    [InlineData(ErrorType.TimeoutError)]
    [InlineData(ErrorType.OverloadedError)]
    [InlineData(ErrorType.ApiError)]
    [InlineData(ErrorType.BillingError)]
    public void SerializationRoundtrip_Works(ErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
