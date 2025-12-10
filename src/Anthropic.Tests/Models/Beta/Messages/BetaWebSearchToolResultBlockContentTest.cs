using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void errorValidation_Works()
    {
        BetaWebSearchToolResultBlockContent value = new(
            new(BetaWebSearchToolResultErrorCode.InvalidToolInput)
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebSearchResultBlocksValidation_Works()
    {
        BetaWebSearchToolResultBlockContent value = new(
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
        BetaWebSearchToolResultBlockContent value = new(
            new(BetaWebSearchToolResultErrorCode.InvalidToolInput)
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebSearchResultBlocksSerializationRoundtrip_Works()
    {
        BetaWebSearchToolResultBlockContent value = new(
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
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }
}
