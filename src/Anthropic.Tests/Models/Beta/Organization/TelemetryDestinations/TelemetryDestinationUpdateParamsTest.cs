using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class TelemetryDestinationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TelemetryDestinationUpdateParams
        {
            DestinationID = "destination_id",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            Headers = new Dictionary<string, string?>() { { "foo", "string" } },
            State = new BetaTelemetryDestinationStateEnabledParams(),
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedDestinationID = "destination_id";
        string expectedDisplayName = "display_name";
        string expectedEndpointUrl = "endpoint_url";
        Dictionary<string, string?> expectedHeaders = new() { { "foo", "string" } };
        BetaTelemetryDestinationStateParams expectedState =
            new BetaTelemetryDestinationStateEnabledParams();
        BetaTelemetryDestinationTracesParams expectedTraces = new()
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };
        BetaTelemetryDestinationWorkspacesParams expectedWorkspaces =
            new BetaTelemetryDestinationWorkspacesAllParams();
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedDestinationID, parameters.DestinationID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedEndpointUrl, parameters.EndpointUrl);
        Assert.NotNull(parameters.Headers);
        Assert.Equal(expectedHeaders.Count, parameters.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(parameters.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Headers[item.Key]);
        }
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedTraces, parameters.Traces);
        Assert.Equal(expectedWorkspaces, parameters.Workspaces);
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
        var parameters = new TelemetryDestinationUpdateParams
        {
            DestinationID = "destination_id",
            DisplayName = "display_name",
            Headers = new Dictionary<string, string?>() { { "foo", "string" } },
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
        };

        Assert.Null(parameters.EndpointUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint_url"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.Workspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("workspaces"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TelemetryDestinationUpdateParams
        {
            DestinationID = "destination_id",
            DisplayName = "display_name",
            Headers = new Dictionary<string, string?>() { { "foo", "string" } },
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },

            // Null should be interpreted as omitted for these properties
            EndpointUrl = null,
            State = null,
            Workspaces = null,
            Betas = null,
        };

        Assert.Null(parameters.EndpointUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint_url"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.Workspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("workspaces"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new TelemetryDestinationUpdateParams
        {
            DestinationID = "destination_id",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            Headers = new Dictionary<string, string?>() { { "foo", "string" } },
            State = new BetaTelemetryDestinationStateEnabledParams(),
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            EndpointUrl = null,
            State = null,
            Workspaces = null,
            Betas = null,
        };

        Assert.Null(parameters.EndpointUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("endpoint_url"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.Workspaces);
        Assert.False(parameters.RawBodyData.ContainsKey("workspaces"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TelemetryDestinationUpdateParams
        {
            DestinationID = "destination_id",
            EndpointUrl = "endpoint_url",
            State = new BetaTelemetryDestinationStateEnabledParams(),
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Headers);
        Assert.False(parameters.RawBodyData.ContainsKey("headers"));
        Assert.Null(parameters.Traces);
        Assert.False(parameters.RawBodyData.ContainsKey("traces"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TelemetryDestinationUpdateParams
        {
            DestinationID = "destination_id",
            EndpointUrl = "endpoint_url",
            State = new BetaTelemetryDestinationStateEnabledParams(),
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DisplayName = null,
            Headers = null,
            Traces = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Headers);
        Assert.True(parameters.RawBodyData.ContainsKey("headers"));
        Assert.Null(parameters.Traces);
        Assert.True(parameters.RawBodyData.ContainsKey("traces"));
    }

    [Fact]
    public void Url_Works()
    {
        TelemetryDestinationUpdateParams parameters = new() { DestinationID = "destination_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/telemetry_destinations/destination_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TelemetryDestinationUpdateParams parameters = new()
        {
            DestinationID = "destination_id",
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
        var parameters = new TelemetryDestinationUpdateParams
        {
            DestinationID = "destination_id",
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            Headers = new Dictionary<string, string?>() { { "foo", "string" } },
            State = new BetaTelemetryDestinationStateEnabledParams(),
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        TelemetryDestinationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
