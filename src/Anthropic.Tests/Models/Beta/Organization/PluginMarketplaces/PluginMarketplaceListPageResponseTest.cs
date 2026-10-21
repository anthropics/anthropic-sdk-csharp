using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class PluginMarketplaceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PluginMarketplaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    DefaultInstallationPreference =
                        BetaPluginMarketplaceDefaultInstallationPreference.Available,
                    LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
                    Name = "engineering-tools",
                    Owner = new BetaPluginOwnerOrganization(),
                    Source = BetaPluginMarketplaceSource.GitHub,
                    SyncStatus = SyncStatus.Success,
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        List<BetaPluginMarketplace> expectedData =
        [
            new()
            {
                ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                DefaultInstallationPreference =
                    BetaPluginMarketplaceDefaultInstallationPreference.Available,
                LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
                Name = "engineering-tools",
                Owner = new BetaPluginOwnerOrganization(),
                Source = BetaPluginMarketplaceSource.GitHub,
                SyncStatus = SyncStatus.Success,
            },
        ];
        string expectedNextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PluginMarketplaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    DefaultInstallationPreference =
                        BetaPluginMarketplaceDefaultInstallationPreference.Available,
                    LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
                    Name = "engineering-tools",
                    Owner = new BetaPluginOwnerOrganization(),
                    Source = BetaPluginMarketplaceSource.GitHub,
                    SyncStatus = SyncStatus.Success,
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PluginMarketplaceListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PluginMarketplaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    DefaultInstallationPreference =
                        BetaPluginMarketplaceDefaultInstallationPreference.Available,
                    LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
                    Name = "engineering-tools",
                    Owner = new BetaPluginOwnerOrganization(),
                    Source = BetaPluginMarketplaceSource.GitHub,
                    SyncStatus = SyncStatus.Success,
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PluginMarketplaceListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaPluginMarketplace> expectedData =
        [
            new()
            {
                ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                DefaultInstallationPreference =
                    BetaPluginMarketplaceDefaultInstallationPreference.Available,
                LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
                Name = "engineering-tools",
                Owner = new BetaPluginOwnerOrganization(),
                Source = BetaPluginMarketplaceSource.GitHub,
                SyncStatus = SyncStatus.Success,
            },
        ];
        string expectedNextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PluginMarketplaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    DefaultInstallationPreference =
                        BetaPluginMarketplaceDefaultInstallationPreference.Available,
                    LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
                    Name = "engineering-tools",
                    Owner = new BetaPluginOwnerOrganization(),
                    Source = BetaPluginMarketplaceSource.GitHub,
                    SyncStatus = SyncStatus.Success,
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PluginMarketplaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    DefaultInstallationPreference =
                        BetaPluginMarketplaceDefaultInstallationPreference.Available,
                    LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
                    Name = "engineering-tools",
                    Owner = new BetaPluginOwnerOrganization(),
                    Source = BetaPluginMarketplaceSource.GitHub,
                    SyncStatus = SyncStatus.Success,
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        PluginMarketplaceListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
