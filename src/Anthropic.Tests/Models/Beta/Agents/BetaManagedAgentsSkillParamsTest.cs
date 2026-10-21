using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsSkillParamsTest : TestBase
{
    [Fact]
    public void AnthropicValidationWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsAnthropicSkillParams()
        {
            SkillID = "xlsx",
            Version = "1",
        };
        value.Validate();
    }

    [Fact]
    public void CustomValidationWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsCustomSkillParams()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        value.Validate();
    }

    [Fact]
    public void AnthropicSerializationRoundtripWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsAnthropicSkillParams()
        {
            SkillID = "xlsx",
            Version = "1",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSkillParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CustomSerializationRoundtripWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsCustomSkillParams()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSkillParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnthropicTypeWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsAnthropicSkillParams()
        {
            SkillID = "xlsx",
            Version = "1",
        };
        Assert.Equal(BetaManagedAgentsSkillParamsType.Anthropic, value.Type.Value());
    }

    [Fact]
    public void CustomTypeWorks()
    {
        BetaManagedAgentsSkillParams value = new BetaManagedAgentsCustomSkillParams()
        {
            SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
            Version = "2",
        };
        Assert.Equal(BetaManagedAgentsSkillParamsType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSkillParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": "xlsx",
                  "type": "anthropic",
                  "version": "1"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedSkillID = "xlsx";
        ApiEnum<string, BetaManagedAgentsSkillParamsType> expectedType =
            BetaManagedAgentsSkillParamsType.Anthropic;
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, value.SkillID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedVersion, value.Version);

        BetaManagedAgentsSkillParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.SkillID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Version);

        BetaManagedAgentsSkillParams mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "skill_id": [
                    "invalid"
                  ],
                  "version": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.SkillID);
        Assert.Null(mismatchedValue.Version);
    }
}

public class BetaManagedAgentsSkillParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSkillParamsType.Anthropic)]
    [InlineData(BetaManagedAgentsSkillParamsType.Custom)]
    public void Validation_Works(BetaManagedAgentsSkillParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSkillParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSkillParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSkillParamsType.Anthropic)]
    [InlineData(BetaManagedAgentsSkillParamsType.Custom)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSkillParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSkillParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSkillParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSkillParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSkillParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
