using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IModelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    global::Anthropic.Services.Beta.IModelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Anthropic.Services.Beta.IModelService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Get a specific model.
    ///
    /// <para>The Models API response can be used to determine information about a
    /// specific model or resolve a model alias to a model ID.</para>
    /// </summary>
    Task<BetaModelInfo> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ModelRetrieveParams, CancellationToken)"/>
    Task<BetaModelInfo> Retrieve(
        string modelID,
        ModelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List available models.
    ///
    /// <para>The Models API response can be used to determine which models are available
    /// for use in the API. More recently released models are listed first.</para>
    /// </summary>
    Task<ModelListPage> List(
        ModelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="global::Anthropic.Services.Beta.IModelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IModelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Anthropic.Services.Beta.IModelServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/models/{model_id}?beta=true`, but is otherwise the
    /// same as <see cref="global::Anthropic.Services.Beta.IModelService.Retrieve(ModelRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaModelInfo>> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ModelRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaModelInfo>> Retrieve(
        string modelID,
        ModelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/models?beta=true`, but is otherwise the
    /// same as <see cref="global::Anthropic.Services.Beta.IModelService.List(ModelListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ModelListPage>> List(
        ModelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
