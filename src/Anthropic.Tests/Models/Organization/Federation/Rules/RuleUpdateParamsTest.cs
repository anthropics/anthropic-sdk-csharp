using System;
using System.Collections.Generic;
using Anthropic.Models.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Organization.Federation.Rules;

public class RuleUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleUpdateParams
        {
            FederationRuleID = "federation_rule_id",
            AppliesToAllWorkspaces = true,
            Description = "description",
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
            TokenLifetimeSeconds = 60,
            WorkspaceID = "workspace_id",
        };

        string expectedFederationRuleID = "federation_rule_id";
        bool expectedAppliesToAllWorkspaces = true;
        string expectedDescription = "description";
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
        long expectedTokenLifetimeSeconds = 60;
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedFederationRuleID, parameters.FederationRuleID);
        Assert.Equal(expectedAppliesToAllWorkspaces, parameters.AppliesToAllWorkspaces);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedMatch, parameters.Match);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOAuthScope, parameters.OAuthScope);
        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedTokenLifetimeSeconds, parameters.TokenLifetimeSeconds);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleUpdateParams { FederationRuleID = "federation_rule_id" };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Match);
        Assert.False(parameters.RawBodyData.ContainsKey("match"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OAuthScope);
        Assert.False(parameters.RawBodyData.ContainsKey("oauth_scope"));
        Assert.Null(parameters.Target);
        Assert.False(parameters.RawBodyData.ContainsKey("target"));
        Assert.Null(parameters.TokenLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("token_lifetime_seconds"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawBodyData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RuleUpdateParams
        {
            FederationRuleID = "federation_rule_id",

            AppliesToAllWorkspaces = null,
            Description = null,
            Match = null,
            Name = null,
            OAuthScope = null,
            Target = null,
            TokenLifetimeSeconds = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.True(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Match);
        Assert.True(parameters.RawBodyData.ContainsKey("match"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OAuthScope);
        Assert.True(parameters.RawBodyData.ContainsKey("oauth_scope"));
        Assert.Null(parameters.Target);
        Assert.True(parameters.RawBodyData.ContainsKey("target"));
        Assert.Null(parameters.TokenLifetimeSeconds);
        Assert.True(parameters.RawBodyData.ContainsKey("token_lifetime_seconds"));
        Assert.Null(parameters.WorkspaceID);
        Assert.True(parameters.RawBodyData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void Url_Works()
    {
        RuleUpdateParams parameters = new() { FederationRuleID = "federation_rule_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_rules/federation_rule_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RuleUpdateParams
        {
            FederationRuleID = "federation_rule_id",
            AppliesToAllWorkspaces = true,
            Description = "description",
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
            TokenLifetimeSeconds = 60,
            WorkspaceID = "workspace_id",
        };

        RuleUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
