using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CacheMissReasonTest : TestBase
{
    [Fact]
    public void ModelChangedValidationWorks()
    {
        CacheMissReason value = new CacheMissModelChanged(0);
        value.Validate();
    }

    [Fact]
    public void SystemChangedValidationWorks()
    {
        CacheMissReason value = new CacheMissSystemChanged(0);
        value.Validate();
    }

    [Fact]
    public void ToolsChangedValidationWorks()
    {
        CacheMissReason value = new CacheMissToolsChanged(0);
        value.Validate();
    }

    [Fact]
    public void MessagesChangedValidationWorks()
    {
        CacheMissReason value = new CacheMissMessagesChanged(0);
        value.Validate();
    }

    [Fact]
    public void PreviousMessageNotFoundValidationWorks()
    {
        CacheMissReason value = new CacheMissPreviousMessageNotFound();
        value.Validate();
    }

    [Fact]
    public void UnavailableValidationWorks()
    {
        CacheMissReason value = new CacheMissUnavailable();
        value.Validate();
    }

    [Fact]
    public void ModelChangedSerializationRoundtripWorks()
    {
        CacheMissReason value = new CacheMissModelChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemChangedSerializationRoundtripWorks()
    {
        CacheMissReason value = new CacheMissSystemChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolsChangedSerializationRoundtripWorks()
    {
        CacheMissReason value = new CacheMissToolsChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MessagesChangedSerializationRoundtripWorks()
    {
        CacheMissReason value = new CacheMissMessagesChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PreviousMessageNotFoundSerializationRoundtripWorks()
    {
        CacheMissReason value = new CacheMissPreviousMessageNotFound();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnavailableSerializationRoundtripWorks()
    {
        CacheMissReason value = new CacheMissUnavailable();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        CacheMissReason value = new(
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

        CacheMissReason emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.CacheMissedInputTokens);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        CacheMissReason mismatchedValue = new(
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
