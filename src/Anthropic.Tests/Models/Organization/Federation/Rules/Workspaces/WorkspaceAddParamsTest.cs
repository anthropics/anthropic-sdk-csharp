using System;
using Anthropic.Models.Organization.Federation.Rules.Workspaces;

namespace Anthropic.Tests.Models.Organization.Federation.Rules.Workspaces;

public class WorkspaceAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceAddParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
        };

        string expectedFederationRuleID = "federation_rule_id";
        string expectedWorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx";

        Assert.Equal(expectedFederationRuleID, parameters.FederationRuleID);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceAddParams parameters = new()
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_rules/federation_rule_id/workspaces"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceAddParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx",
        };

        WorkspaceAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
