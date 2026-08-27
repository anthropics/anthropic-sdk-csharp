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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISkillServiceWithRawResponse WithRawResponse { get; }

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
    Task<BetaSkill> Create(
        SkillCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Skill
    /// </summary>
    Task<BetaSkill> Retrieve(
        SkillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SkillRetrieveParams, CancellationToken)"/>
    Task<BetaSkill> Retrieve(
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
    Task<BetaDeletedSkill> Delete(
        SkillDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SkillDeleteParams, CancellationToken)"/>
    Task<BetaDeletedSkill> Delete(
        string skillID,
        SkillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISkillService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISkillServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISkillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionServiceWithRawResponse Versions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/skills?beta=true</c>, but is otherwise the
    /// same as <see cref="ISkillService.Create(SkillCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSkill>> Create(
        SkillCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/skills/{skill_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ISkillService.Retrieve(SkillRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSkill>> Retrieve(
        SkillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SkillRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaSkill>> Retrieve(
        string skillID,
        SkillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/skills?beta=true</c>, but is otherwise the
    /// same as <see cref="ISkillService.List(SkillListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SkillListPage>> List(
        SkillListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/skills/{skill_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ISkillService.Delete(SkillDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDeletedSkill>> Delete(
        SkillDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SkillDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedSkill>> Delete(
        string skillID,
        SkillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
