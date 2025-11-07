using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Skills.Versions;

namespace Anthropic.Client.Services.Beta.Skills.Versions;

public interface IVersionService
{
    IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create Skill Version
    /// </summary>
    Task<VersionCreateResponse> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Skill Version
    /// </summary>
    Task<VersionRetrieveResponse> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Skill Versions
    /// </summary>
    Task<VersionListPageResponse> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Skill Version
    /// </summary>
    Task<VersionDeleteResponse> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
