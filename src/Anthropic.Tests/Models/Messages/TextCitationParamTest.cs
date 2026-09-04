using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextCitationParamTest : TestBase
{
    [Fact]
    public void CitationCharLocationValidationWorks()
    {
        TextCitationParam value = new CitationCharLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndCharIndex = 0,
            StartCharIndex = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CitationPageLocationValidationWorks()
    {
        TextCitationParam value = new CitationPageLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };
        value.Validate();
    }

    [Fact]
    public void CitationContentBlockLocationValidationWorks()
    {
        TextCitationParam value = new CitationContentBlockLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndBlockIndex = 0,
            StartBlockIndex = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CitationWebSearchResultLocationValidationWorks()
    {
        TextCitationParam value = new CitationWebSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };
        value.Validate();
    }

    [Fact]
    public void CitationSearchResultLocationValidationWorks()
    {
        TextCitationParam value = new CitationSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        value.Validate();
    }

    [Fact]
    public void CitationCharLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new CitationCharLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndCharIndex = 0,
            StartCharIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationPageLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new CitationPageLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationContentBlockLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new CitationContentBlockLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndBlockIndex = 0,
            StartBlockIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationWebSearchResultLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new CitationWebSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationSearchResultLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new CitationSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        TextCitationParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cited_text": "The grass is green. The sky is blue.",
                  "document_index": 0,
                  "document_title": "x",
                  "type": "char_location",
                  "end_block_index": 0,
                  "start_block_index": 0,
                  "title": "x"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedCitedText = "The grass is green. The sky is blue.";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("char_location");
        long expectedEndBlockIndex = 0;
        long expectedStartBlockIndex = 0;
        string expectedTitle = "x";

        Assert.Equal(expectedCitedText, value.CitedText);
        Assert.Equal(expectedDocumentIndex, value.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, value.DocumentTitle);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.Equal(expectedEndBlockIndex, value.EndBlockIndex);
        Assert.Equal(expectedStartBlockIndex, value.StartBlockIndex);
        Assert.Equal(expectedTitle, value.Title);

        TextCitationParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.CitedText);
        Assert.Null(emptyValue.DocumentIndex);
        Assert.Null(emptyValue.DocumentTitle);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.EndBlockIndex);
        Assert.Null(emptyValue.StartBlockIndex);
        Assert.Null(emptyValue.Title);

        TextCitationParam mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cited_text": [
                    "invalid"
                  ],
                  "document_index": [
                    "invalid"
                  ],
                  "document_title": [
                    "invalid"
                  ],
                  "end_block_index": [
                    "invalid"
                  ],
                  "start_block_index": [
                    "invalid"
                  ],
                  "title": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.CitedText);
        Assert.Null(mismatchedValue.DocumentIndex);
        Assert.Null(mismatchedValue.DocumentTitle);
        Assert.Null(mismatchedValue.EndBlockIndex);
        Assert.Null(mismatchedValue.StartBlockIndex);
        Assert.Null(mismatchedValue.Title);
    }
}
