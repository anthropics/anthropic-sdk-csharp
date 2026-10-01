using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class BetaPluginMarketplaceValidationPluginErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginError
        {
            Error = "error",
            ErrorCode = "marketplace_sync_plugin_missing_manifest",
            Name = "name",
        };

        string expectedError = "error";
        string expectedErrorCode = "marketplace_sync_plugin_missing_manifest";
        string expectedName = "name";

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginError
        {
            Error = "error",
            ErrorCode = "marketplace_sync_plugin_missing_manifest",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginMarketplaceValidationPluginError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginError
        {
            Error = "error",
            ErrorCode = "marketplace_sync_plugin_missing_manifest",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginMarketplaceValidationPluginError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        string expectedErrorCode = "marketplace_sync_plugin_missing_manifest";
        string expectedName = "name";

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginError
        {
            Error = "error",
            ErrorCode = "marketplace_sync_plugin_missing_manifest",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginError
        {
            Error = "error",
            ErrorCode = "marketplace_sync_plugin_missing_manifest",
            Name = "name",
        };

        BetaPluginMarketplaceValidationPluginError copied = new(model);

        Assert.Equal(model, copied);
    }
}
