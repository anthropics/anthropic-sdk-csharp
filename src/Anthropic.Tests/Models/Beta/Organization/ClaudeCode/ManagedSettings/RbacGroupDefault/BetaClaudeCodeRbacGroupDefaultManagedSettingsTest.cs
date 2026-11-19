using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroupDefault;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroupDefault;

public class BetaClaudeCodeRbacGroupDefaultManagedSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeCodeRbacGroupDefaultManagedSettings
        {
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_default_managed_settings"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.NotNull(model.Settings);
        Assert.Equal(expectedSettings.Count, model.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(model.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Settings[item.Key]));
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeCodeRbacGroupDefaultManagedSettings
        {
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupDefaultManagedSettings>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeCodeRbacGroupDefaultManagedSettings
        {
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupDefaultManagedSettings>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_default_managed_settings"
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.NotNull(deserialized.Settings);
        Assert.Equal(expectedSettings.Count, deserialized.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(deserialized.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Settings[item.Key]));
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeCodeRbacGroupDefaultManagedSettings
        {
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeCodeRbacGroupDefaultManagedSettings
        {
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaClaudeCodeRbacGroupDefaultManagedSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}
