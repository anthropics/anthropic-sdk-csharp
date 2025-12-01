using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationsConfigParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationsConfigParam { Enabled = true };

        bool expectedEnabled = true;

        Assert.Equal(expectedEnabled, model.Enabled);
    }
}
