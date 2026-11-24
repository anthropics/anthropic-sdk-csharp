using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Workspaces = Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class WorkspaceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Workspaces::WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
                    ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
                    CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DataResidency = new()
                    {
                        AllowedInferenceGeos = new Workspaces::Unrestricted(),
                        DefaultInferenceGeo = Workspaces::DefaultInferenceGeo.Global,
                        WorkspaceGeo = Workspaces::WorkspaceGeo.Us,
                    },
                    DisplayColor = "#6C5BB9",
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Name = "Workspace Name",
                    Tags = new Dictionary<string, string>()
                    {
                        { "env", "prod" },
                        { "team", "platform" },
                    },
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                    InferenceDataPrivacy = new()
                    {
                        HumanReview = new(Workspaces::Type.Disabled),
                        SafeguardsStorage = new Workspaces::BetaInternalStorage(),
                        TranscriptsStorage = new Workspaces::BetaInternalStorage(),
                    },
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        List<Workspaces::BetaWorkspace> expectedData =
        [
            new()
            {
                ID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
                ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
                CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                DataResidency = new()
                {
                    AllowedInferenceGeos = new Workspaces::Unrestricted(),
                    DefaultInferenceGeo = Workspaces::DefaultInferenceGeo.Global,
                    WorkspaceGeo = Workspaces::WorkspaceGeo.Us,
                },
                DisplayColor = "#6C5BB9",
                ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                Name = "Workspace Name",
                Tags = new Dictionary<string, string>()
                {
                    { "env", "prod" },
                    { "team", "platform" },
                },
                UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                InferenceDataPrivacy = new()
                {
                    HumanReview = new(Workspaces::Type.Disabled),
                    SafeguardsStorage = new Workspaces::BetaInternalStorage(),
                    TranscriptsStorage = new Workspaces::BetaInternalStorage(),
                },
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedFirstID, model.FirstID);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLastID, model.LastID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Workspaces::WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
                    ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
                    CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DataResidency = new()
                    {
                        AllowedInferenceGeos = new Workspaces::Unrestricted(),
                        DefaultInferenceGeo = Workspaces::DefaultInferenceGeo.Global,
                        WorkspaceGeo = Workspaces::WorkspaceGeo.Us,
                    },
                    DisplayColor = "#6C5BB9",
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Name = "Workspace Name",
                    Tags = new Dictionary<string, string>()
                    {
                        { "env", "prod" },
                        { "team", "platform" },
                    },
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                    InferenceDataPrivacy = new()
                    {
                        HumanReview = new(Workspaces::Type.Disabled),
                        SafeguardsStorage = new Workspaces::BetaInternalStorage(),
                        TranscriptsStorage = new Workspaces::BetaInternalStorage(),
                    },
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Workspaces::WorkspaceListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Workspaces::WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
                    ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
                    CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DataResidency = new()
                    {
                        AllowedInferenceGeos = new Workspaces::Unrestricted(),
                        DefaultInferenceGeo = Workspaces::DefaultInferenceGeo.Global,
                        WorkspaceGeo = Workspaces::WorkspaceGeo.Us,
                    },
                    DisplayColor = "#6C5BB9",
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Name = "Workspace Name",
                    Tags = new Dictionary<string, string>()
                    {
                        { "env", "prod" },
                        { "team", "platform" },
                    },
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                    InferenceDataPrivacy = new()
                    {
                        HumanReview = new(Workspaces::Type.Disabled),
                        SafeguardsStorage = new Workspaces::BetaInternalStorage(),
                        TranscriptsStorage = new Workspaces::BetaInternalStorage(),
                    },
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Workspaces::WorkspaceListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Workspaces::BetaWorkspace> expectedData =
        [
            new()
            {
                ID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
                ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
                CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                DataResidency = new()
                {
                    AllowedInferenceGeos = new Workspaces::Unrestricted(),
                    DefaultInferenceGeo = Workspaces::DefaultInferenceGeo.Global,
                    WorkspaceGeo = Workspaces::WorkspaceGeo.Us,
                },
                DisplayColor = "#6C5BB9",
                ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                Name = "Workspace Name",
                Tags = new Dictionary<string, string>()
                {
                    { "env", "prod" },
                    { "team", "platform" },
                },
                UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                InferenceDataPrivacy = new()
                {
                    HumanReview = new(Workspaces::Type.Disabled),
                    SafeguardsStorage = new Workspaces::BetaInternalStorage(),
                    TranscriptsStorage = new Workspaces::BetaInternalStorage(),
                },
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedFirstID, deserialized.FirstID);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLastID, deserialized.LastID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Workspaces::WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
                    ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
                    CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DataResidency = new()
                    {
                        AllowedInferenceGeos = new Workspaces::Unrestricted(),
                        DefaultInferenceGeo = Workspaces::DefaultInferenceGeo.Global,
                        WorkspaceGeo = Workspaces::WorkspaceGeo.Us,
                    },
                    DisplayColor = "#6C5BB9",
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Name = "Workspace Name",
                    Tags = new Dictionary<string, string>()
                    {
                        { "env", "prod" },
                        { "team", "platform" },
                    },
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                    InferenceDataPrivacy = new()
                    {
                        HumanReview = new(Workspaces::Type.Disabled),
                        SafeguardsStorage = new Workspaces::BetaInternalStorage(),
                        TranscriptsStorage = new Workspaces::BetaInternalStorage(),
                    },
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Workspaces::WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
                    ArchivedAt = DateTimeOffset.Parse("2024-11-01T23:59:27.427722Z"),
                    CompartmentID = "f8a7b6c5-4d3e-4f1a-8b9c-0d1e2f3a4b5c",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    DataResidency = new()
                    {
                        AllowedInferenceGeos = new Workspaces::Unrestricted(),
                        DefaultInferenceGeo = Workspaces::DefaultInferenceGeo.Global,
                        WorkspaceGeo = Workspaces::WorkspaceGeo.Us,
                    },
                    DisplayColor = "#6C5BB9",
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Name = "Workspace Name",
                    Tags = new Dictionary<string, string>()
                    {
                        { "env", "prod" },
                        { "team", "platform" },
                    },
                    UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
                    InferenceDataPrivacy = new()
                    {
                        HumanReview = new(Workspaces::Type.Disabled),
                        SafeguardsStorage = new Workspaces::BetaInternalStorage(),
                        TranscriptsStorage = new Workspaces::BetaInternalStorage(),
                    },
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        Workspaces::WorkspaceListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
