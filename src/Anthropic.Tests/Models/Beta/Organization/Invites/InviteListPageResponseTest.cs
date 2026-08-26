using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.Invites;

namespace Anthropic.Tests.Models.Beta.Organization.Invites;

public class InviteListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InviteListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
                    AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "user@emaildomain.com",
                    ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
                    InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    RbacGroupIds = ["string"],
                    Role = BetaOrganizationRole.Admin,
                    Status = BetaOrganizationInviteStatus.Pending,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        List<BetaOrganizationInvite> expectedData =
        [
            new()
            {
                ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
                AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Email = "user@emaildomain.com",
                ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
                InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                RbacGroupIds = ["string"],
                Role = BetaOrganizationRole.Admin,
                Status = BetaOrganizationInviteStatus.Pending,
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedFirstID, model.FirstID);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLastID, model.LastID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InviteListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
                    AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "user@emaildomain.com",
                    ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
                    InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    RbacGroupIds = ["string"],
                    Role = BetaOrganizationRole.Admin,
                    Status = BetaOrganizationInviteStatus.Pending,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InviteListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InviteListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
                    AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "user@emaildomain.com",
                    ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
                    InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    RbacGroupIds = ["string"],
                    Role = BetaOrganizationRole.Admin,
                    Status = BetaOrganizationInviteStatus.Pending,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InviteListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaOrganizationInvite> expectedData =
        [
            new()
            {
                ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
                AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Email = "user@emaildomain.com",
                ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
                InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                RbacGroupIds = ["string"],
                Role = BetaOrganizationRole.Admin,
                Status = BetaOrganizationInviteStatus.Pending,
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedFirstID, deserialized.FirstID);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLastID, deserialized.LastID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InviteListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
                    AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "user@emaildomain.com",
                    ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
                    InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    RbacGroupIds = ["string"],
                    Role = BetaOrganizationRole.Admin,
                    Status = BetaOrganizationInviteStatus.Pending,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InviteListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
                    AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Email = "user@emaildomain.com",
                    ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
                    InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    RbacGroupIds = ["string"],
                    Role = BetaOrganizationRole.Admin,
                    Status = BetaOrganizationInviteStatus.Pending,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        InviteListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
