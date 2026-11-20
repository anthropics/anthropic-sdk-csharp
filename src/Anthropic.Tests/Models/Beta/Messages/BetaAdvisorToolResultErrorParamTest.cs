using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorToolResultErrorParam
        {
            ErrorCode = BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded,
        };

        ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode> expectedErrorCode =
            BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded;
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_tool_result_error");

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorToolResultErrorParam
        {
            ErrorCode = BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorToolResultErrorParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorToolResultErrorParam
        {
            ErrorCode = BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorToolResultErrorParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode> expectedErrorCode =
            BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded;
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_tool_result_error");

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorToolResultErrorParam
        {
            ErrorCode = BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorToolResultErrorParam
        {
            ErrorCode = BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded,
        };

        BetaAdvisorToolResultErrorParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAdvisorToolResultErrorParamErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.PromptTooLong)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.TooManyRequests)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.Overloaded)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.Unavailable)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.ExecutionTimeExceeded)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.ModelNotFound)]
    public void Validation_Works(BetaAdvisorToolResultErrorParamErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded, 0, "max_uses_exceeded")]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.PromptTooLong, 1, "prompt_too_long")]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.TooManyRequests, 2, "too_many_requests")]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.Overloaded, 3, "overloaded")]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.Unavailable, 4, "unavailable")]
    [InlineData(
        BetaAdvisorToolResultErrorParamErrorCode.ExecutionTimeExceeded,
        5,
        "execution_time_exceeded"
    )]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.ModelNotFound, 6, "model_not_found")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAdvisorToolResultErrorParamErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
