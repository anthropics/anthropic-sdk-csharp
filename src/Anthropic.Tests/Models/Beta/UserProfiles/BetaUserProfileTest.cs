using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using UserProfiles = Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class BetaUserProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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
        };

        string expectedID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Dictionary<string, string> expectedMetadata = new();
        Dictionary<string, UserProfiles::BetaUserProfileTrustGrant> expectedTrustGrants = new()
        {
            { "cyber", new(UserProfiles::Status.Active) },
        };
        ApiEnum<string, UserProfiles::Type> expectedType = UserProfiles::Type.UserProfile;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedExternalID = "user_12345";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedTrustGrants.Count, model.TrustGrants.Count);
        foreach (var item in expectedTrustGrants)
        {
            Assert.True(model.TrustGrants.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TrustGrants[item.Key]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedExternalID, model.ExternalID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfiles::BetaUserProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfiles::BetaUserProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Dictionary<string, string> expectedMetadata = new();
        Dictionary<string, UserProfiles::BetaUserProfileTrustGrant> expectedTrustGrants = new()
        {
            { "cyber", new(UserProfiles::Status.Active) },
        };
        ApiEnum<string, UserProfiles::Type> expectedType = UserProfiles::Type.UserProfile;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedExternalID = "user_12345";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedTrustGrants.Count, deserialized.TrustGrants.Count);
        foreach (var item in expectedTrustGrants)
        {
            Assert.True(deserialized.TrustGrants.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TrustGrants[item.Key]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedExternalID, deserialized.ExternalID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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
        };

        Assert.Null(model.ExternalID);
        Assert.False(model.RawData.ContainsKey("external_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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

            ExternalID = null,
        };

        Assert.Null(model.ExternalID);
        Assert.True(model.RawData.ContainsKey("external_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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

            ExternalID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfiles::BetaUserProfile
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
        };

        UserProfiles::BetaUserProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(UserProfiles::Type.UserProfile)]
    public void Validation_Works(UserProfiles::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfiles::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfiles::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfiles::Type.UserProfile)]
    public void SerializationRoundtrip_Works(UserProfiles::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfiles::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfiles::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfiles::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserProfiles::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
