using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class BetaUserProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUserProfile
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
        };

        string expectedID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "Example User";
        Dictionary<string, BetaUserProfileTrustGrant> expectedTrustGrants = new()
        {
            { "cyber", new(Status.Active) },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_profile");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        ApiEnum<string, BetaUserProfileAccessType> expectedAccessType =
            BetaUserProfileAccessType.Application;
        string expectedExternalID = "user_12345";
        BetaUserProfileExternalUserDetails expectedExternalUserDetails = new()
        {
            AccountStatus = AccountStatus.Active,
            Country = "US",
            EmailHash = null,
            EntityType = EntityType.Business,
            NameHash = null,
            OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
            ReferenceID = "user_12345",
        };
        DateTimeOffset expectedExternalUserOnboardedAt = DateTimeOffset.Parse(
            "2024-11-02T08:15:00Z"
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTrustGrants.Count, model.TrustGrants.Count);
        foreach (var item in expectedTrustGrants)
        {
            Assert.True(model.TrustGrants.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TrustGrants[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedAccessType, model.AccessType);
        Assert.Equal(expectedExternalID, model.ExternalID);
        Assert.Equal(expectedExternalUserDetails, model.ExternalUserDetails);
        Assert.Equal(expectedExternalUserOnboardedAt, model.ExternalUserOnboardedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaUserProfile
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUserProfile
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "Example User";
        Dictionary<string, BetaUserProfileTrustGrant> expectedTrustGrants = new()
        {
            { "cyber", new(Status.Active) },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_profile");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        ApiEnum<string, BetaUserProfileAccessType> expectedAccessType =
            BetaUserProfileAccessType.Application;
        string expectedExternalID = "user_12345";
        BetaUserProfileExternalUserDetails expectedExternalUserDetails = new()
        {
            AccountStatus = AccountStatus.Active,
            Country = "US",
            EmailHash = null,
            EntityType = EntityType.Business,
            NameHash = null,
            OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
            ReferenceID = "user_12345",
        };
        DateTimeOffset expectedExternalUserOnboardedAt = DateTimeOffset.Parse(
            "2024-11-02T08:15:00Z"
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTrustGrants.Count, deserialized.TrustGrants.Count);
        foreach (var item in expectedTrustGrants)
        {
            Assert.True(deserialized.TrustGrants.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TrustGrants[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedAccessType, deserialized.AccessType);
        Assert.Equal(expectedExternalID, deserialized.ExternalID);
        Assert.Equal(expectedExternalUserDetails, deserialized.ExternalUserDetails);
        Assert.Equal(expectedExternalUserOnboardedAt, deserialized.ExternalUserOnboardedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaUserProfile
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaUserProfile
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
            ExternalID = "user_12345",
            ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
        };

        Assert.Null(model.AccessType);
        Assert.False(model.RawData.ContainsKey("access_type"));
        Assert.Null(model.ExternalUserDetails);
        Assert.False(model.RawData.ContainsKey("external_user_details"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaUserProfile
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
            ExternalID = "user_12345",
            ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaUserProfile
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
            ExternalID = "user_12345",
            ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),

            // Null should be interpreted as omitted for these properties
            AccessType = null,
            ExternalUserDetails = null,
        };

        Assert.Null(model.AccessType);
        Assert.False(model.RawData.ContainsKey("access_type"));
        Assert.Null(model.ExternalUserDetails);
        Assert.False(model.RawData.ContainsKey("external_user_details"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaUserProfile
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
        } with
        {
            // Null should be interpreted as omitted for these properties
            AccessType = null,
            ExternalUserDetails = null,
        };

        Assert.Null(model.AccessType);
        Assert.False(model.RawData.ContainsKey("access_type"));
        Assert.Null(model.ExternalUserDetails);
        Assert.False(model.RawData.ContainsKey("external_user_details"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaUserProfile
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
            ExternalID = "user_12345",
            ExternalUserOnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),

            // Null should be interpreted as omitted for these properties
            AccessType = null,
            ExternalUserDetails = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaUserProfile
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
        };

        Assert.Null(model.ExternalID);
        Assert.False(model.RawData.ContainsKey("external_id"));
        Assert.Null(model.ExternalUserOnboardedAt);
        Assert.False(model.RawData.ContainsKey("external_user_onboarded_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaUserProfile
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaUserProfile
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

            ExternalID = null,
            ExternalUserOnboardedAt = null,
        };

        Assert.Null(model.ExternalID);
        Assert.True(model.RawData.ContainsKey("external_id"));
        Assert.Null(model.ExternalUserOnboardedAt);
        Assert.True(model.RawData.ContainsKey("external_user_onboarded_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaUserProfile
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

            ExternalID = null,
            ExternalUserOnboardedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaUserProfile
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
        };

        BetaUserProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaUserProfileAccessTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaUserProfileAccessType.Application)]
    [InlineData(BetaUserProfileAccessType.Passthrough)]
    public void Validation_Works(BetaUserProfileAccessType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileAccessType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileAccessType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaUserProfileAccessType.Application)]
    [InlineData(BetaUserProfileAccessType.Passthrough)]
    public void SerializationRoundtrip_Works(BetaUserProfileAccessType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileAccessType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileAccessType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileAccessType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileAccessType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
