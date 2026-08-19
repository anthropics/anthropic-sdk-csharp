using System;
using Anthropic.Models.Skills;

namespace Anthropic.Tests.Models.Skills;

public class SkillRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SkillRetrieveParams { SkillID = "skill_id" };

        string expectedSkillID = "skill_id";

        Assert.Equal(expectedSkillID, parameters.SkillID);
    }

    [Fact]
    public void Url_Works()
    {
        SkillRetrieveParams parameters = new() { SkillID = "skill_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/skills/skill_id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillRetrieveParams { SkillID = "skill_id" };

        SkillRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
