using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class TelemetryDestinationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TelemetryDestinationCreateParams
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            DisplayName = "display_name",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedEndpointUrl = "https://gateway.example.com";
        BetaTelemetryDestinationWorkspacesParams expectedWorkspaces =
            new BetaTelemetryDestinationWorkspacesAllParams();
        string expectedDisplayName = "display_name";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        BetaTelemetryDestinationTracesParams expectedTraces = new()
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedEndpointUrl, parameters.EndpointUrl);
        Assert.Equal(expectedWorkspaces, parameters.Workspaces);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Headers);
        Assert.Equal(expectedHeaders.Count, parameters.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(parameters.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Headers[item.Key]);
        }
        Assert.Equal(expectedTraces, parameters.Traces);
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
        var parameters = new TelemetryDestinationCreateParams
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            DisplayName = "display_name",
        };

        Assert.Null(parameters.Headers);
        Assert.False(parameters.RawBodyData.ContainsKey("headers"));
        Assert.Null(parameters.Traces);
        Assert.False(parameters.RawBodyData.ContainsKey("traces"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TelemetryDestinationCreateParams
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            DisplayName = "display_name",

            // Null should be interpreted as omitted for these properties
            Headers = null,
            Traces = null,
            Betas = null,
        };

        Assert.Null(parameters.Headers);
        Assert.False(parameters.RawBodyData.ContainsKey("headers"));
        Assert.Null(parameters.Traces);
        Assert.False(parameters.RawBodyData.ContainsKey("traces"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new TelemetryDestinationCreateParams
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            DisplayName = "display_name",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Headers = null,
            Traces = null,
            Betas = null,
        };

        Assert.Null(parameters.Headers);
        Assert.False(parameters.RawBodyData.ContainsKey("headers"));
        Assert.Null(parameters.Traces);
        Assert.False(parameters.RawBodyData.ContainsKey("traces"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TelemetryDestinationCreateParams
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TelemetryDestinationCreateParams
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],

            DisplayName = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void Url_Works()
    {
        TelemetryDestinationCreateParams parameters = new()
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/telemetry_destinations"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TelemetryDestinationCreateParams parameters = new()
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,telemetry-destinations-2026-08-11"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TelemetryDestinationCreateParams
        {
            EndpointUrl = "https://gateway.example.com",
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            DisplayName = "display_name",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        TelemetryDestinationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
