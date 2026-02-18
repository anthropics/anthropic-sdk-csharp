using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void ItemValidationWorks()
    {
        WebSearchToolResultBlockParamContent value = new(
            [
                new WebSearchResultBlockParam()
                {
                    EncryptedContent = "encrypted_content",
                    Title = "title",
                    Url = "url",
                    PageAge = "page_age",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void RequestErrorValidationWorks()
    {
        WebSearchToolResultBlockParamContent value = new WebSearchToolRequestError(
            WebSearchToolResultErrorCode.InvalidToolInput
        );
        value.Validate();
    }

    [Fact]
    public void ItemSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockParamContent value = new(
            [
                new WebSearchResultBlockParam()
                {
                    EncryptedContent = "encrypted_content",
                    Title = "title",
                    Url = "url",
                    PageAge = "page_age",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequestErrorSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockParamContent value = new WebSearchToolRequestError(
            WebSearchToolResultErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
