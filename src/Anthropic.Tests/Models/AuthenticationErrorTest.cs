using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class AuthenticationErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthenticationError { Message = "message" };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.SerializeToElement("authentication_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuthenticationError { Message = "message" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthenticationError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuthenticationError { Message = "message" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthenticationError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.SerializeToElement("authentication_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuthenticationError { Message = "message" };

        model.Validate();
    }
}
