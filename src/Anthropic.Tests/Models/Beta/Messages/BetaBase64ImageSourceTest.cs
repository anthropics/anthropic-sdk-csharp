using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBase64ImageSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBase64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.ImageJPEG;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"base64\"");

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBase64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBase64ImageSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBase64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBase64ImageSource>(json);
        Assert.NotNull(deserialized);

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.ImageJPEG;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"base64\"");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBase64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };

        model.Validate();
    }
}
