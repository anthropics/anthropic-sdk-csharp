using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMessageTokensCountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageTokensCount { ContextManagement = new(0), InputTokens = 2095 };

        BetaCountTokensContextManagementResponse expectedContextManagement = new(0);
        long expectedInputTokens = 2095;

        Assert.Equal(expectedContextManagement, model.ContextManagement);
        Assert.Equal(expectedInputTokens, model.InputTokens);
    }
}
