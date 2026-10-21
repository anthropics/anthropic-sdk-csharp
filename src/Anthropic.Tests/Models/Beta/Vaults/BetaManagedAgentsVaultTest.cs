using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults;

namespace Anthropic.Tests.Models.Beta.Vaults;

public class BetaManagedAgentsVaultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsVault
        {
            ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string expectedID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDisplayName = "Example vault";
        Dictionary<string, string> expectedMetadata = new() { { "environment", "production" } };
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsVault
        {
            ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsVault>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsVault
        {
            ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsVault>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedDisplayName = "Example vault";
        Dictionary<string, string> expectedMetadata = new() { { "environment", "production" } };
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsVault
        {
            ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsVault
        {
            ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            ArchivedAt = null,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        BetaManagedAgentsVault copied = new(model);

        Assert.Equal(model, copied);
    }
}
