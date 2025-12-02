using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSkillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSkill
        {
            SkillID = "x",
            Type = Type.Anthropic,
            Version = "x",
        };

        string expectedSkillID = "x";
        ApiEnum<string, Type> expectedType = Type.Anthropic;
        string expectedVersion = "x";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSkill
        {
            SkillID = "x",
            Type = Type.Anthropic,
            Version = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaSkill>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSkill
        {
            SkillID = "x",
            Type = Type.Anthropic,
            Version = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaSkill>(json);
        Assert.NotNull(deserialized);

        string expectedSkillID = "x";
        ApiEnum<string, Type> expectedType = Type.Anthropic;
        string expectedVersion = "x";

        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSkill
        {
            SkillID = "x",
            Type = Type.Anthropic,
            Version = "x",
        };

        model.Validate();
    }
}
