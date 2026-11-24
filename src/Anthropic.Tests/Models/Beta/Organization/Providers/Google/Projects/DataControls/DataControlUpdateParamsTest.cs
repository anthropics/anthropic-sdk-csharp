using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class DataControlUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataControlUpdateParams
        {
            ProjectNumber = "123456789012",
            Cmek = new BetaGoogleManagedProjectCmekDisabledParams(),
            Storage = new BetaGoogleManagedProjectStorageDisabledParams(),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedProjectNumber = "123456789012";
        BetaGoogleManagedProjectCmekControlParams expectedCmek =
            new BetaGoogleManagedProjectCmekDisabledParams();
        BetaGoogleManagedProjectStorageControlParams expectedStorage =
            new BetaGoogleManagedProjectStorageDisabledParams();
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedProjectNumber, parameters.ProjectNumber);
        Assert.Equal(expectedCmek, parameters.Cmek);
        Assert.Equal(expectedStorage, parameters.Storage);
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
        var parameters = new DataControlUpdateParams { ProjectNumber = "123456789012" };

        Assert.Null(parameters.Cmek);
        Assert.False(parameters.RawBodyData.ContainsKey("cmek"));
        Assert.Null(parameters.Storage);
        Assert.False(parameters.RawBodyData.ContainsKey("storage"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DataControlUpdateParams
        {
            ProjectNumber = "123456789012",

            // Null should be interpreted as omitted for these properties
            Cmek = null,
            Storage = null,
            Betas = null,
        };

        Assert.Null(parameters.Cmek);
        Assert.False(parameters.RawBodyData.ContainsKey("cmek"));
        Assert.Null(parameters.Storage);
        Assert.False(parameters.RawBodyData.ContainsKey("storage"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new DataControlUpdateParams
        {
            ProjectNumber = "123456789012",
            Cmek = new BetaGoogleManagedProjectCmekDisabledParams(),
            Storage = new BetaGoogleManagedProjectStorageDisabledParams(),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Cmek = null,
            Storage = null,
            Betas = null,
        };

        Assert.Null(parameters.Cmek);
        Assert.False(parameters.RawBodyData.ContainsKey("cmek"));
        Assert.Null(parameters.Storage);
        Assert.False(parameters.RawBodyData.ContainsKey("storage"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        DataControlUpdateParams parameters = new() { ProjectNumber = "123456789012" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/providers/google/projects/123456789012/data_controls"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        DataControlUpdateParams parameters = new()
        {
            ProjectNumber = "123456789012",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,google-managed-data-controls-2026-09-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataControlUpdateParams
        {
            ProjectNumber = "123456789012",
            Cmek = new BetaGoogleManagedProjectCmekDisabledParams(),
            Storage = new BetaGoogleManagedProjectStorageDisabledParams(),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        DataControlUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
