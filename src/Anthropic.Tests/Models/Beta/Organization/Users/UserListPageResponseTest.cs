using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.Users;

namespace Anthropic.Tests.Models.Beta.Organization.Users;

public class UserListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Email = "user@emaildomain.com",
                    Name = "Jane Doe",
                    Role = BetaOrganizationRole.Admin,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        List<BetaOrganizationUser> expectedData =
        [
            new()
            {
                ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Email = "user@emaildomain.com",
                Name = "Jane Doe",
                Role = BetaOrganizationRole.Admin,
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
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Email = "user@emaildomain.com",
                    Name = "Jane Doe",
                    Role = BetaOrganizationRole.Admin,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Email = "user@emaildomain.com",
                    Name = "Jane Doe",
                    Role = BetaOrganizationRole.Admin,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaOrganizationUser> expectedData =
        [
            new()
            {
                ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Email = "user@emaildomain.com",
                Name = "Jane Doe",
                Role = BetaOrganizationRole.Admin,
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
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Email = "user@emaildomain.com",
                    Name = "Jane Doe",
                    Role = BetaOrganizationRole.Admin,
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
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Email = "user@emaildomain.com",
                    Name = "Jane Doe",
                    Role = BetaOrganizationRole.Admin,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        UserListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
