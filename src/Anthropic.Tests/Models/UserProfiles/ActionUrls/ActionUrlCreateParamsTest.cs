using System;
using System.Net.Http;
using Anthropic.Models.UserProfiles.ActionUrls;

namespace Anthropic.Tests.Models.UserProfiles.ActionUrls;

public class ActionUrlCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ActionUrlCreateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Action = new(),
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedUserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        UserProfileEnrollEndUserAction expectedAction = new();
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
        Assert.Equal(expectedAction, parameters.Action);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ActionUrlCreateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Action = new(),
        };

        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ActionUrlCreateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Action = new(),

            // Null should be interpreted as omitted for these properties
            WorkspaceID = null,
        };

        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ActionUrlCreateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Action = new(),
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
        ActionUrlCreateParams parameters = new()
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Action = new(),
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/user_profiles/uprof_011CZkZCu8hGbp5mYRQgUmz9/action_urls"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ActionUrlCreateParams parameters = new()
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Action = new(),
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
        var parameters = new ActionUrlCreateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            Action = new(),
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        ActionUrlCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
