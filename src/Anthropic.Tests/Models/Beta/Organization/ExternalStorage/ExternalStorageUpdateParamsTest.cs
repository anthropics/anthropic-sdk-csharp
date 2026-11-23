using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class ExternalStorageUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalStorageUpdateParams
        {
            ExternalStorageID = "external_storage_id",
            DisplayName = "x",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedExternalStorageID = "external_storage_id";
        string expectedDisplayName = "x";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedExternalStorageID, parameters.ExternalStorageID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
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
        var parameters = new ExternalStorageUpdateParams
        {
            ExternalStorageID = "external_storage_id",
            DisplayName = "x",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalStorageUpdateParams
        {
            ExternalStorageID = "external_storage_id",
            DisplayName = "x",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ExternalStorageUpdateParams
        {
            ExternalStorageID = "external_storage_id",
            DisplayName = "x",
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
        ExternalStorageUpdateParams parameters = new()
        {
            ExternalStorageID = "external_storage_id",
            DisplayName = "x",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/external_storage/external_storage_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExternalStorageUpdateParams parameters = new()
        {
            ExternalStorageID = "external_storage_id",
            DisplayName = "x",
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
        var parameters = new ExternalStorageUpdateParams
        {
            ExternalStorageID = "external_storage_id",
            DisplayName = "x",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        ExternalStorageUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
