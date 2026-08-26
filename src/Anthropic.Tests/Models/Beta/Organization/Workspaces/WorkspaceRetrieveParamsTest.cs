using System;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class WorkspaceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceRetrieveParams { WorkspaceID = "workspace_id" };

        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceRetrieveParams parameters = new() { WorkspaceID = "workspace_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceRetrieveParams { WorkspaceID = "workspace_id" };

        WorkspaceRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
