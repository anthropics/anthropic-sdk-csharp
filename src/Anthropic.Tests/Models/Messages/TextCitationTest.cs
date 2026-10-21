using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextCitationTest : TestBase
{
    [Fact]
    public void CitationCharLocationValidationWorks()
    {
        TextCitation value = new CitationCharLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndCharIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartCharIndex = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CitationPageLocationValidationWorks()
    {
        TextCitation value = new CitationPageLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };
        value.Validate();
    }

    [Fact]
    public void CitationContentBlockLocationValidationWorks()
    {
        TextCitation value = new CitationContentBlockLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CitationsWebSearchResultLocationValidationWorks()
    {
        TextCitation value = new CitationsWebSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void CitationsSearchResultLocationValidationWorks()
    {
        TextCitation value = new CitationsSearchResultLocation()
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
        TextCitation value = new CitationCharLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndCharIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartCharIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationPageLocationSerializationRoundtripWorks()
    {
        TextCitation value = new CitationPageLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationContentBlockLocationSerializationRoundtripWorks()
    {
        TextCitation value = new CitationContentBlockLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsWebSearchResultLocationSerializationRoundtripWorks()
    {
        TextCitation value = new CitationsWebSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsSearchResultLocationSerializationRoundtripWorks()
    {
        TextCitation value = new CitationsSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationCharLocationTypeWorks()
    {
        TextCitation value = new CitationCharLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndCharIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartCharIndex = 0,
        };
        Assert.Equal(TextCitationType.CharLocation, value.Type.Value());
    }

    [Fact]
    public void CitationPageLocationTypeWorks()
    {
        TextCitation value = new CitationPageLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };
        Assert.Equal(TextCitationType.PageLocation, value.Type.Value());
    }

    [Fact]
    public void CitationContentBlockLocationTypeWorks()
    {
        TextCitation value = new CitationContentBlockLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };
        Assert.Equal(TextCitationType.ContentBlockLocation, value.Type.Value());
    }

    [Fact]
    public void CitationsWebSearchResultLocationTypeWorks()
    {
        TextCitation value = new CitationsWebSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };
        Assert.Equal(TextCitationType.WebSearchResultLocation, value.Type.Value());
    }

    [Fact]
    public void CitationsSearchResultLocationTypeWorks()
    {
        TextCitation value = new CitationsSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        Assert.Equal(TextCitationType.SearchResultLocation, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        TextCitation value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cited_text": "The grass is green. The sky is blue.",
                  "document_index": 0,
                  "document_title": "My Document",
                  "file_id": "file_011CNha8iCJcU1wXNR6q4V8w",
                  "type": "char_location",
                  "end_block_index": 0,
                  "start_block_index": 0,
                  "title": "title"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedCitedText = "The grass is green. The sky is blue.";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "My Document";
        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        ApiEnum<string, TextCitationType> expectedType = TextCitationType.CharLocation;
        long expectedEndBlockIndex = 0;
        long expectedStartBlockIndex = 0;
        string expectedTitle = "title";

        Assert.Equal(expectedCitedText, value.CitedText);
        Assert.Equal(expectedDocumentIndex, value.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, value.DocumentTitle);
        Assert.Equal(expectedFileID, value.FileID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedEndBlockIndex, value.EndBlockIndex);
        Assert.Equal(expectedStartBlockIndex, value.StartBlockIndex);
        Assert.Equal(expectedTitle, value.Title);

        TextCitation emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.CitedText);
        Assert.Null(emptyValue.DocumentIndex);
        Assert.Null(emptyValue.DocumentTitle);
        Assert.Null(emptyValue.FileID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.EndBlockIndex);
        Assert.Null(emptyValue.StartBlockIndex);
        Assert.Null(emptyValue.Title);

        TextCitation mismatchedValue = new(
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
                  "file_id": [
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
        Assert.Null(mismatchedValue.FileID);
        Assert.Null(mismatchedValue.EndBlockIndex);
        Assert.Null(mismatchedValue.StartBlockIndex);
        Assert.Null(mismatchedValue.Title);
    }
}

public class TextCitationTypeTest : TestBase
{
    [Theory]
    [InlineData(TextCitationType.CharLocation)]
    [InlineData(TextCitationType.PageLocation)]
    [InlineData(TextCitationType.ContentBlockLocation)]
    [InlineData(TextCitationType.WebSearchResultLocation)]
    [InlineData(TextCitationType.SearchResultLocation)]
    public void Validation_Works(TextCitationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextCitationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextCitationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextCitationType.CharLocation)]
    [InlineData(TextCitationType.PageLocation)]
    [InlineData(TextCitationType.ContentBlockLocation)]
    [InlineData(TextCitationType.WebSearchResultLocation)]
    [InlineData(TextCitationType.SearchResultLocation)]
    public void SerializationRoundtrip_Works(TextCitationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextCitationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextCitationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextCitationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextCitationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
