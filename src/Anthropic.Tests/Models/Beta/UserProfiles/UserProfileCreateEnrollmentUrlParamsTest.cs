using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class UserProfileCreateEnrollmentUrlParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserProfileCreateEnrollmentUrlParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedUserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserProfileCreateEnrollmentUrlParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserProfileCreateEnrollmentUrlParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",

            // Null should be interpreted as omitted for these properties
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void Url_Works()
    {
        UserProfileCreateEnrollmentUrlParams parameters = new()
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/user_profiles/uprof_011CZkZCu8hGbp5mYRQgUmz9/enrollment_url?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserProfileCreateEnrollmentUrlParams parameters = new()
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["user-profiles-2026-08-18", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserProfileCreateEnrollmentUrlParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        UserProfileCreateEnrollmentUrlParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
