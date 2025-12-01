using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillDeleteResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
        };

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }
}
