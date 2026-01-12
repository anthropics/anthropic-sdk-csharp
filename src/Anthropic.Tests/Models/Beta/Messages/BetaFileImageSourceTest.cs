using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFileImageSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFileImageSource { FileID = "file_id" };

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"file\"");

        Assert.Equal(expectedFileID, model.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFileImageSource { FileID = "file_id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaFileImageSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFileImageSource { FileID = "file_id" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaFileImageSource>(element);
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"file\"");

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFileImageSource { FileID = "file_id" };

        model.Validate();
    }
}
