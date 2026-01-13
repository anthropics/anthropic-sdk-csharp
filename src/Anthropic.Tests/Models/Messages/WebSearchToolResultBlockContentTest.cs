using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void ErrorValidationWorks()
    {
        WebSearchToolResultBlockContent value = new WebSearchToolResultError(
            WebSearchToolResultErrorErrorCode.InvalidToolInput
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
                    Url = "url",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockContent value = new WebSearchToolResultError(
            WebSearchToolResultErrorErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockContent>(element);

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
                    Url = "url",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }
}
