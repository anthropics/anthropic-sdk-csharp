using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",
            PageAge = "page_age",
        };

        string expectedEncryptedContent = "encrypted_content";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_result");
        string expectedUrl = "url";
        string expectedPageAge = "page_age";

        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedPageAge, model.PageAge);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",
            PageAge = "page_age",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",
            PageAge = "page_age",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEncryptedContent = "encrypted_content";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_result");
        string expectedUrl = "url";
        string expectedPageAge = "page_age";

        Assert.Equal(expectedEncryptedContent, deserialized.EncryptedContent);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedPageAge, deserialized.PageAge);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",
            PageAge = "page_age",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",
        };

        Assert.Null(model.PageAge);
        Assert.False(model.RawData.ContainsKey("page_age"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",

            PageAge = null,
        };

        Assert.Null(model.PageAge);
        Assert.True(model.RawData.ContainsKey("page_age"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",

            PageAge = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Url = "url",
            PageAge = "page_age",
        };

        WebSearchResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
