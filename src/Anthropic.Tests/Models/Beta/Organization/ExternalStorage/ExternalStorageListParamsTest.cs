using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class ExternalStorageListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalStorageListParams
        {
            Limit = 1,
            Page = "page",
            UserProfileIds = ["string"],
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        long expectedLimit = 1;
        string expectedPage = "page";
        List<string> expectedUserProfileIds = ["string"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.UserProfileIds);
        Assert.Equal(expectedUserProfileIds.Count, parameters.UserProfileIds.Count);
        for (int i = 0; i < expectedUserProfileIds.Count; i++)
        {
            Assert.Equal(expectedUserProfileIds[i], parameters.UserProfileIds[i]);
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
        var parameters = new ExternalStorageListParams
        {
            Page = "page",
            UserProfileIds = ["string"],
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalStorageListParams
        {
            Page = "page",
            UserProfileIds = ["string"],

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ExternalStorageListParams
        {
            Limit = 1,
            Page = "page",
            UserProfileIds = ["string"],
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalStorageListParams
        {
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.UserProfileIds);
        Assert.False(parameters.RawQueryData.ContainsKey("user_profile_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalStorageListParams
        {
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],

            Page = null,
            UserProfileIds = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.UserProfileIds);
        Assert.True(parameters.RawQueryData.ContainsKey("user_profile_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalStorageListParams parameters = new()
        {
            Limit = 1,
            Page = "page",
            UserProfileIds = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/external_storage?limit=1&page=page&user_profile_ids%5b%5d=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExternalStorageListParams parameters = new()
        {
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,efs-2026-10-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalStorageListParams
        {
            Limit = 1,
            Page = "page",
            UserProfileIds = ["string"],
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        ExternalStorageListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
