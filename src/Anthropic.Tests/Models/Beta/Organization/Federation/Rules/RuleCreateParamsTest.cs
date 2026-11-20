using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules;

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
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedIssuerID = "fdis_01SDCCSbTxrXDpWc1phhtcfK";
        BetaFederationRuleMatch expectedMatch = new()
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
        BetaServiceAccountTarget expectedTarget = new()
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };
        bool expectedAppliesToAllWorkspaces = true;
        Dictionary<string, string> expectedAttributes = new() { { "foo", "string" } };
        string expectedDescription = "description";
        long expectedTokenLifetimeSeconds = 60;
        string expectedWorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedIssuerID, parameters.IssuerID);
        Assert.Equal(expectedMatch, parameters.Match);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOAuthScope, parameters.OAuthScope);
        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedAppliesToAllWorkspaces, parameters.AppliesToAllWorkspaces);
        Assert.NotNull(parameters.Attributes);
        Assert.Equal(expectedAttributes.Count, parameters.Attributes.Count);
        foreach (var item in expectedAttributes)
        {
            Assert.True(parameters.Attributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Attributes[item.Key]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
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
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
            Description = "description",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.TokenLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("token_lifetime_seconds"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
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
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
            Description = "description",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",

            // Null should be interpreted as omitted for these properties
            AppliesToAllWorkspaces = null,
            TokenLifetimeSeconds = null,
            Betas = null,
        };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.TokenLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("token_lifetime_seconds"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
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
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            AppliesToAllWorkspaces = null,
            TokenLifetimeSeconds = null,
            Betas = null,
        };

        Assert.Null(parameters.AppliesToAllWorkspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("applies_to_all_workspaces"));
        Assert.Null(parameters.TokenLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("token_lifetime_seconds"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
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
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.Null(parameters.Attributes);
        Assert.False(parameters.RawBodyData.ContainsKey("attributes"));
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
            Betas = [AnthropicBeta.ComputerUse2024_10_22],

            Attributes = null,
            Description = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Attributes);
        Assert.True(parameters.RawBodyData.ContainsKey("attributes"));
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
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
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
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22"],
            requestMessage.Headers.GetValues("anthropic-beta")
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
            Attributes = new Dictionary<string, string>() { { "foo", "string" } },
            Description = "description",
            TokenLifetimeSeconds = 60,
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        RuleCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
