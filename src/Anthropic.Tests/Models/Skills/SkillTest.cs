using System;
using System.Text.Json;
using Anthropic.Core;
using Skills = Anthropic.Models.Skills;

namespace Anthropic.Tests.Models.Skills;

public class SkillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Skills::Skill
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            LatestVersionID = "latest_version_id",
            Source = new(Skills::Type.Custom),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "display_name";
        string expectedLatestVersionID = "latest_version_id";
        Skills::SkillSource expectedSource = new(Skills::Type.Custom);
        JsonElement expectedType = JsonSerializer.SerializeToElement("skill");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedLatestVersionID, model.LatestVersionID);
        Assert.Equal(expectedSource, model.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Skills::Skill
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            LatestVersionID = "latest_version_id",
            Source = new(Skills::Type.Custom),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skills::Skill>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Skills::Skill
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            LatestVersionID = "latest_version_id",
            Source = new(Skills::Type.Custom),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Skills::Skill>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "display_name";
        string expectedLatestVersionID = "latest_version_id";
        Skills::SkillSource expectedSource = new(Skills::Type.Custom);
        JsonElement expectedType = JsonSerializer.SerializeToElement("skill");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedLatestVersionID, deserialized.LatestVersionID);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Skills::Skill
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            LatestVersionID = "latest_version_id",
            Source = new(Skills::Type.Custom),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Skills::Skill
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            LatestVersionID = "latest_version_id",
            Source = new(Skills::Type.Custom),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        Skills::Skill copied = new(model);

        Assert.Equal(model, copied);
    }
}
