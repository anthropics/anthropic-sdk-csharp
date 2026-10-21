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
    public void ModelChangedTypeWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissModelChanged(0);
        Assert.Equal(BetaCacheMissReasonType.ModelChanged, value.Type.Value());
    }

    [Fact]
    public void SystemChangedTypeWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissSystemChanged(0);
        Assert.Equal(BetaCacheMissReasonType.SystemChanged, value.Type.Value());
    }

    [Fact]
    public void ToolsChangedTypeWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissToolsChanged(0);
        Assert.Equal(BetaCacheMissReasonType.ToolsChanged, value.Type.Value());
    }

    [Fact]
    public void MessagesChangedTypeWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissMessagesChanged(0);
        Assert.Equal(BetaCacheMissReasonType.MessagesChanged, value.Type.Value());
    }

    [Fact]
    public void PreviousMessageNotFoundTypeWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissPreviousMessageNotFound();
        Assert.Equal(BetaCacheMissReasonType.PreviousMessageNotFound, value.Type.Value());
    }

    [Fact]
    public void UnavailableTypeWorks()
    {
        BetaCacheMissReason value = new BetaCacheMissUnavailable();
        Assert.Equal(BetaCacheMissReasonType.Unavailable, value.Type.Value());
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
        ApiEnum<string, BetaCacheMissReasonType> expectedType =
            BetaCacheMissReasonType.ModelChanged;

        Assert.Equal(expectedCacheMissedInputTokens, value.CacheMissedInputTokens);
        Assert.Equal(expectedType, value.Type);

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

public class BetaCacheMissReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaCacheMissReasonType.ModelChanged)]
    [InlineData(BetaCacheMissReasonType.SystemChanged)]
    [InlineData(BetaCacheMissReasonType.ToolsChanged)]
    [InlineData(BetaCacheMissReasonType.MessagesChanged)]
    [InlineData(BetaCacheMissReasonType.PreviousMessageNotFound)]
    [InlineData(BetaCacheMissReasonType.Unavailable)]
    public void Validation_Works(BetaCacheMissReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCacheMissReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaCacheMissReasonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaCacheMissReasonType.ModelChanged)]
    [InlineData(BetaCacheMissReasonType.SystemChanged)]
    [InlineData(BetaCacheMissReasonType.ToolsChanged)]
    [InlineData(BetaCacheMissReasonType.MessagesChanged)]
    [InlineData(BetaCacheMissReasonType.PreviousMessageNotFound)]
    [InlineData(BetaCacheMissReasonType.Unavailable)]
    public void SerializationRoundtrip_Works(BetaCacheMissReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCacheMissReasonType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaCacheMissReasonType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaCacheMissReasonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaCacheMissReasonType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
