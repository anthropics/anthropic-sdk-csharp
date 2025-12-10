using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void errorValidation_Works()
    {
        WebSearchToolResultBlockContent value = new(
            new(WebSearchToolResultErrorErrorCode.InvalidToolInput)
        );
        value.Validate();
    }

    [Fact]
    public void WebSearchResultBlocksValidation_Works()
    {
        WebSearchToolResultBlockContent value = new(
            [
                new()
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
    public void errorSerializationRoundtrip_Works()
    {
        WebSearchToolResultBlockContent value = new(
            new(WebSearchToolResultErrorErrorCode.InvalidToolInput)
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchResultBlocksSerializationRoundtrip_Works()
    {
        WebSearchToolResultBlockContent value = new(
            [
                new()
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
