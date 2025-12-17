using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextCitationTest : TestBase
{
    [Fact]
    public void CitationCharLocationValidationWorks()
    {
        BetaTextCitation value = new(
            new BetaCitationCharLocation()
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
        BetaTextCitation value = new(
            new BetaCitationPageLocation()
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
        BetaTextCitation value = new(
            new BetaCitationContentBlockLocation()
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
        BetaTextCitation value = new(
            new BetaCitationsWebSearchResultLocation()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "title",
                URL = "url",
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationSearchResultLocationValidationWorks()
    {
        BetaTextCitation value = new(
            new BetaCitationSearchResultLocation()
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
        BetaTextCitation value = new(
            new BetaCitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationPageLocationSerializationRoundtripWorks()
    {
        BetaTextCitation value = new(
            new BetaCitationPageLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndPageNumber = 0,
                FileID = "file_id",
                StartPageNumber = 1,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationContentBlockLocationSerializationRoundtripWorks()
    {
        BetaTextCitation value = new(
            new BetaCitationContentBlockLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndBlockIndex = 0,
                FileID = "file_id",
                StartBlockIndex = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsWebSearchResultLocationSerializationRoundtripWorks()
    {
        BetaTextCitation value = new(
            new BetaCitationsWebSearchResultLocation()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "title",
                URL = "url",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationSearchResultLocationSerializationRoundtripWorks()
    {
        BetaTextCitation value = new(
            new BetaCitationSearchResultLocation()
            {
                CitedText = "cited_text",
                EndBlockIndex = 0,
                SearchResultIndex = 0,
                Source = "source",
                StartBlockIndex = 0,
                Title = "title",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(json);

        Assert.Equal(value, deserialized);
    }
}
