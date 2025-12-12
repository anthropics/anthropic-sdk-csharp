using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void result_blockValidation_Works()
    {
        BetaWebSearchToolResultBlockParamContent value = new(
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
        BetaWebSearchToolResultBlockParamContent value = new(
            new BetaWebSearchToolRequestError(BetaWebSearchToolResultErrorCode.InvalidToolInput)
        );
        value.Validate();
    }

    [Fact]
    public void result_blockSerializationRoundtrip_Works()
    {
        BetaWebSearchToolResultBlockParamContent value = new(
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
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParamContent>(
            json
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void request_errorSerializationRoundtrip_Works()
    {
        BetaWebSearchToolResultBlockParamContent value = new(
            new BetaWebSearchToolRequestError(BetaWebSearchToolResultErrorCode.InvalidToolInput)
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParamContent>(
            json
        );

        Assert.Equal(value, deserialized);
    }
}
