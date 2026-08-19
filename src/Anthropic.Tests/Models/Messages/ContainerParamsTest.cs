using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContainerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string expectedID = "id";
        List<SkillParams> expectedSkills =
        [
            new()
            {
                SkillID = "pdf",
                Type = SkillParamsType.Anthropic,
                Version = "latest",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Skills);
        Assert.Equal(expectedSkills.Count, model.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], model.Skills[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContainerParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContainerParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<SkillParams> expectedSkills =
        [
            new()
            {
                SkillID = "pdf",
                Type = SkillParamsType.Anthropic,
                Version = "latest",
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Skills);
        Assert.Equal(expectedSkills.Count, deserialized.Skills.Count);
        for (int i = 0; i < expectedSkills.Count; i++)
        {
            Assert.Equal(expectedSkills[i], deserialized.Skills[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContainerParams { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Skills);
        Assert.False(model.RawData.ContainsKey("skills"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContainerParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContainerParams { ID = null, Skills = null };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Skills);
        Assert.True(model.RawData.ContainsKey("skills"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContainerParams { ID = null, Skills = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        ContainerParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
