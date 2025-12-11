using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationsDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationsDelta
        {
            Citation = new BetaCitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        Citation expectedCitation = new BetaCitationCharLocation()
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndCharIndex = 0,
            FileID = "file_id",
            StartCharIndex = 0,
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");

        Assert.Equal(expectedCitation, model.Citation);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCitationsDelta
        {
            Citation = new BetaCitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCitationsDelta
        {
            Citation = new BetaCitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(json);
        Assert.NotNull(deserialized);

        Citation expectedCitation = new BetaCitationCharLocation()
        {
            CitedText = "cited_text",
            DocumentIndex = 0,
            DocumentTitle = "document_title",
            EndCharIndex = 0,
            FileID = "file_id",
            StartCharIndex = 0,
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");

        Assert.Equal(expectedCitation, deserialized.Citation);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCitationsDelta
        {
            Citation = new BetaCitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        model.Validate();
    }
}

public class CitationTest : TestBase
{
    [Fact]
    public void beta_citation_char_locationValidation_Works()
    {
        Citation value = new(
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
    public void beta_citation_page_locationValidation_Works()
    {
        Citation value = new(
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
    public void beta_citation_content_block_locationValidation_Works()
    {
        Citation value = new(
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
    public void beta_citations_web_search_result_locationValidation_Works()
    {
        Citation value = new(
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
    public void beta_citation_search_result_locationValidation_Works()
    {
        Citation value = new(
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
    public void beta_citation_char_locationSerializationRoundtrip_Works()
    {
        Citation value = new(
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
        var deserialized = JsonSerializer.Deserialize<Citation>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_citation_page_locationSerializationRoundtrip_Works()
    {
        Citation value = new(
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
        var deserialized = JsonSerializer.Deserialize<Citation>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_citation_content_block_locationSerializationRoundtrip_Works()
    {
        Citation value = new(
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
        var deserialized = JsonSerializer.Deserialize<Citation>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_citations_web_search_result_locationSerializationRoundtrip_Works()
    {
        Citation value = new(
            new BetaCitationsWebSearchResultLocation()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "title",
                URL = "url",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Citation>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_citation_search_result_locationSerializationRoundtrip_Works()
    {
        Citation value = new(
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
        var deserialized = JsonSerializer.Deserialize<Citation>(json);

        Assert.Equal(value, deserialized);
    }
}
