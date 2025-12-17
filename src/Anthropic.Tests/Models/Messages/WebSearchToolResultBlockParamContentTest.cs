using System.Text.Json;
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
                    URL = "url",
                    PageAge = "page_age",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void RequestErrorValidationWorks()
    {
        WebSearchToolResultBlockParamContent value = new(
            new WebSearchToolRequestError(ErrorCode.InvalidToolInput)
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
                    URL = "url",
                    PageAge = "page_age",
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequestErrorSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockParamContent value = new(
            new WebSearchToolRequestError(ErrorCode.InvalidToolInput)
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }
}
