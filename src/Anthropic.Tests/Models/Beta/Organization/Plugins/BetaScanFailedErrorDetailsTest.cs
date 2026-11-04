using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaScanFailedErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaScanFailedErrorDetails { PluginVersionID = "plugin_version_id" };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("scan_failed");
        string expectedPluginVersionID = "plugin_version_id";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedPluginVersionID, model.PluginVersionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaScanFailedErrorDetails { PluginVersionID = "plugin_version_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaScanFailedErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaScanFailedErrorDetails { PluginVersionID = "plugin_version_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaScanFailedErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("scan_failed");
        string expectedPluginVersionID = "plugin_version_id";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedPluginVersionID, deserialized.PluginVersionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaScanFailedErrorDetails { PluginVersionID = "plugin_version_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaScanFailedErrorDetails { PluginVersionID = "plugin_version_id" };

        BetaScanFailedErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
