using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces.RateLimits;
using RateLimits = Anthropic.Models.Organization.RateLimits;

namespace Anthropic.Tests.Models.Organization.Workspaces.RateLimits;

public class RateLimitListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateLimitListPageResponse
        {
            Data =
            [
                new()
                {
                    Group = new RateLimits::OrganizationRateLimitModelGroup()
                    {
                        ID = "id",
                        DisplayName = "display_name",
                    },
                    Limits =
                    [
                        new()
                        {
                            OrgLimit = 0,
                            Source = new WorkspaceRateLimitWorkspaceSource(),
                            Type = "type",
                            Value = 0,
                        },
                    ],
                    Models = ["string"],
                    RateLimitID = "rate_limit_id",
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        List<WorkspaceRateLimit> expectedData =
        [
            new()
            {
                Group = new RateLimits::OrganizationRateLimitModelGroup()
                {
                    ID = "id",
                    DisplayName = "display_name",
                },
                Limits =
                [
                    new()
                    {
                        OrgLimit = 0,
                        Source = new WorkspaceRateLimitWorkspaceSource(),
                        Type = "type",
                        Value = 0,
                    },
                ],
                Models = ["string"],
                RateLimitID = "rate_limit_id",
                WorkspaceID = "workspace_id",
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RateLimitListPageResponse
        {
            Data =
            [
                new()
                {
                    Group = new RateLimits::OrganizationRateLimitModelGroup()
                    {
                        ID = "id",
                        DisplayName = "display_name",
                    },
                    Limits =
                    [
                        new()
                        {
                            OrgLimit = 0,
                            Source = new WorkspaceRateLimitWorkspaceSource(),
                            Type = "type",
                            Value = 0,
                        },
                    ],
                    Models = ["string"],
                    RateLimitID = "rate_limit_id",
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateLimitListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RateLimitListPageResponse
        {
            Data =
            [
                new()
                {
                    Group = new RateLimits::OrganizationRateLimitModelGroup()
                    {
                        ID = "id",
                        DisplayName = "display_name",
                    },
                    Limits =
                    [
                        new()
                        {
                            OrgLimit = 0,
                            Source = new WorkspaceRateLimitWorkspaceSource(),
                            Type = "type",
                            Value = 0,
                        },
                    ],
                    Models = ["string"],
                    RateLimitID = "rate_limit_id",
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateLimitListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WorkspaceRateLimit> expectedData =
        [
            new()
            {
                Group = new RateLimits::OrganizationRateLimitModelGroup()
                {
                    ID = "id",
                    DisplayName = "display_name",
                },
                Limits =
                [
                    new()
                    {
                        OrgLimit = 0,
                        Source = new WorkspaceRateLimitWorkspaceSource(),
                        Type = "type",
                        Value = 0,
                    },
                ],
                Models = ["string"],
                RateLimitID = "rate_limit_id",
                WorkspaceID = "workspace_id",
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RateLimitListPageResponse
        {
            Data =
            [
                new()
                {
                    Group = new RateLimits::OrganizationRateLimitModelGroup()
                    {
                        ID = "id",
                        DisplayName = "display_name",
                    },
                    Limits =
                    [
                        new()
                        {
                            OrgLimit = 0,
                            Source = new WorkspaceRateLimitWorkspaceSource(),
                            Type = "type",
                            Value = 0,
                        },
                    ],
                    Models = ["string"],
                    RateLimitID = "rate_limit_id",
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RateLimitListPageResponse
        {
            Data =
            [
                new()
                {
                    Group = new RateLimits::OrganizationRateLimitModelGroup()
                    {
                        ID = "id",
                        DisplayName = "display_name",
                    },
                    Limits =
                    [
                        new()
                        {
                            OrgLimit = 0,
                            Source = new WorkspaceRateLimitWorkspaceSource(),
                            Type = "type",
                            Value = 0,
                        },
                    ],
                    Models = ["string"],
                    RateLimitID = "rate_limit_id",
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        RateLimitListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
