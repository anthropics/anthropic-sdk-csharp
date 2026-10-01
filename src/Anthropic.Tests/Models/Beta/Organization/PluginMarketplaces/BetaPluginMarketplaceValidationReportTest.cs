using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class BetaPluginMarketplaceValidationReportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginMarketplaceValidationReport
        {
            CommitSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            ManifestError = "manifest_error",
            ManifestErrorCode = "marketplace_sync_manifest_not_found",
            PluginErrors =
            [
                new()
                {
                    Error = "error",
                    ErrorCode = "marketplace_sync_plugin_missing_manifest",
                    Name = "name",
                },
            ],
            PluginWarnings =
            [
                new()
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
                },
            ],
            Ref = "main",
            TotalPluginCount = 0,
            Valid = false,
        };

        string expectedCommitSha = "9fceb02d0ae598e95dc970b74767f19372d61af8";
        string expectedManifestError = "manifest_error";
        string expectedManifestErrorCode = "marketplace_sync_manifest_not_found";
        List<BetaPluginMarketplaceValidationPluginError> expectedPluginErrors =
        [
            new()
            {
                Error = "error",
                ErrorCode = "marketplace_sync_plugin_missing_manifest",
                Name = "name",
            },
        ];
        List<BetaPluginMarketplaceValidationPluginWarnings> expectedPluginWarnings =
        [
            new()
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
            },
        ];
        string expectedRef = "main";
        long expectedTotalPluginCount = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "plugin_marketplace_validation_report"
        );
        bool expectedValid = false;

        Assert.Equal(expectedCommitSha, model.CommitSha);
        Assert.Equal(expectedManifestError, model.ManifestError);
        Assert.Equal(expectedManifestErrorCode, model.ManifestErrorCode);
        Assert.Equal(expectedPluginErrors.Count, model.PluginErrors.Count);
        for (int i = 0; i < expectedPluginErrors.Count; i++)
        {
            Assert.Equal(expectedPluginErrors[i], model.PluginErrors[i]);
        }
        Assert.Equal(expectedPluginWarnings.Count, model.PluginWarnings.Count);
        for (int i = 0; i < expectedPluginWarnings.Count; i++)
        {
            Assert.Equal(expectedPluginWarnings[i], model.PluginWarnings[i]);
        }
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedTotalPluginCount, model.TotalPluginCount);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValid, model.Valid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginMarketplaceValidationReport
        {
            CommitSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            ManifestError = "manifest_error",
            ManifestErrorCode = "marketplace_sync_manifest_not_found",
            PluginErrors =
            [
                new()
                {
                    Error = "error",
                    ErrorCode = "marketplace_sync_plugin_missing_manifest",
                    Name = "name",
                },
            ],
            PluginWarnings =
            [
                new()
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
                },
            ],
            Ref = "main",
            TotalPluginCount = 0,
            Valid = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginMarketplaceValidationReport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginMarketplaceValidationReport
        {
            CommitSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            ManifestError = "manifest_error",
            ManifestErrorCode = "marketplace_sync_manifest_not_found",
            PluginErrors =
            [
                new()
                {
                    Error = "error",
                    ErrorCode = "marketplace_sync_plugin_missing_manifest",
                    Name = "name",
                },
            ],
            PluginWarnings =
            [
                new()
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
                },
            ],
            Ref = "main",
            TotalPluginCount = 0,
            Valid = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginMarketplaceValidationReport>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCommitSha = "9fceb02d0ae598e95dc970b74767f19372d61af8";
        string expectedManifestError = "manifest_error";
        string expectedManifestErrorCode = "marketplace_sync_manifest_not_found";
        List<BetaPluginMarketplaceValidationPluginError> expectedPluginErrors =
        [
            new()
            {
                Error = "error",
                ErrorCode = "marketplace_sync_plugin_missing_manifest",
                Name = "name",
            },
        ];
        List<BetaPluginMarketplaceValidationPluginWarnings> expectedPluginWarnings =
        [
            new()
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
            },
        ];
        string expectedRef = "main";
        long expectedTotalPluginCount = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "plugin_marketplace_validation_report"
        );
        bool expectedValid = false;

        Assert.Equal(expectedCommitSha, deserialized.CommitSha);
        Assert.Equal(expectedManifestError, deserialized.ManifestError);
        Assert.Equal(expectedManifestErrorCode, deserialized.ManifestErrorCode);
        Assert.Equal(expectedPluginErrors.Count, deserialized.PluginErrors.Count);
        for (int i = 0; i < expectedPluginErrors.Count; i++)
        {
            Assert.Equal(expectedPluginErrors[i], deserialized.PluginErrors[i]);
        }
        Assert.Equal(expectedPluginWarnings.Count, deserialized.PluginWarnings.Count);
        for (int i = 0; i < expectedPluginWarnings.Count; i++)
        {
            Assert.Equal(expectedPluginWarnings[i], deserialized.PluginWarnings[i]);
        }
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedTotalPluginCount, deserialized.TotalPluginCount);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValid, deserialized.Valid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginMarketplaceValidationReport
        {
            CommitSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            ManifestError = "manifest_error",
            ManifestErrorCode = "marketplace_sync_manifest_not_found",
            PluginErrors =
            [
                new()
                {
                    Error = "error",
                    ErrorCode = "marketplace_sync_plugin_missing_manifest",
                    Name = "name",
                },
            ],
            PluginWarnings =
            [
                new()
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
                },
            ],
            Ref = "main",
            TotalPluginCount = 0,
            Valid = false,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginMarketplaceValidationReport
        {
            CommitSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            ManifestError = "manifest_error",
            ManifestErrorCode = "marketplace_sync_manifest_not_found",
            PluginErrors =
            [
                new()
                {
                    Error = "error",
                    ErrorCode = "marketplace_sync_plugin_missing_manifest",
                    Name = "name",
                },
            ],
            PluginWarnings =
            [
                new()
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
                },
            ],
            Ref = "main",
            TotalPluginCount = 0,
            Valid = false,
        };

        BetaPluginMarketplaceValidationReport copied = new(model);

        Assert.Equal(model, copied);
    }
}
