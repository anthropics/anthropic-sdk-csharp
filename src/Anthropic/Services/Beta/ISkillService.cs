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
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    /// <inheritdoc cref="Retrieve(SkillRetrieveParams, CancellationToken)"/>
    Task<SkillRetrieveResponse> Retrieve(
        string skillID,
        SkillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Skills
    /// </summary>
    Task<SkillListPage> List(
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

    /// <inheritdoc cref="Delete(SkillDeleteParams, CancellationToken)"/>
    Task<SkillDeleteResponse> Delete(
        string skillID,
        SkillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
