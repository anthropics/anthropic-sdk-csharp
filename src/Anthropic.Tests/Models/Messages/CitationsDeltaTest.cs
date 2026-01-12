using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationsDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationsDelta
        {
            Citation = new CitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        Citation expectedCitation = new CitationCharLocation()
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
        var model = new CitationsDelta
        {
            Citation = new CitationCharLocation()
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
        var deserialized = JsonSerializer.Deserialize<CitationsDelta>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CitationsDelta
        {
            Citation = new CitationCharLocation()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "document_title",
                EndCharIndex = 0,
                FileID = "file_id",
                StartCharIndex = 0,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CitationsDelta>(element);
        Assert.NotNull(deserialized);

        Citation expectedCitation = new CitationCharLocation()
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
        var model = new CitationsDelta
        {
            Citation = new CitationCharLocation()
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
    public void CharLocationValidationWorks()
    {
        Citation value = new(
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
    public void PageLocationValidationWorks()
    {
        Citation value = new(
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
    public void ContentBlockLocationValidationWorks()
    {
        Citation value = new(
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
        Citation value = new(
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
        Citation value = new(
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
    public void CharLocationSerializationRoundtripWorks()
    {
        Citation value = new(
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
        var deserialized = JsonSerializer.Deserialize<Citation>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PageLocationSerializationRoundtripWorks()
    {
        Citation value = new(
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
        var deserialized = JsonSerializer.Deserialize<Citation>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockLocationSerializationRoundtripWorks()
    {
        Citation value = new(
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
        var deserialized = JsonSerializer.Deserialize<Citation>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsWebSearchResultLocationSerializationRoundtripWorks()
    {
        Citation value = new(
            new CitationsWebSearchResultLocation()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "title",
                Url = "url",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Citation>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsSearchResultLocationSerializationRoundtripWorks()
    {
        Citation value = new(
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
        var deserialized = JsonSerializer.Deserialize<Citation>(element);

        Assert.Equal(value, deserialized);
    }
}
