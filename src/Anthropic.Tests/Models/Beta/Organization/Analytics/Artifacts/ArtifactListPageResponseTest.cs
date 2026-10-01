using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Artifacts;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Artifacts;

public class ArtifactListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ArtifactListPageResponse
        {
            Data =
            [
                new()
                {
                    ArtifactType = "artifact_type",
                    ArtifactsCreatedCount = 0,
                    DistinctUserCount = 0,
                    IsShared = true,
                    PublishedArtifactsCreatedCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaAnalyticsArtifactActivity> expectedData =
        [
            new()
            {
                ArtifactType = "artifact_type",
                ArtifactsCreatedCount = 0,
                DistinctUserCount = 0,
                IsShared = true,
                PublishedArtifactsCreatedCount = 0,
                Product = "product",
                RbacGroupID = "rbac_group_id",
                RbacGroupName = "rbac_group_name",
                UserID = "user_id",
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
        var model = new ArtifactListPageResponse
        {
            Data =
            [
                new()
                {
                    ArtifactType = "artifact_type",
                    ArtifactsCreatedCount = 0,
                    DistinctUserCount = 0,
                    IsShared = true,
                    PublishedArtifactsCreatedCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArtifactListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ArtifactListPageResponse
        {
            Data =
            [
                new()
                {
                    ArtifactType = "artifact_type",
                    ArtifactsCreatedCount = 0,
                    DistinctUserCount = 0,
                    IsShared = true,
                    PublishedArtifactsCreatedCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArtifactListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsArtifactActivity> expectedData =
        [
            new()
            {
                ArtifactType = "artifact_type",
                ArtifactsCreatedCount = 0,
                DistinctUserCount = 0,
                IsShared = true,
                PublishedArtifactsCreatedCount = 0,
                Product = "product",
                RbacGroupID = "rbac_group_id",
                RbacGroupName = "rbac_group_name",
                UserID = "user_id",
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
        var model = new ArtifactListPageResponse
        {
            Data =
            [
                new()
                {
                    ArtifactType = "artifact_type",
                    ArtifactsCreatedCount = 0,
                    DistinctUserCount = 0,
                    IsShared = true,
                    PublishedArtifactsCreatedCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ArtifactListPageResponse
        {
            Data =
            [
                new()
                {
                    ArtifactType = "artifact_type",
                    ArtifactsCreatedCount = 0,
                    DistinctUserCount = 0,
                    IsShared = true,
                    PublishedArtifactsCreatedCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        ArtifactListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
