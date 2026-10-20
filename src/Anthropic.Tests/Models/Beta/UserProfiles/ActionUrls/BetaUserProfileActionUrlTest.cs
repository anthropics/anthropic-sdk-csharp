using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.ActionUrls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.ActionUrls;

public class BetaUserProfileActionUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUserProfileActionUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_profile_action_url");
        string expectedUrl =
            "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1";

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaUserProfileActionUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileActionUrl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUserProfileActionUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileActionUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_profile_action_url");
        string expectedUrl =
            "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1";

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaUserProfileActionUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaUserProfileActionUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        BetaUserProfileActionUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}
