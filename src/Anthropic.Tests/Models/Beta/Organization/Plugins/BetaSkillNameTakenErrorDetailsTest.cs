using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaSkillNameTakenErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSkillNameTakenErrorDetails { SkillName = "skill_name" };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("skill_name_taken");
        string expectedSkillName = "skill_name";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedSkillName, model.SkillName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSkillNameTakenErrorDetails { SkillName = "skill_name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSkillNameTakenErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSkillNameTakenErrorDetails { SkillName = "skill_name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSkillNameTakenErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("skill_name_taken");
        string expectedSkillName = "skill_name";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedSkillName, deserialized.SkillName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSkillNameTakenErrorDetails { SkillName = "skill_name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSkillNameTakenErrorDetails { SkillName = "skill_name" };

        BetaSkillNameTakenErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
