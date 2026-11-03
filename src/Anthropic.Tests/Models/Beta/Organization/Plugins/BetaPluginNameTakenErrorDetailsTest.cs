using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaPluginNameTakenErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { PluginID = "plugin_id" };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("plugin_name_taken");
        string expectedPluginID = "plugin_id";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedPluginID, model.PluginID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { PluginID = "plugin_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginNameTakenErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { PluginID = "plugin_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginNameTakenErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("plugin_name_taken");
        string expectedPluginID = "plugin_id";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedPluginID, deserialized.PluginID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { PluginID = "plugin_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { };

        Assert.Null(model.PluginID);
        Assert.False(model.RawData.ContainsKey("plugin_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { PluginID = null };

        Assert.Null(model.PluginID);
        Assert.True(model.RawData.ContainsKey("plugin_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { PluginID = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginNameTakenErrorDetails { PluginID = "plugin_id" };

        BetaPluginNameTakenErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
