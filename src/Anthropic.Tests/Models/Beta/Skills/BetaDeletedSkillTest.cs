using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class BetaDeletedSkillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDeletedSkill { ID = "skill_01JAbcdefghijklmnopqrstuvw" };

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        JsonElement expectedType = JsonSerializer.SerializeToElement("skill_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDeletedSkill { ID = "skill_01JAbcdefghijklmnopqrstuvw" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedSkill>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDeletedSkill { ID = "skill_01JAbcdefghijklmnopqrstuvw" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedSkill>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        JsonElement expectedType = JsonSerializer.SerializeToElement("skill_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDeletedSkill { ID = "skill_01JAbcdefghijklmnopqrstuvw" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDeletedSkill { ID = "skill_01JAbcdefghijklmnopqrstuvw" };

        BetaDeletedSkill copied = new(model);

        Assert.Equal(model, copied);
    }
}
