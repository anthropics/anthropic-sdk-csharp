using System;
using System.Collections.Generic;
using Anthropic.Models.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Organization.Workspaces.RateLimits;

public class RateLimitUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RateLimitUpdateParams
        {
            WorkspaceID = "workspace_id",
            RateLimitID = "rate_limit_id",
            Limits = [new() { Type = WorkspaceRateLimitType.FastItpmca, Value = 0 }],
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedRateLimitID = "rate_limit_id";
        List<WorkspaceRateLimitUpdateValue> expectedLimits =
        [
            new() { Type = WorkspaceRateLimitType.FastItpmca, Value = 0 },
        ];

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedRateLimitID, parameters.RateLimitID);
        Assert.Equal(expectedLimits.Count, parameters.Limits.Count);
        for (int i = 0; i < expectedLimits.Count; i++)
        {
            Assert.Equal(expectedLimits[i], parameters.Limits[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        RateLimitUpdateParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            RateLimitID = "rate_limit_id",
            Limits = [new() { Type = WorkspaceRateLimitType.FastItpmca, Value = 0 }],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id/rate_limits/rate_limit_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RateLimitUpdateParams
        {
            WorkspaceID = "workspace_id",
            RateLimitID = "rate_limit_id",
            Limits = [new() { Type = WorkspaceRateLimitType.FastItpmca, Value = 0 }],
        };

        RateLimitUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
