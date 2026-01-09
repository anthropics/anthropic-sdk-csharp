using System.Text.Json;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaAuthenticationErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAuthenticationError { Message = "message" };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"authentication_error\""
        );

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAuthenticationError { Message = "message" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaAuthenticationError>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAuthenticationError { Message = "message" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaAuthenticationError>(element);
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"authentication_error\""
        );

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAuthenticationError { Message = "message" };

        model.Validate();
    }
}
