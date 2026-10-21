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
            IssuerID = "issuer_id",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>() { { "foo", "string" } },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "x",
            OAuthScope = "x",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            AppliesToAllWorkspaces = true,
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "workspace_id",
        };

        string expectedIssuerID = "issuer_id";
        FederationRuleMatch expectedMatch = new()
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };
        string expectedName = "x";
        string expectedOAuthScope = "x";
        ServiceAccountTarget expectedTarget = new()
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };
        bool expectedAppliesToAllWorkspaces = true;
        string expectedDescription = "description";
        long expectedTokenLifetimeSeconds = 60;
        string expectedWorkspaceID = "workspace_id";

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
            IssuerID = "issuer_id",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>() { { "foo", "string" } },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "x",
            OAuthScope = "x",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            Description = "description",
            WorkspaceID = "workspace_id",
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
            IssuerID = "issuer_id",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>() { { "foo", "string" } },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "x",
            OAuthScope = "x",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            Description = "description",
            WorkspaceID = "workspace_id",

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
            IssuerID = "issuer_id",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>() { { "foo", "string" } },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "x",
            OAuthScope = "x",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            AppliesToAllWorkspaces = true,
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "workspace_id",
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
            IssuerID = "issuer_id",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>() { { "foo", "string" } },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "x",
            OAuthScope = "x",
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
            IssuerID = "issuer_id",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>() { { "foo", "string" } },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "x",
            OAuthScope = "x",
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
            IssuerID = "issuer_id",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>() { { "foo", "string" } },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "x",
            OAuthScope = "x",
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
            IssuerID = "issuer_id",
            Match = new()
            {
                Audience = "audience",
                Claims = new Dictionary<string, string>() { { "foo", "string" } },
                Condition = "condition",
                SubjectPrefix = "subject_prefix",
            },
            Name = "x",
            OAuthScope = "x",
            Target = new()
            {
                ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                ServiceAccountName = "service_account_name",
            },
            AppliesToAllWorkspaces = true,
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "workspace_id",
        };

        RuleCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
