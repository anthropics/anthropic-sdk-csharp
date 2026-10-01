using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CacheMissPreviousMessageNotFoundTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CacheMissPreviousMessageNotFound { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("previous_message_not_found");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CacheMissPreviousMessageNotFound { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissPreviousMessageNotFound>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CacheMissPreviousMessageNotFound { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissPreviousMessageNotFound>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("previous_message_not_found");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CacheMissPreviousMessageNotFound { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CacheMissPreviousMessageNotFound { };

        CacheMissPreviousMessageNotFound copied = new(model);

        Assert.Equal(model, copied);
    }
}
