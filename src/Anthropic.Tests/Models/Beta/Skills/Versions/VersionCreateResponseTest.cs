using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Tests.Models.Beta.Skills.Versions;

public class VersionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionCreateResponse
        {
            ID = "skillver_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            Description = "A custom skill for doing something useful",
            Directory = "my-skill",
            Name = "my-skill",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
            Version = "1759178010641129",
        };

        string expectedID = "skillver_01JAbcdefghijklmnopqrstuvw";
        string expectedCreatedAt = "2024-10-30T23:58:27.427722Z";
        string expectedDescription = "A custom skill for doing something useful";
        string expectedDirectory = "my-skill";
        string expectedName = "my-skill";
        string expectedSkillID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedType = "type";
        string expectedVersion = "1759178010641129";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDirectory, model.Directory);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSkillID, model.SkillID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VersionCreateResponse
        {
            ID = "skillver_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            Description = "A custom skill for doing something useful",
            Directory = "my-skill",
            Name = "my-skill",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
            Version = "1759178010641129",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionCreateResponse
        {
            ID = "skillver_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            Description = "A custom skill for doing something useful",
            Directory = "my-skill",
            Name = "my-skill",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
            Version = "1759178010641129",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "skillver_01JAbcdefghijklmnopqrstuvw";
        string expectedCreatedAt = "2024-10-30T23:58:27.427722Z";
        string expectedDescription = "A custom skill for doing something useful";
        string expectedDirectory = "my-skill";
        string expectedName = "my-skill";
        string expectedSkillID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedType = "type";
        string expectedVersion = "1759178010641129";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDirectory, deserialized.Directory);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSkillID, deserialized.SkillID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VersionCreateResponse
        {
            ID = "skillver_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            Description = "A custom skill for doing something useful",
            Directory = "my-skill",
            Name = "my-skill",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
            Version = "1759178010641129",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VersionCreateResponse
        {
            ID = "skillver_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            Description = "A custom skill for doing something useful",
            Directory = "my-skill",
            Name = "my-skill",
            SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
            Type = "type",
            Version = "1759178010641129",
        };

        VersionCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
