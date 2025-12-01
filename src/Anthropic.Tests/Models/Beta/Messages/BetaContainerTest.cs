using System;
using System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContainerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Messages::BetaContainer
        {
            ID = "id",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Skills =
            [
                new()
                {
                    SkillID = "x",
                    Type = Messages::Type.Anthropic,
                    Version = "x",
                },
            ],
        };

        string expectedID = "id";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Messages::BetaSkill> expectedSkills =
        [
            new()
            {
                SkillID = "x",
                Type = Messages::Type.Anthropic,
                Version = "x",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedSkills.Count, model.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], model.Skills[i]);
        }
    }
}
