using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCountTokensContextManagementResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCountTokensContextManagementResponse { OriginalInputTokens = 0 };

        long expectedOriginalInputTokens = 0;

        Assert.Equal(expectedOriginalInputTokens, model.OriginalInputTokens);
    }
}
