using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class ResourceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ResourceUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            ResourceID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            AuthorizationToken = "ghp_exampletoken",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        string expectedResourceID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht";
        string expectedAuthorizationToken = "ghp_exampletoken";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedSessionID, parameters.SessionID);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedAuthorizationToken, parameters.AuthorizationToken);
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
        var parameters = new ResourceUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            ResourceID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            AuthorizationToken = "ghp_exampletoken",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ResourceUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            ResourceID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            AuthorizationToken = "ghp_exampletoken",

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
        ResourceUpdateParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            ResourceID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            AuthorizationToken = "ghp_exampletoken",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/sessions/sesn_011CZkZAtmR3yMPDzynEDxu7/resources/sesrsc_011CZkZBJq5dWxk9fVLNcPht?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ResourceUpdateParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            ResourceID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            AuthorizationToken = "ghp_exampletoken",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
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
        var parameters = new ResourceUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            ResourceID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            AuthorizationToken = "ghp_exampletoken",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        ResourceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
