using System;
using System.Collections.Generic;
using Anthropic.Models.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Organization.Federation.Rules;

public class RuleCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleCreateParams
        {
            IssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>()
                {
                    { "event_name", "push" },
                    { "ref", "refs/heads/main" },
                    { "repository_id", "123456789" },
                    { "repository_owner_id", "987654321" },
                },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "prod-deploy-pipeline",
            OAuthScope = "workspace:developer",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            AppliesToAllWorkspaces = true,
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
        };

        string expectedIssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK";
        FederationRuleMatch expectedMatch = new()
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>()
            {
                { "event_name", "push" },
                { "ref", "refs/heads/main" },
                { "repository_id", "123456789" },
                { "repository_owner_id", "987654321" },
            },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };
        string expectedName = "prod-deploy-pipeline";
        string expectedOAuthScope = "workspace:developer";
        ServiceAccountTarget expectedTarget = new()
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };
        bool expectedAppliesToAllWorkspaces = true;
        string expectedDescription = "description";
        long expectedTokenLifetimeSeconds = 60;
        string expectedWorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx";

        Assert.Equal(expectedIssuerID, parameters.IssuerID);
        Assert.Equal(expectedMatch, parameters.Match);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOAuthScope, parameters.OAuthScope);
        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedAppliesToAllWorkspaces, parameters.AppliesToAllWorkspaces);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedTokenLifetimeSeconds, parameters.TokenLifetimeSeconds);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleCreateParams
        {
            IssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>()
                {
                    { "event_name", "push" },
                    { "ref", "refs/heads/main" },
                    { "repository_id", "123456789" },
                    { "repository_owner_id", "987654321" },
                },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "prod-deploy-pipeline",
            OAuthScope = "workspace:developer",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            Description = "description",
            WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
        };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.TokenLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("token_lifetime_seconds"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RuleCreateParams
        {
            IssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>()
                {
                    { "event_name", "push" },
                    { "ref", "refs/heads/main" },
                    { "repository_id", "123456789" },
                    { "repository_owner_id", "987654321" },
                },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "prod-deploy-pipeline",
            OAuthScope = "workspace:developer",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            Description = "description",
            WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",

            // Null should be interpreted as omitted for these properties
            AppliesToAllWorkspaces = null,
            TokenLifetimeSeconds = null,
        };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.TokenLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("token_lifetime_seconds"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new RuleCreateParams
        {
            IssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>()
                {
                    { "event_name", "push" },
                    { "ref", "refs/heads/main" },
                    { "repository_id", "123456789" },
                    { "repository_owner_id", "987654321" },
                },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "prod-deploy-pipeline",
            OAuthScope = "workspace:developer",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            AppliesToAllWorkspaces = true,
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
        } with
        {
            // Null should be interpreted as omitted for these properties
            AppliesToAllWorkspaces = null,
            TokenLifetimeSeconds = null,
        };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.TokenLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("token_lifetime_seconds"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleCreateParams
        {
            IssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>()
                {
                    { "event_name", "push" },
                    { "ref", "refs/heads/main" },
                    { "repository_id", "123456789" },
                    { "repository_owner_id", "987654321" },
                },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "prod-deploy-pipeline",
            OAuthScope = "workspace:developer",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            AppliesToAllWorkspaces = true,
            TokenLifetimeSeconds = 60,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawBodyData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RuleCreateParams
        {
            IssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>()
                {
                    { "event_name", "push" },
                    { "ref", "refs/heads/main" },
                    { "repository_id", "123456789" },
                    { "repository_owner_id", "987654321" },
                },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "prod-deploy-pipeline",
            OAuthScope = "workspace:developer",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            AppliesToAllWorkspaces = true,
            TokenLifetimeSeconds = 60,

            Description = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.WorkspaceID);
        Assert.True(parameters.RawBodyData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void Url_Works()
    {
        RuleCreateParams parameters = new()
        {
            IssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>()
                {
                    { "event_name", "push" },
                    { "ref", "refs/heads/main" },
                    { "repository_id", "123456789" },
                    { "repository_owner_id", "987654321" },
                },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "prod-deploy-pipeline",
            OAuthScope = "workspace:developer",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/federation_rules"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RuleCreateParams
        {
            IssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>()
                {
                    { "event_name", "push" },
                    { "ref", "refs/heads/main" },
                    { "repository_id", "123456789" },
                    { "repository_owner_id", "987654321" },
                },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "prod-deploy-pipeline",
            OAuthScope = "workspace:developer",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            AppliesToAllWorkspaces = true,
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
        };

        RuleCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
