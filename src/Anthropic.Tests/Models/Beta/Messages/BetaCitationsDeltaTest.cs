using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            },
        };

        Citation expectedCitation = new BetaCitationCharLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndCharIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartCharIndex = 0,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("citations_delta");

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
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCitationsDelta
        {
            Citation = new BetaCitationCharLocation()
            {
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Citation expectedCitation = new BetaCitationCharLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndCharIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartCharIndex = 0,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("citations_delta");

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
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCitationsDelta
        {
            Citation = new BetaCitationCharLocation()
            {
                CitedText = "The grass is green. The sky is blue.",
                DocumentIndex = 0,
                DocumentTitle = "My Document",
                EndCharIndex = 0,
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                StartCharIndex = 0,
            },
        };

        BetaCitationsDelta copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CitationTest : TestBase
{
    [Fact]
    public void BetaCitationCharLocationValidationWorks()
    {
        Citation value = new BetaCitationCharLocation()
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
    public void BetaCitationPageLocationValidationWorks()
    {
        Citation value = new BetaCitationPageLocation()
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
    public void BetaCitationContentBlockLocationValidationWorks()
    {
        Citation value = new BetaCitationContentBlockLocation()
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
    public void BetaCitationsWebSearchResultLocationValidationWorks()
    {
        Citation value = new BetaCitationsWebSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void BetaCitationSearchResultLocationValidationWorks()
    {
        Citation value = new BetaCitationSearchResultLocation()
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
    public void BetaCitationCharLocationSerializationRoundtripWorks()
    {
        Citation value = new BetaCitationCharLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndCharIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartCharIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCitationPageLocationSerializationRoundtripWorks()
    {
        Citation value = new BetaCitationPageLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCitationContentBlockLocationSerializationRoundtripWorks()
    {
        Citation value = new BetaCitationContentBlockLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCitationsWebSearchResultLocationSerializationRoundtripWorks()
    {
        Citation value = new BetaCitationsWebSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCitationSearchResultLocationSerializationRoundtripWorks()
    {
        Citation value = new BetaCitationSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCitationCharLocationTypeWorks()
    {
        Citation value = new BetaCitationCharLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndCharIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartCharIndex = 0,
        };
        Assert.Equal(CitationType.CharLocation, value.Type.Value());
    }

    [Fact]
    public void BetaCitationPageLocationTypeWorks()
    {
        Citation value = new BetaCitationPageLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndPageNumber = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartPageNumber = 1,
        };
        Assert.Equal(CitationType.PageLocation, value.Type.Value());
    }

    [Fact]
    public void BetaCitationContentBlockLocationTypeWorks()
    {
        Citation value = new BetaCitationContentBlockLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "My Document",
            EndBlockIndex = 0,
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            StartBlockIndex = 0,
        };
        Assert.Equal(CitationType.ContentBlockLocation, value.Type.Value());
    }

    [Fact]
    public void BetaCitationsWebSearchResultLocationTypeWorks()
    {
        Citation value = new BetaCitationsWebSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };
        Assert.Equal(CitationType.WebSearchResultLocation, value.Type.Value());
    }

    [Fact]
    public void BetaCitationSearchResultLocationTypeWorks()
    {
        Citation value = new BetaCitationSearchResultLocation()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        Assert.Equal(CitationType.SearchResultLocation, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Citation value = new(
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
        ApiEnum<string, CitationType> expectedType = CitationType.CharLocation;
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

        Citation emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.CitedText);
        Assert.Null(emptyValue.DocumentIndex);
        Assert.Null(emptyValue.DocumentTitle);
        Assert.Null(emptyValue.FileID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.EndBlockIndex);
        Assert.Null(emptyValue.StartBlockIndex);
        Assert.Null(emptyValue.Title);

        Citation mismatchedValue = new(
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

public class CitationTypeTest : TestBase
{
    [Theory]
    [InlineData(CitationType.CharLocation)]
    [InlineData(CitationType.PageLocation)]
    [InlineData(CitationType.ContentBlockLocation)]
    [InlineData(CitationType.WebSearchResultLocation)]
    [InlineData(CitationType.SearchResultLocation)]
    public void Validation_Works(CitationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CitationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CitationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CitationType.CharLocation)]
    [InlineData(CitationType.PageLocation)]
    [InlineData(CitationType.ContentBlockLocation)]
    [InlineData(CitationType.WebSearchResultLocation)]
    [InlineData(CitationType.SearchResultLocation)]
    public void SerializationRoundtrip_Works(CitationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CitationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CitationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CitationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CitationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
