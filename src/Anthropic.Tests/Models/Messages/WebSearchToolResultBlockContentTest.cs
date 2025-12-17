using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void ErrorValidationWorks()
    {
        WebSearchToolResultBlockContent value = new(
            new WebSearchToolResultError(WebSearchToolResultErrorErrorCode.InvalidToolInput)
        );
        value.Validate();
    }

    [Fact]
    public void WebSearchResultBlocksValidationWorks()
    {
        WebSearchToolResultBlockContent value = new(
            [
                new WebSearchResultBlock()
                {
                    EncryptedContent = "encrypted_content",
                    PageAge = "page_age",
                    Title = "title",
                    URL = "url",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockContent value = new(
            new WebSearchToolResultError(WebSearchToolResultErrorErrorCode.InvalidToolInput)
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchResultBlocksSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockContent value = new(
            [
                new WebSearchResultBlock()
                {
                    EncryptedContent = "encrypted_content",
                    PageAge = "page_age",
                    Title = "title",
                    URL = "url",
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }
}
