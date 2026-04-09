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
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.PromptTooLong)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.TooManyRequests)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.Overloaded)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.Unavailable)]
    [InlineData(BetaAdvisorToolResultErrorParamErrorCode.ExecutionTimeExceeded)]
    public void SerializationRoundtrip_Works(BetaAdvisorToolResultErrorParamErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
