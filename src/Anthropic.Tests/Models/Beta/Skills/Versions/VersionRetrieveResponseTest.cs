using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Tests.Models.Beta.Skills.Versions;

public class VersionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionRetrieveResponse
        {
            ID = "skillver_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            Description = "A custom skill for doing something useful",
            Directory = "my-skill",
            Name = "my-skill",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
            Version = "1759178010641129",
        };

        string expectedID = "skillver_01JAbcdefghijklmnopqrstuvw";
        string expectedCreatedAt = "2024-10-30T23:58:27.427722Z";
        string expectedDescription = "A custom skill for doing something useful";
        string expectedDirectory = "my-skill";
        string expectedName = "my-skill";
        string expectedSkillID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedType = "type";
        string expectedVersion = "1759178010641129";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDirectory, model.Directory);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }
}
