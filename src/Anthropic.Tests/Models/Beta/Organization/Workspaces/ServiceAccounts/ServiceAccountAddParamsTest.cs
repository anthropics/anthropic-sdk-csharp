using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Workspaces;
using Anthropic.Models.Beta.Organization.Workspaces.ServiceAccounts;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.ServiceAccounts;

public class ServiceAccountAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountAddParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedServiceAccountID = "service_account_id";
        ApiEnum<string, BetaNoBillingWorkspaceRole> expectedWorkspaceRole =
            BetaNoBillingWorkspaceRole.WorkspaceAdmin;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
        Assert.Equal(expectedWorkspaceRole, parameters.WorkspaceRole);
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
        var parameters = new ServiceAccountAddParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ServiceAccountAddParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountAddParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id/service_accounts?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ServiceAccountAddParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
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
        var parameters = new ServiceAccountAddParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        ServiceAccountAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
