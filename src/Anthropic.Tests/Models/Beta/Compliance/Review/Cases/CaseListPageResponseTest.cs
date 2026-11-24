using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class CaseListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CaseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EnforcementAction = new("type"),
                    OrganizationID = "organization_id",
                    PolicyCategories = [BetaComplianceReviewPolicyCategory.Cyber],
                    Status = new BetaComplianceReviewCaseOpen(),
                    Transcripts = [new() { ItemID = "item_id", UserProfileID = "user_profile_id" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaComplianceReviewCase> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EnforcementAction = new("type"),
                OrganizationID = "organization_id",
                PolicyCategories = [BetaComplianceReviewPolicyCategory.Cyber],
                Status = new BetaComplianceReviewCaseOpen(),
                Transcripts = [new() { ItemID = "item_id", UserProfileID = "user_profile_id" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new CaseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EnforcementAction = new("type"),
                    OrganizationID = "organization_id",
                    PolicyCategories = [BetaComplianceReviewPolicyCategory.Cyber],
                    Status = new BetaComplianceReviewCaseOpen(),
                    Transcripts = [new() { ItemID = "item_id", UserProfileID = "user_profile_id" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CaseListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CaseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EnforcementAction = new("type"),
                    OrganizationID = "organization_id",
                    PolicyCategories = [BetaComplianceReviewPolicyCategory.Cyber],
                    Status = new BetaComplianceReviewCaseOpen(),
                    Transcripts = [new() { ItemID = "item_id", UserProfileID = "user_profile_id" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CaseListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaComplianceReviewCase> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EnforcementAction = new("type"),
                OrganizationID = "organization_id",
                PolicyCategories = [BetaComplianceReviewPolicyCategory.Cyber],
                Status = new BetaComplianceReviewCaseOpen(),
                Transcripts = [new() { ItemID = "item_id", UserProfileID = "user_profile_id" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new CaseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EnforcementAction = new("type"),
                    OrganizationID = "organization_id",
                    PolicyCategories = [BetaComplianceReviewPolicyCategory.Cyber],
                    Status = new BetaComplianceReviewCaseOpen(),
                    Transcripts = [new() { ItemID = "item_id", UserProfileID = "user_profile_id" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new CaseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EnforcementAction = new("type"),
                    OrganizationID = "organization_id",
                    PolicyCategories = [BetaComplianceReviewPolicyCategory.Cyber],
                    Status = new BetaComplianceReviewCaseOpen(),
                    Transcripts = [new() { ItemID = "item_id", UserProfileID = "user_profile_id" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WorkspaceID = "workspace_id",
                },
            ],
            NextPage = "next_page",
        };

        CaseListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
