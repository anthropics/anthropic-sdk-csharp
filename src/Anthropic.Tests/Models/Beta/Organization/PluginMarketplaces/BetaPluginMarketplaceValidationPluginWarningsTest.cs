using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class BetaPluginMarketplaceValidationPluginWarningsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarnings
        {
            Name = "name",
            Warnings =
            [
                new()
                {
                    ErrorCode = "marketplace_sync_zipball_symlink_dangling",
                    Message = "message",
                },
            ],
        };

        string expectedName = "name";
        List<BetaPluginMarketplaceValidationPluginWarning> expectedWarnings =
        [
            new() { ErrorCode = "marketplace_sync_zipball_symlink_dangling", Message = "message" },
        ];

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedWarnings.Count, model.Warnings.Count);
        for (int i = 0; i < expectedWarnings.Count; i++)
        {
            Assert.Equal(expectedWarnings[i], model.Warnings[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarnings
        {
            Name = "name",
            Warnings =
            [
                new()
                {
                    ErrorCode = "marketplace_sync_zipball_symlink_dangling",
                    Message = "message",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaPluginMarketplaceValidationPluginWarnings>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarnings
        {
            Name = "name",
            Warnings =
            [
                new()
                {
                    ErrorCode = "marketplace_sync_zipball_symlink_dangling",
                    Message = "message",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaPluginMarketplaceValidationPluginWarnings>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        List<BetaPluginMarketplaceValidationPluginWarning> expectedWarnings =
        [
            new() { ErrorCode = "marketplace_sync_zipball_symlink_dangling", Message = "message" },
        ];

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedWarnings.Count, deserialized.Warnings.Count);
        for (int i = 0; i < expectedWarnings.Count; i++)
        {
            Assert.Equal(expectedWarnings[i], deserialized.Warnings[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarnings
        {
            Name = "name",
            Warnings =
            [
                new()
                {
                    ErrorCode = "marketplace_sync_zipball_symlink_dangling",
                    Message = "message",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginMarketplaceValidationPluginWarnings
        {
            Name = "name",
            Warnings =
            [
                new()
                {
                    ErrorCode = "marketplace_sync_zipball_symlink_dangling",
                    Message = "message",
                },
            ],
        };

        BetaPluginMarketplaceValidationPluginWarnings copied = new(model);

        Assert.Equal(model, copied);
    }
}
