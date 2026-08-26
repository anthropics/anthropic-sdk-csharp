using System;
using Anthropic.Models.Beta.Organization.Workspaces.Members;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.Members;

public class MemberListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemberListParams
        {
            WorkspaceID = "workspace_id",
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 1,
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedAfterID = "after_id";
        string expectedBeforeID = "before_id";
        long expectedLimit = 1;

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedAfterID, parameters.AfterID);
        Assert.Equal(expectedBeforeID, parameters.BeforeID);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemberListParams { WorkspaceID = "workspace_id" };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemberListParams
        {
            WorkspaceID = "workspace_id",

            // Null should be interpreted as omitted for these properties
            AfterID = null,
            BeforeID = null,
            Limit = null,
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        MemberListParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id/members?beta=true&after_id=after_id&before_id=before_id&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemberListParams
        {
            WorkspaceID = "workspace_id",
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 1,
        };

        MemberListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
