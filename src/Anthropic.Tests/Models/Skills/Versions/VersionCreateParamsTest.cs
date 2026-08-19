using System;
using System.Collections.Generic;
using System.Text;
using Anthropic.Core;
using Anthropic.Models.Skills.Versions;

namespace Anthropic.Tests.Models.Skills.Versions;

public class VersionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new VersionCreateParams { SkillID = "skill_id", Files = [files] };

        string expectedSkillID = "skill_id";
        List<BinaryContent> expectedFiles = [files];

        Assert.Equal(expectedSkillID, parameters.SkillID);
        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], parameters.Files[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        VersionCreateParams parameters = new()
        {
            SkillID = "skill_id",
            Files = [Encoding.UTF8.GetBytes("Example data")],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/skills/skill_id/versions"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Files = [Encoding.UTF8.GetBytes("Example data")],
        };

        VersionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
