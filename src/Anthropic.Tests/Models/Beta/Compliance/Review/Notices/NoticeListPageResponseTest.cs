using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Notices = Anthropic.Models.Beta.Compliance.Review.Notices;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Notices;

public class NoticeListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notices::NoticeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CaseIds = ["string"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = new(Notices::Type.ResponseRequested),
                    Message = "message",
                    OrganizationID = "organization_id",
                    RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        List<Notices::BetaComplianceReviewNotice> expectedData =
        [
            new()
            {
                ID = "id",
                CaseIds = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Kind = new(Notices::Type.ResponseRequested),
                Message = "message",
                OrganizationID = "organization_id",
                RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new Notices::NoticeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CaseIds = ["string"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = new(Notices::Type.ResponseRequested),
                    Message = "message",
                    OrganizationID = "organization_id",
                    RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notices::NoticeListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notices::NoticeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CaseIds = ["string"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = new(Notices::Type.ResponseRequested),
                    Message = "message",
                    OrganizationID = "organization_id",
                    RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notices::NoticeListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Notices::BetaComplianceReviewNotice> expectedData =
        [
            new()
            {
                ID = "id",
                CaseIds = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Kind = new(Notices::Type.ResponseRequested),
                Message = "message",
                OrganizationID = "organization_id",
                RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new Notices::NoticeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CaseIds = ["string"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = new(Notices::Type.ResponseRequested),
                    Message = "message",
                    OrganizationID = "organization_id",
                    RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notices::NoticeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CaseIds = ["string"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = new(Notices::Type.ResponseRequested),
                    Message = "message",
                    OrganizationID = "organization_id",
                    RespondBy = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPage = "next_page",
        };

        Notices::NoticeListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
