using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SkillDeleteResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SkillDeleteResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SkillDeleteResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SkillDeleteResponse>(element);
        Assert.NotNull(deserialized);

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SkillDeleteResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
        };

        model.Validate();
    }
}
