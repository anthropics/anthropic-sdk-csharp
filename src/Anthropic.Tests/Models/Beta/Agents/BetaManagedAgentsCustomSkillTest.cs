using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsCustomSkillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCustomSkill
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };

        string expectedSkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx";
        ApiEnum<string, BetaManagedAgentsCustomSkillType> expectedType =
            BetaManagedAgentsCustomSkillType.Custom;
        string expectedVersion = "2";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCustomSkill
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCustomSkill>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCustomSkill
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCustomSkill>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx";
        ApiEnum<string, BetaManagedAgentsCustomSkillType> expectedType =
            BetaManagedAgentsCustomSkillType.Custom;
        string expectedVersion = "2";

        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCustomSkill
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCustomSkill
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTlx",
            Type = BetaManagedAgentsCustomSkillType.Custom,
            Version = "2",
        };

        BetaManagedAgentsCustomSkill copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCustomSkillTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCustomSkillType.Custom)]
    public void Validation_Works(BetaManagedAgentsCustomSkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCustomSkillType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsCustomSkillType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCustomSkillType.Custom)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsCustomSkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCustomSkillType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCustomSkillType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsCustomSkillType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCustomSkillType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
