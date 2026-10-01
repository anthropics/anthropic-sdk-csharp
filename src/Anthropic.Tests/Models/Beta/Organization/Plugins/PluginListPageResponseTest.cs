using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Plugins = Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class PluginListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plugins::PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Components =
                    [
                        new()
                        {
                            Description = "description",
                            Name = "review-pr",
                            Type = Plugins::Type.Skill,
                        },
                    ],
                    ContentScan = new()
                    {
                        Assessment = Plugins::Assessment.Warn,
                        Reason = "credential-exposure",
                        Status = Plugins::Status.Completed,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    CreatedBy = new Plugins::BetaPluginUserActor()
                    {
                        EmailAddress = "user@example.com",
                        UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    },
                    Description = "Reviews pull requests against your team's conventions.",
                    DisplayName = "Code Review Helper",
                    LatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
                    ManifestVersion = "1.2.0",
                    MarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    Name = "code-review-helper",
                    OrganizationInstallationPreference =
                        Plugins::OrganizationInstallationPreference.Available,
                    OrganizationInstallationPreferenceInherited = true,
                    Owner = new Plugins::BetaPluginOwnerOrganization(),
                    Reach = Plugins::Reach.Contained,
                    ServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb",
                    ServedVersionPinned = true,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        List<Plugins::BetaPlugin> expectedData =
        [
            new()
            {
                ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                Components =
                [
                    new()
                    {
                        Description = "description",
                        Name = "review-pr",
                        Type = Plugins::Type.Skill,
                    },
                ],
                ContentScan = new()
                {
                    Assessment = Plugins::Assessment.Warn,
                    Reason = "credential-exposure",
                    Status = Plugins::Status.Completed,
                },
                CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                CreatedBy = new Plugins::BetaPluginUserActor()
                {
                    EmailAddress = "user@example.com",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Description = "Reviews pull requests against your team's conventions.",
                DisplayName = "Code Review Helper",
                LatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
                ManifestVersion = "1.2.0",
                MarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                Name = "code-review-helper",
                OrganizationInstallationPreference =
                    Plugins::OrganizationInstallationPreference.Available,
                OrganizationInstallationPreferenceInherited = true,
                Owner = new Plugins::BetaPluginOwnerOrganization(),
                Reach = Plugins::Reach.Contained,
                ServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb",
                ServedVersionPinned = true,
                UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
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
        var model = new Plugins::PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Components =
                    [
                        new()
                        {
                            Description = "description",
                            Name = "review-pr",
                            Type = Plugins::Type.Skill,
                        },
                    ],
                    ContentScan = new()
                    {
                        Assessment = Plugins::Assessment.Warn,
                        Reason = "credential-exposure",
                        Status = Plugins::Status.Completed,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    CreatedBy = new Plugins::BetaPluginUserActor()
                    {
                        EmailAddress = "user@example.com",
                        UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    },
                    Description = "Reviews pull requests against your team's conventions.",
                    DisplayName = "Code Review Helper",
                    LatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
                    ManifestVersion = "1.2.0",
                    MarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    Name = "code-review-helper",
                    OrganizationInstallationPreference =
                        Plugins::OrganizationInstallationPreference.Available,
                    OrganizationInstallationPreferenceInherited = true,
                    Owner = new Plugins::BetaPluginOwnerOrganization(),
                    Reach = Plugins::Reach.Contained,
                    ServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb",
                    ServedVersionPinned = true,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plugins::PluginListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plugins::PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Components =
                    [
                        new()
                        {
                            Description = "description",
                            Name = "review-pr",
                            Type = Plugins::Type.Skill,
                        },
                    ],
                    ContentScan = new()
                    {
                        Assessment = Plugins::Assessment.Warn,
                        Reason = "credential-exposure",
                        Status = Plugins::Status.Completed,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    CreatedBy = new Plugins::BetaPluginUserActor()
                    {
                        EmailAddress = "user@example.com",
                        UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    },
                    Description = "Reviews pull requests against your team's conventions.",
                    DisplayName = "Code Review Helper",
                    LatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
                    ManifestVersion = "1.2.0",
                    MarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    Name = "code-review-helper",
                    OrganizationInstallationPreference =
                        Plugins::OrganizationInstallationPreference.Available,
                    OrganizationInstallationPreferenceInherited = true,
                    Owner = new Plugins::BetaPluginOwnerOrganization(),
                    Reach = Plugins::Reach.Contained,
                    ServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb",
                    ServedVersionPinned = true,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plugins::PluginListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Plugins::BetaPlugin> expectedData =
        [
            new()
            {
                ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                Components =
                [
                    new()
                    {
                        Description = "description",
                        Name = "review-pr",
                        Type = Plugins::Type.Skill,
                    },
                ],
                ContentScan = new()
                {
                    Assessment = Plugins::Assessment.Warn,
                    Reason = "credential-exposure",
                    Status = Plugins::Status.Completed,
                },
                CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                CreatedBy = new Plugins::BetaPluginUserActor()
                {
                    EmailAddress = "user@example.com",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Description = "Reviews pull requests against your team's conventions.",
                DisplayName = "Code Review Helper",
                LatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
                ManifestVersion = "1.2.0",
                MarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                Name = "code-review-helper",
                OrganizationInstallationPreference =
                    Plugins::OrganizationInstallationPreference.Available,
                OrganizationInstallationPreferenceInherited = true,
                Owner = new Plugins::BetaPluginOwnerOrganization(),
                Reach = Plugins::Reach.Contained,
                ServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb",
                ServedVersionPinned = true,
                UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
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
        var model = new Plugins::PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Components =
                    [
                        new()
                        {
                            Description = "description",
                            Name = "review-pr",
                            Type = Plugins::Type.Skill,
                        },
                    ],
                    ContentScan = new()
                    {
                        Assessment = Plugins::Assessment.Warn,
                        Reason = "credential-exposure",
                        Status = Plugins::Status.Completed,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    CreatedBy = new Plugins::BetaPluginUserActor()
                    {
                        EmailAddress = "user@example.com",
                        UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    },
                    Description = "Reviews pull requests against your team's conventions.",
                    DisplayName = "Code Review Helper",
                    LatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
                    ManifestVersion = "1.2.0",
                    MarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    Name = "code-review-helper",
                    OrganizationInstallationPreference =
                        Plugins::OrganizationInstallationPreference.Available,
                    OrganizationInstallationPreferenceInherited = true,
                    Owner = new Plugins::BetaPluginOwnerOrganization(),
                    Reach = Plugins::Reach.Contained,
                    ServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb",
                    ServedVersionPinned = true,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plugins::PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Components =
                    [
                        new()
                        {
                            Description = "description",
                            Name = "review-pr",
                            Type = Plugins::Type.Skill,
                        },
                    ],
                    ContentScan = new()
                    {
                        Assessment = Plugins::Assessment.Warn,
                        Reason = "credential-exposure",
                        Status = Plugins::Status.Completed,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    CreatedBy = new Plugins::BetaPluginUserActor()
                    {
                        EmailAddress = "user@example.com",
                        UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    },
                    Description = "Reviews pull requests against your team's conventions.",
                    DisplayName = "Code Review Helper",
                    LatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
                    ManifestVersion = "1.2.0",
                    MarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
                    Name = "code-review-helper",
                    OrganizationInstallationPreference =
                        Plugins::OrganizationInstallationPreference.Available,
                    OrganizationInstallationPreferenceInherited = true,
                    Owner = new Plugins::BetaPluginOwnerOrganization(),
                    Reach = Plugins::Reach.Contained,
                    ServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb",
                    ServedVersionPinned = true,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        Plugins::PluginListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
