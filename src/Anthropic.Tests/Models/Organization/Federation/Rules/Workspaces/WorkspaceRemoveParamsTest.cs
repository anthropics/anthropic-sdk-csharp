using System;
using Anthropic.Models.Organization.Federation.Rules.Workspaces;

namespace Anthropic.Tests.Models.Organization.Federation.Rules.Workspaces;

public class WorkspaceRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceRemoveParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        string expectedFederationRuleID = "federation_rule_id";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedFederationRuleID, parameters.FederationRuleID);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
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
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceRemoveParams
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        WorkspaceRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
