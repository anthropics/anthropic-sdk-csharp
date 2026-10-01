using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Organization.ExternalKeys;

public class ExternalKeyAttachedAttachmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalKeyAttachedAttachment { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("attached");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalKeyAttachedAttachment { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyAttachedAttachment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalKeyAttachedAttachment { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyAttachedAttachment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("attached");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalKeyAttachedAttachment { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalKeyAttachedAttachment { };

        ExternalKeyAttachedAttachment copied = new(model);

        Assert.Equal(model, copied);
    }
}
