using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawContentBlockDeltaTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        RawContentBlockDelta value = new TextDelta("text");
        value.Validate();
    }

    [Fact]
    public void InputJsonValidationWorks()
    {
        RawContentBlockDelta value = new InputJsonDelta("partial_json");
        value.Validate();
    }

    [Fact]
    public void CitationsValidationWorks()
    {
        RawContentBlockDelta value = new CitationsDelta(
            new CitationCharLocation()
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
        RawContentBlockDelta value = new ThinkingDelta("thinking");
        value.Validate();
    }

    [Fact]
    public void SignatureValidationWorks()
    {
        RawContentBlockDelta value = new SignatureDelta("signature");
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new TextDelta("text");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InputJsonSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new InputJsonDelta("partial_json");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new CitationsDelta(
            new CitationCharLocation()
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
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new ThinkingDelta("thinking");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SignatureSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new SignatureDelta("signature");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextTypeWorks()
    {
        RawContentBlockDelta value = new TextDelta("text");
        Assert.Equal(RawContentBlockDeltaType.TextDelta, value.Type.Value());
    }

    [Fact]
    public void InputJsonTypeWorks()
    {
        RawContentBlockDelta value = new InputJsonDelta("partial_json");
        Assert.Equal(RawContentBlockDeltaType.InputJsonDelta, value.Type.Value());
    }

    [Fact]
    public void CitationsTypeWorks()
    {
        RawContentBlockDelta value = new CitationsDelta(
            new CitationCharLocation()
            {
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            }
        );
        Assert.Equal(RawContentBlockDeltaType.CitationsDelta, value.Type.Value());
    }

    [Fact]
    public void ThinkingTypeWorks()
    {
        RawContentBlockDelta value = new ThinkingDelta("thinking");
        Assert.Equal(RawContentBlockDeltaType.ThinkingDelta, value.Type.Value());
    }

    [Fact]
    public void SignatureTypeWorks()
    {
        RawContentBlockDelta value = new SignatureDelta("signature");
        Assert.Equal(RawContentBlockDeltaType.SignatureDelta, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        RawContentBlockDelta value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text_delta"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, RawContentBlockDeltaType> expectedType = RawContentBlockDeltaType.TextDelta;

        Assert.Equal(expectedType, value.Type);

        RawContentBlockDelta emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class RawContentBlockDeltaTypeTest : TestBase
{
    [Theory]
    [InlineData(RawContentBlockDeltaType.TextDelta)]
    [InlineData(RawContentBlockDeltaType.InputJsonDelta)]
    [InlineData(RawContentBlockDeltaType.CitationsDelta)]
    [InlineData(RawContentBlockDeltaType.ThinkingDelta)]
    [InlineData(RawContentBlockDeltaType.SignatureDelta)]
    public void Validation_Works(RawContentBlockDeltaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RawContentBlockDeltaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RawContentBlockDeltaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RawContentBlockDeltaType.TextDelta)]
    [InlineData(RawContentBlockDeltaType.InputJsonDelta)]
    [InlineData(RawContentBlockDeltaType.CitationsDelta)]
    [InlineData(RawContentBlockDeltaType.ThinkingDelta)]
    [InlineData(RawContentBlockDeltaType.SignatureDelta)]
    public void SerializationRoundtrip_Works(RawContentBlockDeltaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RawContentBlockDeltaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RawContentBlockDeltaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RawContentBlockDeltaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RawContentBlockDeltaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
