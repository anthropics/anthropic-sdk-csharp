using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsProjectActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
            DistinctConversationCount = 0,
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        long expectedDistinctUserCount = 0;
        long expectedMessageCount = 0;
        string expectedProjectID = "project_id";
        string expectedProjectName = "project_name";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaAnalyticsUser expectedCreatedBy = new() { ID = "id", EmailAddress = "email_address" };
        long expectedDistinctConversationCount = 0;
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedDistinctUserCount, model.DistinctUserCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedProjectName, model.ProjectName);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedDistinctConversationCount, model.DistinctConversationCount);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, model.RbacGroupName);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
            DistinctConversationCount = 0,
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsProjectActivity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
            DistinctConversationCount = 0,
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsProjectActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDistinctUserCount = 0;
        long expectedMessageCount = 0;
        string expectedProjectID = "project_id";
        string expectedProjectName = "project_name";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaAnalyticsUser expectedCreatedBy = new() { ID = "id", EmailAddress = "email_address" };
        long expectedDistinctConversationCount = 0;
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedDistinctUserCount, deserialized.DistinctUserCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedProjectName, deserialized.ProjectName);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedDistinctConversationCount, deserialized.DistinctConversationCount);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, deserialized.RbacGroupName);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
            DistinctConversationCount = 0,
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
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.DistinctConversationCount);
        Assert.False(model.RawData.ContainsKey("distinct_conversation_count"));
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
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",

            CreatedAt = null,
            CreatedBy = null,
            DistinctConversationCount = null,
            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            UserID = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CreatedBy);
        Assert.True(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.DistinctConversationCount);
        Assert.True(model.RawData.ContainsKey("distinct_conversation_count"));
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
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",

            CreatedAt = null,
            CreatedBy = null,
            DistinctConversationCount = null,
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
        var model = new BetaAnalyticsProjectActivity
        {
            DistinctUserCount = 0,
            MessageCount = 0,
            ProjectID = "project_id",
            ProjectName = "project_name",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
            DistinctConversationCount = 0,
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        BetaAnalyticsProjectActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}
