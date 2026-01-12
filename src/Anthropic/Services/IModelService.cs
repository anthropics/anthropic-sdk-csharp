using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Services;

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
    IModelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IModelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a specific model.
    ///
    /// <para>The Models API response can be used to determine information about a
    /// specific model or resolve a model alias to a model ID.</para>
    /// </summary>
    Task<ModelInfo> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ModelRetrieveParams, CancellationToken)"/>
    Task<ModelInfo> Retrieve(
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
/// A view of <see cref="IModelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IModelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IModelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/models/{model_id}`, but is otherwise the
    /// same as <see cref="IModelService.Retrieve(ModelRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ModelInfo>> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ModelRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ModelInfo>> Retrieve(
        string modelID,
        ModelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/models`, but is otherwise the
    /// same as <see cref="IModelService.List(ModelListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ModelListPage>> List(
        ModelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
