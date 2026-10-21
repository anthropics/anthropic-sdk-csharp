using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawContentBlockDeltaTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaTextDelta("text");
        value.Validate();
    }

    [Fact]
    public void InputJsonValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaInputJsonDelta("partial_json");
        value.Validate();
    }

    [Fact]
    public void CitationsValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaCitationsDelta(
            new BetaCitationCharLocation()
            {
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void ThinkingValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaThinkingDelta()
        {
            EstimatedTokens = 0,
            Thinking = "thinking",
        };
        value.Validate();
    }

    [Fact]
    public void SignatureValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaSignatureDelta("signature");
        value.Validate();
    }

    [Fact]
    public void CompactionValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaCompactionContentBlockDelta()
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
        };
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaTextDelta("text");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InputJsonSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaInputJsonDelta("partial_json");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaCitationsDelta(
            new BetaCitationCharLocation()
            {
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaThinkingDelta()
        {
            EstimatedTokens = 0,
            Thinking = "thinking",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SignatureSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaSignatureDelta("signature");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaCompactionContentBlockDelta()
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextTypeWorks()
    {
        BetaRawContentBlockDelta value = new BetaTextDelta("text");
        Assert.Equal(BetaRawContentBlockDeltaType.TextDelta, value.Type.Value());
    }

    [Fact]
    public void InputJsonTypeWorks()
    {
        BetaRawContentBlockDelta value = new BetaInputJsonDelta("partial_json");
        Assert.Equal(BetaRawContentBlockDeltaType.InputJsonDelta, value.Type.Value());
    }

    [Fact]
    public void CitationsTypeWorks()
    {
        BetaRawContentBlockDelta value = new BetaCitationsDelta(
            new BetaCitationCharLocation()
            {
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            }
        );
        Assert.Equal(BetaRawContentBlockDeltaType.CitationsDelta, value.Type.Value());
    }

    [Fact]
    public void ThinkingTypeWorks()
    {
        BetaRawContentBlockDelta value = new BetaThinkingDelta()
        {
            EstimatedTokens = 0,
            Thinking = "thinking",
        };
        Assert.Equal(BetaRawContentBlockDeltaType.ThinkingDelta, value.Type.Value());
    }

    [Fact]
    public void SignatureTypeWorks()
    {
        BetaRawContentBlockDelta value = new BetaSignatureDelta("signature");
        Assert.Equal(BetaRawContentBlockDeltaType.SignatureDelta, value.Type.Value());
    }

    [Fact]
    public void CompactionTypeWorks()
    {
        BetaRawContentBlockDelta value = new BetaCompactionContentBlockDelta()
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
        };
        Assert.Equal(BetaRawContentBlockDeltaType.CompactionDelta, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaRawContentBlockDelta value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text_delta"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaRawContentBlockDeltaType> expectedType =
            BetaRawContentBlockDeltaType.TextDelta;

        Assert.Equal(expectedType, value.Type);

        BetaRawContentBlockDelta emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaRawContentBlockDeltaTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaRawContentBlockDeltaType.TextDelta)]
    [InlineData(BetaRawContentBlockDeltaType.InputJsonDelta)]
    [InlineData(BetaRawContentBlockDeltaType.CitationsDelta)]
    [InlineData(BetaRawContentBlockDeltaType.ThinkingDelta)]
    [InlineData(BetaRawContentBlockDeltaType.SignatureDelta)]
    [InlineData(BetaRawContentBlockDeltaType.CompactionDelta)]
    public void Validation_Works(BetaRawContentBlockDeltaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaRawContentBlockDeltaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaRawContentBlockDeltaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaRawContentBlockDeltaType.TextDelta)]
    [InlineData(BetaRawContentBlockDeltaType.InputJsonDelta)]
    [InlineData(BetaRawContentBlockDeltaType.CitationsDelta)]
    [InlineData(BetaRawContentBlockDeltaType.ThinkingDelta)]
    [InlineData(BetaRawContentBlockDeltaType.SignatureDelta)]
    [InlineData(BetaRawContentBlockDeltaType.CompactionDelta)]
    public void SerializationRoundtrip_Works(BetaRawContentBlockDeltaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaRawContentBlockDeltaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRawContentBlockDeltaType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaRawContentBlockDeltaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRawContentBlockDeltaType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
