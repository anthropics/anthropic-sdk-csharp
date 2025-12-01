using System.Collections.Generic;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContainerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "x",
                    Type = BetaSkillParamsType.Anthropic,
                    Version = "x",
                },
            ],
        };

        string expectedID = "id";
        List<BetaSkillParams> expectedSkills =
        [
            new()
            {
                SkillID = "x",
                Type = BetaSkillParamsType.Anthropic,
                Version = "x",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSkills.Count, model.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], model.Skills[i]);
        }
    }
}
