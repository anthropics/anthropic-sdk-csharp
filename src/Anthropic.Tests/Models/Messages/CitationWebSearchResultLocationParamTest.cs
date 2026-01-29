using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationWebSearchResultLocationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };

        string expectedCitedText = "cited_text";
        string expectedEncryptedIndex = "encrypted_index";
        string expectedTitle = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_result_location");
        string expectedUrl = "x";

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedEncryptedIndex, model.EncryptedIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CitationWebSearchResultLocationParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CitationWebSearchResultLocationParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCitedText = "cited_text";
        string expectedEncryptedIndex = "encrypted_index";
        string expectedTitle = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_result_location");
        string expectedUrl = "x";

        Assert.Equal(expectedCitedText, deserialized.CitedText);
        Assert.Equal(expectedEncryptedIndex, deserialized.EncryptedIndex);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Url = "x",
        };

        CitationWebSearchResultLocationParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
