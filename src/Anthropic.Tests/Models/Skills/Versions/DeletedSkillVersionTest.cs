using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Skills.Versions;

namespace Anthropic.Tests.Models.Skills.Versions;

public class DeletedSkillVersionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeletedSkillVersion { ID = "id" };

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("skill_version_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeletedSkillVersion { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeletedSkillVersion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeletedSkillVersion { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeletedSkillVersion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("skill_version_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeletedSkillVersion { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeletedSkillVersion { ID = "id" };

        DeletedSkillVersion copied = new(model);

        Assert.Equal(model, copied);
    }
}
