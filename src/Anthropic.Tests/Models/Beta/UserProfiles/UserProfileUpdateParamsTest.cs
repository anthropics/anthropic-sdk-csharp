using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
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
            ExternalID = "user_12345",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedUserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        string expectedExternalID = "user_12345";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
        Assert.Equal(expectedExternalID, parameters.ExternalID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
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
            ExternalID = "user_12345",
        };

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
            ExternalID = "user_12345",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Betas = null,
        };

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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.ExternalID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            ExternalID = null,
        };

        Assert.Null(parameters.ExternalID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_id"));
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
            ["user-profiles-2026-03-24", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            ExternalID = "user_12345",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        UserProfileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
