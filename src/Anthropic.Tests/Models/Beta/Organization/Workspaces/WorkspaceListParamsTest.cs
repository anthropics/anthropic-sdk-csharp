using System;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class WorkspaceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            IncludeArchived = true,
            Limit = 1,
        };

        string expectedAfterID = "after_id";
        string expectedBeforeID = "before_id";
        bool expectedIncludeArchived = true;
        long expectedLimit = 1;

        Assert.Equal(expectedAfterID, parameters.AfterID);
        Assert.Equal(expectedBeforeID, parameters.BeforeID);
        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspaceListParams { };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspaceListParams
        {
            // Null should be interpreted as omitted for these properties
            AfterID = null,
            BeforeID = null,
            IncludeArchived = null,
            Limit = null,
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceListParams parameters = new()
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            IncludeArchived = true,
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces?beta=true&after_id=after_id&before_id=before_id&include_archived=true&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            IncludeArchived = true,
            Limit = 1,
        };

        WorkspaceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
