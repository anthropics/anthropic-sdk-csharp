using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewCase
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
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaComplianceReviewEnforcementAction expectedEnforcementAction = new("type");
        string expectedOrganizationID = "organization_id";
        List<ApiEnum<string, BetaComplianceReviewPolicyCategory>> expectedPolicyCategories =
        [
            BetaComplianceReviewPolicyCategory.Cyber,
        ];
        BetaComplianceReviewCaseStatus expectedStatus = new BetaComplianceReviewCaseOpen();
        List<BetaComplianceReviewTranscript> expectedTranscripts =
        [
            new() { ItemID = "item_id", UserProfileID = "user_profile_id" },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_review_case");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnforcementAction, model.EnforcementAction);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedPolicyCategories.Count, model.PolicyCategories.Count);
        for (int i = 0; i < expectedPolicyCategories.Count; i++)
        {
            Assert.Equal(expectedPolicyCategories[i], model.PolicyCategories[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTranscripts.Count, model.Transcripts.Count);
        for (int i = 0; i < expectedTranscripts.Count; i++)
        {
            Assert.Equal(expectedTranscripts[i], model.Transcripts[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewCase
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewCase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewCase
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaComplianceReviewEnforcementAction expectedEnforcementAction = new("type");
        string expectedOrganizationID = "organization_id";
        List<ApiEnum<string, BetaComplianceReviewPolicyCategory>> expectedPolicyCategories =
        [
            BetaComplianceReviewPolicyCategory.Cyber,
        ];
        BetaComplianceReviewCaseStatus expectedStatus = new BetaComplianceReviewCaseOpen();
        List<BetaComplianceReviewTranscript> expectedTranscripts =
        [
            new() { ItemID = "item_id", UserProfileID = "user_profile_id" },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_review_case");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnforcementAction, deserialized.EnforcementAction);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedPolicyCategories.Count, deserialized.PolicyCategories.Count);
        for (int i = 0; i < expectedPolicyCategories.Count; i++)
        {
            Assert.Equal(expectedPolicyCategories[i], deserialized.PolicyCategories[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTranscripts.Count, deserialized.Transcripts.Count);
        for (int i = 0; i < expectedTranscripts.Count; i++)
        {
            Assert.Equal(expectedTranscripts[i], deserialized.Transcripts[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewCase
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewCase
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
        };

        BetaComplianceReviewCase copied = new(model);

        Assert.Equal(model, copied);
    }
}
