using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using UserProfiles = Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class UserProfileListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfiles::UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    TrustGrants = new Dictionary<string, UserProfiles::BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(UserProfiles::Status.Active) },
                    },
                    Type = UserProfiles::Type.UserProfile,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    ExternalID = "user_12345",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<UserProfiles::BetaUserProfile> expectedData =
        [
            new()
            {
                ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Metadata = new Dictionary<string, string>(),
                TrustGrants = new Dictionary<string, UserProfiles::BetaUserProfileTrustGrant>()
                {
                    { "cyber", new(UserProfiles::Status.Active) },
                },
                Type = UserProfiles::Type.UserProfile,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                ExternalID = "user_12345",
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

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
        var model = new UserProfiles::UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    TrustGrants = new Dictionary<string, UserProfiles::BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(UserProfiles::Status.Active) },
                    },
                    Type = UserProfiles::Type.UserProfile,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    ExternalID = "user_12345",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfiles::UserProfileListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfiles::UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    TrustGrants = new Dictionary<string, UserProfiles::BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(UserProfiles::Status.Active) },
                    },
                    Type = UserProfiles::Type.UserProfile,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    ExternalID = "user_12345",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfiles::UserProfileListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<UserProfiles::BetaUserProfile> expectedData =
        [
            new()
            {
                ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Metadata = new Dictionary<string, string>(),
                TrustGrants = new Dictionary<string, UserProfiles::BetaUserProfileTrustGrant>()
                {
                    { "cyber", new(UserProfiles::Status.Active) },
                },
                Type = UserProfiles::Type.UserProfile,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                ExternalID = "user_12345",
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

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
        var model = new UserProfiles::UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    TrustGrants = new Dictionary<string, UserProfiles::BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(UserProfiles::Status.Active) },
                    },
                    Type = UserProfiles::Type.UserProfile,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    ExternalID = "user_12345",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfiles::UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    TrustGrants = new Dictionary<string, UserProfiles::BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(UserProfiles::Status.Active) },
                    },
                    Type = UserProfiles::Type.UserProfile,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    ExternalID = "user_12345",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        UserProfiles::UserProfileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
