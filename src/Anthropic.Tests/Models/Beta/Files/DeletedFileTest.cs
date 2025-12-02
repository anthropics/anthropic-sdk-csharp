using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Tests.Models.Beta.Files;

public class DeletedFileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeletedFile { ID = "id", Type = Type.FileDeleted };

        string expectedID = "id";
        ApiEnum<string, Type> expectedType = Type.FileDeleted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeletedFile { ID = "id", Type = Type.FileDeleted };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DeletedFile>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeletedFile { ID = "id", Type = Type.FileDeleted };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DeletedFile>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Type> expectedType = Type.FileDeleted;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeletedFile { ID = "id", Type = Type.FileDeleted };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeletedFile { ID = "id" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeletedFile { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DeletedFile
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeletedFile
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }
}
