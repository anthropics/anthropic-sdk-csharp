using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCacheCreationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCacheCreation
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        long expectedEphemeral1hInputTokens = 0;
        long expectedEphemeral5mInputTokens = 0;

        Assert.Equal(expectedEphemeral1hInputTokens, model.Ephemeral1hInputTokens);
        Assert.Equal(expectedEphemeral5mInputTokens, model.Ephemeral5mInputTokens);
    }
}
