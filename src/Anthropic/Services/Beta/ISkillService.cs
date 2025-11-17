using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Skills;
using Anthropic.Services.Beta.Skills;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISkillService
{
    ISkillService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionService Versions { get; }

    /// <summary>
    /// Create Skill
    /// </summary>
    Task<SkillCreateResponse> Create(
        SkillCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Skill
    /// </summary>
    Task<SkillRetrieveResponse> Retrieve(
        SkillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Skills
    /// </summary>
    Task<SkillListPageResponse> List(
        SkillListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Skill
    /// </summary>
    Task<SkillDeleteResponse> Delete(
        SkillDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
