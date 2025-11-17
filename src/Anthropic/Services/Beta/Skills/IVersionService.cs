using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Services.Beta.Skills;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
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
