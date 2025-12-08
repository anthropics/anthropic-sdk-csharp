using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            URL = "url",
            PageAge = "page_age",
        };

        string expectedEncryptedContent = "encrypted_content";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
        string expectedURL = "url";
        string expectedPageAge = "page_age";

        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedPageAge, model.PageAge);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            URL = "url",
            PageAge = "page_age",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            URL = "url",
            PageAge = "page_age",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchResultBlockParam>(json);
        Assert.NotNull(deserialized);

        string expectedEncryptedContent = "encrypted_content";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
        string expectedURL = "url";
        string expectedPageAge = "page_age";

        Assert.Equal(expectedEncryptedContent, deserialized.EncryptedContent);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedPageAge, deserialized.PageAge);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            URL = "url",
            PageAge = "page_age",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            URL = "url",
        };

        Assert.Null(model.PageAge);
        Assert.False(model.RawData.ContainsKey("page_age"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            URL = "url",

            PageAge = null,
        };

        Assert.Null(model.PageAge);
        Assert.True(model.RawData.ContainsKey("page_age"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            URL = "url",

            PageAge = null,
        };

        model.Validate();
    }
}
