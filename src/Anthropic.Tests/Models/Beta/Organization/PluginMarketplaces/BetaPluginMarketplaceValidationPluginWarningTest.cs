using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class BetaPluginMarketplaceValidationPluginWarningTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarning
        {
            ErrorCode = "marketplace_sync_zipball_symlink_dangling",
            Message = "message",
        };

        string expectedErrorCode = "marketplace_sync_zipball_symlink_dangling";
        string expectedMessage = "message";

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarning
        {
            ErrorCode = "marketplace_sync_zipball_symlink_dangling",
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginMarketplaceValidationPluginWarning>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarning
        {
            ErrorCode = "marketplace_sync_zipball_symlink_dangling",
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginMarketplaceValidationPluginWarning>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedErrorCode = "marketplace_sync_zipball_symlink_dangling";
        string expectedMessage = "message";

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarning
        {
            ErrorCode = "marketplace_sync_zipball_symlink_dangling",
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarning
        {
            ErrorCode = "marketplace_sync_zipball_symlink_dangling",
            Message = "message",
        };

        BetaPluginMarketplaceValidationPluginWarning copied = new(model);

        Assert.Equal(model, copied);
    }
}
