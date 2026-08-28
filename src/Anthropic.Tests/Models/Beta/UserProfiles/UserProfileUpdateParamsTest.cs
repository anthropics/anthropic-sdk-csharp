using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class UserProfileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileUpdateParamsAccessType.Application,
            ExternalID = "user_12345",
            ExternalUserOnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedUserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        ApiEnum<string, UserProfileUpdateParamsAccessType> expectedAccessType =
            UserProfileUpdateParamsAccessType.Application;
        string expectedExternalID = "user_12345";
        DateTimeOffset expectedExternalUserOnboardedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "x";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
        Assert.Equal(expectedAccessType, parameters.AccessType);
        Assert.Equal(expectedExternalID, parameters.ExternalID);
        Assert.Equal(expectedExternalUserOnboardedAt, parameters.ExternalUserOnboardedAt);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileUpdateParamsAccessType.Application,
            ExternalID = "user_12345",
            Name = "x",
        };

        Assert.Null(parameters.ExternalUserOnboardedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("external_user_onboarded_at"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileUpdateParamsAccessType.Application,
            ExternalID = "user_12345",
            Name = "x",

            // Null should be interpreted as omitted for these properties
            ExternalUserOnboardedAt = null,
            Metadata = null,
            Betas = null,
        };

        Assert.Null(parameters.ExternalUserOnboardedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("external_user_onboarded_at"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            ExternalUserOnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.AccessType);
        Assert.False(parameters.RawBodyData.ContainsKey("access_type"));
        Assert.Null(parameters.ExternalID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            ExternalUserOnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            AccessType = null,
            ExternalID = null,
            Name = null,
        };

        Assert.Null(parameters.AccessType);
        Assert.True(parameters.RawBodyData.ContainsKey("access_type"));
        Assert.Null(parameters.ExternalID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_id"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        UserProfileUpdateParams parameters = new()
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/user_profiles/uprof_011CZkZCu8hGbp5mYRQgUmz9?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserProfileUpdateParams parameters = new()
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["user-profiles-2026-08-18", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileUpdateParamsAccessType.Application,
            ExternalID = "user_12345",
            ExternalUserOnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        UserProfileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UserProfileUpdateParamsAccessTypeTest : TestBase
{
    [Theory]
    [InlineData(UserProfileUpdateParamsAccessType.Application)]
    [InlineData(UserProfileUpdateParamsAccessType.Passthrough)]
    public void Validation_Works(UserProfileUpdateParamsAccessType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileUpdateParamsAccessType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileUpdateParamsAccessType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserProfileUpdateParamsAccessType.Application)]
    [InlineData(UserProfileUpdateParamsAccessType.Passthrough)]
    public void SerializationRoundtrip_Works(UserProfileUpdateParamsAccessType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserProfileUpdateParamsAccessType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileUpdateParamsAccessType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserProfileUpdateParamsAccessType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserProfileUpdateParamsAccessType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
