using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules;

public class RuleListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RuleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK",
                    AppliesToAllWorkspaces = true,
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ArchivedByActorID = "archived_by_actor_id",
                    Attributes = new Dictionary<string, string>() { { "foo", "string" } },
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedByActorID = "created_by_actor_id",
                    Description = "description",
                    IssuerID = "issuer_id",
                    IssuerName = "issuer_name",
                    Match = new()
                    {
                        Audience = "audience",
                        Claims = new Dictionary<string, string>() { { "foo", "string" } },
                        Condition = "condition",
                        SubjectPrefix = "subject_prefix",
                    },
                    Name = "prod-deploy-pipeline",
                    OAuthScope = "oauth_scope",
                    Target = new()
                    {
                        ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                        ServiceAccountName = "service_account_name",
                    },
                    TokenLifetimeSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UpdatedByActorID = "updated_by_actor_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        List<BetaFederationRule> expectedData =
        [
            new()
            {
                ID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK",
                AppliesToAllWorkspaces = true,
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ArchivedByActorID = "archived_by_actor_id",
                Attributes = new Dictionary<string, string>() { { "foo", "string" } },
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                CreatedByActorID = "created_by_actor_id",
                Description = "description",
                IssuerID = "issuer_id",
                IssuerName = "issuer_name",
                Match = new()
                {
                    Audience = "audience",
                    Claims = new Dictionary<string, string>() { { "foo", "string" } },
                    Condition = "condition",
                    SubjectPrefix = "subject_prefix",
                },
                Name = "prod-deploy-pipeline",
                OAuthScope = "oauth_scope",
                Target = new()
                {
                    ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                    ServiceAccountName = "service_account_name",
                },
                TokenLifetimeSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                UpdatedByActorID = "updated_by_actor_id",
                WorkspaceID = "workspace_id",
                WorkspaceIds = ["string"],
            },
        ];
        string expectedNextPage = "next_page";

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
        var model = new RuleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK",
                    AppliesToAllWorkspaces = true,
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ArchivedByActorID = "archived_by_actor_id",
                    Attributes = new Dictionary<string, string>() { { "foo", "string" } },
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedByActorID = "created_by_actor_id",
                    Description = "description",
                    IssuerID = "issuer_id",
                    IssuerName = "issuer_name",
                    Match = new()
                    {
                        Audience = "audience",
                        Claims = new Dictionary<string, string>() { { "foo", "string" } },
                        Condition = "condition",
                        SubjectPrefix = "subject_prefix",
                    },
                    Name = "prod-deploy-pipeline",
                    OAuthScope = "oauth_scope",
                    Target = new()
                    {
                        ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                        ServiceAccountName = "service_account_name",
                    },
                    TokenLifetimeSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UpdatedByActorID = "updated_by_actor_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RuleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK",
                    AppliesToAllWorkspaces = true,
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ArchivedByActorID = "archived_by_actor_id",
                    Attributes = new Dictionary<string, string>() { { "foo", "string" } },
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedByActorID = "created_by_actor_id",
                    Description = "description",
                    IssuerID = "issuer_id",
                    IssuerName = "issuer_name",
                    Match = new()
                    {
                        Audience = "audience",
                        Claims = new Dictionary<string, string>() { { "foo", "string" } },
                        Condition = "condition",
                        SubjectPrefix = "subject_prefix",
                    },
                    Name = "prod-deploy-pipeline",
                    OAuthScope = "oauth_scope",
                    Target = new()
                    {
                        ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                        ServiceAccountName = "service_account_name",
                    },
                    TokenLifetimeSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UpdatedByActorID = "updated_by_actor_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaFederationRule> expectedData =
        [
            new()
            {
                ID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK",
                AppliesToAllWorkspaces = true,
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ArchivedByActorID = "archived_by_actor_id",
                Attributes = new Dictionary<string, string>() { { "foo", "string" } },
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                CreatedByActorID = "created_by_actor_id",
                Description = "description",
                IssuerID = "issuer_id",
                IssuerName = "issuer_name",
                Match = new()
                {
                    Audience = "audience",
                    Claims = new Dictionary<string, string>() { { "foo", "string" } },
                    Condition = "condition",
                    SubjectPrefix = "subject_prefix",
                },
                Name = "prod-deploy-pipeline",
                OAuthScope = "oauth_scope",
                Target = new()
                {
                    ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                    ServiceAccountName = "service_account_name",
                },
                TokenLifetimeSeconds = 0,
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                UpdatedByActorID = "updated_by_actor_id",
                WorkspaceID = "workspace_id",
                WorkspaceIds = ["string"],
            },
        ];
        string expectedNextPage = "next_page";

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
        var model = new RuleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK",
                    AppliesToAllWorkspaces = true,
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ArchivedByActorID = "archived_by_actor_id",
                    Attributes = new Dictionary<string, string>() { { "foo", "string" } },
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedByActorID = "created_by_actor_id",
                    Description = "description",
                    IssuerID = "issuer_id",
                    IssuerName = "issuer_name",
                    Match = new()
                    {
                        Audience = "audience",
                        Claims = new Dictionary<string, string>() { { "foo", "string" } },
                        Condition = "condition",
                        SubjectPrefix = "subject_prefix",
                    },
                    Name = "prod-deploy-pipeline",
                    OAuthScope = "oauth_scope",
                    Target = new()
                    {
                        ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                        ServiceAccountName = "service_account_name",
                    },
                    TokenLifetimeSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UpdatedByActorID = "updated_by_actor_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RuleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK",
                    AppliesToAllWorkspaces = true,
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ArchivedByActorID = "archived_by_actor_id",
                    Attributes = new Dictionary<string, string>() { { "foo", "string" } },
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedByActorID = "created_by_actor_id",
                    Description = "description",
                    IssuerID = "issuer_id",
                    IssuerName = "issuer_name",
                    Match = new()
                    {
                        Audience = "audience",
                        Claims = new Dictionary<string, string>() { { "foo", "string" } },
                        Condition = "condition",
                        SubjectPrefix = "subject_prefix",
                    },
                    Name = "prod-deploy-pipeline",
                    OAuthScope = "oauth_scope",
                    Target = new()
                    {
                        ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                        ServiceAccountName = "service_account_name",
                    },
                    TokenLifetimeSeconds = 0,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    UpdatedByActorID = "updated_by_actor_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceIds = ["string"],
                },
            ],
            NextPage = "next_page",
        };

        RuleListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
