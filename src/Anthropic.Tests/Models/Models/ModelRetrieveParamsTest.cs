using System;
using System.Net.Http;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ModelRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ModelRetrieveParams
        {
            ModelID = "model_id",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedModelID = "model_id";
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedModelID, parameters.ModelID);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ModelRetrieveParams { ModelID = "model_id" };

        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ModelRetrieveParams
        {
            ModelID = "model_id",

            // Null should be interpreted as omitted for these properties
            WorkspaceID = null,
        };

        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ModelRetrieveParams
        {
            ModelID = "model_id",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            WorkspaceID = null,
        };

        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void Url_Works()
    {
        ModelRetrieveParams parameters = new() { ModelID = "model_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/models/model_id"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ModelRetrieveParams parameters = new()
        {
            ModelID = "model_id",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ModelRetrieveParams
        {
            ModelID = "model_id",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        ModelRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
