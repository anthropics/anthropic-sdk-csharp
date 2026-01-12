using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextCitationParamTest : TestBase
{
    [Fact]
    public void CitationCharLocationValidationWorks()
    {
        TextCitationParam value = new(
            new CitationCharLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndCharIndex = 0,
                StartCharIndex = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationPageLocationValidationWorks()
    {
        TextCitationParam value = new(
            new CitationPageLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndPageNumber = 0,
                StartPageNumber = 1,
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationContentBlockLocationValidationWorks()
    {
        TextCitationParam value = new(
            new CitationContentBlockLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndBlockIndex = 0,
                StartBlockIndex = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationWebSearchResultLocationValidationWorks()
    {
        TextCitationParam value = new(
            new CitationWebSearchResultLocationParam()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "x",
                Url = "x",
            }
        );
        value.Validate();
    }

    [Fact]
    public void CitationSearchResultLocationValidationWorks()
    {
        TextCitationParam value = new(
            new CitationSearchResultLocationParam()
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
        TextCitationParam value = new(
            new CitationCharLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndCharIndex = 0,
                StartCharIndex = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationPageLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new(
            new CitationPageLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndPageNumber = 0,
                StartPageNumber = 1,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationContentBlockLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new(
            new CitationContentBlockLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndBlockIndex = 0,
                StartBlockIndex = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationWebSearchResultLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new(
            new CitationWebSearchResultLocationParam()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "x",
                Url = "x",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationSearchResultLocationSerializationRoundtripWorks()
    {
        TextCitationParam value = new(
            new CitationSearchResultLocationParam()
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
        var deserialized = JsonSerializer.Deserialize<TextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }
}
