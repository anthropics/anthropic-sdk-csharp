using System.Threading.Tasks;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Service.Beta.Models;

public interface IModelService
{
    /// <summary>
    /// Get a specific model.
    ///
    /// The Models API response can be used to determine information about a specific
    /// model or resolve a model alias to a model ID.
    /// </summary>
    Task<BetaModelInfo> Retrieve(ModelRetrieveParams @params);

    /// <summary>
    /// List available models.
    ///
    /// The Models API response can be used to determine which models are available
    /// for use in the API. More recently released models are listed first.
    /// </summary>
    Task<ModelListPageResponse> List(ModelListParams @params);
}
