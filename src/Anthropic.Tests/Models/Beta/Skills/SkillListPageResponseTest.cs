using System.Collections.Generic;
using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    DisplayTitle = "My Custom Skill",
                    LatestVersion = "1759178010641129",
                    Source = "custom",
                    Type = "type",
                    UpdatedAt = "2024-10-30T23:58:27.427722Z",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<Data> expectedData =
        [
            new()
            {
                ID = "skill_01JAbcdefghijklmnopqrstuvw",
                CreatedAt = "2024-10-30T23:58:27.427722Z",
                DisplayTitle = "My Custom Skill",
                LatestVersion = "1759178010641129",
                Source = "custom",
                Type = "type",
                UpdatedAt = "2024-10-30T23:58:27.427722Z",
            },
        ];
        bool expectedHasMore = true;
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextPage, model.NextPage);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedCreatedAt = "2024-10-30T23:58:27.427722Z";
        string expectedDisplayTitle = "My Custom Skill";
        string expectedLatestVersion = "1759178010641129";
        string expectedSource = "custom";
        string expectedType = "type";
        string expectedUpdatedAt = "2024-10-30T23:58:27.427722Z";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayTitle, model.DisplayTitle);
        Assert.Equal(expectedLatestVersion, model.LatestVersion);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }
}
