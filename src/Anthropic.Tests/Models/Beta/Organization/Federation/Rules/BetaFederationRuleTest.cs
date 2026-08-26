using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules;

public class BetaFederationRuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFederationRule
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
        };

        string expectedID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK";
        bool expectedAppliesToAllWorkspaces = true;
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedArchivedByActorID = "archived_by_actor_id";
        Dictionary<string, string> expectedAttributes = new() { { "foo", "string" } };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedCreatedByActorID = "created_by_actor_id";
        string expectedDescription = "description";
        string expectedIssuerID = "issuer_id";
        string expectedIssuerName = "issuer_name";
        BetaFederationRuleMatch expectedMatch = new()
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };
        string expectedName = "prod-deploy-pipeline";
        string expectedOAuthScope = "oauth_scope";
        BetaServiceAccountTarget expectedTarget = new()
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };
        long expectedTokenLifetimeSeconds = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("federation_rule");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedUpdatedByActorID = "updated_by_actor_id";
        string expectedWorkspaceID = "workspace_id";
        List<string> expectedWorkspaceIds = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAppliesToAllWorkspaces, model.AppliesToAllWorkspaces);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedArchivedByActorID, model.ArchivedByActorID);
        Assert.NotNull(model.Attributes);
        Assert.Equal(expectedAttributes.Count, model.Attributes.Count);
        foreach (var item in expectedAttributes)
        {
            Assert.True(model.Attributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Attributes[item.Key]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedByActorID, model.CreatedByActorID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedIssuerID, model.IssuerID);
        Assert.Equal(expectedIssuerName, model.IssuerName);
        Assert.Equal(expectedMatch, model.Match);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOAuthScope, model.OAuthScope);
        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedTokenLifetimeSeconds, model.TokenLifetimeSeconds);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUpdatedByActorID, model.UpdatedByActorID);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
        Assert.Equal(expectedWorkspaceIds.Count, model.WorkspaceIds.Count);
        for (int i = 0; i < expectedWorkspaceIds.Count; i++)
        {
            Assert.Equal(expectedWorkspaceIds[i], model.WorkspaceIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFederationRule
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationRule>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFederationRule
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationRule>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "fdrl_01SDCCSbTxrXDpWc1phhtcfK";
        bool expectedAppliesToAllWorkspaces = true;
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedArchivedByActorID = "archived_by_actor_id";
        Dictionary<string, string> expectedAttributes = new() { { "foo", "string" } };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedCreatedByActorID = "created_by_actor_id";
        string expectedDescription = "description";
        string expectedIssuerID = "issuer_id";
        string expectedIssuerName = "issuer_name";
        BetaFederationRuleMatch expectedMatch = new()
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };
        string expectedName = "prod-deploy-pipeline";
        string expectedOAuthScope = "oauth_scope";
        BetaServiceAccountTarget expectedTarget = new()
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };
        long expectedTokenLifetimeSeconds = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("federation_rule");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedUpdatedByActorID = "updated_by_actor_id";
        string expectedWorkspaceID = "workspace_id";
        List<string> expectedWorkspaceIds = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAppliesToAllWorkspaces, deserialized.AppliesToAllWorkspaces);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedArchivedByActorID, deserialized.ArchivedByActorID);
        Assert.NotNull(deserialized.Attributes);
        Assert.Equal(expectedAttributes.Count, deserialized.Attributes.Count);
        foreach (var item in expectedAttributes)
        {
            Assert.True(deserialized.Attributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Attributes[item.Key]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedByActorID, deserialized.CreatedByActorID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedIssuerID, deserialized.IssuerID);
        Assert.Equal(expectedIssuerName, deserialized.IssuerName);
        Assert.Equal(expectedMatch, deserialized.Match);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOAuthScope, deserialized.OAuthScope);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedTokenLifetimeSeconds, deserialized.TokenLifetimeSeconds);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUpdatedByActorID, deserialized.UpdatedByActorID);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
        Assert.Equal(expectedWorkspaceIds.Count, deserialized.WorkspaceIds.Count);
        for (int i = 0; i < expectedWorkspaceIds.Count; i++)
        {
            Assert.Equal(expectedWorkspaceIds[i], deserialized.WorkspaceIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFederationRule
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFederationRule
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
        };

        BetaFederationRule copied = new(model);

        Assert.Equal(model, copied);
    }
}
