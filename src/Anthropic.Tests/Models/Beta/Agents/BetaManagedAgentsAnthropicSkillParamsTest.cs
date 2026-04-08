using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAnthropicSkillParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
            Version = "1",
        };

        string expectedSkillID = "xlsx";
        ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType> expectedType =
            BetaManagedAgentsAnthropicSkillParamsType.Anthropic;
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
            Version = "1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAnthropicSkillParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
            Version = "1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAnthropicSkillParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSkillID = "xlsx";
        ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType> expectedType =
            BetaManagedAgentsAnthropicSkillParamsType.Anthropic;
        string expectedVersion = "1";

        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
            Version = "1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
        };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,

            Version = null,
        };

        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,

            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAnthropicSkillParams
        {
            SkillID = "xlsx",
            Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
            Version = "1",
        };

        BetaManagedAgentsAnthropicSkillParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAnthropicSkillParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAnthropicSkillParamsType.Anthropic)]
    public void Validation_Works(BetaManagedAgentsAnthropicSkillParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAnthropicSkillParamsType.Anthropic)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAnthropicSkillParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
