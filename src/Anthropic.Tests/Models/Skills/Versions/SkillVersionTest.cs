using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Skills.Versions;

namespace Anthropic.Tests.Models.Skills.Versions;

public class SkillVersionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Description = "description",
            Name = "name",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedSkillID = "skill_01JAbcdefghijklmnopqrstuvw";
        JsonElement expectedType = JsonSerializer.SerializeToElement("skill_version");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SkillVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Description = "description",
            Name = "name",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillVersion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SkillVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Description = "description",
            Name = "name",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillVersion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedSkillID = "skill_01JAbcdefghijklmnopqrstuvw";
        JsonElement expectedType = JsonSerializer.SerializeToElement("skill_version");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SkillVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Description = "description",
            Name = "name",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SkillVersion
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Description = "description",
            Name = "name",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
        };

        SkillVersion copied = new(model);

        Assert.Equal(model, copied);
    }
}
