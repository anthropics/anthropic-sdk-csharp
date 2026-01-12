using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchResultBlock
        {
            EncryptedContent = "encrypted_content",
            PageAge = "page_age",
            Title = "title",
            Url = "url",
        };

        string expectedEncryptedContent = "encrypted_content";
        string expectedPageAge = "page_age";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
        string expectedUrl = "url";

        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.Equal(expectedPageAge, model.PageAge);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebSearchResultBlock
        {
            EncryptedContent = "encrypted_content",
            PageAge = "page_age",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchResultBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebSearchResultBlock
        {
            EncryptedContent = "encrypted_content",
            PageAge = "page_age",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchResultBlock>(element);
        Assert.NotNull(deserialized);

        string expectedEncryptedContent = "encrypted_content";
        string expectedPageAge = "page_age";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
        string expectedUrl = "url";

        Assert.Equal(expectedEncryptedContent, deserialized.EncryptedContent);
        Assert.Equal(expectedPageAge, deserialized.PageAge);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebSearchResultBlock
        {
            EncryptedContent = "encrypted_content",
            PageAge = "page_age",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }
}
