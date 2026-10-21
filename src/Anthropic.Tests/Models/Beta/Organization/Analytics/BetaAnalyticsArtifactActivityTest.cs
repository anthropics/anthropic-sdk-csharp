using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsArtifactActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
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
        };

        string expectedArtifactType = "artifact_type";
        long expectedArtifactsCreatedCount = 0;
        long expectedDistinctUserCount = 0;
        bool expectedIsShared = true;
        long expectedPublishedArtifactsCreatedCount = 0;
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedArtifactType, model.ArtifactType);
        Assert.Equal(expectedArtifactsCreatedCount, model.ArtifactsCreatedCount);
        Assert.Equal(expectedDistinctUserCount, model.DistinctUserCount);
        Assert.Equal(expectedIsShared, model.IsShared);
        Assert.Equal(expectedPublishedArtifactsCreatedCount, model.PublishedArtifactsCreatedCount);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, model.RbacGroupName);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsArtifactActivity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsArtifactActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedArtifactType = "artifact_type";
        long expectedArtifactsCreatedCount = 0;
        long expectedDistinctUserCount = 0;
        bool expectedIsShared = true;
        long expectedPublishedArtifactsCreatedCount = 0;
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedArtifactType, deserialized.ArtifactType);
        Assert.Equal(expectedArtifactsCreatedCount, deserialized.ArtifactsCreatedCount);
        Assert.Equal(expectedDistinctUserCount, deserialized.DistinctUserCount);
        Assert.Equal(expectedIsShared, deserialized.IsShared);
        Assert.Equal(
            expectedPublishedArtifactsCreatedCount,
            deserialized.PublishedArtifactsCreatedCount
        );
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, deserialized.RbacGroupName);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
        {
            ArtifactType = "artifact_type",
            ArtifactsCreatedCount = 0,
            DistinctUserCount = 0,
            IsShared = true,
            PublishedArtifactsCreatedCount = 0,
        };

        Assert.Null(model.Product);
        Assert.False(model.RawData.ContainsKey("product"));
        Assert.Null(model.RbacGroupID);
        Assert.False(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.False(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
        {
            ArtifactType = "artifact_type",
            ArtifactsCreatedCount = 0,
            DistinctUserCount = 0,
            IsShared = true,
            PublishedArtifactsCreatedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
        {
            ArtifactType = "artifact_type",
            ArtifactsCreatedCount = 0,
            DistinctUserCount = 0,
            IsShared = true,
            PublishedArtifactsCreatedCount = 0,

            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            UserID = null,
        };

        Assert.Null(model.Product);
        Assert.True(model.RawData.ContainsKey("product"));
        Assert.Null(model.RbacGroupID);
        Assert.True(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.True(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.UserID);
        Assert.True(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
        {
            ArtifactType = "artifact_type",
            ArtifactsCreatedCount = 0,
            DistinctUserCount = 0,
            IsShared = true,
            PublishedArtifactsCreatedCount = 0,

            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            UserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsArtifactActivity
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
        };

        BetaAnalyticsArtifactActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}
