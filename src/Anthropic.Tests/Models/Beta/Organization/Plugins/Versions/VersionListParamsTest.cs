using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Plugins.Versions;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.Versions;

public class VersionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            OrganizationID = "organization_id",
            Page = "page",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedPluginID = "plugin_id";
        long expectedLimit = 1;
        string expectedOrganizationID = "organization_id";
        string expectedPage = "page";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedPluginID, parameters.PluginID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPage, parameters.Page);
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
        var parameters = new VersionListParams
        {
            PluginID = "plugin_id",
            OrganizationID = "organization_id",
            Page = "page",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VersionListParams
        {
            PluginID = "plugin_id",
            OrganizationID = "organization_id",
            Page = "page",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new VersionListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            OrganizationID = "organization_id",
            Page = "page",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VersionListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VersionListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],

            OrganizationID = null,
            Page = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        VersionListParams parameters = new()
        {
            PluginID = "plugin_id",
            Limit = 1,
            OrganizationID = "organization_id",
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugins/plugin_id/versions?limit=1&organization_id=organization_id&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        VersionListParams parameters = new()
        {
            PluginID = "plugin_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,ce-plugins-2026-09-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            OrganizationID = "organization_id",
            Page = "page",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        VersionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
