using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void itemValidation_Works()
    {
        WebSearchToolResultBlockParamContent value = new(
            [
                new()
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
    public void request_errorValidation_Works()
    {
        WebSearchToolResultBlockParamContent value = new(
            new WebSearchToolRequestError(ErrorCode.InvalidToolInput)
        );
        value.Validate();
    }

    [Fact]
    public void itemSerializationRoundtrip_Works()
    {
        WebSearchToolResultBlockParamContent value = new(
            [
                new()
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
    public void request_errorSerializationRoundtrip_Works()
    {
        WebSearchToolResultBlockParamContent value = new(
            new WebSearchToolRequestError(ErrorCode.InvalidToolInput)
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }
}
