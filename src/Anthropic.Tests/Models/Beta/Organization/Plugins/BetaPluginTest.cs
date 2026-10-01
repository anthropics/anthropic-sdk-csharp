using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Plugins = Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaPluginTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plugins::BetaPlugin
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
        };

        string expectedID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        List<Plugins::BetaPluginComponent> expectedComponents =
        [
            new()
            {
                Description = "description",
                Name = "review-pr",
                Type = Plugins::Type.Skill,
            },
        ];
        Plugins::BetaPluginContentScan expectedContentScan = new()
        {
            Assessment = Plugins::Assessment.Warn,
            Reason = "credential-exposure",
            Status = Plugins::Status.Completed,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");
        Plugins::CreatedBy expectedCreatedBy = new Plugins::BetaPluginUserActor()
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string expectedDescription = "Reviews pull requests against your team's conventions.";
        string expectedDisplayName = "Code Review Helper";
        string expectedLatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8";
        string expectedManifestVersion = "1.2.0";
        string expectedMarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7";
        string expectedName = "code-review-helper";
        ApiEnum<
            string,
            Plugins::OrganizationInstallationPreference
        > expectedOrganizationInstallationPreference =
            Plugins::OrganizationInstallationPreference.Available;
        bool expectedOrganizationInstallationPreferenceInherited = true;
        Plugins::Owner expectedOwner = new Plugins::BetaPluginOwnerOrganization();
        ApiEnum<string, Plugins::Reach> expectedReach = Plugins::Reach.Contained;
        string expectedServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb";
        bool expectedServedVersionPinned = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Components);
        Assert.Equal(expectedComponents.Count, model.Components.Count);
        for (int i = 0; i < expectedComponents.Count; i++)
        {
            Assert.Equal(expectedComponents[i], model.Components[i]);
        }
        Assert.Equal(expectedContentScan, model.ContentScan);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedLatestVersionID, model.LatestVersionID);
        Assert.Equal(expectedManifestVersion, model.ManifestVersion);
        Assert.Equal(expectedMarketplaceID, model.MarketplaceID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(
            expectedOrganizationInstallationPreference,
            model.OrganizationInstallationPreference
        );
        Assert.Equal(
            expectedOrganizationInstallationPreferenceInherited,
            model.OrganizationInstallationPreferenceInherited
        );
        Assert.Equal(expectedOwner, model.Owner);
        Assert.Equal(expectedReach, model.Reach);
        Assert.Equal(expectedServedVersionID, model.ServedVersionID);
        Assert.Equal(expectedServedVersionPinned, model.ServedVersionPinned);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plugins::BetaPlugin
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plugins::BetaPlugin>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plugins::BetaPlugin
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plugins::BetaPlugin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        List<Plugins::BetaPluginComponent> expectedComponents =
        [
            new()
            {
                Description = "description",
                Name = "review-pr",
                Type = Plugins::Type.Skill,
            },
        ];
        Plugins::BetaPluginContentScan expectedContentScan = new()
        {
            Assessment = Plugins::Assessment.Warn,
            Reason = "credential-exposure",
            Status = Plugins::Status.Completed,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");
        Plugins::CreatedBy expectedCreatedBy = new Plugins::BetaPluginUserActor()
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string expectedDescription = "Reviews pull requests against your team's conventions.";
        string expectedDisplayName = "Code Review Helper";
        string expectedLatestVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8";
        string expectedManifestVersion = "1.2.0";
        string expectedMarketplaceID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7";
        string expectedName = "code-review-helper";
        ApiEnum<
            string,
            Plugins::OrganizationInstallationPreference
        > expectedOrganizationInstallationPreference =
            Plugins::OrganizationInstallationPreference.Available;
        bool expectedOrganizationInstallationPreferenceInherited = true;
        Plugins::Owner expectedOwner = new Plugins::BetaPluginOwnerOrganization();
        ApiEnum<string, Plugins::Reach> expectedReach = Plugins::Reach.Contained;
        string expectedServedVersionID = "pluginver_01K9wPcHd4Rm2Tx8Vq6Ln3Sb";
        bool expectedServedVersionPinned = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Components);
        Assert.Equal(expectedComponents.Count, deserialized.Components.Count);
        for (int i = 0; i < expectedComponents.Count; i++)
        {
            Assert.Equal(expectedComponents[i], deserialized.Components[i]);
        }
        Assert.Equal(expectedContentScan, deserialized.ContentScan);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedLatestVersionID, deserialized.LatestVersionID);
        Assert.Equal(expectedManifestVersion, deserialized.ManifestVersion);
        Assert.Equal(expectedMarketplaceID, deserialized.MarketplaceID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(
            expectedOrganizationInstallationPreference,
            deserialized.OrganizationInstallationPreference
        );
        Assert.Equal(
            expectedOrganizationInstallationPreferenceInherited,
            deserialized.OrganizationInstallationPreferenceInherited
        );
        Assert.Equal(expectedOwner, deserialized.Owner);
        Assert.Equal(expectedReach, deserialized.Reach);
        Assert.Equal(expectedServedVersionID, deserialized.ServedVersionID);
        Assert.Equal(expectedServedVersionPinned, deserialized.ServedVersionPinned);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plugins::BetaPlugin
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plugins::BetaPlugin
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
        };

        Plugins::BetaPlugin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void BetaPluginUserActorValidationWorks()
    {
        Plugins::CreatedBy value = new Plugins::BetaPluginUserActor()
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        value.Validate();
    }

    [Fact]
    public void BetaPluginApiActorValidationWorks()
    {
        Plugins::CreatedBy value = new Plugins::BetaPluginApiActor(
            "apikey_01Rj2N8SVvo6BePZj99NhmiT"
        );
        value.Validate();
    }

    [Fact]
    public void BetaPluginUserActorSerializationRoundtripWorks()
    {
        Plugins::CreatedBy value = new Plugins::BetaPluginUserActor()
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plugins::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginApiActorSerializationRoundtripWorks()
    {
        Plugins::CreatedBy value = new Plugins::BetaPluginApiActor(
            "apikey_01Rj2N8SVvo6BePZj99NhmiT"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plugins::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Plugins::CreatedBy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        Plugins::CreatedBy emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class OrganizationInstallationPreferenceTest : TestBase
{
    [Theory]
    [InlineData(Plugins::OrganizationInstallationPreference.AutoInstall)]
    [InlineData(Plugins::OrganizationInstallationPreference.Available)]
    [InlineData(Plugins::OrganizationInstallationPreference.NotAvailable)]
    [InlineData(Plugins::OrganizationInstallationPreference.Required)]
    public void Validation_Works(Plugins::OrganizationInstallationPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plugins::OrganizationInstallationPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Plugins::OrganizationInstallationPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plugins::OrganizationInstallationPreference.AutoInstall)]
    [InlineData(Plugins::OrganizationInstallationPreference.Available)]
    [InlineData(Plugins::OrganizationInstallationPreference.NotAvailable)]
    [InlineData(Plugins::OrganizationInstallationPreference.Required)]
    public void SerializationRoundtrip_Works(Plugins::OrganizationInstallationPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plugins::OrganizationInstallationPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Plugins::OrganizationInstallationPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Plugins::OrganizationInstallationPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Plugins::OrganizationInstallationPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OwnerTest : TestBase
{
    [Fact]
    public void BetaPluginOwnerOrganizationValidationWorks()
    {
        Plugins::Owner value = new Plugins::BetaPluginOwnerOrganization();
        value.Validate();
    }

    [Fact]
    public void BetaPluginOwnerUserValidationWorks()
    {
        Plugins::Owner value = new Plugins::BetaPluginOwnerUser("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void BetaPluginOwnerOrganizationSerializationRoundtripWorks()
    {
        Plugins::Owner value = new Plugins::BetaPluginOwnerOrganization();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plugins::Owner>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginOwnerUserSerializationRoundtripWorks()
    {
        Plugins::Owner value = new Plugins::BetaPluginOwnerUser("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plugins::Owner>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Plugins::Owner value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "organization"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        Plugins::Owner emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ReachTest : TestBase
{
    [Theory]
    [InlineData(Plugins::Reach.Contained)]
    [InlineData(Plugins::Reach.Privileged)]
    [InlineData(Plugins::Reach.Remote)]
    public void Validation_Works(Plugins::Reach rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plugins::Reach> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plugins::Reach>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plugins::Reach.Contained)]
    [InlineData(Plugins::Reach.Privileged)]
    [InlineData(Plugins::Reach.Remote)]
    public void SerializationRoundtrip_Works(Plugins::Reach rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plugins::Reach> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plugins::Reach>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plugins::Reach>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plugins::Reach>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
