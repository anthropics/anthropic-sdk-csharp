using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules;

public class RuleUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleUpdateParams
        {
            FederationRuleID = "federation_rule_id",
            AppliesToAllWorkspaces = true,
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedFederationRuleID = "federation_rule_id";
        bool expectedAppliesToAllWorkspaces = true;
        Dictionary<string, string> expectedAttributes = new() { { "foo", "string" } };
        string expectedDescription = "description";
        BetaFederationRuleMatch expectedMatch = new()
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };
        string expectedName = "x";
        string expectedOAuthScope = "x";
        BetaServiceAccountTarget expectedTarget = new()
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };
        long expectedTokenLifetimeSeconds = 60;
        string expectedWorkspaceID = "workspace_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedFederationRuleID, parameters.FederationRuleID);
        Assert.Equal(expectedAppliesToAllWorkspaces, parameters.AppliesToAllWorkspaces);
        Assert.NotNull(parameters.Attributes);
        Assert.Equal(expectedAttributes.Count, parameters.Attributes.Count);
        foreach (var item in expectedAttributes)
        {
            Assert.True(parameters.Attributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Attributes[item.Key]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedMatch, parameters.Match);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOAuthScope, parameters.OAuthScope);
        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedTokenLifetimeSeconds, parameters.TokenLifetimeSeconds);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleUpdateParams
        {
            FederationRuleID = "federation_rule_id",
            AppliesToAllWorkspaces = true,
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
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

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RuleUpdateParams
        {
            FederationRuleID = "federation_rule_id",
            AppliesToAllWorkspaces = true,
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
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

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleUpdateParams
        {
            FederationRuleID = "federation_rule_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.Attributes);
        Assert.False(parameters.RawBodyData.ContainsKey("attributes"));
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            AppliesToAllWorkspaces = null,
            Attributes = null,
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
        Assert.Null(parameters.Attributes);
        Assert.True(parameters.RawBodyData.ContainsKey("attributes"));
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
                    "https://api.anthropic.com/v1/organizations/federation_rules/federation_rule_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RuleUpdateParams parameters = new()
        {
            FederationRuleID = "federation_rule_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RuleUpdateParams
        {
            FederationRuleID = "federation_rule_id",
            AppliesToAllWorkspaces = true,
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        RuleUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
