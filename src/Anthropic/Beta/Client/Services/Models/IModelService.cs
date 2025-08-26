using System.Threading.Tasks;
using Anthropic.Beta.Client.Models.Models;

namespace Anthropic.Beta.Client.Services.Models;

public interface IModelService
{
    /// <summary>
    /// Get a specific model.
    ///
    /// The Models API response can be used to determine information about a specific
    /// model or resolve a model alias to a model ID.
    /// </summary>
    Task<ModelInfo> Retrieve(ModelRetrieveParams parameters);

    /// <summary>
    /// List available models.
    ///
    /// The Models API response can be used to determine which models are available
    /// for use in the API. More recently released models are listed first.
    /// </summary>
    Task<ModelListPageResponse> List(ModelListParams? parameters = null);
}
