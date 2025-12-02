using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSkillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSkill
        {
            SkillID = "x",
            Type = Type.Anthropic,
            Version = "x",
        };

        string expectedSkillID = "x";
        ApiEnum<string, Type> expectedType = Type.Anthropic;
        string expectedVersion = "x";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }
}
