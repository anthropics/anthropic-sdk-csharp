using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

public class RbacGroupListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        List<BetaClaudeCodeRbacGroupManagedSettingsSummary> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaClaudeCodeRbacGroupManagedSettingsSummary> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    RbacGroupStatus = new BetaClaudeCodeRbacGroupStatusActive(),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        RbacGroupListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
