using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaDeletedPluginTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDeletedPlugin { ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne" };

        string expectedID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDeletedPlugin { ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedPlugin>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDeletedPlugin { ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedPlugin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDeletedPlugin { ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDeletedPlugin { ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne" };

        BetaDeletedPlugin copied = new(model);

        Assert.Equal(model, copied);
    }
}
