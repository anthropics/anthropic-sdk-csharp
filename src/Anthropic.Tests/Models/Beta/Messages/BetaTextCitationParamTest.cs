using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextCitationParamTest : TestBase
{
    [Fact]
    public void CitationCharLocationValidationWorks()
    {
        BetaTextCitationParam value = new BetaCitationCharLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndCharIndex = 0,
            StartCharIndex = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CitationPageLocationValidationWorks()
    {
        BetaTextCitationParam value = new BetaCitationPageLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };
        value.Validate();
    }

    [Fact]
    public void CitationContentBlockLocationValidationWorks()
    {
        BetaTextCitationParam value = new BetaCitationContentBlockLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndBlockIndex = 0,
            StartBlockIndex = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CitationWebSearchResultLocationValidationWorks()
    {
        BetaTextCitationParam value = new BetaCitationWebSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };
        value.Validate();
    }

    [Fact]
    public void CitationSearchResultLocationValidationWorks()
    {
        BetaTextCitationParam value = new BetaCitationSearchResultLocationParam()
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
        BetaTextCitationParam value = new BetaCitationCharLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndCharIndex = 0,
            StartCharIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationPageLocationSerializationRoundtripWorks()
    {
        BetaTextCitationParam value = new BetaCitationPageLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationContentBlockLocationSerializationRoundtripWorks()
    {
        BetaTextCitationParam value = new BetaCitationContentBlockLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndBlockIndex = 0,
            StartBlockIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationWebSearchResultLocationSerializationRoundtripWorks()
    {
        BetaTextCitationParam value = new BetaCitationWebSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationSearchResultLocationSerializationRoundtripWorks()
    {
        BetaTextCitationParam value = new BetaCitationSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextCitationParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationCharLocationTypeWorks()
    {
        BetaTextCitationParam value = new BetaCitationCharLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndCharIndex = 0,
            StartCharIndex = 0,
        };
        Assert.Equal(BetaTextCitationParamType.CharLocation, value.Type.Value());
    }

    [Fact]
    public void CitationPageLocationTypeWorks()
    {
        BetaTextCitationParam value = new BetaCitationPageLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndPageNumber = 0,
            StartPageNumber = 1,
        };
        Assert.Equal(BetaTextCitationParamType.PageLocation, value.Type.Value());
    }

    [Fact]
    public void CitationContentBlockLocationTypeWorks()
    {
        BetaTextCitationParam value = new BetaCitationContentBlockLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            DocumentIndex = 0,
            DocumentTitle = "x",
            EndBlockIndex = 0,
            StartBlockIndex = 0,
        };
        Assert.Equal(BetaTextCitationParamType.ContentBlockLocation, value.Type.Value());
    }

    [Fact]
    public void CitationWebSearchResultLocationTypeWorks()
    {
        BetaTextCitationParam value = new BetaCitationWebSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };
        Assert.Equal(BetaTextCitationParamType.WebSearchResultLocation, value.Type.Value());
    }

    [Fact]
    public void CitationSearchResultLocationTypeWorks()
    {
        BetaTextCitationParam value = new BetaCitationSearchResultLocationParam()
        {
            CitedText = "The grass is green. The sky is blue.",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };
        Assert.Equal(BetaTextCitationParamType.SearchResultLocation, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaTextCitationParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cited_text": "The grass is green. The sky is blue.",
                  "document_index": 0,
                  "document_title": "x",
                  "type": "char_location",
                  "end_block_index": 0,
                  "start_block_index": 0,
                  "title": "x"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedCitedText = "The grass is green. The sky is blue.";
        long expectedDocumentIndex = 0;
        string expectedDocumentTitle = "x";
        ApiEnum<string, BetaTextCitationParamType> expectedType =
            BetaTextCitationParamType.CharLocation;
        long expectedEndBlockIndex = 0;
        long expectedStartBlockIndex = 0;
        string expectedTitle = "x";

        Assert.Equal(expectedCitedText, value.CitedText);
        Assert.Equal(expectedDocumentIndex, value.DocumentIndex);
        Assert.Equal(expectedDocumentTitle, value.DocumentTitle);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedEndBlockIndex, value.EndBlockIndex);
        Assert.Equal(expectedStartBlockIndex, value.StartBlockIndex);
        Assert.Equal(expectedTitle, value.Title);

        BetaTextCitationParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.CitedText);
        Assert.Null(emptyValue.DocumentIndex);
        Assert.Null(emptyValue.DocumentTitle);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.EndBlockIndex);
        Assert.Null(emptyValue.StartBlockIndex);
        Assert.Null(emptyValue.Title);

        BetaTextCitationParam mismatchedValue = new(
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
        Assert.Null(mismatchedValue.EndBlockIndex);
        Assert.Null(mismatchedValue.StartBlockIndex);
        Assert.Null(mismatchedValue.Title);
    }
}

public class BetaTextCitationParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaTextCitationParamType.CharLocation)]
    [InlineData(BetaTextCitationParamType.PageLocation)]
    [InlineData(BetaTextCitationParamType.ContentBlockLocation)]
    [InlineData(BetaTextCitationParamType.WebSearchResultLocation)]
    [InlineData(BetaTextCitationParamType.SearchResultLocation)]
    public void Validation_Works(BetaTextCitationParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTextCitationParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaTextCitationParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTextCitationParamType.CharLocation)]
    [InlineData(BetaTextCitationParamType.PageLocation)]
    [InlineData(BetaTextCitationParamType.ContentBlockLocation)]
    [InlineData(BetaTextCitationParamType.WebSearchResultLocation)]
    [InlineData(BetaTextCitationParamType.SearchResultLocation)]
    public void SerializationRoundtrip_Works(BetaTextCitationParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTextCitationParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaTextCitationParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaTextCitationParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaTextCitationParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
