using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorToolResultError { ErrorCode = ErrorCode.MaxUsesExceeded };

        ApiEnum<string, ErrorCode> expectedErrorCode = ErrorCode.MaxUsesExceeded;
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_tool_result_error");

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorToolResultError { ErrorCode = ErrorCode.MaxUsesExceeded };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorToolResultError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorToolResultError { ErrorCode = ErrorCode.MaxUsesExceeded };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorToolResultError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ErrorCode> expectedErrorCode = ErrorCode.MaxUsesExceeded;
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_tool_result_error");

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorToolResultError { ErrorCode = ErrorCode.MaxUsesExceeded };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorToolResultError { ErrorCode = ErrorCode.MaxUsesExceeded };

        BetaAdvisorToolResultError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(ErrorCode.MaxUsesExceeded)]
    [InlineData(ErrorCode.PromptTooLong)]
    [InlineData(ErrorCode.TooManyRequests)]
    [InlineData(ErrorCode.Overloaded)]
    [InlineData(ErrorCode.Unavailable)]
    [InlineData(ErrorCode.ExecutionTimeExceeded)]
    public void Validation_Works(ErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ErrorCode.MaxUsesExceeded)]
    [InlineData(ErrorCode.PromptTooLong)]
    [InlineData(ErrorCode.TooManyRequests)]
    [InlineData(ErrorCode.Overloaded)]
    [InlineData(ErrorCode.Unavailable)]
    [InlineData(ErrorCode.ExecutionTimeExceeded)]
    public void SerializationRoundtrip_Works(ErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
