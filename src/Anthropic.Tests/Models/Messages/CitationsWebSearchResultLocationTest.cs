using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationsWebSearchResultLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationsWebSearchResultLocation
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };

        string expectedCitedText = "cited_text";
        string expectedEncryptedIndex = "encrypted_index";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_result_location\""
        );
        string expectedUrl = "url";

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedEncryptedIndex, model.EncryptedIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CitationsWebSearchResultLocation
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CitationsWebSearchResultLocation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CitationsWebSearchResultLocation
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CitationsWebSearchResultLocation>(element);
        Assert.NotNull(deserialized);

        string expectedCitedText = "cited_text";
        string expectedEncryptedIndex = "encrypted_index";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_result_location\""
        );
        string expectedUrl = "url";

        Assert.Equal(expectedCitedText, deserialized.CitedText);
        Assert.Equal(expectedEncryptedIndex, deserialized.EncryptedIndex);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CitationsWebSearchResultLocation
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }
}
