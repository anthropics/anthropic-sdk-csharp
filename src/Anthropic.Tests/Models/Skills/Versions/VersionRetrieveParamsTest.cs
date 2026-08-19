using System;
using Anthropic.Models.Skills.Versions;

namespace Anthropic.Tests.Models.Skills.Versions;

public class VersionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionRetrieveParams { SkillID = "skill_id", Version = "version" };

        string expectedSkillID = "skill_id";
        string expectedVersion = "version";

        Assert.Equal(expectedSkillID, parameters.SkillID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void Url_Works()
    {
        VersionRetrieveParams parameters = new() { SkillID = "skill_id", Version = "version" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/skills/skill_id/versions/version"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionRetrieveParams { SkillID = "skill_id", Version = "version" };

        VersionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
