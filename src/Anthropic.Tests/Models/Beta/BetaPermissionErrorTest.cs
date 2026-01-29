using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaPermissionErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPermissionError { Message = "message" };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.SerializeToElement("permission_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPermissionError { Message = "message" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPermissionError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPermissionError { Message = "message" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPermissionError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.SerializeToElement("permission_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPermissionError { Message = "message" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPermissionError { Message = "message" };

        BetaPermissionError copied = new(model);

        Assert.Equal(model, copied);
    }
}
