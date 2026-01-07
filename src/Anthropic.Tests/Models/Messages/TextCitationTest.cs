using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextCitationTest : TestBase
{
    [Fact]
    public void CitationCharLocationValidationWorks()
    {
        TextCitation value = new(
            new CitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationPageLocationValidationWorks()
    {
        TextCitation value = new(
            new CitationPageLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndPageNumber = 0,
                FileID = "file_id",
                StartPageNumber = 1,
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationContentBlockLocationValidationWorks()
    {
        TextCitation value = new(
            new CitationContentBlockLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndBlockIndex = 0,
                FileID = "file_id",
                StartBlockIndex = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationsWebSearchResultLocationValidationWorks()
    {
        TextCitation value = new(
            new CitationsWebSearchResultLocation()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "title",
                Url = "url",
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationsSearchResultLocationValidationWorks()
    {
        TextCitation value = new(
            new CitationsSearchResultLocation()
            {
                CitedText = "cited_text",
                EndBlockIndex = 0,
                SearchResultIndex = 0,
                Source = "source",
                StartBlockIndex = 0,
                Title = "title",
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationCharLocationSerializationRoundtripWorks()
    {
        TextCitation value = new(
            new CitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationPageLocationSerializationRoundtripWorks()
    {
        TextCitation value = new(
            new CitationPageLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndPageNumber = 0,
                FileID = "file_id",
                StartPageNumber = 1,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationContentBlockLocationSerializationRoundtripWorks()
    {
        TextCitation value = new(
            new CitationContentBlockLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndBlockIndex = 0,
                FileID = "file_id",
                StartBlockIndex = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsWebSearchResultLocationSerializationRoundtripWorks()
    {
        TextCitation value = new(
            new CitationsWebSearchResultLocation()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "title",
                Url = "url",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsSearchResultLocationSerializationRoundtripWorks()
    {
        TextCitation value = new(
            new CitationsSearchResultLocation()
            {
                CitedText = "cited_text",
                EndBlockIndex = 0,
                SearchResultIndex = 0,
                Source = "source",
                StartBlockIndex = 0,
                Title = "title",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitation>(element);

        Assert.Equal(value, deserialized);
    }
}
