using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins.Versions;
using Plugins = Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.Versions;

public class BetaPluginVersionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginVersion
        {
            ID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
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
            ManifestVersion = "1.2.0",
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Reach = Reach.Contained,
            ReleaseNotes = "Adds a review checklist for database migrations.",
        };

        string expectedID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8";
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
        CreatedBy expectedCreatedBy = new Plugins::BetaPluginUserActor()
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string expectedDescription = "Reviews pull requests against your team's conventions.";
        string expectedDisplayName = "Code Review Helper";
        string expectedManifestVersion = "1.2.0";
        string expectedPluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        ApiEnum<string, Reach> expectedReach = Reach.Contained;
        string expectedReleaseNotes = "Adds a review checklist for database migrations.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_version");

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
        Assert.Equal(expectedManifestVersion, model.ManifestVersion);
        Assert.Equal(expectedPluginID, model.PluginID);
        Assert.Equal(expectedReach, model.Reach);
        Assert.Equal(expectedReleaseNotes, model.ReleaseNotes);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginVersion
        {
            ID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
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
            ManifestVersion = "1.2.0",
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Reach = Reach.Contained,
            ReleaseNotes = "Adds a review checklist for database migrations.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginVersion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginVersion
        {
            ID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
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
            ManifestVersion = "1.2.0",
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Reach = Reach.Contained,
            ReleaseNotes = "Adds a review checklist for database migrations.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginVersion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8";
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
        CreatedBy expectedCreatedBy = new Plugins::BetaPluginUserActor()
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string expectedDescription = "Reviews pull requests against your team's conventions.";
        string expectedDisplayName = "Code Review Helper";
        string expectedManifestVersion = "1.2.0";
        string expectedPluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        ApiEnum<string, Reach> expectedReach = Reach.Contained;
        string expectedReleaseNotes = "Adds a review checklist for database migrations.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_version");

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
        Assert.Equal(expectedManifestVersion, deserialized.ManifestVersion);
        Assert.Equal(expectedPluginID, deserialized.PluginID);
        Assert.Equal(expectedReach, deserialized.Reach);
        Assert.Equal(expectedReleaseNotes, deserialized.ReleaseNotes);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginVersion
        {
            ID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
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
            ManifestVersion = "1.2.0",
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Reach = Reach.Contained,
            ReleaseNotes = "Adds a review checklist for database migrations.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginVersion
        {
            ID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8",
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
            ManifestVersion = "1.2.0",
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Reach = Reach.Contained,
            ReleaseNotes = "Adds a review checklist for database migrations.",
        };

        BetaPluginVersion copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void BetaPluginUserActorValidationWorks()
    {
        CreatedBy value = new Plugins::BetaPluginUserActor()
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        value.Validate();
    }

    [Fact]
    public void BetaPluginApiActorValidationWorks()
    {
        CreatedBy value = new Plugins::BetaPluginApiActor("apikey_01Rj2N8SVvo6BePZj99NhmiT");
        value.Validate();
    }

    [Fact]
    public void BetaPluginUserActorSerializationRoundtripWorks()
    {
        CreatedBy value = new Plugins::BetaPluginUserActor()
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginApiActorSerializationRoundtripWorks()
    {
        CreatedBy value = new Plugins::BetaPluginApiActor("apikey_01Rj2N8SVvo6BePZj99NhmiT");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        CreatedBy value = new(
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

        CreatedBy emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ReachTest : TestBase
{
    [Theory]
    [InlineData(Reach.Contained)]
    [InlineData(Reach.Privileged)]
    [InlineData(Reach.Remote)]
    public void Validation_Works(Reach rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reach> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reach>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reach.Contained)]
    [InlineData(Reach.Privileged)]
    [InlineData(Reach.Remote)]
    public void SerializationRoundtrip_Works(Reach rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reach> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reach>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reach>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reach>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
