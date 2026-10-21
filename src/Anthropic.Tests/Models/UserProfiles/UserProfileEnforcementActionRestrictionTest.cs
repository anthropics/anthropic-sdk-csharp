using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileEnforcementActionRestrictionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfileEnforcementActionRestriction
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = UserProfileEnforcementActionNextStep.Verify,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
        };

        string expectedID = "enac_011CZkZCu8hGbp5mYRQgUmz9";
        ApiEnum<string, UserProfileEnforcementActionNextStep> expectedAction =
            UserProfileEnforcementActionNextStep.Verify;
        DateTimeOffset expectedOpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z");
        ApiEnum<string, UserProfileEnforcementActionReason> expectedReason =
            UserProfileEnforcementActionReason.FraudOrAbuse;
        JsonElement expectedType = JsonSerializer.SerializeToElement("restriction");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAction, model.Action);
        Assert.Null(model.ExpiresAt);
        Assert.Equal(expectedOpenedAt, model.OpenedAt);
        Assert.Equal(expectedReason, model.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfileEnforcementActionRestriction
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = UserProfileEnforcementActionNextStep.Verify,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEnforcementActionRestriction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfileEnforcementActionRestriction
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = UserProfileEnforcementActionNextStep.Verify,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEnforcementActionRestriction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "enac_011CZkZCu8hGbp5mYRQgUmz9";
        ApiEnum<string, UserProfileEnforcementActionNextStep> expectedAction =
            UserProfileEnforcementActionNextStep.Verify;
        DateTimeOffset expectedOpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z");
        ApiEnum<string, UserProfileEnforcementActionReason> expectedReason =
            UserProfileEnforcementActionReason.FraudOrAbuse;
        JsonElement expectedType = JsonSerializer.SerializeToElement("restriction");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Null(deserialized.ExpiresAt);
        Assert.Equal(expectedOpenedAt, deserialized.OpenedAt);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfileEnforcementActionRestriction
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = UserProfileEnforcementActionNextStep.Verify,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfileEnforcementActionRestriction
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = UserProfileEnforcementActionNextStep.Verify,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.FraudOrAbuse,
        };

        UserProfileEnforcementActionRestriction copied = new(model);

        Assert.Equal(model, copied);
    }
}
