using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles;

public class BundleUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BundleUpdateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Instructions = "instructions",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedBundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq";
        string expectedInstructions = "instructions";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedBundleID, parameters.BundleID);
        Assert.Equal(expectedInstructions, parameters.Instructions);
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
        var parameters = new BundleUpdateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Instructions = "instructions",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BundleUpdateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Instructions = "instructions",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new BundleUpdateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Instructions = "instructions",
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
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BundleUpdateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BundleUpdateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],

            Instructions = null,
        };

        Assert.Null(parameters.Instructions);
        Assert.True(parameters.RawBodyData.ContainsKey("instructions"));
    }

    [Fact]
    public void Url_Works()
    {
        BundleUpdateParams parameters = new() { BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/claude_tag/bundles/capp_011CZkZjLP1cWxj5EtMmdgbq"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BundleUpdateParams parameters = new()
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,experimental-claude-tag-2026-10-21"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BundleUpdateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Instructions = "instructions",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        BundleUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
