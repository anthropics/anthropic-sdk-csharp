using System;
using Anthropic.Core;
using Anthropic.Credentials;

namespace Anthropic.Tests.Core;

public sealed class ClientCredentialTest
{
    // Setting a variable of this process to an empty string deletes it on the frameworks the tests
    // run on.
    static ClientCredential FromEnvironment(string? apiKey, string? authToken) =>
        ClientCredential.FromEnvironment(name =>
            name switch
            {
                CredentialsConstants.EnvApiKey => apiKey,
                CredentialsConstants.EnvAuthToken => authToken,
                _ => throw new ArgumentException(name),
            }
        );

    [Theory]
    [InlineData(null, null, null, null, false)]
    [InlineData("key", null, "key", null, false)]
    [InlineData(null, "token", null, "token", false)]
    [InlineData("key", "token", "key", null, true)]
    [InlineData("", "token", null, "token", false)]
    [InlineData("key", "", "key", null, false)]
    [InlineData("", "", null, null, false)]
    public void FromEnvironment_ApiKeyHidesAuthToken(
        string? apiKey,
        string? authToken,
        string? expectedApiKey,
        string? expectedAuthToken,
        bool expectedHidden
    )
    {
        var credential = FromEnvironment(apiKey, authToken);

        Assert.Equal(expectedApiKey, credential.ApiKey);
        Assert.Equal(expectedAuthToken, credential.AuthToken);
        Assert.Null(credential.Credentials);
        Assert.Equal(expectedHidden, credential.ApiKeyHidesAuthToken);
    }

    [Fact]
    public void FromEnvironment_IsUnsetUntilInheritedOrAKeyOrTokenIsSet()
    {
        var credential = FromEnvironment("key", "token");

        Assert.True(credential.IsUnset);
        Assert.True(credential.WithCredentials(null).IsUnset);
        Assert.False(credential.WithApiKey(null).IsUnset);
        Assert.False(credential.WithAuthToken(null).IsUnset);
        Assert.False(credential.WithApiKey("other").IsUnset);
        Assert.False(credential.Inherit().IsUnset);
    }

    [Fact]
    public void FromEnvironment_ClearingOneVariableKeepsTheOther()
    {
        var credential = FromEnvironment("key", "token");

        var withoutApiKey = credential.WithApiKey(null);
        Assert.Null(withoutApiKey.ApiKey);
        Assert.Equal("token", withoutApiKey.AuthToken);
        Assert.False(withoutApiKey.ApiKeyHidesAuthToken);

        var withoutAuthToken = credential.WithAuthToken(null);
        Assert.Equal("key", withoutAuthToken.ApiKey);
        Assert.Null(withoutAuthToken.AuthToken);
        Assert.False(withoutAuthToken.ApiKeyHidesAuthToken);

        var withoutEither = withoutApiKey.WithAuthToken(null);
        Assert.Null(withoutEither.ApiKey);
        Assert.Null(withoutEither.AuthToken);
    }

    [Fact]
    public void PassedCredential_ReplacesTheEnvironment()
    {
        var credential = FromEnvironment("key", "token").WithAuthToken("passed");

        Assert.Null(credential.ApiKey);
        Assert.Equal("passed", credential.AuthToken);
        Assert.False(credential.ApiKeyHidesAuthToken);
    }

    [Fact]
    public void PassedCredential_IsReplacedOnlyThroughItsOwnOption()
    {
        var credential = FromEnvironment(null, null).WithApiKey("key");

        Assert.Equal("other", credential.WithApiKey("other").ApiKey);
        var exception = Assert.Throws<ArgumentException>(() => credential.WithAuthToken("token"));
        Assert.Equal(
            "Pass at most one of ApiKey, AuthToken and Credentials. "
                + "Both ApiKey and AuthToken were passed.",
            exception.Message
        );
    }

    [Fact]
    public void InheritedCredential_IsReplacedThroughAnyOption()
    {
        var credential = FromEnvironment(null, null).WithApiKey("key").Inherit();

        Assert.Equal("key", credential.ApiKey);
        var replaced = credential.WithAuthToken("token");
        Assert.Null(replaced.ApiKey);
        Assert.Equal("token", replaced.AuthToken);
    }

    [Fact]
    public void ClearedCredential_LeavesRoomForAnother()
    {
        using var provider = new StaticTokenCredentials("token");
        var cleared = FromEnvironment("key", null).WithApiKey("passed").WithApiKey(null);

        Assert.Null(cleared.ApiKey);
        Assert.False(cleared.IsUnset);
        Assert.Same(provider, cleared.WithCredentials(provider).Credentials);
    }

    [Fact]
    public void ClearingAnotherOption_KeepsTheCredential()
    {
        var credential = FromEnvironment(null, null).WithAuthToken("token");

        var cleared = credential.WithApiKey(null).WithCredentials(null);

        Assert.Equal("token", cleared.AuthToken);
        Assert.Throws<ArgumentException>(() => cleared.WithApiKey("key"));
    }
}
