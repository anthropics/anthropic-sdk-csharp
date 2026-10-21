using System;
using Anthropic.Credentials;

namespace Anthropic.Core;

/// <summary>
/// The credential of a <see cref="ClientOptions"/> value, which holds exactly one.
/// </summary>
internal abstract class ClientCredential
{
    static readonly ClientCredential s_none = new NoCredential();

    ClientCredential() { }

    public static ClientCredential FromEnvironment() =>
        FromEnvironment(Environment.GetEnvironmentVariable);

    /// <summary>
    /// An empty variable counts as not set.
    /// </summary>
    public static ClientCredential FromEnvironment(Func<string, string?> getVariable)
    {
        Lazy<string?> Variable(string name) =>
            new(() => getVariable(name) is { Length: > 0 } value ? value : null);

        return new UnsetCredential(
            Variable(CredentialsConstants.EnvApiKey),
            Variable(CredentialsConstants.EnvAuthToken)
        );
    }

    public virtual string? ApiKey => null;

    public virtual string? AuthToken => null;

    public virtual IAccessTokenProvider? Credentials => null;

    /// <summary>
    /// Whether the client is left to look for a credential with
    /// <see cref="AnthropicCredentials.Resolve"/>. Setting the API key or the auth token ends
    /// that, even to null. Setting the credentials to null doesn't.
    /// </summary>
    public virtual bool IsUnset => false;

    public virtual bool ApiKeyHidesAuthToken => false;

    /// <summary>
    /// The name of the option that passed this credential, or null for a credential that was
    /// inherited or read from the environment.
    /// </summary>
    protected virtual string? PassedAs => null;

    /// <inheritdoc cref="ClientOptions.InheritCredential"/>
    public virtual ClientCredential Inherit() => this;

    public ClientCredential WithApiKey(string? value) =>
        value == null ? WithoutApiKey() : Pass(new ApiKeyCredential(value, passed: true));

    public ClientCredential WithAuthToken(string? value) =>
        value == null ? WithoutAuthToken() : Pass(new AuthTokenCredential(value, passed: true));

    public ClientCredential WithCredentials(IAccessTokenProvider? value) =>
        value == null ? WithoutCredentials() : Pass(new ProviderCredential(value, passed: true));

    protected virtual ClientCredential WithoutApiKey() => this;

    protected virtual ClientCredential WithoutAuthToken() => this;

    protected virtual ClientCredential WithoutCredentials() => this;

    ClientCredential Pass(ClientCredential credential)
    {
        if (PassedAs is { } passed && passed != credential.PassedAs)
        {
            throw new ArgumentException(
                $"Pass at most one of {nameof(ClientOptions.ApiKey)}, "
                    + $"{nameof(ClientOptions.AuthToken)} and {nameof(ClientOptions.Credentials)}. "
                    + $"Both {passed} and {credential.PassedAs} were passed."
            );
        }

        return credential;
    }

    class EnvironmentCredential(Lazy<string?> apiKey, Lazy<string?> authToken) : ClientCredential
    {
        public override string? ApiKey => apiKey.Value;

        public override string? AuthToken => apiKey.Value == null ? authToken.Value : null;

        public override bool ApiKeyHidesAuthToken =>
            apiKey.Value != null && authToken.Value != null;

        public override ClientCredential Inherit() => new EnvironmentCredential(apiKey, authToken);

        protected override ClientCredential WithoutApiKey() =>
            new EnvironmentAuthTokenCredential(authToken);

        protected override ClientCredential WithoutAuthToken() =>
            new EnvironmentApiKeyCredential(apiKey);
    }

    sealed class UnsetCredential(Lazy<string?> apiKey, Lazy<string?> authToken)
        : EnvironmentCredential(apiKey, authToken)
    {
        public override bool IsUnset => true;
    }

    sealed class EnvironmentApiKeyCredential(Lazy<string?> apiKey) : ClientCredential
    {
        public override string? ApiKey => apiKey.Value;

        protected override ClientCredential WithoutApiKey() => s_none;
    }

    sealed class EnvironmentAuthTokenCredential(Lazy<string?> authToken) : ClientCredential
    {
        public override string? AuthToken => authToken.Value;

        protected override ClientCredential WithoutAuthToken() => s_none;
    }

    sealed class ApiKeyCredential(string apiKey, bool passed) : ClientCredential
    {
        public override string? ApiKey => apiKey;

        protected override string? PassedAs => passed ? nameof(ClientOptions.ApiKey) : null;

        public override ClientCredential Inherit() => new ApiKeyCredential(apiKey, passed: false);

        protected override ClientCredential WithoutApiKey() => s_none;
    }

    sealed class AuthTokenCredential(string authToken, bool passed) : ClientCredential
    {
        public override string? AuthToken => authToken;

        protected override string? PassedAs => passed ? nameof(ClientOptions.AuthToken) : null;

        public override ClientCredential Inherit() =>
            new AuthTokenCredential(authToken, passed: false);

        protected override ClientCredential WithoutAuthToken() => s_none;
    }

    sealed class ProviderCredential(IAccessTokenProvider provider, bool passed) : ClientCredential
    {
        public override IAccessTokenProvider? Credentials => provider;

        protected override string? PassedAs => passed ? nameof(ClientOptions.Credentials) : null;

        public override ClientCredential Inherit() =>
            new ProviderCredential(provider, passed: false);

        protected override ClientCredential WithoutCredentials() => s_none;
    }

    sealed class NoCredential : ClientCredential;
}
