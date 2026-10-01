using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCacheMissReasonTest : TestBase
{
    [Fact]
    public void ModelChangedValidationWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissModelChanged(0);
        value.Validate();
    }

    [Fact]
    public void SystemChangedValidationWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissSystemChanged(0);
        value.Validate();
    }

    [Fact]
    public void ToolsChangedValidationWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissToolsChanged(0);
        value.Validate();
    }

    [Fact]
    public void MessagesChangedValidationWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissMessagesChanged(0);
        value.Validate();
    }

    [Fact]
    public void PreviousMessageNotFoundValidationWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissPreviousMessageNotFound();
        value.Validate();
    }

    [Fact]
    public void UnavailableValidationWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissUnavailable();
        value.Validate();
    }

    [Fact]
    public void ModelChangedSerializationRoundtripWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissModelChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemChangedSerializationRoundtripWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissSystemChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolsChangedSerializationRoundtripWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissToolsChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MessagesChangedSerializationRoundtripWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissMessagesChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PreviousMessageNotFoundSerializationRoundtripWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissPreviousMessageNotFound();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnavailableSerializationRoundtripWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissUnavailable();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaCacheMissReason value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_missed_input_tokens": 0,
                  "type": "model_changed"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        long expectedCacheMissedInputTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("model_changed");

        Assert.Equal(expectedCacheMissedInputTokens, value.CacheMissedInputTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaCacheMissReason emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.CacheMissedInputTokens);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaCacheMissReason mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_missed_input_tokens": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.CacheMissedInputTokens);
    }
}
