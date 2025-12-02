using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationConfig { Enabled = true };

        bool expectedEnabled = true;

        Assert.Equal(expectedEnabled, model.Enabled);
    }
}
