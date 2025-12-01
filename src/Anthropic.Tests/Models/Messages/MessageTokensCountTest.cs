using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageTokensCountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageTokensCount { InputTokens = 2095 };

        long expectedInputTokens = 2095;

        Assert.Equal(expectedInputTokens, model.InputTokens);
    }
}
