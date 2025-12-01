using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillRetrieveResponse
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
