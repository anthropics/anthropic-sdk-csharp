using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Workspaces.ServiceAccounts;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.ServiceAccounts;

public class ServiceAccountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountRetrieveParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedServiceAccountID = "service_account_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
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
        var parameters = new ServiceAccountRetrieveParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ServiceAccountRetrieveParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountRetrieveParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id/service_accounts/service_account_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ServiceAccountRetrieveParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ServiceAccountRetrieveParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        ServiceAccountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
