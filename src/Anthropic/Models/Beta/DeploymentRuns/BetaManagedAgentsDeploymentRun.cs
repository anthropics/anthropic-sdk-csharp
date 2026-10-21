using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// A persistent, append-only record of a single deployment execution. Records session
/// creation success or failure — no session lifecycle tracking.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeploymentRun,
        BetaManagedAgentsDeploymentRunFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeploymentRun : JsonModel
{
    /// <summary>
    /// Unique identifier for this run (`drun_...`).
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Snapshot of the agent at fire time. Always fully resolved — deployments pin
    /// agent + version.
    /// </summary>
    public required Agents::BetaManagedAgentsAgentReference Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Agents::BetaManagedAgentsAgentReference>("agent");
        }
        init { this._rawData.Set("agent", value); }
    }

    /// <summary>
    /// Time this run record was persisted.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// ID of the deployment that produced this run.
    /// </summary>
    public required string DeploymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("deployment_id");
        }
        init { this._rawData.Set("deployment_id", value); }
    }

    /// <summary>
    /// Populated on creation failure. Null on success. Exactly one of `session_id`
    /// or `error` is non-null.
    /// </summary>
    public required Error? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Error>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Populated on success. Null on creation failure. Exactly one of `session_id`
    /// or `error` is non-null.
    /// </summary>
    public required string? SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// What triggered this run and trigger-specific metadata.
    /// </summary>
    public required BetaManagedAgentsTriggerContext TriggerContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsTriggerContext>(
                "trigger_context"
            );
        }
        init { this._rawData.Set("trigger_context", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Agent.Validate();
        _ = this.CreatedAt;
        _ = this.DeploymentID;
        this.Error?.Validate();
        _ = this.SessionID;
        this.TriggerContext.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("deployment_run")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeploymentRun()
    {
        this.Type = JsonSerializer.SerializeToElement("deployment_run");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeploymentRun(
        BetaManagedAgentsDeploymentRun betaManagedAgentsDeploymentRun
    )
        : base(betaManagedAgentsDeploymentRun) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeploymentRun(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("deployment_run");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeploymentRun(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeploymentRunFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeploymentRun FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeploymentRunFromRaw : IFromRawJson<BetaManagedAgentsDeploymentRun>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeploymentRun FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeploymentRun.FromRawUnchecked(rawData);
}

/// <summary>
/// Populated on creation failure. Null on success. Exactly one of `session_id` or
/// `error` is non-null.
/// </summary>
[JsonConverter(typeof(ErrorConverter))]
public record class Error : ModelBase
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

    public string Message
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsEnvironmentArchivedRunError x => x.Message,
                BetaManagedAgentsAgentArchivedRunError x => x.Message,
                BetaManagedAgentsEnvironmentNotFoundRunError x => x.Message,
                BetaManagedAgentsVaultNotFoundRunError x => x.Message,
                BetaManagedAgentsVaultArchivedRunError x => x.Message,
                BetaManagedAgentsFileNotFoundRunError x => x.Message,
                BetaManagedAgentsMemoryStoreArchivedRunError x => x.Message,
                BetaManagedAgentsSkillNotFoundRunError x => x.Message,
                BetaManagedAgentsSessionResourceNotFoundRunError x => x.Message,
                BetaManagedAgentsWorkspaceArchivedRunError x => x.Message,
                BetaManagedAgentsOrganizationDisabledRunError x => x.Message,
                BetaManagedAgentsSessionRateLimitedRunError x => x.Message,
                BetaManagedAgentsSessionCreationRejectedRunError x => x.Message,
                BetaManagedAgentsUnknownRunError x => x.Message,
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunError x => x.Message,
                BetaManagedAgentsMcpEgressBlockedRunError x => x.Message,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "message"),
            };
        }
    }

    public ApiEnum<string, ErrorType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsEnvironmentArchivedRunError _ =>
                    ErrorType.EnvironmentArchivedError,
                BetaManagedAgentsAgentArchivedRunError _ => ErrorType.AgentArchivedError,
                BetaManagedAgentsEnvironmentNotFoundRunError _ =>
                    ErrorType.EnvironmentNotFoundError,
                BetaManagedAgentsVaultNotFoundRunError _ => ErrorType.VaultNotFoundError,
                BetaManagedAgentsVaultArchivedRunError _ => ErrorType.VaultArchivedError,
                BetaManagedAgentsFileNotFoundRunError _ => ErrorType.FileNotFoundError,
                BetaManagedAgentsMemoryStoreArchivedRunError _ =>
                    ErrorType.MemoryStoreArchivedError,
                BetaManagedAgentsSkillNotFoundRunError _ => ErrorType.SkillNotFoundError,
                BetaManagedAgentsSessionResourceNotFoundRunError _ =>
                    ErrorType.SessionResourceNotFoundError,
                BetaManagedAgentsWorkspaceArchivedRunError _ => ErrorType.WorkspaceArchivedError,
                BetaManagedAgentsOrganizationDisabledRunError _ =>
                    ErrorType.OrganizationDisabledError,
                BetaManagedAgentsSessionRateLimitedRunError _ => ErrorType.SessionRateLimitedError,
                BetaManagedAgentsSessionCreationRejectedRunError _ =>
                    ErrorType.SessionCreationRejectedError,
                BetaManagedAgentsUnknownRunError _ => ErrorType.UnknownError,
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunError _ =>
                    ErrorType.SelfHostedResourcesUnsupportedError,
                BetaManagedAgentsMcpEgressBlockedRunError _ => ErrorType.McpEgressBlockedError,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, ErrorType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public Error(BetaManagedAgentsEnvironmentArchivedRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsAgentArchivedRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsEnvironmentNotFoundRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsVaultNotFoundRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsVaultArchivedRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsFileNotFoundRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsMemoryStoreArchivedRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsSkillNotFoundRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(
        BetaManagedAgentsSessionResourceNotFoundRunError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsWorkspaceArchivedRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsOrganizationDisabledRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsSessionRateLimitedRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(
        BetaManagedAgentsSessionCreationRejectedRunError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsUnknownRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsMcpEgressBlockedRunError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEnvironmentArchivedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsEnvironmentArchivedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEnvironmentArchivedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsEnvironmentArchivedRun(
        [NotNullWhen(true)] out BetaManagedAgentsEnvironmentArchivedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsEnvironmentArchivedRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentArchivedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentArchivedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentArchivedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentArchivedRun(
        [NotNullWhen(true)] out BetaManagedAgentsAgentArchivedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentArchivedRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEnvironmentNotFoundRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsEnvironmentNotFoundRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEnvironmentNotFoundRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsEnvironmentNotFoundRun(
        [NotNullWhen(true)] out BetaManagedAgentsEnvironmentNotFoundRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsEnvironmentNotFoundRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsVaultNotFoundRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsVaultNotFoundRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsVaultNotFoundRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsVaultNotFoundRun(
        [NotNullWhen(true)] out BetaManagedAgentsVaultNotFoundRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsVaultNotFoundRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsVaultArchivedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsVaultArchivedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsVaultArchivedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsVaultArchivedRun(
        [NotNullWhen(true)] out BetaManagedAgentsVaultArchivedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsVaultArchivedRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileNotFoundRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFileNotFoundRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileNotFoundRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFileNotFoundRun(
        [NotNullWhen(true)] out BetaManagedAgentsFileNotFoundRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsFileNotFoundRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMemoryStoreArchivedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMemoryStoreArchivedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMemoryStoreArchivedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMemoryStoreArchivedRun(
        [NotNullWhen(true)] out BetaManagedAgentsMemoryStoreArchivedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsMemoryStoreArchivedRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSkillNotFoundRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSkillNotFoundRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSkillNotFoundRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSkillNotFoundRun(
        [NotNullWhen(true)] out BetaManagedAgentsSkillNotFoundRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsSkillNotFoundRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionResourceNotFoundRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSessionResourceNotFoundRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionResourceNotFoundRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSessionResourceNotFoundRun(
        [NotNullWhen(true)] out BetaManagedAgentsSessionResourceNotFoundRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionResourceNotFoundRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWorkspaceArchivedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsWorkspaceArchivedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWorkspaceArchivedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsWorkspaceArchivedRun(
        [NotNullWhen(true)] out BetaManagedAgentsWorkspaceArchivedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsWorkspaceArchivedRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsOrganizationDisabledRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsOrganizationDisabledRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsOrganizationDisabledRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsOrganizationDisabledRun(
        [NotNullWhen(true)] out BetaManagedAgentsOrganizationDisabledRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsOrganizationDisabledRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionRateLimitedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSessionRateLimitedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionRateLimitedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSessionRateLimitedRun(
        [NotNullWhen(true)] out BetaManagedAgentsSessionRateLimitedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionRateLimitedRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionCreationRejectedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSessionCreationRejectedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionCreationRejectedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSessionCreationRejectedRun(
        [NotNullWhen(true)] out BetaManagedAgentsSessionCreationRejectedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionCreationRejectedRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUnknownRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUnknownRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUnknownRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUnknownRun(
        [NotNullWhen(true)] out BetaManagedAgentsUnknownRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsUnknownRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSelfHostedResourcesUnsupportedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSelfHostedResourcesUnsupportedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSelfHostedResourcesUnsupportedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSelfHostedResourcesUnsupportedRun(
        [NotNullWhen(true)] out BetaManagedAgentsSelfHostedResourcesUnsupportedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsSelfHostedResourcesUnsupportedRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpEgressBlockedRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpEgressBlockedRun(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpEgressBlockedRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpEgressBlockedRun(
        [NotNullWhen(true)] out BetaManagedAgentsMcpEgressBlockedRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpEgressBlockedRunError;
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
    ///     (BetaManagedAgentsEnvironmentArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsAgentArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsEnvironmentNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsVaultNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsVaultArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsFileNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSkillNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSessionResourceNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsWorkspaceArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsOrganizationDisabledRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSessionRateLimitedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSessionCreationRejectedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsUnknownRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSelfHostedResourcesUnsupportedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsMcpEgressBlockedRunError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaManagedAgentsEnvironmentArchivedRunError> betaManagedAgentsEnvironmentArchivedRun,
        Action<BetaManagedAgentsAgentArchivedRunError> betaManagedAgentsAgentArchivedRun,
        Action<BetaManagedAgentsEnvironmentNotFoundRunError> betaManagedAgentsEnvironmentNotFoundRun,
        Action<BetaManagedAgentsVaultNotFoundRunError> betaManagedAgentsVaultNotFoundRun,
        Action<BetaManagedAgentsVaultArchivedRunError> betaManagedAgentsVaultArchivedRun,
        Action<BetaManagedAgentsFileNotFoundRunError> betaManagedAgentsFileNotFoundRun,
        Action<BetaManagedAgentsMemoryStoreArchivedRunError> betaManagedAgentsMemoryStoreArchivedRun,
        Action<BetaManagedAgentsSkillNotFoundRunError> betaManagedAgentsSkillNotFoundRun,
        Action<BetaManagedAgentsSessionResourceNotFoundRunError> betaManagedAgentsSessionResourceNotFoundRun,
        Action<BetaManagedAgentsWorkspaceArchivedRunError> betaManagedAgentsWorkspaceArchivedRun,
        Action<BetaManagedAgentsOrganizationDisabledRunError> betaManagedAgentsOrganizationDisabledRun,
        Action<BetaManagedAgentsSessionRateLimitedRunError> betaManagedAgentsSessionRateLimitedRun,
        Action<BetaManagedAgentsSessionCreationRejectedRunError> betaManagedAgentsSessionCreationRejectedRun,
        Action<BetaManagedAgentsUnknownRunError> betaManagedAgentsUnknownRun,
        Action<BetaManagedAgentsSelfHostedResourcesUnsupportedRunError> betaManagedAgentsSelfHostedResourcesUnsupportedRun,
        Action<BetaManagedAgentsMcpEgressBlockedRunError> betaManagedAgentsMcpEgressBlockedRun
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsEnvironmentArchivedRunError value:
                betaManagedAgentsEnvironmentArchivedRun(value);
                break;
            case BetaManagedAgentsAgentArchivedRunError value:
                betaManagedAgentsAgentArchivedRun(value);
                break;
            case BetaManagedAgentsEnvironmentNotFoundRunError value:
                betaManagedAgentsEnvironmentNotFoundRun(value);
                break;
            case BetaManagedAgentsVaultNotFoundRunError value:
                betaManagedAgentsVaultNotFoundRun(value);
                break;
            case BetaManagedAgentsVaultArchivedRunError value:
                betaManagedAgentsVaultArchivedRun(value);
                break;
            case BetaManagedAgentsFileNotFoundRunError value:
                betaManagedAgentsFileNotFoundRun(value);
                break;
            case BetaManagedAgentsMemoryStoreArchivedRunError value:
                betaManagedAgentsMemoryStoreArchivedRun(value);
                break;
            case BetaManagedAgentsSkillNotFoundRunError value:
                betaManagedAgentsSkillNotFoundRun(value);
                break;
            case BetaManagedAgentsSessionResourceNotFoundRunError value:
                betaManagedAgentsSessionResourceNotFoundRun(value);
                break;
            case BetaManagedAgentsWorkspaceArchivedRunError value:
                betaManagedAgentsWorkspaceArchivedRun(value);
                break;
            case BetaManagedAgentsOrganizationDisabledRunError value:
                betaManagedAgentsOrganizationDisabledRun(value);
                break;
            case BetaManagedAgentsSessionRateLimitedRunError value:
                betaManagedAgentsSessionRateLimitedRun(value);
                break;
            case BetaManagedAgentsSessionCreationRejectedRunError value:
                betaManagedAgentsSessionCreationRejectedRun(value);
                break;
            case BetaManagedAgentsUnknownRunError value:
                betaManagedAgentsUnknownRun(value);
                break;
            case BetaManagedAgentsSelfHostedResourcesUnsupportedRunError value:
                betaManagedAgentsSelfHostedResourcesUnsupportedRun(value);
                break;
            case BetaManagedAgentsMcpEgressBlockedRunError value:
                betaManagedAgentsMcpEgressBlockedRun(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Error");
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
    ///     (BetaManagedAgentsEnvironmentArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsAgentArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsEnvironmentNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsVaultNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsVaultArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsFileNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSkillNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSessionResourceNotFoundRunError value) =&gt; {...},
    ///     (BetaManagedAgentsWorkspaceArchivedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsOrganizationDisabledRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSessionRateLimitedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSessionCreationRejectedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsUnknownRunError value) =&gt; {...},
    ///     (BetaManagedAgentsSelfHostedResourcesUnsupportedRunError value) =&gt; {...},
    ///     (BetaManagedAgentsMcpEgressBlockedRunError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<
            BetaManagedAgentsEnvironmentArchivedRunError,
            T
        > betaManagedAgentsEnvironmentArchivedRun,
        Func<BetaManagedAgentsAgentArchivedRunError, T> betaManagedAgentsAgentArchivedRun,
        Func<
            BetaManagedAgentsEnvironmentNotFoundRunError,
            T
        > betaManagedAgentsEnvironmentNotFoundRun,
        Func<BetaManagedAgentsVaultNotFoundRunError, T> betaManagedAgentsVaultNotFoundRun,
        Func<BetaManagedAgentsVaultArchivedRunError, T> betaManagedAgentsVaultArchivedRun,
        Func<BetaManagedAgentsFileNotFoundRunError, T> betaManagedAgentsFileNotFoundRun,
        Func<
            BetaManagedAgentsMemoryStoreArchivedRunError,
            T
        > betaManagedAgentsMemoryStoreArchivedRun,
        Func<BetaManagedAgentsSkillNotFoundRunError, T> betaManagedAgentsSkillNotFoundRun,
        Func<
            BetaManagedAgentsSessionResourceNotFoundRunError,
            T
        > betaManagedAgentsSessionResourceNotFoundRun,
        Func<BetaManagedAgentsWorkspaceArchivedRunError, T> betaManagedAgentsWorkspaceArchivedRun,
        Func<
            BetaManagedAgentsOrganizationDisabledRunError,
            T
        > betaManagedAgentsOrganizationDisabledRun,
        Func<BetaManagedAgentsSessionRateLimitedRunError, T> betaManagedAgentsSessionRateLimitedRun,
        Func<
            BetaManagedAgentsSessionCreationRejectedRunError,
            T
        > betaManagedAgentsSessionCreationRejectedRun,
        Func<BetaManagedAgentsUnknownRunError, T> betaManagedAgentsUnknownRun,
        Func<
            BetaManagedAgentsSelfHostedResourcesUnsupportedRunError,
            T
        > betaManagedAgentsSelfHostedResourcesUnsupportedRun,
        Func<BetaManagedAgentsMcpEgressBlockedRunError, T> betaManagedAgentsMcpEgressBlockedRun
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsEnvironmentArchivedRunError value =>
                betaManagedAgentsEnvironmentArchivedRun(value),
            BetaManagedAgentsAgentArchivedRunError value => betaManagedAgentsAgentArchivedRun(
                value
            ),
            BetaManagedAgentsEnvironmentNotFoundRunError value =>
                betaManagedAgentsEnvironmentNotFoundRun(value),
            BetaManagedAgentsVaultNotFoundRunError value => betaManagedAgentsVaultNotFoundRun(
                value
            ),
            BetaManagedAgentsVaultArchivedRunError value => betaManagedAgentsVaultArchivedRun(
                value
            ),
            BetaManagedAgentsFileNotFoundRunError value => betaManagedAgentsFileNotFoundRun(value),
            BetaManagedAgentsMemoryStoreArchivedRunError value =>
                betaManagedAgentsMemoryStoreArchivedRun(value),
            BetaManagedAgentsSkillNotFoundRunError value => betaManagedAgentsSkillNotFoundRun(
                value
            ),
            BetaManagedAgentsSessionResourceNotFoundRunError value =>
                betaManagedAgentsSessionResourceNotFoundRun(value),
            BetaManagedAgentsWorkspaceArchivedRunError value =>
                betaManagedAgentsWorkspaceArchivedRun(value),
            BetaManagedAgentsOrganizationDisabledRunError value =>
                betaManagedAgentsOrganizationDisabledRun(value),
            BetaManagedAgentsSessionRateLimitedRunError value =>
                betaManagedAgentsSessionRateLimitedRun(value),
            BetaManagedAgentsSessionCreationRejectedRunError value =>
                betaManagedAgentsSessionCreationRejectedRun(value),
            BetaManagedAgentsUnknownRunError value => betaManagedAgentsUnknownRun(value),
            BetaManagedAgentsSelfHostedResourcesUnsupportedRunError value =>
                betaManagedAgentsSelfHostedResourcesUnsupportedRun(value),
            BetaManagedAgentsMcpEgressBlockedRunError value => betaManagedAgentsMcpEgressBlockedRun(
                value
            ),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Error"),
        };
    }

    public static implicit operator Error(BetaManagedAgentsEnvironmentArchivedRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsAgentArchivedRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsEnvironmentNotFoundRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsVaultNotFoundRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsVaultArchivedRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsFileNotFoundRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsMemoryStoreArchivedRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsSkillNotFoundRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsSessionResourceNotFoundRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsWorkspaceArchivedRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsOrganizationDisabledRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsSessionRateLimitedRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsSessionCreationRejectedRunError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsUnknownRunError value) => new(value);

    public static implicit operator Error(
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunError value
    ) => new(value);

    public static implicit operator Error(BetaManagedAgentsMcpEgressBlockedRunError value) =>
        new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Error");
        }
        this.Switch(
            (betaManagedAgentsEnvironmentArchivedRun) =>
                betaManagedAgentsEnvironmentArchivedRun.Validate(),
            (betaManagedAgentsAgentArchivedRun) => betaManagedAgentsAgentArchivedRun.Validate(),
            (betaManagedAgentsEnvironmentNotFoundRun) =>
                betaManagedAgentsEnvironmentNotFoundRun.Validate(),
            (betaManagedAgentsVaultNotFoundRun) => betaManagedAgentsVaultNotFoundRun.Validate(),
            (betaManagedAgentsVaultArchivedRun) => betaManagedAgentsVaultArchivedRun.Validate(),
            (betaManagedAgentsFileNotFoundRun) => betaManagedAgentsFileNotFoundRun.Validate(),
            (betaManagedAgentsMemoryStoreArchivedRun) =>
                betaManagedAgentsMemoryStoreArchivedRun.Validate(),
            (betaManagedAgentsSkillNotFoundRun) => betaManagedAgentsSkillNotFoundRun.Validate(),
            (betaManagedAgentsSessionResourceNotFoundRun) =>
                betaManagedAgentsSessionResourceNotFoundRun.Validate(),
            (betaManagedAgentsWorkspaceArchivedRun) =>
                betaManagedAgentsWorkspaceArchivedRun.Validate(),
            (betaManagedAgentsOrganizationDisabledRun) =>
                betaManagedAgentsOrganizationDisabledRun.Validate(),
            (betaManagedAgentsSessionRateLimitedRun) =>
                betaManagedAgentsSessionRateLimitedRun.Validate(),
            (betaManagedAgentsSessionCreationRejectedRun) =>
                betaManagedAgentsSessionCreationRejectedRun.Validate(),
            (betaManagedAgentsUnknownRun) => betaManagedAgentsUnknownRun.Validate(),
            (betaManagedAgentsSelfHostedResourcesUnsupportedRun) =>
                betaManagedAgentsSelfHostedResourcesUnsupportedRun.Validate(),
            (betaManagedAgentsMcpEgressBlockedRun) =>
                betaManagedAgentsMcpEgressBlockedRun.Validate()
        );
    }

    public virtual bool Equals(Error? other) =>
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
            BetaManagedAgentsEnvironmentArchivedRunError _ => 0,
            BetaManagedAgentsAgentArchivedRunError _ => 1,
            BetaManagedAgentsEnvironmentNotFoundRunError _ => 2,
            BetaManagedAgentsVaultNotFoundRunError _ => 3,
            BetaManagedAgentsVaultArchivedRunError _ => 4,
            BetaManagedAgentsFileNotFoundRunError _ => 5,
            BetaManagedAgentsMemoryStoreArchivedRunError _ => 6,
            BetaManagedAgentsSkillNotFoundRunError _ => 7,
            BetaManagedAgentsSessionResourceNotFoundRunError _ => 8,
            BetaManagedAgentsWorkspaceArchivedRunError _ => 9,
            BetaManagedAgentsOrganizationDisabledRunError _ => 10,
            BetaManagedAgentsSessionRateLimitedRunError _ => 11,
            BetaManagedAgentsSessionCreationRejectedRunError _ => 12,
            BetaManagedAgentsUnknownRunError _ => 13,
            BetaManagedAgentsSelfHostedResourcesUnsupportedRunError _ => 14,
            BetaManagedAgentsMcpEgressBlockedRunError _ => 15,
            _ => -1,
        };
    }
}

sealed class ErrorConverter : JsonConverter<Error?>
{
    public override Error? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentArchivedRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentArchivedRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentNotFoundRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsVaultNotFoundRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsVaultArchivedRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsFileNotFoundRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreArchivedRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsSkillNotFoundRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceNotFoundRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsWorkspaceArchivedRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsOrganizationDisabledRunError>(
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
            case "session_rate_limited_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionRateLimitedRunError>(
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
            case "session_creation_rejected_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionCreationRejectedRunError>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUnknownRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsSelfHostedResourcesUnsupportedRunError>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMcpEgressBlockedRunError>(
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
                return new Error(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Error? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(ErrorTypeConverter))]
public enum ErrorType
{
    EnvironmentArchivedError,
    AgentArchivedError,
    EnvironmentNotFoundError,
    VaultNotFoundError,
    VaultArchivedError,
    FileNotFoundError,
    MemoryStoreArchivedError,
    SkillNotFoundError,
    SessionResourceNotFoundError,
    WorkspaceArchivedError,
    OrganizationDisabledError,
    SessionRateLimitedError,
    SessionCreationRejectedError,
    UnknownError,
    SelfHostedResourcesUnsupportedError,
    McpEgressBlockedError,
}

sealed class ErrorTypeConverter : JsonConverter<ErrorType>
{
    public override ErrorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_archived_error" => ErrorType.EnvironmentArchivedError,
            "agent_archived_error" => ErrorType.AgentArchivedError,
            "environment_not_found_error" => ErrorType.EnvironmentNotFoundError,
            "vault_not_found_error" => ErrorType.VaultNotFoundError,
            "vault_archived_error" => ErrorType.VaultArchivedError,
            "file_not_found_error" => ErrorType.FileNotFoundError,
            "memory_store_archived_error" => ErrorType.MemoryStoreArchivedError,
            "skill_not_found_error" => ErrorType.SkillNotFoundError,
            "session_resource_not_found_error" => ErrorType.SessionResourceNotFoundError,
            "workspace_archived_error" => ErrorType.WorkspaceArchivedError,
            "organization_disabled_error" => ErrorType.OrganizationDisabledError,
            "session_rate_limited_error" => ErrorType.SessionRateLimitedError,
            "session_creation_rejected_error" => ErrorType.SessionCreationRejectedError,
            "unknown_error" => ErrorType.UnknownError,
            "self_hosted_resources_unsupported_error" =>
                ErrorType.SelfHostedResourcesUnsupportedError,
            "mcp_egress_blocked_error" => ErrorType.McpEgressBlockedError,
            _ => (ErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorType.EnvironmentArchivedError => "environment_archived_error",
                ErrorType.AgentArchivedError => "agent_archived_error",
                ErrorType.EnvironmentNotFoundError => "environment_not_found_error",
                ErrorType.VaultNotFoundError => "vault_not_found_error",
                ErrorType.VaultArchivedError => "vault_archived_error",
                ErrorType.FileNotFoundError => "file_not_found_error",
                ErrorType.MemoryStoreArchivedError => "memory_store_archived_error",
                ErrorType.SkillNotFoundError => "skill_not_found_error",
                ErrorType.SessionResourceNotFoundError => "session_resource_not_found_error",
                ErrorType.WorkspaceArchivedError => "workspace_archived_error",
                ErrorType.OrganizationDisabledError => "organization_disabled_error",
                ErrorType.SessionRateLimitedError => "session_rate_limited_error",
                ErrorType.SessionCreationRejectedError => "session_creation_rejected_error",
                ErrorType.UnknownError => "unknown_error",
                ErrorType.SelfHostedResourcesUnsupportedError =>
                    "self_hosted_resources_unsupported_error",
                ErrorType.McpEgressBlockedError => "mcp_egress_blocked_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
