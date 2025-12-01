using System.Collections.Generic;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestMCPServerToolConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestMCPServerToolConfiguration
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        List<string> expectedAllowedTools = ["string"];
        bool expectedEnabled = true;

        Assert.Equal(expectedAllowedTools.Count, model.AllowedTools.Count);
        for (int i = 0; i < expectedAllowedTools.Count; i++)
        {
            Assert.Equal(expectedAllowedTools[i], model.AllowedTools[i]);
        }
        Assert.Equal(expectedEnabled, model.Enabled);
    }
}
