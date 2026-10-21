using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class UserProfileListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    Name = "Example User",
                    TrustGrants = new Dictionary<string, BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(Status.Active) },
                    },
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    AccessType = BetaUserProfileAccessType.Application,
                    ExternalID = "user_12345",
                    ExternalUserDetails = new()
                    {
                        AccountStatus = AccountStatus.Active,
                        Country = "US",
                        EmailHash = null,
                        EntityType = EntityType.Business,
                        NameHash = null,
                        OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                        ReferenceID = "user_12345",
                    },
                    ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<BetaUserProfile> expectedData =
        [
            new()
            {
                ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Metadata = new Dictionary<string, string>(),
                Name = "Example User",
                TrustGrants = new Dictionary<string, BetaUserProfileTrustGrant>()
                {
                    { "cyber", new(Status.Active) },
                },
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                AccessType = BetaUserProfileAccessType.Application,
                ExternalID = "user_12345",
                ExternalUserDetails = new()
                {
                    AccountStatus = AccountStatus.Active,
                    Country = "US",
                    EmailHash = null,
                    EntityType = EntityType.Business,
                    NameHash = null,
                    OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                    ReferenceID = "user_12345",
                },
                ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
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
        var model = new UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    Name = "Example User",
                    TrustGrants = new Dictionary<string, BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(Status.Active) },
                    },
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    AccessType = BetaUserProfileAccessType.Application,
                    ExternalID = "user_12345",
                    ExternalUserDetails = new()
                    {
                        AccountStatus = AccountStatus.Active,
                        Country = "US",
                        EmailHash = null,
                        EntityType = EntityType.Business,
                        NameHash = null,
                        OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                        ReferenceID = "user_12345",
                    },
                    ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    Name = "Example User",
                    TrustGrants = new Dictionary<string, BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(Status.Active) },
                    },
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    AccessType = BetaUserProfileAccessType.Application,
                    ExternalID = "user_12345",
                    ExternalUserDetails = new()
                    {
                        AccountStatus = AccountStatus.Active,
                        Country = "US",
                        EmailHash = null,
                        EntityType = EntityType.Business,
                        NameHash = null,
                        OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                        ReferenceID = "user_12345",
                    },
                    ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaUserProfile> expectedData =
        [
            new()
            {
                ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Metadata = new Dictionary<string, string>(),
                Name = "Example User",
                TrustGrants = new Dictionary<string, BetaUserProfileTrustGrant>()
                {
                    { "cyber", new(Status.Active) },
                },
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                AccessType = BetaUserProfileAccessType.Application,
                ExternalID = "user_12345",
                ExternalUserDetails = new()
                {
                    AccountStatus = AccountStatus.Active,
                    Country = "US",
                    EmailHash = null,
                    EntityType = EntityType.Business,
                    NameHash = null,
                    OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                    ReferenceID = "user_12345",
                },
                ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
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
        var model = new UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    Name = "Example User",
                    TrustGrants = new Dictionary<string, BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(Status.Active) },
                    },
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    AccessType = BetaUserProfileAccessType.Application,
                    ExternalID = "user_12345",
                    ExternalUserDetails = new()
                    {
                        AccountStatus = AccountStatus.Active,
                        Country = "US",
                        EmailHash = null,
                        EntityType = EntityType.Business,
                        NameHash = null,
                        OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                        ReferenceID = "user_12345",
                    },
                    ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>(),
                    Name = "Example User",
                    TrustGrants = new Dictionary<string, BetaUserProfileTrustGrant>()
                    {
                        { "cyber", new(Status.Active) },
                    },
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    AccessType = BetaUserProfileAccessType.Application,
                    ExternalID = "user_12345",
                    ExternalUserDetails = new()
                    {
                        AccountStatus = AccountStatus.Active,
                        Country = "US",
                        EmailHash = null,
                        EntityType = EntityType.Business,
                        NameHash = null,
                        OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                        ReferenceID = "user_12345",
                    },
                    ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        UserProfileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
