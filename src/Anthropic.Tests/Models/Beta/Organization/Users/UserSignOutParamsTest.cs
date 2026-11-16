using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Users;

namespace Anthropic.Tests.Models.Beta.Organization.Users;

public class UserSignOutParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserSignOutParams
        {
            UserID = "user_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedUserID = "user_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedUserID, parameters.UserID);
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
        var parameters = new UserSignOutParams { UserID = "user_id" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserSignOutParams
        {
            UserID = "user_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new UserSignOutParams
        {
            UserID = "user_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        UserSignOutParams parameters = new() { UserID = "user_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/users/user_id/sign_out"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserSignOutParams parameters = new()
        {
            UserID = "user_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,admin-user-sign-out-2026-10-08"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserSignOutParams
        {
            UserID = "user_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        UserSignOutParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
