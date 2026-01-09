using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void ResultBlockValidationWorks()
    {
        BetaWebSearchToolResultBlockParamContent value = new(
            [
                new BetaWebSearchResultBlockParam()
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
        BetaWebSearchToolResultBlockParamContent value = new(
            new BetaWebSearchToolRequestError(BetaWebSearchToolResultErrorCode.InvalidToolInput)
        );
        value.Validate();
    }

    [Fact]
    public void ResultBlockSerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockParamContent value = new(
            [
                new BetaWebSearchResultBlockParam()
                {
                    EncryptedContent = "encrypted_content",
                    Title = "title",
                    URL = "url",
                    PageAge = "page_age",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParamContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequestErrorSerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockParamContent value = new(
            new BetaWebSearchToolRequestError(BetaWebSearchToolResultErrorCode.InvalidToolInput)
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParamContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }
}
