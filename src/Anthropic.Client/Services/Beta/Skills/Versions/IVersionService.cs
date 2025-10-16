using System.Threading.Tasks;
using Anthropic.Client.Models.Beta.Skills.Versions;

namespace Anthropic.Client.Services.Beta.Skills.Versions;

public interface IVersionService
{
    /// <summary>
    /// Create Skill Version
    /// </summary>
    Task<VersionCreateResponse> Create(VersionCreateParams parameters);

    /// <summary>
    /// Get Skill Version
    /// </summary>
    Task<VersionRetrieveResponse> Retrieve(VersionRetrieveParams parameters);

    /// <summary>
    /// List Skill Versions
    /// </summary>
    Task<VersionListPageResponse> List(VersionListParams parameters);

    /// <summary>
    /// Delete Skill Version
    /// </summary>
    Task<VersionDeleteResponse> Delete(VersionDeleteParams parameters);
}
