using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContainerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Container
        {
            ID = "container_011CpZohnwH4vuy7gazohgSP",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = ContainerSkillType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string expectedID = "container_011CpZohnwH4vuy7gazohgSP";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ContainerSkill> expectedSkills =
        [
            new()
            {
                SkillID = "pdf",
                Type = ContainerSkillType.Anthropic,
                Version = "latest",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
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
        var model = new Container
        {
            ID = "container_011CpZohnwH4vuy7gazohgSP",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = ContainerSkillType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Container>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Container
        {
            ID = "container_011CpZohnwH4vuy7gazohgSP",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = ContainerSkillType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Container>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "container_011CpZohnwH4vuy7gazohgSP";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ContainerSkill> expectedSkills =
        [
            new()
            {
                SkillID = "pdf",
                Type = ContainerSkillType.Anthropic,
                Version = "latest",
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
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
        var model = new Container
        {
            ID = "container_011CpZohnwH4vuy7gazohgSP",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = ContainerSkillType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Container
        {
            ID = "container_011CpZohnwH4vuy7gazohgSP",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = ContainerSkillType.Anthropic,
                    Version = "latest",
                },
            ],
        };

        Container copied = new(model);

        Assert.Equal(model, copied);
    }
}
