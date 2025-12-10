using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextCitationTest : TestBase
{
    [Fact]
    public void citation_char_locationValidation_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citation_page_locationValidation_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citation_content_block_locationValidation_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citations_web_search_result_locationValidation_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citation_search_result_locationValidation_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citation_char_locationSerializationRoundtrip_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citation_page_locationSerializationRoundtrip_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citation_content_block_locationSerializationRoundtrip_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citations_web_search_result_locationSerializationRoundtrip_Works()
    {
        BetaTextCitation value = new(
            new()
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
    public void citation_search_result_locationSerializationRoundtrip_Works()
    {
        BetaTextCitation value = new(
            new()
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
