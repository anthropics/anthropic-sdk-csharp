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
    public void ModelChangedTypeWorks()
    {
        CacheMissReason value = new CacheMissModelChanged(0);
        Assert.Equal(CacheMissReasonType.ModelChanged, value.Type.Value());
    }

    [Fact]
    public void SystemChangedTypeWorks()
    {
        CacheMissReason value = new CacheMissSystemChanged(0);
        Assert.Equal(CacheMissReasonType.SystemChanged, value.Type.Value());
    }

    [Fact]
    public void ToolsChangedTypeWorks()
    {
        CacheMissReason value = new CacheMissToolsChanged(0);
        Assert.Equal(CacheMissReasonType.ToolsChanged, value.Type.Value());
    }

    [Fact]
    public void MessagesChangedTypeWorks()
    {
        CacheMissReason value = new CacheMissMessagesChanged(0);
        Assert.Equal(CacheMissReasonType.MessagesChanged, value.Type.Value());
    }

    [Fact]
    public void PreviousMessageNotFoundTypeWorks()
    {
        CacheMissReason value = new CacheMissPreviousMessageNotFound();
        Assert.Equal(CacheMissReasonType.PreviousMessageNotFound, value.Type.Value());
    }

    [Fact]
    public void UnavailableTypeWorks()
    {
        CacheMissReason value = new CacheMissUnavailable();
        Assert.Equal(CacheMissReasonType.Unavailable, value.Type.Value());
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
        ApiEnum<string, CacheMissReasonType> expectedType = CacheMissReasonType.ModelChanged;

        Assert.Equal(expectedCacheMissedInputTokens, value.CacheMissedInputTokens);
        Assert.Equal(expectedType, value.Type);

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

public class CacheMissReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(CacheMissReasonType.ModelChanged)]
    [InlineData(CacheMissReasonType.SystemChanged)]
    [InlineData(CacheMissReasonType.ToolsChanged)]
    [InlineData(CacheMissReasonType.MessagesChanged)]
    [InlineData(CacheMissReasonType.PreviousMessageNotFound)]
    [InlineData(CacheMissReasonType.Unavailable)]
    public void Validation_Works(CacheMissReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CacheMissReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CacheMissReasonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CacheMissReasonType.ModelChanged)]
    [InlineData(CacheMissReasonType.SystemChanged)]
    [InlineData(CacheMissReasonType.ToolsChanged)]
    [InlineData(CacheMissReasonType.MessagesChanged)]
    [InlineData(CacheMissReasonType.PreviousMessageNotFound)]
    [InlineData(CacheMissReasonType.Unavailable)]
    public void SerializationRoundtrip_Works(CacheMissReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CacheMissReasonType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CacheMissReasonType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CacheMissReasonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CacheMissReasonType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
