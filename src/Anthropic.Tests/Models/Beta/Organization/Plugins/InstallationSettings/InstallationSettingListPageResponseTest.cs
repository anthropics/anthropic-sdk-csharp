using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.InstallationSettings;

public class InstallationSettingListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InstallationSettingListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    InstallationPreference =
                        BetaPluginInstallationSettingInstallationPreference.Required,
                    PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Target = new BetaPluginTargetOrganization(),
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        List<BetaPluginInstallationSetting> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                InstallationPreference =
                    BetaPluginInstallationSettingInstallationPreference.Required,
                PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                Target = new BetaPluginTargetOrganization(),
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
        var model = new InstallationSettingListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    InstallationPreference =
                        BetaPluginInstallationSettingInstallationPreference.Required,
                    PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Target = new BetaPluginTargetOrganization(),
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstallationSettingListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InstallationSettingListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    InstallationPreference =
                        BetaPluginInstallationSettingInstallationPreference.Required,
                    PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Target = new BetaPluginTargetOrganization(),
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstallationSettingListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaPluginInstallationSetting> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                InstallationPreference =
                    BetaPluginInstallationSettingInstallationPreference.Required,
                PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                Target = new BetaPluginTargetOrganization(),
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
        var model = new InstallationSettingListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    InstallationPreference =
                        BetaPluginInstallationSettingInstallationPreference.Required,
                    PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Target = new BetaPluginTargetOrganization(),
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
        var model = new InstallationSettingListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                    InstallationPreference =
                        BetaPluginInstallationSettingInstallationPreference.Required,
                    PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
                    Target = new BetaPluginTargetOrganization(),
                    UpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
                },
            ],
            NextPage = "page_MjAyNi0wOS0xNlQxNDowNTowOVo",
        };

        InstallationSettingListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
