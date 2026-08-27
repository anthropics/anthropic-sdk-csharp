using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Skills = Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Skills::SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    LatestVersionID = "latest_version_id",
                    Source = new(Skills::Type.Custom),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        List<Skills::BetaSkill> expectedData =
        [
            new()
            {
                ID = "skill_01JAbcdefghijklmnopqrstuvw",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                DisplayName = "display_name",
                LatestVersionID = "latest_version_id",
                Source = new(Skills::Type.Custom),
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
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
        var model = new Skills::SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    LatestVersionID = "latest_version_id",
                    Source = new(Skills::Type.Custom),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skills::SkillListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Skills::SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    LatestVersionID = "latest_version_id",
                    Source = new(Skills::Type.Custom),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skills::SkillListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Skills::BetaSkill> expectedData =
        [
            new()
            {
                ID = "skill_01JAbcdefghijklmnopqrstuvw",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                DisplayName = "display_name",
                LatestVersionID = "latest_version_id",
                Source = new(Skills::Type.Custom),
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
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
        var model = new Skills::SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    LatestVersionID = "latest_version_id",
                    Source = new(Skills::Type.Custom),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Skills::SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DisplayName = "display_name",
                    LatestVersionID = "latest_version_id",
                    Source = new(Skills::Type.Custom),
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            NextPage = "next_page",
        };

        Skills::SkillListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
