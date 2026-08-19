using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContainerSkillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContainerSkill
        {
            SkillID = "pdf",
            Type = ContainerSkillType.Anthropic,
            Version = "latest",
        };

        string expectedSkillID = "pdf";
        ApiEnum<string, ContainerSkillType> expectedType = ContainerSkillType.Anthropic;
        string expectedVersion = "latest";

        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContainerSkill
        {
            SkillID = "pdf",
            Type = ContainerSkillType.Anthropic,
            Version = "latest",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContainerSkill>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContainerSkill
        {
            SkillID = "pdf",
            Type = ContainerSkillType.Anthropic,
            Version = "latest",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContainerSkill>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSkillID = "pdf";
        ApiEnum<string, ContainerSkillType> expectedType = ContainerSkillType.Anthropic;
        string expectedVersion = "latest";

        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContainerSkill
        {
            SkillID = "pdf",
            Type = ContainerSkillType.Anthropic,
            Version = "latest",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContainerSkill
        {
            SkillID = "pdf",
            Type = ContainerSkillType.Anthropic,
            Version = "latest",
        };

        ContainerSkill copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContainerSkillTypeTest : TestBase
{
    [Theory]
    [InlineData(ContainerSkillType.Anthropic)]
    [InlineData(ContainerSkillType.Custom)]
    public void Validation_Works(ContainerSkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContainerSkillType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContainerSkillType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContainerSkillType.Anthropic)]
    [InlineData(ContainerSkillType.Custom)]
    public void SerializationRoundtrip_Works(ContainerSkillType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContainerSkillType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContainerSkillType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContainerSkillType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContainerSkillType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
