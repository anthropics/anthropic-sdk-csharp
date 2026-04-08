using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAnthropicSkillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkill
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };

        string expectedSkillID = "xlsx";
        ApiEnum<string, BetaManagedAgentsAnthropicSkillType> expectedType =
            BetaManagedAgentsAnthropicSkillType.Anthropic;
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkill
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAnthropicSkill>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkill
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAnthropicSkill>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSkillID = "xlsx";
        ApiEnum<string, BetaManagedAgentsAnthropicSkillType> expectedType =
            BetaManagedAgentsAnthropicSkillType.Anthropic;
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkill
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkill
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillType.Anthropic,
            Version = "1",
        };

        BetaManagedAgentsAnthropicSkill copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAnthropicSkillTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAnthropicSkillType.Anthropic)]
    public void Validation_Works(BetaManagedAgentsAnthropicSkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAnthropicSkillType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAnthropicSkillType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAnthropicSkillType.Anthropic)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAnthropicSkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAnthropicSkillType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAnthropicSkillType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAnthropicSkillType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAnthropicSkillType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
