using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class BetaUserProfileEnrollmentUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUserProfileEnrollmentUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Type = BetaUserProfileEnrollmentUrlType.EnrollmentUrl,
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z");
        ApiEnum<string, BetaUserProfileEnrollmentUrlType> expectedType =
            BetaUserProfileEnrollmentUrlType.EnrollmentUrl;
        string expectedUrl =
            "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1";

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaUserProfileEnrollmentUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Type = BetaUserProfileEnrollmentUrlType.EnrollmentUrl,
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileEnrollmentUrl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUserProfileEnrollmentUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Type = BetaUserProfileEnrollmentUrlType.EnrollmentUrl,
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileEnrollmentUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z");
        ApiEnum<string, BetaUserProfileEnrollmentUrlType> expectedType =
            BetaUserProfileEnrollmentUrlType.EnrollmentUrl;
        string expectedUrl =
            "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1";

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaUserProfileEnrollmentUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Type = BetaUserProfileEnrollmentUrlType.EnrollmentUrl,
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaUserProfileEnrollmentUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2026-03-15T10:15:00Z"),
            Type = BetaUserProfileEnrollmentUrlType.EnrollmentUrl,
            Url = "https://platform.claude.com/user-profiles/enrollment/M3J0bGJxZ2ppMnptbnB1",
        };

        BetaUserProfileEnrollmentUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaUserProfileEnrollmentUrlTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaUserProfileEnrollmentUrlType.EnrollmentUrl)]
    public void Validation_Works(BetaUserProfileEnrollmentUrlType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileEnrollmentUrlType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileEnrollmentUrlType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaUserProfileEnrollmentUrlType.EnrollmentUrl)]
    public void SerializationRoundtrip_Works(BetaUserProfileEnrollmentUrlType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileEnrollmentUrlType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileEnrollmentUrlType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUserProfileEnrollmentUrlType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileEnrollmentUrlType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
