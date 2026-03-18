using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContainerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = BetaSkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string expectedID = "id";
        List<BetaSkillParams> expectedSkills =
        [
            new()
            {
                SkillID = "pdf",
                Type = BetaSkillParamsType.Anthropic,
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
        var model = new BetaContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = BetaSkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContainerParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = BetaSkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContainerParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<BetaSkillParams> expectedSkills =
        [
            new()
            {
                SkillID = "pdf",
                Type = BetaSkillParamsType.Anthropic,
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
        var model = new BetaContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = BetaSkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaContainerParams { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Skills);
        Assert.False(model.RawData.ContainsKey("skills"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaContainerParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaContainerParams { ID = null, Skills = null };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Skills);
        Assert.True(model.RawData.ContainsKey("skills"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaContainerParams { ID = null, Skills = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaContainerParams
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = BetaSkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        BetaContainerParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
