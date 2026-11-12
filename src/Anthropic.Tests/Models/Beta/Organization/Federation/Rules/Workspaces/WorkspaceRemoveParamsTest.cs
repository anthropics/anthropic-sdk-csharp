using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Federation.Rules.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules.Workspaces;

public class WorkspaceRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceRemoveParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedFederationRuleID = "federation_rule_id";
        string expectedWorkspaceID = "workspace_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedFederationRuleID, parameters.FederationRuleID);
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
        var parameters = new WorkspaceRemoveParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspaceRemoveParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new WorkspaceRemoveParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceRemoveParams parameters = new()
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_rules/federation_rule_id/workspaces/workspace_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkspaceRemoveParams parameters = new()
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
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
        var parameters = new WorkspaceRemoveParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        WorkspaceRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
