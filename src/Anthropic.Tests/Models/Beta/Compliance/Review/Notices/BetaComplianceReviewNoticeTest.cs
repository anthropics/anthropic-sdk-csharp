using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Notices = Anthropic.Models.Beta.Compliance.Review.Notices;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Notices;

public class BetaComplianceReviewNoticeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notices::BetaComplianceReviewNotice
        {
            ID = "id",
            CaseIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = new(Notices::Type.ResponseRequested),
            Message = "message",
            OrganizationID = "organization_id",
            RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<string> expectedCaseIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Notices::BetaComplianceReviewNoticeKind expectedKind = new(Notices::Type.ResponseRequested);
        string expectedMessage = "message";
        string expectedOrganizationID = "organization_id";
        DateTimeOffset expectedRespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_review_notice");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCaseIds.Count, model.CaseIds.Count);
        for (int i = 0; i < expectedCaseIds.Count; i++)
        {
            Assert.Equal(expectedCaseIds[i], model.CaseIds[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedRespondBy, model.RespondBy);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notices::BetaComplianceReviewNotice
        {
            ID = "id",
            CaseIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = new(Notices::Type.ResponseRequested),
            Message = "message",
            OrganizationID = "organization_id",
            RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notices::BetaComplianceReviewNotice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notices::BetaComplianceReviewNotice
        {
            ID = "id",
            CaseIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = new(Notices::Type.ResponseRequested),
            Message = "message",
            OrganizationID = "organization_id",
            RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notices::BetaComplianceReviewNotice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedCaseIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Notices::BetaComplianceReviewNoticeKind expectedKind = new(Notices::Type.ResponseRequested);
        string expectedMessage = "message";
        string expectedOrganizationID = "organization_id";
        DateTimeOffset expectedRespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_review_notice");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCaseIds.Count, deserialized.CaseIds.Count);
        for (int i = 0; i < expectedCaseIds.Count; i++)
        {
            Assert.Equal(expectedCaseIds[i], deserialized.CaseIds[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedRespondBy, deserialized.RespondBy);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notices::BetaComplianceReviewNotice
        {
            ID = "id",
            CaseIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = new(Notices::Type.ResponseRequested),
            Message = "message",
            OrganizationID = "organization_id",
            RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notices::BetaComplianceReviewNotice
        {
            ID = "id",
            CaseIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = new(Notices::Type.ResponseRequested),
            Message = "message",
            OrganizationID = "organization_id",
            RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Notices::BetaComplianceReviewNotice copied = new(model);

        Assert.Equal(model, copied);
    }
}
