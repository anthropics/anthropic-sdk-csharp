using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextCitationParamTest : TestBase
{
    [Fact]
    public void citation_char_locationValidation_Works()
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
    public void citation_page_locationValidation_Works()
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
    public void citation_content_block_locationValidation_Works()
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
    public void citation_web_search_result_locationValidation_Works()
    {
        BetaTextCitationParam value = new(
            new BetaCitationWebSearchResultLocationParam()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "x",
                URL = "x",
            }
        );
        value.Validate();
    }

    [Fact]
    public void citation_search_result_locationValidation_Works()
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
    public void citation_char_locationSerializationRoundtrip_Works()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void citation_page_locationSerializationRoundtrip_Works()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void citation_content_block_locationSerializationRoundtrip_Works()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void citation_web_search_result_locationSerializationRoundtrip_Works()
    {
        BetaTextCitationParam value = new(
            new BetaCitationWebSearchResultLocationParam()
            {
                CitedText = "cited_text",
                EncryptedIndex = "encrypted_index",
                Title = "x",
                URL = "x",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void citation_search_result_locationSerializationRoundtrip_Works()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(json);

        Assert.Equal(value, deserialized);
    }
}
