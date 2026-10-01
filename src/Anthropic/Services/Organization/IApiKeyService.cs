using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Organization.ApiKeys;

namespace Anthropic.Services.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IApiKeyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IApiKeyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IApiKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get API Key
    /// </summary>
    Task<ApiKey> Retrieve(
        ApiKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ApiKeyRetrieveParams, CancellationToken)"/>
    Task<ApiKey> Retrieve(
        string apiKeyID,
        ApiKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update API Key
    /// </summary>
    Task<ApiKey> Update(
        ApiKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ApiKeyUpdateParams, CancellationToken)"/>
    Task<ApiKey> Update(
        string apiKeyID,
        ApiKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List API Keys
    /// </summary>
    Task<ApiKeyListPage> List(
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IApiKeyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IApiKeyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IApiKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/api_keys/{api_key_id}</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.Retrieve(ApiKeyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiKey>> Retrieve(
        ApiKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ApiKeyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ApiKey>> Retrieve(
        string apiKeyID,
        ApiKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/api_keys/{api_key_id}</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.Update(ApiKeyUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiKey>> Update(
        ApiKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ApiKeyUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ApiKey>> Update(
        string apiKeyID,
        ApiKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/api_keys</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.List(ApiKeyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiKeyListPage>> List(
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
