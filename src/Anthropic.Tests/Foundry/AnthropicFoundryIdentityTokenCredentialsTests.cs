using System;
using System.Net.Http;
using Anthropic.Foundry;
using Azure.Core;

namespace Anthropic.Tests.Foundry;

public class AnthropicFoundryIdentityTokenCredentialsTests
{
    private const string TestResourceName = "test-resource";
    private static readonly string[] DefaultScopes = ["https://ai.azure.com/.default"];

    #region Constructor Validation Tests

    [Fact]
    public void Constructor_WithNullTokenCredential_ThrowsArgumentNullException()
    {
        // Arrange
        TokenCredential? nullCredential = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() =>
            new AnthropicFoundryIdentityTokenCredentials(nullCredential!, TestResourceName)
        );

        Assert.Equal("tokenCredential", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullResourceName_ThrowsArgumentNullException()
    {
        // Arrange
        var credential = CreateFakeTokenCredential("test-token");

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() =>
            new AnthropicFoundryIdentityTokenCredentials(credential, null!)
        );

        Assert.Equal("resourceName", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithValidParameters_CreatesInstance()
    {
        // Arrange
        var credential = CreateFakeTokenCredential("test-token");

        // Act
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);

        // Assert
        Assert.NotNull(instance);
        Assert.Equal(TestResourceName, instance.ResourceName);
    }

    [Fact]
    public void Constructor_WithCustomScopes_UsesProvidedScopes()
    {
        // Arrange
        var credential = CreateFakeTokenCredential("test-token");
        string[]? receivedScopes = null;
        var trackingCredential = CreateTrackingTokenCredential(
            "test-token",
            ctx =>
            {
                receivedScopes = ctx.Scopes;
            }
        );
        var customScopes = new[] { "https://custom.scope/.default" };

        // Act
        var instance = new AnthropicFoundryIdentityTokenCredentials(
            trackingCredential,
            TestResourceName,
            customScopes
        );
        var request = new HttpRequestMessage();
        instance.Apply(request);

        // Assert
        Assert.NotNull(receivedScopes);
        Assert.Equal(customScopes, receivedScopes);
    }

    [Fact]
    public void Constructor_WithNullScopes_UsesDefaultScopes()
    {
        // Arrange
        var credential = CreateFakeTokenCredential("test-token");
        string[]? receivedScopes = null;
        var trackingCredential = CreateTrackingTokenCredential(
            "test-token",
            ctx =>
            {
                receivedScopes = ctx.Scopes;
            }
        );

        // Act
        var instance = new AnthropicFoundryIdentityTokenCredentials(
            trackingCredential,
            TestResourceName,
            null
        );
        var request = new HttpRequestMessage();
        instance.Apply(request);

        // Assert
        Assert.NotNull(receivedScopes);
        Assert.Equal(DefaultScopes, receivedScopes);
    }

    #endregion

    #region Apply Method Tests

    [Fact]
    public void Apply_SetsAuthorizationHeaderWithBearerScheme()
    {
        // Arrange
        const string testToken = "my-test-token";
        var credential = CreateFakeTokenCredential(testToken);
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);
        var request = new HttpRequestMessage();

        // Act
        instance.Apply(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("bearer", request.Headers.Authorization.Scheme);
        Assert.Equal(testToken, request.Headers.Authorization.Parameter);
    }

    [Fact]
    public void Apply_WithEmptyToken_SetsEmptyAuthorizationParameter()
    {
        // Arrange
        const string emptyToken = "";
        var credential = CreateFakeTokenCredential(emptyToken);
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);
        var request = new HttpRequestMessage();

        // Act
        instance.Apply(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("bearer", request.Headers.Authorization.Scheme);
        Assert.Equal(emptyToken, request.Headers.Authorization.Parameter);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("  ")]
    [InlineData("\t")]
    public void Apply_WithWhitespaceToken_SetsWhitespaceAuthorizationParameter(
        string whitespaceToken
    )
    {
        // Arrange
        var credential = CreateFakeTokenCredential(whitespaceToken);
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);
        var request = new HttpRequestMessage();

        // Act
        instance.Apply(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("bearer", request.Headers.Authorization.Scheme);
        Assert.Equal(whitespaceToken, request.Headers.Authorization.Parameter);
    }

    [Theory]
    [InlineData("token-with-special-chars!@#$%^&*()")]
    [InlineData("token.with.dots")]
    [InlineData("token/with/slashes")]
    [InlineData("token=with=equals")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIn0.dozjgNryP4J3jVmNHl0w5N_XgL0n3I9PlFUP0THsR8U"
    )]
    public void Apply_WithSpecialCharacterTokens_SetsAuthorizationParameter(string specialToken)
    {
        // Arrange
        var credential = CreateFakeTokenCredential(specialToken);
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);
        var request = new HttpRequestMessage();

        // Act
        instance.Apply(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("bearer", request.Headers.Authorization.Scheme);
        Assert.Equal(specialToken, request.Headers.Authorization.Parameter);
    }

    [Fact]
    public void Apply_CalledMultipleTimes_UpdatesAuthorizationHeader()
    {
        // Arrange
        const string token = "test-token";
        var credential = CreateFakeTokenCredential(token);
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);
        var request1 = new HttpRequestMessage();
        var request2 = new HttpRequestMessage();

        // Act
        instance.Apply(request1);
        instance.Apply(request2);

        // Assert
        Assert.Equal(token, request1.Headers.Authorization?.Parameter);
        Assert.Equal(token, request2.Headers.Authorization?.Parameter);
    }

    #endregion

    #region Token Retrieval Tests

    [Fact]
    public void Apply_InvokesTokenCredentialGetToken_WithCorrectContext()
    {
        // Arrange
        TokenRequestContext? capturedContext = null;
        var credential = CreateTrackingTokenCredential("test-token", ctx => capturedContext = ctx);
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);
        var request = new HttpRequestMessage();

        // Act
        instance.Apply(request);

        // Assert
        Assert.NotNull(capturedContext);
        Assert.Equal(DefaultScopes, capturedContext.Value.Scopes);
    }

    [Fact]
    public void Apply_WithCustomScopes_PassesCustomScopesToGetToken()
    {
        // Arrange
        var customScopes = new[]
        {
            "https://custom.api.com/.default",
            "https://another.api.com/.default",
        };
        TokenRequestContext? capturedContext = null;
        var credential = CreateTrackingTokenCredential("test-token", ctx => capturedContext = ctx);
        var instance = new AnthropicFoundryIdentityTokenCredentials(
            credential,
            TestResourceName,
            customScopes
        );
        var request = new HttpRequestMessage();

        // Act
        instance.Apply(request);

        // Assert
        Assert.NotNull(capturedContext);
        Assert.Equal(customScopes, capturedContext.Value.Scopes);
    }

    #endregion

    #region Error Handling Tests

    [Fact]
    public void Apply_WhenTokenCredentialThrowsException_PropagatesException()
    {
        // Arrange
        var expectedException = new InvalidOperationException("Token retrieval failed");
        var credential = CreateThrowingTokenCredential(expectedException);
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);
        var request = new HttpRequestMessage();

        // Act & Assert
        var thrownException = Assert.Throws<InvalidOperationException>(() =>
            instance.Apply(request)
        );
        Assert.Same(expectedException, thrownException);
    }

    [Fact]
    public void Apply_WhenTokenCredentialThrowsAuthenticationException_PropagatesException()
    {
        // Arrange
        var expectedException = new Azure.Identity.AuthenticationFailedException(
            "Authentication failed"
        );
        var credential = CreateThrowingTokenCredential(expectedException);
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);
        var request = new HttpRequestMessage();

        // Act & Assert
        var thrownException = Assert.Throws<Azure.Identity.AuthenticationFailedException>(() =>
            instance.Apply(request)
        );
        Assert.Same(expectedException, thrownException);
    }

    #endregion

    #region IAnthropicFoundryCredentials Interface Tests

    [Fact]
    public void Instance_ImplementsIAnthropicFoundryCredentials()
    {
        // Arrange
        var credential = CreateFakeTokenCredential("test-token");

        // Act
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, TestResourceName);

        // Assert
        Assert.IsAssignableFrom<IAnthropicFoundryCredentials>(instance);
    }

    [Fact]
    public void ResourceName_ReturnsConstructorValue()
    {
        // Arrange
        const string resourceName = "my-custom-resource";
        var credential = CreateFakeTokenCredential("test-token");

        // Act
        var instance = new AnthropicFoundryIdentityTokenCredentials(credential, resourceName);

        // Assert
        Assert.Equal(resourceName, instance.ResourceName);
    }

    #endregion

    #region Helper Methods

    private static TokenCredential CreateFakeTokenCredential(string token)
    {
        return DelegatedTokenCredential.Create(
            (context, cancellationToken) =>
                new AccessToken(token, DateTimeOffset.UtcNow.AddHours(1))
        );
    }

    private static TokenCredential CreateTrackingTokenCredential(
        string token,
        Action<TokenRequestContext> onGetToken
    )
    {
        return DelegatedTokenCredential.Create(
            (context, cancellationToken) =>
            {
                onGetToken(context);
                return new AccessToken(token, DateTimeOffset.UtcNow.AddHours(1));
            }
        );
    }

    private static TokenCredential CreateCountingTokenCredential(string token, Action onGetToken)
    {
        return DelegatedTokenCredential.Create(
            (context, cancellationToken) =>
            {
                onGetToken();
                return new AccessToken(token, DateTimeOffset.UtcNow.AddHours(1));
            }
        );
    }

    private static TokenCredential CreateThrowingTokenCredential(Exception exception)
    {
        return DelegatedTokenCredential.Create(
            (context, cancellationToken) =>
            {
                throw exception;
            }
        );
    }

    #endregion
}
