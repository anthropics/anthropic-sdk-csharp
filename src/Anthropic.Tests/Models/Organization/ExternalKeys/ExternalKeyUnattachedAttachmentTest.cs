using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Organization.ExternalKeys;

public class ExternalKeyUnattachedAttachmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalKeyUnattachedAttachment { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("unattached");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalKeyUnattachedAttachment { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyUnattachedAttachment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalKeyUnattachedAttachment { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyUnattachedAttachment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("unattached");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalKeyUnattachedAttachment { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalKeyUnattachedAttachment { };

        ExternalKeyUnattachedAttachment copied = new(model);

        Assert.Equal(model, copied);
    }
}
