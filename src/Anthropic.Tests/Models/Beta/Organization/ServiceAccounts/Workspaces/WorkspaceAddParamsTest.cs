using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ServiceAccounts.Workspaces;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.ServiceAccounts.Workspaces;

public class WorkspaceAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceAddParams
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedServiceAccountID = "service_account_id";
        string expectedWorkspaceID = "workspace_id";
        ApiEnum<string, BetaNoBillingWorkspaceRole> expectedWorkspaceRole =
            BetaNoBillingWorkspaceRole.WorkspaceAdmin;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
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
        var parameters = new WorkspaceAddParams
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspaceAddParams
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
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
        WorkspaceAddParams parameters = new()
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/service_accounts/service_account_id/workspaces?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkspaceAddParams parameters = new()
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
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
        var parameters = new WorkspaceAddParams
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WorkspaceAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
