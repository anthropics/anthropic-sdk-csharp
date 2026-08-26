using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaWorkspaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWorkspace
        {
            ID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
            CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DataResidency = new()
            {
                AllowedInferenceGeos = new Unrestricted(),
                DefaultInferenceGeo = "default_inference_geo",
                WorkspaceGeo = "workspace_geo",
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Name = "Workspace Name",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
        };

        string expectedID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z");
        string expectedCompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        BetaDataResidency expectedDataResidency = new()
        {
            AllowedInferenceGeos = new Unrestricted(),
            DefaultInferenceGeo = "default_inference_geo",
            WorkspaceGeo = "workspace_geo",
        };
        string expectedDisplayColor = "#6C5BB9";
        string expectedExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        string expectedName = "Workspace Name";
        Dictionary<string, string> expectedTags = new()
        {
            { "env", "prod" },
            { "team", "platform" },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedCompartmentID, model.CompartmentID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDataResidency, model.DataResidency);
        Assert.Equal(expectedDisplayColor, model.DisplayColor);
        Assert.Equal(expectedExternalKeyID, model.ExternalKeyID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        foreach (var item in expectedTags)
        {
            Assert.True(model.Tags.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Tags[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWorkspace
        {
            ID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
            CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DataResidency = new()
            {
                AllowedInferenceGeos = new Unrestricted(),
                DefaultInferenceGeo = "default_inference_geo",
                WorkspaceGeo = "workspace_geo",
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Name = "Workspace Name",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspace>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWorkspace
        {
            ID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
            CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DataResidency = new()
            {
                AllowedInferenceGeos = new Unrestricted(),
                DefaultInferenceGeo = "default_inference_geo",
                WorkspaceGeo = "workspace_geo",
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Name = "Workspace Name",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z");
        string expectedCompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        BetaDataResidency expectedDataResidency = new()
        {
            AllowedInferenceGeos = new Unrestricted(),
            DefaultInferenceGeo = "default_inference_geo",
            WorkspaceGeo = "workspace_geo",
        };
        string expectedDisplayColor = "#6C5BB9";
        string expectedExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        string expectedName = "Workspace Name";
        Dictionary<string, string> expectedTags = new()
        {
            { "env", "prod" },
            { "team", "platform" },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedCompartmentID, deserialized.CompartmentID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDataResidency, deserialized.DataResidency);
        Assert.Equal(expectedDisplayColor, deserialized.DisplayColor);
        Assert.Equal(expectedExternalKeyID, deserialized.ExternalKeyID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        foreach (var item in expectedTags)
        {
            Assert.True(deserialized.Tags.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Tags[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWorkspace
        {
            ID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
            CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DataResidency = new()
            {
                AllowedInferenceGeos = new Unrestricted(),
                DefaultInferenceGeo = "default_inference_geo",
                WorkspaceGeo = "workspace_geo",
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Name = "Workspace Name",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWorkspace
        {
            ID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
            CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DataResidency = new()
            {
                AllowedInferenceGeos = new Unrestricted(),
                DefaultInferenceGeo = "default_inference_geo",
                WorkspaceGeo = "workspace_geo",
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Name = "Workspace Name",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
        };

        BetaWorkspace copied = new(model);

        Assert.Equal(model, copied);
    }
}
