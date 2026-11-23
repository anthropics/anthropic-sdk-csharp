using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class WorkspaceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Ids = ["string"],
            IncludeArchived = true,
            IncludeDefault = true,
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedAfterID = "after_id";
        string expectedBeforeID = "before_id";
        List<string> expectedIds = ["string"];
        bool expectedIncludeArchived = true;
        bool expectedIncludeDefault = true;
        long expectedLimit = 1;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedAfterID, parameters.AfterID);
        Assert.Equal(expectedBeforeID, parameters.BeforeID);
        Assert.NotNull(parameters.Ids);
        Assert.Equal(expectedIds.Count, parameters.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], parameters.Ids[i]);
        }
        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
        Assert.Equal(expectedIncludeDefault, parameters.IncludeDefault);
        Assert.Equal(expectedLimit, parameters.Limit);
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
        var parameters = new WorkspaceListParams { };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.IncludeDefault);
        Assert.False(parameters.RawQueryData.ContainsKey("include_default"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspaceListParams
        {
            // Null should be interpreted as omitted for these properties
            AfterID = null,
            BeforeID = null,
            Ids = null,
            IncludeArchived = null,
            IncludeDefault = null,
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.IncludeDefault);
        Assert.False(parameters.RawQueryData.ContainsKey("include_default"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new WorkspaceListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Ids = ["string"],
            IncludeArchived = true,
            IncludeDefault = true,
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            AfterID = null,
            BeforeID = null,
            Ids = null,
            IncludeArchived = null,
            IncludeDefault = null,
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.IncludeDefault);
        Assert.False(parameters.RawQueryData.ContainsKey("include_default"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceListParams parameters = new()
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Ids = ["string"],
            IncludeArchived = true,
            IncludeDefault = true,
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces?after_id=after_id&before_id=before_id&ids%5b%5d=string&include_archived=true&include_default=true&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkspaceListParams parameters = new() { Betas = [AnthropicBeta.ComputerUse2024_10_22] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Ids = ["string"],
            IncludeArchived = true,
            IncludeDefault = true,
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        WorkspaceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
