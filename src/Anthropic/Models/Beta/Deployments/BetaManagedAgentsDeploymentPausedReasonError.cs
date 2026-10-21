using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// The error that triggered an auto-pause. Matches the failed run's `error.type`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsDeploymentPausedReasonErrorConverter))]
public record class BetaManagedAgentsDeploymentPausedReasonError : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentArchivedError,
                BetaManagedAgentsAgentArchivedDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.AgentArchivedError,
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
                BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.VaultNotFoundError,
                BetaManagedAgentsFileNotFoundDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.FileNotFoundError,
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.WorkspaceArchivedError,
                BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.OrganizationDisabledError,
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
                BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.SkillNotFoundError,
                BetaManagedAgentsVaultArchivedDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.VaultArchivedError,
                BetaManagedAgentsUnknownDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.UnknownError,
                BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError,
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError _ =>
                    BetaManagedAgentsDeploymentPausedReasonErrorType.McpEgressBlockedError,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsAgentArchivedDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsFileNotFoundDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsUnknownDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReasonError(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnvironmentArchived(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnvironmentArchived(
        [NotNullWhen(true)]
            out BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentArchivedDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentArchived(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentArchivedDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentArchived(
        [NotNullWhen(true)] out BetaManagedAgentsAgentArchivedDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentArchivedDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnvironmentNotFound(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnvironmentNotFound(
        [NotNullWhen(true)]
            out BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultNotFound(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultNotFound(
        [NotNullWhen(true)] out BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileNotFoundDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileNotFound(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileNotFoundDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileNotFound(
        [NotNullWhen(true)] out BetaManagedAgentsFileNotFoundDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsFileNotFoundDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionResourceNotFound(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionResourceNotFound(
        [NotNullWhen(true)]
            out BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWorkspaceArchived(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWorkspaceArchived(
        [NotNullWhen(true)] out BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationDisabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationDisabled(
        [NotNullWhen(true)]
            out BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMemoryStoreArchived(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMemoryStoreArchived(
        [NotNullWhen(true)]
            out BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSkillNotFound(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSkillNotFound(
        [NotNullWhen(true)] out BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsVaultArchivedDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultArchived(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsVaultArchivedDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultArchived(
        [NotNullWhen(true)] out BetaManagedAgentsVaultArchivedDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsVaultArchivedDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUnknownDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnknown(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUnknownDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnknown(
        [NotNullWhen(true)] out BetaManagedAgentsUnknownDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsUnknownDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelfHostedResourcesUnsupported(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelfHostedResourcesUnsupported(
        [NotNullWhen(true)]
            out BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError? value
    )
    {
        value =
            this.Value
            as BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpEgressBlocked(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpEgressBlocked(
        [NotNullWhen(true)] out BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsAgentArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsFileNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsVaultArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsUnknownDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError> environmentArchived,
        Action<BetaManagedAgentsAgentArchivedDeploymentPausedReasonError> agentArchived,
        Action<BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError> environmentNotFound,
        Action<BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError> vaultNotFound,
        Action<BetaManagedAgentsFileNotFoundDeploymentPausedReasonError> fileNotFound,
        Action<BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError> sessionResourceNotFound,
        Action<BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError> workspaceArchived,
        Action<BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError> organizationDisabled,
        Action<BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError> memoryStoreArchived,
        Action<BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError> skillNotFound,
        Action<BetaManagedAgentsVaultArchivedDeploymentPausedReasonError> vaultArchived,
        Action<BetaManagedAgentsUnknownDeploymentPausedReasonError> unknown,
        Action<BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError> selfHostedResourcesUnsupported,
        Action<BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError> mcpEgressBlocked
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError value:
                environmentArchived(value);
                break;
            case BetaManagedAgentsAgentArchivedDeploymentPausedReasonError value:
                agentArchived(value);
                break;
            case BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError value:
                environmentNotFound(value);
                break;
            case BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError value:
                vaultNotFound(value);
                break;
            case BetaManagedAgentsFileNotFoundDeploymentPausedReasonError value:
                fileNotFound(value);
                break;
            case BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError value:
                sessionResourceNotFound(value);
                break;
            case BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError value:
                workspaceArchived(value);
                break;
            case BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError value:
                organizationDisabled(value);
                break;
            case BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError value:
                memoryStoreArchived(value);
                break;
            case BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError value:
                skillNotFound(value);
                break;
            case BetaManagedAgentsVaultArchivedDeploymentPausedReasonError value:
                vaultArchived(value);
                break;
            case BetaManagedAgentsUnknownDeploymentPausedReasonError value:
                unknown(value);
                break;
            case BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError value:
                selfHostedResourcesUnsupported(value);
                break;
            case BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError value:
                mcpEgressBlocked(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsDeploymentPausedReasonError"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsAgentArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsFileNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsVaultArchivedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsUnknownDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError value) =&gt; {...},
    ///     (BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<
            BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError,
            T
        > environmentArchived,
        Func<BetaManagedAgentsAgentArchivedDeploymentPausedReasonError, T> agentArchived,
        Func<
            BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError,
            T
        > environmentNotFound,
        Func<BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError, T> vaultNotFound,
        Func<BetaManagedAgentsFileNotFoundDeploymentPausedReasonError, T> fileNotFound,
        Func<
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError,
            T
        > sessionResourceNotFound,
        Func<BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError, T> workspaceArchived,
        Func<
            BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError,
            T
        > organizationDisabled,
        Func<
            BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError,
            T
        > memoryStoreArchived,
        Func<BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError, T> skillNotFound,
        Func<BetaManagedAgentsVaultArchivedDeploymentPausedReasonError, T> vaultArchived,
        Func<BetaManagedAgentsUnknownDeploymentPausedReasonError, T> unknown,
        Func<
            BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError,
            T
        > selfHostedResourcesUnsupported,
        Func<BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError, T> mcpEgressBlocked
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError value =>
                environmentArchived(value),
            BetaManagedAgentsAgentArchivedDeploymentPausedReasonError value => agentArchived(value),
            BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError value =>
                environmentNotFound(value),
            BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError value => vaultNotFound(value),
            BetaManagedAgentsFileNotFoundDeploymentPausedReasonError value => fileNotFound(value),
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError value =>
                sessionResourceNotFound(value),
            BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError value =>
                workspaceArchived(value),
            BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError value =>
                organizationDisabled(value),
            BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError value =>
                memoryStoreArchived(value),
            BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError value => skillNotFound(value),
            BetaManagedAgentsVaultArchivedDeploymentPausedReasonError value => vaultArchived(value),
            BetaManagedAgentsUnknownDeploymentPausedReasonError value => unknown(value),
            BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError value =>
                selfHostedResourcesUnsupported(value),
            BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError value => mcpEgressBlocked(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsDeploymentPausedReasonError"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsAgentArchivedDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsFileNotFoundDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsUnknownDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReasonError(
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsDeploymentPausedReasonError"
            );
        }
        this.Switch(
            (environmentArchived) => environmentArchived.Validate(),
            (agentArchived) => agentArchived.Validate(),
            (environmentNotFound) => environmentNotFound.Validate(),
            (vaultNotFound) => vaultNotFound.Validate(),
            (fileNotFound) => fileNotFound.Validate(),
            (sessionResourceNotFound) => sessionResourceNotFound.Validate(),
            (workspaceArchived) => workspaceArchived.Validate(),
            (organizationDisabled) => organizationDisabled.Validate(),
            (memoryStoreArchived) => memoryStoreArchived.Validate(),
            (skillNotFound) => skillNotFound.Validate(),
            (vaultArchived) => vaultArchived.Validate(),
            (unknown) => unknown.Validate(),
            (selfHostedResourcesUnsupported) => selfHostedResourcesUnsupported.Validate(),
            (mcpEgressBlocked) => mcpEgressBlocked.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsDeploymentPausedReasonError? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError _ => 0,
            BetaManagedAgentsAgentArchivedDeploymentPausedReasonError _ => 1,
            BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError _ => 2,
            BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError _ => 3,
            BetaManagedAgentsFileNotFoundDeploymentPausedReasonError _ => 4,
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError _ => 5,
            BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError _ => 6,
            BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError _ => 7,
            BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError _ => 8,
            BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError _ => 9,
            BetaManagedAgentsVaultArchivedDeploymentPausedReasonError _ => 10,
            BetaManagedAgentsUnknownDeploymentPausedReasonError _ => 11,
            BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError _ => 12,
            BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError _ => 13,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsDeploymentPausedReasonErrorConverter
    : JsonConverter<BetaManagedAgentsDeploymentPausedReasonError>
{
    public override BetaManagedAgentsDeploymentPausedReasonError? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "environment_archived_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent_archived_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentArchivedDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "environment_not_found_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "vault_not_found_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "file_not_found_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsFileNotFoundDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session_resource_not_found_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "workspace_archived_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "organization_disabled_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "memory_store_archived_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "skill_not_found_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "vault_archived_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsVaultArchivedDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "unknown_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUnknownDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "self_hosted_resources_unsupported_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "mcp_egress_blocked_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaManagedAgentsDeploymentPausedReasonError(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentPausedReasonError value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsDeploymentPausedReasonErrorTypeConverter))]
public enum BetaManagedAgentsDeploymentPausedReasonErrorType
{
    EnvironmentArchivedError,
    AgentArchivedError,
    EnvironmentNotFoundError,
    VaultNotFoundError,
    FileNotFoundError,
    SessionResourceNotFoundError,
    WorkspaceArchivedError,
    OrganizationDisabledError,
    MemoryStoreArchivedError,
    SkillNotFoundError,
    VaultArchivedError,
    UnknownError,
    SelfHostedResourcesUnsupportedError,
    McpEgressBlockedError,
}

sealed class BetaManagedAgentsDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_archived_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentArchivedError,
            "agent_archived_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.AgentArchivedError,
            "environment_not_found_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
            "vault_not_found_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.VaultNotFoundError,
            "file_not_found_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.FileNotFoundError,
            "session_resource_not_found_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
            "workspace_archived_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.WorkspaceArchivedError,
            "organization_disabled_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.OrganizationDisabledError,
            "memory_store_archived_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
            "skill_not_found_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.SkillNotFoundError,
            "vault_archived_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.VaultArchivedError,
            "unknown_error" => BetaManagedAgentsDeploymentPausedReasonErrorType.UnknownError,
            "self_hosted_resources_unsupported_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError,
            "mcp_egress_blocked_error" =>
                BetaManagedAgentsDeploymentPausedReasonErrorType.McpEgressBlockedError,
            _ => (BetaManagedAgentsDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentArchivedError =>
                    "environment_archived_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.AgentArchivedError =>
                    "agent_archived_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentNotFoundError =>
                    "environment_not_found_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.VaultNotFoundError =>
                    "vault_not_found_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.FileNotFoundError =>
                    "file_not_found_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.SessionResourceNotFoundError =>
                    "session_resource_not_found_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.WorkspaceArchivedError =>
                    "workspace_archived_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.OrganizationDisabledError =>
                    "organization_disabled_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.MemoryStoreArchivedError =>
                    "memory_store_archived_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.SkillNotFoundError =>
                    "skill_not_found_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.VaultArchivedError =>
                    "vault_archived_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.UnknownError => "unknown_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError =>
                    "self_hosted_resources_unsupported_error",
                BetaManagedAgentsDeploymentPausedReasonErrorType.McpEgressBlockedError =>
                    "mcp_egress_blocked_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
