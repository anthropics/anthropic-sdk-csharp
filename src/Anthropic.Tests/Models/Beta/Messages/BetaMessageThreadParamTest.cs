using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMessageThreadParamTest : TestBase
{
    [Fact]
    public void ThreadCreateParamsValidationWorks()
    {
        BetaMessageThreadParam value = new BetaThreadCreateParams();
        value.Validate();
    }

    [Fact]
    public void ThreadContinueParamsValidationWorks()
    {
        BetaMessageThreadParam value = new BetaThreadContinueParams("previous_message_id");
        value.Validate();
    }

    [Fact]
    public void ThreadCreateParamsSerializationRoundtripWorks()
    {
        BetaMessageThreadParam value = new BetaThreadCreateParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageThreadParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadContinueParamsSerializationRoundtripWorks()
    {
        BetaMessageThreadParam value = new BetaThreadContinueParams("previous_message_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageThreadParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadCreateParamsTypeWorks()
    {
        BetaMessageThreadParam value = new BetaThreadCreateParams();
        Assert.Equal(BetaMessageThreadParamType.Create, value.Type.Value());
    }

    [Fact]
    public void ThreadContinueParamsTypeWorks()
    {
        BetaMessageThreadParam value = new BetaThreadContinueParams("previous_message_id");
        Assert.Equal(BetaMessageThreadParamType.Continue, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaMessageThreadParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "create"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaMessageThreadParamType> expectedType =
            BetaMessageThreadParamType.Create;

        Assert.Equal(expectedType, value.Type);

        BetaMessageThreadParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaMessageThreadParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaMessageThreadParamType.Create)]
    [InlineData(BetaMessageThreadParamType.Continue)]
    public void Validation_Works(BetaMessageThreadParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaMessageThreadParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaMessageThreadParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaMessageThreadParamType.Create)]
    [InlineData(BetaMessageThreadParamType.Continue)]
    public void SerializationRoundtrip_Works(BetaMessageThreadParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaMessageThreadParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaMessageThreadParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaMessageThreadParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaMessageThreadParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
