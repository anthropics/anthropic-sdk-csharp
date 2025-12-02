using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSkillParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSkillParams
        {
            SkillID = "x",
            Type = BetaSkillParamsType.Anthropic,
            Version = "x",
        };

        string expectedSkillID = "x";
        ApiEnum<string, BetaSkillParamsType> expectedType = BetaSkillParamsType.Anthropic;
        string expectedVersion = "x";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }
}
