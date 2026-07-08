using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextCitationTest : TestBase
{
    [Fact]
    public void CitationCharLocationValidationWorks()
    {
        BetaTextCitation value = new BetaCitationCharLocation()
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
        BetaTextCitation value = new BetaCitationPageLocation()
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
        BetaTextCitation value = new BetaCitationContentBlockLocation()
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
        BetaTextCitation value = new BetaCitationsWebSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void CitationSearchResultLocationValidationWorks()
    {
        BetaTextCitation value = new BetaCitationSearchResultLocation()
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
        BetaTextCitation value = new BetaCitationCharLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndCharIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartCharIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationPageLocationSerializationRoundtripWorks()
    {
        BetaTextCitation value = new BetaCitationPageLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationContentBlockLocationSerializationRoundtripWorks()
    {
        BetaTextCitation value = new BetaCitationContentBlockLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsWebSearchResultLocationSerializationRoundtripWorks()
    {
        BetaTextCitation value = new BetaCitationsWebSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationSearchResultLocationSerializationRoundtripWorks()
    {
        BetaTextCitation value = new BetaCitationSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
