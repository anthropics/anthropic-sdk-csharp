using System;
using System.Collections.Generic;
using System.Text;
using Anthropic.Core;
using Anthropic.Models.Skills;

namespace Anthropic.Tests.Models.Skills;

public class SkillCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams { Files = [files], DisplayName = "display_name" };

        List<BinaryContent> expectedFiles = [files];
        string expectedDisplayName = "display_name";

        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], parameters.Files[i]);
        }
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams { Files = [files] };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams
        {
            Files = [files],

            DisplayName = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void Url_Works()
    {
        SkillCreateParams parameters = new() { Files = [Encoding.UTF8.GetBytes("Example data")] };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/skills"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillCreateParams
        {
            Files = [Encoding.UTF8.GetBytes("Example data")],
            DisplayName = "display_name",
        };

        SkillCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
