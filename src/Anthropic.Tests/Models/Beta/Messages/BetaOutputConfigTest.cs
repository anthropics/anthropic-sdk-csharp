using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOutputConfig { Effort = Effort.Low };

        ApiEnum<string, Effort> expectedEffort = Effort.Low;

        Assert.Equal(expectedEffort, model.Effort);
    }
}
