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

    /// <summary>
    /// List available models.
    ///
    /// <para>The Models API response can be used to determine which models are available
    /// for use in the API. More recently released models are listed first.</para>
    /// </summary>
    Task<ModelListPageResponse> List(
        ModelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
