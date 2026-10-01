using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CacheMissUnavailableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CacheMissUnavailable { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("unavailable");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CacheMissUnavailable { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissUnavailable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CacheMissUnavailable { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissUnavailable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("unavailable");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CacheMissUnavailable { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CacheMissUnavailable { };

        CacheMissUnavailable copied = new(model);

        Assert.Equal(model, copied);
    }
}
