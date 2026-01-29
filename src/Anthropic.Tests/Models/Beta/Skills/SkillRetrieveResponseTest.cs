using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillRetrieveResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedCreatedAt = "2024-10-30T23:58:27.427722Z";
        string expectedDisplayTitle = "My Custom Skill";
        string expectedLatestVersion = "1759178010641129";
        string expectedSource = "custom";
        string expectedType = "type";
        string expectedUpdatedAt = "2024-10-30T23:58:27.427722Z";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayTitle, model.DisplayTitle);
        Assert.Equal(expectedLatestVersion, model.LatestVersion);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SkillRetrieveResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SkillRetrieveResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedCreatedAt = "2024-10-30T23:58:27.427722Z";
        string expectedDisplayTitle = "My Custom Skill";
        string expectedLatestVersion = "1759178010641129";
        string expectedSource = "custom";
        string expectedType = "type";
        string expectedUpdatedAt = "2024-10-30T23:58:27.427722Z";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayTitle, deserialized.DisplayTitle);
        Assert.Equal(expectedLatestVersion, deserialized.LatestVersion);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SkillRetrieveResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SkillRetrieveResponse
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        SkillRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
