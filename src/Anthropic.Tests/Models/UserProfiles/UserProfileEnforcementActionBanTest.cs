using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileEnforcementActionBanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfileEnforcementActionBan
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = null,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.UsagePolicyViolation,
        };

        string expectedID = "enac_011CZkZCu8hGbp5mYRQgUmz9";
        DateTimeOffset expectedOpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z");
        ApiEnum<string, UserProfileEnforcementActionReason> expectedReason =
            UserProfileEnforcementActionReason.UsagePolicyViolation;
        JsonElement expectedType = JsonSerializer.SerializeToElement("ban");

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.Action);
        Assert.Null(model.ExpiresAt);
        Assert.Equal(expectedOpenedAt, model.OpenedAt);
        Assert.Equal(expectedReason, model.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfileEnforcementActionBan
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = null,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.UsagePolicyViolation,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEnforcementActionBan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfileEnforcementActionBan
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = null,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.UsagePolicyViolation,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEnforcementActionBan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "enac_011CZkZCu8hGbp5mYRQgUmz9";
        DateTimeOffset expectedOpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z");
        ApiEnum<string, UserProfileEnforcementActionReason> expectedReason =
            UserProfileEnforcementActionReason.UsagePolicyViolation;
        JsonElement expectedType = JsonSerializer.SerializeToElement("ban");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.Action);
        Assert.Null(deserialized.ExpiresAt);
        Assert.Equal(expectedOpenedAt, deserialized.OpenedAt);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfileEnforcementActionBan
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = null,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.UsagePolicyViolation,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfileEnforcementActionBan
        {
            ID = "enac_011CZkZCu8hGbp5mYRQgUmz9",
            Action = null,
            ExpiresAt = null,
            OpenedAt = DateTimeOffset.Parse("2026-10-02T19:30:00Z"),
            Reason = UserProfileEnforcementActionReason.UsagePolicyViolation,
        };

        UserProfileEnforcementActionBan copied = new(model);

        Assert.Equal(model, copied);
    }
}
