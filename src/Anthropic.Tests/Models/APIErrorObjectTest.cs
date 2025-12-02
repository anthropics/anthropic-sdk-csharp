using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class APIErrorObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new APIErrorObject { Message = "message" };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new APIErrorObject { Message = "message" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<APIErrorObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new APIErrorObject { Message = "message" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<APIErrorObject>(json);
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new APIErrorObject { Message = "message" };

        model.Validate();
    }
}
