using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Tests.Models.Beta.Skills.Versions;

public class VersionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Description = "description",
                    Name = "name",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaSkillVersion> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Description = "description",
                Name = "name",
                SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Description = "description",
                    Name = "name",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Description = "description",
                    Name = "name",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaSkillVersion> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Description = "description",
                Name = "name",
                SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Description = "description",
                    Name = "name",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Description = "description",
                    Name = "name",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                },
            ],
            NextPage = "next_page",
        };

        VersionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
