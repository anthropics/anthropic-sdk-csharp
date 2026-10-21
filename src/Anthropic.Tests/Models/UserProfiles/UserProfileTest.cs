using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfile
        {
            ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            EnforcementActions =
            [
                new UserProfileEnforcementActionRestriction()
                {
                    ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
                    Action = UserProfileEnforcementActionNextStep.Verify,
                    ExpiresAt = null,
                    OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
                    Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
                },
            ],
            EnforcementStatus = UserProfileEnforcementStatus.Unrestricted,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = null,
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = null,
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            Name = "Example User",
            Programs = new()
            {
                Cyber = new()
                {
                    Requirements = new() { DataRetention = true, HumanReview = true },
                    Status = UserProfileProgramStatus.Active,
                    Tiers = new Dictionary<string, UserProfileCyberTier>()
                    {
                        { "a", new(Status.Inactive) },
                        { "b", new(Status.Inactive) },
                        { "c", new(Status.Inactive) },
                    },
                },
                Efs = new()
                {
                    Features = new Dictionary<string, UserProfileEfsFeature>()
                    {
                        { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                        { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                        { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                    },
                    Status = UserProfileProgramStatus.Active,
                },
            },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string expectedID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        ApiEnum<string, UserProfileAccessType> expectedAccessType =
            UserProfileAccessType.Application;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        List<UserProfileEnforcementAction> expectedEnforcementActions =
        [
            new UserProfileEnforcementActionRestriction()
            {
                ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
                Action = UserProfileEnforcementActionNextStep.Verify,
                ExpiresAt = null,
                OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
                Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
            },
        ];
        ApiEnum<string, UserProfileEnforcementStatus> expectedEnforcementStatus =
            UserProfileEnforcementStatus.Unrestricted;
        UserProfileExternalUserDetails expectedExternalUserDetails = new()
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Active,
            Country = "US",
            EmailHash = null,
            EntityType = UserProfileExternalUserEntityType.Business,
            NameHash = null,
            OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
            ReferenceID = "user_12345",
        };
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "Example User";
        UserProfilePrograms expectedPrograms = new()
        {
            Cyber = new()
            {
                Requirements = new() { DataRetention = true, HumanReview = true },
                Status = UserProfileProgramStatus.Active,
                Tiers = new Dictionary<string, UserProfileCyberTier>()
                {
                    { "a", new(Status.Inactive) },
                    { "b", new(Status.Inactive) },
                    { "c", new(Status.Inactive) },
                },
            },
            Efs = new()
            {
                Features = new Dictionary<string, UserProfileEfsFeature>()
                {
                    { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                    { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                    { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                },
                Status = UserProfileProgramStatus.Active,
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_profile");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccessType, model.AccessType);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnforcementActions.Count, model.EnforcementActions.Count);
        for (int i = 0; i < expectedEnforcementActions.Count; i++)
        {
            Assert.Equal(expectedEnforcementActions[i], model.EnforcementActions[i]);
        }
        Assert.Equal(expectedEnforcementStatus, model.EnforcementStatus);
        Assert.Equal(expectedExternalUserDetails, model.ExternalUserDetails);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrograms, model.Programs);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfile
        {
            ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            EnforcementActions =
            [
                new UserProfileEnforcementActionRestriction()
                {
                    ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
                    Action = UserProfileEnforcementActionNextStep.Verify,
                    ExpiresAt = null,
                    OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
                    Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
                },
            ],
            EnforcementStatus = UserProfileEnforcementStatus.Unrestricted,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = null,
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = null,
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            Name = "Example User",
            Programs = new()
            {
                Cyber = new()
                {
                    Requirements = new() { DataRetention = true, HumanReview = true },
                    Status = UserProfileProgramStatus.Active,
                    Tiers = new Dictionary<string, UserProfileCyberTier>()
                    {
                        { "a", new(Status.Inactive) },
                        { "b", new(Status.Inactive) },
                        { "c", new(Status.Inactive) },
                    },
                },
                Efs = new()
                {
                    Features = new Dictionary<string, UserProfileEfsFeature>()
                    {
                        { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                        { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                        { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                    },
                    Status = UserProfileProgramStatus.Active,
                },
            },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfile
        {
            ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            EnforcementActions =
            [
                new UserProfileEnforcementActionRestriction()
                {
                    ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
                    Action = UserProfileEnforcementActionNextStep.Verify,
                    ExpiresAt = null,
                    OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
                    Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
                },
            ],
            EnforcementStatus = UserProfileEnforcementStatus.Unrestricted,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = null,
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = null,
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            Name = "Example User",
            Programs = new()
            {
                Cyber = new()
                {
                    Requirements = new() { DataRetention = true, HumanReview = true },
                    Status = UserProfileProgramStatus.Active,
                    Tiers = new Dictionary<string, UserProfileCyberTier>()
                    {
                        { "a", new(Status.Inactive) },
                        { "b", new(Status.Inactive) },
                        { "c", new(Status.Inactive) },
                    },
                },
                Efs = new()
                {
                    Features = new Dictionary<string, UserProfileEfsFeature>()
                    {
                        { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                        { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                        { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                    },
                    Status = UserProfileProgramStatus.Active,
                },
            },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        ApiEnum<string, UserProfileAccessType> expectedAccessType =
            UserProfileAccessType.Application;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        List<UserProfileEnforcementAction> expectedEnforcementActions =
        [
            new UserProfileEnforcementActionRestriction()
            {
                ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
                Action = UserProfileEnforcementActionNextStep.Verify,
                ExpiresAt = null,
                OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
                Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
            },
        ];
        ApiEnum<string, UserProfileEnforcementStatus> expectedEnforcementStatus =
            UserProfileEnforcementStatus.Unrestricted;
        UserProfileExternalUserDetails expectedExternalUserDetails = new()
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Active,
            Country = "US",
            EmailHash = null,
            EntityType = UserProfileExternalUserEntityType.Business,
            NameHash = null,
            OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
            ReferenceID = "user_12345",
        };
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "Example User";
        UserProfilePrograms expectedPrograms = new()
        {
            Cyber = new()
            {
                Requirements = new() { DataRetention = true, HumanReview = true },
                Status = UserProfileProgramStatus.Active,
                Tiers = new Dictionary<string, UserProfileCyberTier>()
                {
                    { "a", new(Status.Inactive) },
                    { "b", new(Status.Inactive) },
                    { "c", new(Status.Inactive) },
                },
            },
            Efs = new()
            {
                Features = new Dictionary<string, UserProfileEfsFeature>()
                {
                    { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                    { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                    { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                },
                Status = UserProfileProgramStatus.Active,
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_profile");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccessType, deserialized.AccessType);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnforcementActions.Count, deserialized.EnforcementActions.Count);
        for (int i = 0; i < expectedEnforcementActions.Count; i++)
        {
            Assert.Equal(expectedEnforcementActions[i], deserialized.EnforcementActions[i]);
        }
        Assert.Equal(expectedEnforcementStatus, deserialized.EnforcementStatus);
        Assert.Equal(expectedExternalUserDetails, deserialized.ExternalUserDetails);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrograms, deserialized.Programs);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfile
        {
            ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            EnforcementActions =
            [
                new UserProfileEnforcementActionRestriction()
                {
                    ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
                    Action = UserProfileEnforcementActionNextStep.Verify,
                    ExpiresAt = null,
                    OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
                    Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
                },
            ],
            EnforcementStatus = UserProfileEnforcementStatus.Unrestricted,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = null,
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = null,
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            Name = "Example User",
            Programs = new()
            {
                Cyber = new()
                {
                    Requirements = new() { DataRetention = true, HumanReview = true },
                    Status = UserProfileProgramStatus.Active,
                    Tiers = new Dictionary<string, UserProfileCyberTier>()
                    {
                        { "a", new(Status.Inactive) },
                        { "b", new(Status.Inactive) },
                        { "c", new(Status.Inactive) },
                    },
                },
                Efs = new()
                {
                    Features = new Dictionary<string, UserProfileEfsFeature>()
                    {
                        { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                        { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                        { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                    },
                    Status = UserProfileProgramStatus.Active,
                },
            },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfile
        {
            ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            EnforcementActions =
            [
                new UserProfileEnforcementActionRestriction()
                {
                    ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
                    Action = UserProfileEnforcementActionNextStep.Verify,
                    ExpiresAt = null,
                    OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
                    Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
                },
            ],
            EnforcementStatus = UserProfileEnforcementStatus.Unrestricted,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = null,
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = null,
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            Name = "Example User",
            Programs = new()
            {
                Cyber = new()
                {
                    Requirements = new() { DataRetention = true, HumanReview = true },
                    Status = UserProfileProgramStatus.Active,
                    Tiers = new Dictionary<string, UserProfileCyberTier>()
                    {
                        { "a", new(Status.Inactive) },
                        { "b", new(Status.Inactive) },
                        { "c", new(Status.Inactive) },
                    },
                },
                Efs = new()
                {
                    Features = new Dictionary<string, UserProfileEfsFeature>()
                    {
                        { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                        { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                        { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                    },
                    Status = UserProfileProgramStatus.Active,
                },
            },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        UserProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
