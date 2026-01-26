using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void ErrorValidationWorks()
    {
        BetaWebSearchToolResultBlockContent value = new BetaWebSearchToolResultError(
            BetaWebSearchToolResultErrorCode.InvalidToolInput
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
                    Url = "url",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockContent value = new BetaWebSearchToolResultError(
            BetaWebSearchToolResultErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

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
                    Url = "url",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
