using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationWebSearchResultLocationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            URL = "x",
        };

        string expectedCitedText = "cited_text";
        string expectedEncryptedIndex = "encrypted_index";
        string expectedTitle = "x";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_result_location\""
        );
        string expectedURL = "x";

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedEncryptedIndex, model.EncryptedIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            URL = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationWebSearchResultLocationParam>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            URL = "x",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationWebSearchResultLocationParam>(
            element
        );
        Assert.NotNull(deserialized);

        string expectedCitedText = "cited_text";
        string expectedEncryptedIndex = "encrypted_index";
        string expectedTitle = "x";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_result_location\""
        );
        string expectedURL = "x";

        Assert.Equal(expectedCitedText, deserialized.CitedText);
        Assert.Equal(expectedEncryptedIndex, deserialized.EncryptedIndex);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            URL = "x",
        };

        model.Validate();
    }
}
