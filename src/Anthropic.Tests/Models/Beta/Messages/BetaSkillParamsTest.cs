using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSkillParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSkillParams
        {
            SkillID = "x",
            Type = BetaSkillParamsType.Anthropic,
            Version = "x",
        };

        string expectedSkillID = "x";
        ApiEnum<string, BetaSkillParamsType> expectedType = BetaSkillParamsType.Anthropic;
        string expectedVersion = "x";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSkillParams
        {
            SkillID = "x",
            Type = BetaSkillParamsType.Anthropic,
            Version = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaSkillParams>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSkillParams
        {
            SkillID = "x",
            Type = BetaSkillParamsType.Anthropic,
            Version = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaSkillParams>(json);
        Assert.NotNull(deserialized);

        string expectedSkillID = "x";
        ApiEnum<string, BetaSkillParamsType> expectedType = BetaSkillParamsType.Anthropic;
        string expectedVersion = "x";

        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSkillParams
        {
            SkillID = "x",
            Type = BetaSkillParamsType.Anthropic,
            Version = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaSkillParams { SkillID = "x", Type = BetaSkillParamsType.Anthropic };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaSkillParams { SkillID = "x", Type = BetaSkillParamsType.Anthropic };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaSkillParams
        {
            SkillID = "x",
            Type = BetaSkillParamsType.Anthropic,

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaSkillParams
        {
            SkillID = "x",
            Type = BetaSkillParamsType.Anthropic,

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        model.Validate();
    }
}
