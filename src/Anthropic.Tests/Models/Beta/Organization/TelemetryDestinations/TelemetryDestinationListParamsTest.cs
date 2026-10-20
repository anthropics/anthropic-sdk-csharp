using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class TelemetryDestinationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TelemetryDestinationListParams
        {
            Limit = 0,
            Page = "page",
            WorkspaceIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        int expectedLimit = 0;
        string expectedPage = "page";
        List<string> expectedWorkspaceIds = ["string"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.WorkspaceIds);
        Assert.Equal(expectedWorkspaceIds.Count, parameters.WorkspaceIds.Count);
        for (int i = 0; i < expectedWorkspaceIds.Count; i++)
        {
            Assert.Equal(expectedWorkspaceIds[i], parameters.WorkspaceIds[i]);
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
        var parameters = new TelemetryDestinationListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.WorkspaceIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workspace_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TelemetryDestinationListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Page = null,
            WorkspaceIds = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.WorkspaceIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workspace_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new TelemetryDestinationListParams
        {
            Limit = 0,
            Page = "page",
            WorkspaceIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Page = null,
            WorkspaceIds = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.WorkspaceIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workspace_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        TelemetryDestinationListParams parameters = new()
        {
            Limit = 0,
            Page = "page",
            WorkspaceIds = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/telemetry_destinations?beta=true&limit=0&page=page&workspace_ids%5b%5d=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TelemetryDestinationListParams parameters = new()
        {
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,telemetry-destinations-2026-08-11"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TelemetryDestinationListParams
        {
            Limit = 0,
            Page = "page",
            WorkspaceIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        TelemetryDestinationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
