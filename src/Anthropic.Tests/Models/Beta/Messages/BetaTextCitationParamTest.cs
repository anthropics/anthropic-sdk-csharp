using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextCitationParamTest : TestBase
{
    [Fact]
    public void CitationCharLocationValidationWorks()
    {
        BetaTextCitationParam value = new(
            new BetaCitationCharLocationParam()
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
        BetaTextCitationParam value = new(
            new BetaCitationPageLocationParam()
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
        BetaTextCitationParam value = new(
            new BetaCitationContentBlockLocationParam()
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
        BetaTextCitationParam value = new(
            new BetaCitationWebSearchResultLocationParam()
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
        BetaTextCitationParam value = new(
            new BetaCitationSearchResultLocationParam()
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
        BetaTextCitationParam value = new(
            new BetaCitationCharLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndCharIndex = 0,
                StartCharIndex = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationPageLocationSerializationRoundtripWorks()
    {
        BetaTextCitationParam value = new(
            new BetaCitationPageLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndPageNumber = 0,
                StartPageNumber = 1,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationContentBlockLocationSerializationRoundtripWorks()
    {
        BetaTextCitationParam value = new(
            new BetaCitationContentBlockLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndBlockIndex = 0,
                StartBlockIndex = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationWebSearchResultLocationSerializationRoundtripWorks()
    {
        BetaTextCitationParam value = new(
            new BetaCitationWebSearchResultLocationParam()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "x",
                Url = "x",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationSearchResultLocationSerializationRoundtripWorks()
    {
        BetaTextCitationParam value = new(
            new BetaCitationSearchResultLocationParam()
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
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(element);

        Assert.Equal(value, deserialized);
    }
}
