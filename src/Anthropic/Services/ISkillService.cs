using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Skills;
using Anthropic.Services.Skills;

namespace Anthropic.Services;

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
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException">
    /// The API key belongs to the Claude Code workspace, and the user who created it is
    /// no longer a member of the organization or of that workspace.
    /// </exception>
    /// <exception cref="AnthropicCmekKeyDisabledException">
    /// The workspace's customer-managed encryption key is disabled or revoked.
    /// Re-enable the key, then retry.
    /// </exception>
    /// <exception cref="AnthropicCmekKeyNetworkBlockedException">
    /// The key management service's network access controls blocked the request to the
    /// workspace's customer-managed encryption key. The key itself may be healthy.
    /// </exception>
    /// <exception cref="AnthropicOrganizationOnHoldException">
    /// Anthropic has disabled the organization for trust and safety reasons. An
    /// organization disabled for any other reason, such as billing, does not get this
    /// code. `appeal_url`, when present, is where the organization can appeal.
    /// </exception>
    /// <exception cref="AnthropicCmekContextUnavailableException">
    /// The request's workspace encryption context could not be resolved, so the request
    /// was refused. Retry in a few minutes.
    /// </exception>
    Task<Skill> Create(SkillCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Skill
    /// </summary>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException">
    /// The API key belongs to the Claude Code workspace, and the user who created it is
    /// no longer a member of the organization or of that workspace.
    /// </exception>
    /// <exception cref="AnthropicOrganizationOnHoldException">
    /// Anthropic has disabled the organization for trust and safety reasons. An
    /// organization disabled for any other reason, such as billing, does not get this
    /// code. `appeal_url`, when present, is where the organization can appeal.
    /// </exception>
    Task<Skill> Retrieve(
        SkillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SkillRetrieveParams, CancellationToken)"/>
    Task<Skill> Retrieve(
        string skillID,
        SkillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Skills
    /// </summary>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException">
    /// The API key belongs to the Claude Code workspace, and the user who created it is
    /// no longer a member of the organization or of that workspace.
    /// </exception>
    /// <exception cref="AnthropicOrganizationOnHoldException">
    /// Anthropic has disabled the organization for trust and safety reasons. An
    /// organization disabled for any other reason, such as billing, does not get this
    /// code. `appeal_url`, when present, is where the organization can appeal.
    /// </exception>
    Task<SkillListPage> List(
        SkillListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Skill
    /// </summary>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException">
    /// The API key belongs to the Claude Code workspace, and the user who created it is
    /// no longer a member of the organization or of that workspace.
    /// </exception>
    /// <exception cref="AnthropicOrganizationOnHoldException">
    /// Anthropic has disabled the organization for trust and safety reasons. An
    /// organization disabled for any other reason, such as billing, does not get this
    /// code. `appeal_url`, when present, is where the organization can appeal.
    /// </exception>
    Task<DeletedSkill> Delete(
        SkillDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SkillDeleteParams, CancellationToken)"/>
    Task<DeletedSkill> Delete(
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
    /// Returns a raw HTTP response for <c>post /v1/skills</c>, but is otherwise the
    /// same as <see cref="ISkillService.Create(SkillCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Skill>> Create(
        SkillCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/skills/{skill_id}</c>, but is otherwise the
    /// same as <see cref="ISkillService.Retrieve(SkillRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Skill>> Retrieve(
        SkillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SkillRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Skill>> Retrieve(
        string skillID,
        SkillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/skills</c>, but is otherwise the
    /// same as <see cref="ISkillService.List(SkillListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SkillListPage>> List(
        SkillListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/skills/{skill_id}</c>, but is otherwise the
    /// same as <see cref="ISkillService.Delete(SkillDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeletedSkill>> Delete(
        SkillDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SkillDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DeletedSkill>> Delete(
        string skillID,
        SkillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
