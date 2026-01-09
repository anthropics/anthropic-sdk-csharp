using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void ErrorValidationWorks()
    {
        BetaWebSearchToolResultBlockContent value = new(
            new BetaWebSearchToolResultError(BetaWebSearchToolResultErrorCode.InvalidToolInput)
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebSearchResultBlocksValidationWorks()
    {
        BetaWebSearchToolResultBlockContent value = new(
            [
                new BetaWebSearchResultBlock()
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
        BetaWebSearchToolResultBlockContent value = new(
            new BetaWebSearchToolResultError(BetaWebSearchToolResultErrorCode.InvalidToolInput)
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebSearchResultBlocksSerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockContent value = new(
            [
                new BetaWebSearchResultBlock()
                {
                    EncryptedContent = "encrypted_content",
                    PageAge = "page_age",
                    Title = "title",
                    URL = "url",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }
}
