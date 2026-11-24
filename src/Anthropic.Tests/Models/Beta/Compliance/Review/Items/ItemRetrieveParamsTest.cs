using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class ItemRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            ItemID = "item_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
            UserProfileID = "anthropic-user-profile-id",
        };

        string expectedItemID = "item_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];
        string expectedUserProfileID = "anthropic-user-profile-id";

        Assert.Equal(expectedItemID, parameters.ItemID);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ItemRetrieveParams { ItemID = "item_id" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-user-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            ItemID = "item_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
            UserProfileID = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-user-profile-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            ItemID = "item_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
            UserProfileID = "anthropic-user-profile-id",
        } with
        {
            // Null should be interpreted as omitted for these properties
            Betas = null,
            UserProfileID = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-user-profile-id"));
    }

    [Fact]
    public void Url_Works()
    {
        ItemRetrieveParams parameters = new() { ItemID = "item_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/compliance/review/items/item_id"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ItemRetrieveParams parameters = new()
        {
            ItemID = "item_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
            UserProfileID = "anthropic-user-profile-id",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
        Assert.Equal(
            ["anthropic-user-profile-id"],
            requestMessage.Headers.GetValues("anthropic-user-profile-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            ItemID = "item_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
            UserProfileID = "anthropic-user-profile-id",
        };

        ItemRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
