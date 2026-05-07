using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Webhooks;

[JsonConverter(typeof(BetaWebhookEventDataConverter))]
public record class BetaWebhookEventData : ModelBase
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

    public string ID
    {
        get
        {
            return Match(
                sessionCreated: (x) => x.ID,
                sessionPending: (x) => x.ID,
                sessionRunning: (x) => x.ID,
                sessionIdled: (x) => x.ID,
                sessionRequiresAction: (x) => x.ID,
                sessionArchived: (x) => x.ID,
                sessionDeleted: (x) => x.ID,
                sessionStatusRescheduled: (x) => x.ID,
                sessionStatusRunStarted: (x) => x.ID,
                sessionStatusIdled: (x) => x.ID,
                sessionStatusTerminated: (x) => x.ID,
                sessionThreadCreated: (x) => x.ID,
                sessionThreadIdled: (x) => x.ID,
                sessionThreadTerminated: (x) => x.ID,
                sessionOutcomeEvaluationEnded: (x) => x.ID,
                vaultCreated: (x) => x.ID,
                vaultArchived: (x) => x.ID,
                vaultDeleted: (x) => x.ID,
                vaultCredentialCreated: (x) => x.ID,
                vaultCredentialArchived: (x) => x.ID,
                vaultCredentialDeleted: (x) => x.ID,
                vaultCredentialRefreshFailed: (x) => x.ID
            );
        }
    }

    public string OrganizationID
    {
        get
        {
            return Match(
                sessionCreated: (x) => x.OrganizationID,
                sessionPending: (x) => x.OrganizationID,
                sessionRunning: (x) => x.OrganizationID,
                sessionIdled: (x) => x.OrganizationID,
                sessionRequiresAction: (x) => x.OrganizationID,
                sessionArchived: (x) => x.OrganizationID,
                sessionDeleted: (x) => x.OrganizationID,
                sessionStatusRescheduled: (x) => x.OrganizationID,
                sessionStatusRunStarted: (x) => x.OrganizationID,
                sessionStatusIdled: (x) => x.OrganizationID,
                sessionStatusTerminated: (x) => x.OrganizationID,
                sessionThreadCreated: (x) => x.OrganizationID,
                sessionThreadIdled: (x) => x.OrganizationID,
                sessionThreadTerminated: (x) => x.OrganizationID,
                sessionOutcomeEvaluationEnded: (x) => x.OrganizationID,
                vaultCreated: (x) => x.OrganizationID,
                vaultArchived: (x) => x.OrganizationID,
                vaultDeleted: (x) => x.OrganizationID,
                vaultCredentialCreated: (x) => x.OrganizationID,
                vaultCredentialArchived: (x) => x.OrganizationID,
                vaultCredentialDeleted: (x) => x.OrganizationID,
                vaultCredentialRefreshFailed: (x) => x.OrganizationID
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                sessionCreated: (x) => x.Type,
                sessionPending: (x) => x.Type,
                sessionRunning: (x) => x.Type,
                sessionIdled: (x) => x.Type,
                sessionRequiresAction: (x) => x.Type,
                sessionArchived: (x) => x.Type,
                sessionDeleted: (x) => x.Type,
                sessionStatusRescheduled: (x) => x.Type,
                sessionStatusRunStarted: (x) => x.Type,
                sessionStatusIdled: (x) => x.Type,
                sessionStatusTerminated: (x) => x.Type,
                sessionThreadCreated: (x) => x.Type,
                sessionThreadIdled: (x) => x.Type,
                sessionThreadTerminated: (x) => x.Type,
                sessionOutcomeEvaluationEnded: (x) => x.Type,
                vaultCreated: (x) => x.Type,
                vaultArchived: (x) => x.Type,
                vaultDeleted: (x) => x.Type,
                vaultCredentialCreated: (x) => x.Type,
                vaultCredentialArchived: (x) => x.Type,
                vaultCredentialDeleted: (x) => x.Type,
                vaultCredentialRefreshFailed: (x) => x.Type
            );
        }
    }

    public string WorkspaceID
    {
        get
        {
            return Match(
                sessionCreated: (x) => x.WorkspaceID,
                sessionPending: (x) => x.WorkspaceID,
                sessionRunning: (x) => x.WorkspaceID,
                sessionIdled: (x) => x.WorkspaceID,
                sessionRequiresAction: (x) => x.WorkspaceID,
                sessionArchived: (x) => x.WorkspaceID,
                sessionDeleted: (x) => x.WorkspaceID,
                sessionStatusRescheduled: (x) => x.WorkspaceID,
                sessionStatusRunStarted: (x) => x.WorkspaceID,
                sessionStatusIdled: (x) => x.WorkspaceID,
                sessionStatusTerminated: (x) => x.WorkspaceID,
                sessionThreadCreated: (x) => x.WorkspaceID,
                sessionThreadIdled: (x) => x.WorkspaceID,
                sessionThreadTerminated: (x) => x.WorkspaceID,
                sessionOutcomeEvaluationEnded: (x) => x.WorkspaceID,
                vaultCreated: (x) => x.WorkspaceID,
                vaultArchived: (x) => x.WorkspaceID,
                vaultDeleted: (x) => x.WorkspaceID,
                vaultCredentialCreated: (x) => x.WorkspaceID,
                vaultCredentialArchived: (x) => x.WorkspaceID,
                vaultCredentialDeleted: (x) => x.WorkspaceID,
                vaultCredentialRefreshFailed: (x) => x.WorkspaceID
            );
        }
    }

    public string? VaultID
    {
        get
        {
            return Match<string?>(
                sessionCreated: (_) => null,
                sessionPending: (_) => null,
                sessionRunning: (_) => null,
                sessionIdled: (_) => null,
                sessionRequiresAction: (_) => null,
                sessionArchived: (_) => null,
                sessionDeleted: (_) => null,
                sessionStatusRescheduled: (_) => null,
                sessionStatusRunStarted: (_) => null,
                sessionStatusIdled: (_) => null,
                sessionStatusTerminated: (_) => null,
                sessionThreadCreated: (_) => null,
                sessionThreadIdled: (_) => null,
                sessionThreadTerminated: (_) => null,
                sessionOutcomeEvaluationEnded: (_) => null,
                vaultCreated: (_) => null,
                vaultArchived: (_) => null,
                vaultDeleted: (_) => null,
                vaultCredentialCreated: (x) => x.VaultID,
                vaultCredentialArchived: (x) => x.VaultID,
                vaultCredentialDeleted: (x) => x.VaultID,
                vaultCredentialRefreshFailed: (x) => x.VaultID
            );
        }
    }

    public BetaWebhookEventData(
        BetaWebhookSessionCreatedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionPendingEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionRunningEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(BetaWebhookSessionIdledEventData value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionRequiresActionEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionArchivedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionDeletedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionStatusRescheduledEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionStatusRunStartedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionStatusIdledEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionStatusTerminatedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionThreadCreatedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionThreadIdledEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionThreadTerminatedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookSessionOutcomeEvaluationEndedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(BetaWebhookVaultCreatedEventData value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookVaultArchivedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(BetaWebhookVaultDeletedEventData value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookVaultCredentialCreatedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookVaultCredentialArchivedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookVaultCredentialDeletedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(
        BetaWebhookVaultCredentialRefreshFailedEventData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebhookEventData(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionCreatedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionCreated(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionCreatedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionCreated(
        [NotNullWhen(true)] out BetaWebhookSessionCreatedEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionCreatedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionPendingEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionPending(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionPendingEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionPending(
        [NotNullWhen(true)] out BetaWebhookSessionPendingEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionPendingEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionRunningEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionRunning(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionRunningEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionRunning(
        [NotNullWhen(true)] out BetaWebhookSessionRunningEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionRunningEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionIdledEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionIdled(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionIdledEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionIdled([NotNullWhen(true)] out BetaWebhookSessionIdledEventData? value)
    {
        value = this.Value as BetaWebhookSessionIdledEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionRequiresActionEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionRequiresAction(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionRequiresActionEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionRequiresAction(
        [NotNullWhen(true)] out BetaWebhookSessionRequiresActionEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionRequiresActionEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionArchivedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionArchived(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionArchivedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionArchived(
        [NotNullWhen(true)] out BetaWebhookSessionArchivedEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionArchivedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionDeletedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionDeleted(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionDeletedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionDeleted(
        [NotNullWhen(true)] out BetaWebhookSessionDeletedEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionDeletedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionStatusRescheduledEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionStatusRescheduled(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionStatusRescheduledEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionStatusRescheduled(
        [NotNullWhen(true)] out BetaWebhookSessionStatusRescheduledEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionStatusRescheduledEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionStatusRunStartedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionStatusRunStarted(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionStatusRunStartedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionStatusRunStarted(
        [NotNullWhen(true)] out BetaWebhookSessionStatusRunStartedEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionStatusRunStartedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionStatusIdledEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionStatusIdled(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionStatusIdledEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionStatusIdled(
        [NotNullWhen(true)] out BetaWebhookSessionStatusIdledEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionStatusIdledEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionStatusTerminatedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionStatusTerminated(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionStatusTerminatedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionStatusTerminated(
        [NotNullWhen(true)] out BetaWebhookSessionStatusTerminatedEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionStatusTerminatedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionThreadCreatedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionThreadCreated(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionThreadCreatedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionThreadCreated(
        [NotNullWhen(true)] out BetaWebhookSessionThreadCreatedEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionThreadCreatedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionThreadIdledEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionThreadIdled(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionThreadIdledEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionThreadIdled(
        [NotNullWhen(true)] out BetaWebhookSessionThreadIdledEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionThreadIdledEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionThreadTerminatedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionThreadTerminated(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionThreadTerminatedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionThreadTerminated(
        [NotNullWhen(true)] out BetaWebhookSessionThreadTerminatedEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionThreadTerminatedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookSessionOutcomeEvaluationEndedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionOutcomeEvaluationEnded(out var value)) {
    ///     // `value` is of type `BetaWebhookSessionOutcomeEvaluationEndedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionOutcomeEvaluationEnded(
        [NotNullWhen(true)] out BetaWebhookSessionOutcomeEvaluationEndedEventData? value
    )
    {
        value = this.Value as BetaWebhookSessionOutcomeEvaluationEndedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookVaultCreatedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultCreated(out var value)) {
    ///     // `value` is of type `BetaWebhookVaultCreatedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultCreated([NotNullWhen(true)] out BetaWebhookVaultCreatedEventData? value)
    {
        value = this.Value as BetaWebhookVaultCreatedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookVaultArchivedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultArchived(out var value)) {
    ///     // `value` is of type `BetaWebhookVaultArchivedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultArchived(
        [NotNullWhen(true)] out BetaWebhookVaultArchivedEventData? value
    )
    {
        value = this.Value as BetaWebhookVaultArchivedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookVaultDeletedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultDeleted(out var value)) {
    ///     // `value` is of type `BetaWebhookVaultDeletedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultDeleted([NotNullWhen(true)] out BetaWebhookVaultDeletedEventData? value)
    {
        value = this.Value as BetaWebhookVaultDeletedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookVaultCredentialCreatedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultCredentialCreated(out var value)) {
    ///     // `value` is of type `BetaWebhookVaultCredentialCreatedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultCredentialCreated(
        [NotNullWhen(true)] out BetaWebhookVaultCredentialCreatedEventData? value
    )
    {
        value = this.Value as BetaWebhookVaultCredentialCreatedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookVaultCredentialArchivedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultCredentialArchived(out var value)) {
    ///     // `value` is of type `BetaWebhookVaultCredentialArchivedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultCredentialArchived(
        [NotNullWhen(true)] out BetaWebhookVaultCredentialArchivedEventData? value
    )
    {
        value = this.Value as BetaWebhookVaultCredentialArchivedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookVaultCredentialDeletedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultCredentialDeleted(out var value)) {
    ///     // `value` is of type `BetaWebhookVaultCredentialDeletedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultCredentialDeleted(
        [NotNullWhen(true)] out BetaWebhookVaultCredentialDeletedEventData? value
    )
    {
        value = this.Value as BetaWebhookVaultCredentialDeletedEventData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebhookVaultCredentialRefreshFailedEventData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultCredentialRefreshFailed(out var value)) {
    ///     // `value` is of type `BetaWebhookVaultCredentialRefreshFailedEventData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultCredentialRefreshFailed(
        [NotNullWhen(true)] out BetaWebhookVaultCredentialRefreshFailedEventData? value
    )
    {
        value = this.Value as BetaWebhookVaultCredentialRefreshFailedEventData;
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
    ///     (BetaWebhookSessionCreatedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionPendingEventData value) =&gt; {...},
    ///     (BetaWebhookSessionRunningEventData value) =&gt; {...},
    ///     (BetaWebhookSessionIdledEventData value) =&gt; {...},
    ///     (BetaWebhookSessionRequiresActionEventData value) =&gt; {...},
    ///     (BetaWebhookSessionArchivedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionDeletedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionStatusRescheduledEventData value) =&gt; {...},
    ///     (BetaWebhookSessionStatusRunStartedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionStatusIdledEventData value) =&gt; {...},
    ///     (BetaWebhookSessionStatusTerminatedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionThreadCreatedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionThreadIdledEventData value) =&gt; {...},
    ///     (BetaWebhookSessionThreadTerminatedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionOutcomeEvaluationEndedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCreatedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultArchivedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultDeletedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCredentialCreatedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCredentialArchivedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCredentialDeletedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCredentialRefreshFailedEventData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaWebhookSessionCreatedEventData> sessionCreated,
        Action<BetaWebhookSessionPendingEventData> sessionPending,
        Action<BetaWebhookSessionRunningEventData> sessionRunning,
        Action<BetaWebhookSessionIdledEventData> sessionIdled,
        Action<BetaWebhookSessionRequiresActionEventData> sessionRequiresAction,
        Action<BetaWebhookSessionArchivedEventData> sessionArchived,
        Action<BetaWebhookSessionDeletedEventData> sessionDeleted,
        Action<BetaWebhookSessionStatusRescheduledEventData> sessionStatusRescheduled,
        Action<BetaWebhookSessionStatusRunStartedEventData> sessionStatusRunStarted,
        Action<BetaWebhookSessionStatusIdledEventData> sessionStatusIdled,
        Action<BetaWebhookSessionStatusTerminatedEventData> sessionStatusTerminated,
        Action<BetaWebhookSessionThreadCreatedEventData> sessionThreadCreated,
        Action<BetaWebhookSessionThreadIdledEventData> sessionThreadIdled,
        Action<BetaWebhookSessionThreadTerminatedEventData> sessionThreadTerminated,
        Action<BetaWebhookSessionOutcomeEvaluationEndedEventData> sessionOutcomeEvaluationEnded,
        Action<BetaWebhookVaultCreatedEventData> vaultCreated,
        Action<BetaWebhookVaultArchivedEventData> vaultArchived,
        Action<BetaWebhookVaultDeletedEventData> vaultDeleted,
        Action<BetaWebhookVaultCredentialCreatedEventData> vaultCredentialCreated,
        Action<BetaWebhookVaultCredentialArchivedEventData> vaultCredentialArchived,
        Action<BetaWebhookVaultCredentialDeletedEventData> vaultCredentialDeleted,
        Action<BetaWebhookVaultCredentialRefreshFailedEventData> vaultCredentialRefreshFailed
    )
    {
        switch (this.Value)
        {
            case BetaWebhookSessionCreatedEventData value:
                sessionCreated(value);
                break;
            case BetaWebhookSessionPendingEventData value:
                sessionPending(value);
                break;
            case BetaWebhookSessionRunningEventData value:
                sessionRunning(value);
                break;
            case BetaWebhookSessionIdledEventData value:
                sessionIdled(value);
                break;
            case BetaWebhookSessionRequiresActionEventData value:
                sessionRequiresAction(value);
                break;
            case BetaWebhookSessionArchivedEventData value:
                sessionArchived(value);
                break;
            case BetaWebhookSessionDeletedEventData value:
                sessionDeleted(value);
                break;
            case BetaWebhookSessionStatusRescheduledEventData value:
                sessionStatusRescheduled(value);
                break;
            case BetaWebhookSessionStatusRunStartedEventData value:
                sessionStatusRunStarted(value);
                break;
            case BetaWebhookSessionStatusIdledEventData value:
                sessionStatusIdled(value);
                break;
            case BetaWebhookSessionStatusTerminatedEventData value:
                sessionStatusTerminated(value);
                break;
            case BetaWebhookSessionThreadCreatedEventData value:
                sessionThreadCreated(value);
                break;
            case BetaWebhookSessionThreadIdledEventData value:
                sessionThreadIdled(value);
                break;
            case BetaWebhookSessionThreadTerminatedEventData value:
                sessionThreadTerminated(value);
                break;
            case BetaWebhookSessionOutcomeEvaluationEndedEventData value:
                sessionOutcomeEvaluationEnded(value);
                break;
            case BetaWebhookVaultCreatedEventData value:
                vaultCreated(value);
                break;
            case BetaWebhookVaultArchivedEventData value:
                vaultArchived(value);
                break;
            case BetaWebhookVaultDeletedEventData value:
                vaultDeleted(value);
                break;
            case BetaWebhookVaultCredentialCreatedEventData value:
                vaultCredentialCreated(value);
                break;
            case BetaWebhookVaultCredentialArchivedEventData value:
                vaultCredentialArchived(value);
                break;
            case BetaWebhookVaultCredentialDeletedEventData value:
                vaultCredentialDeleted(value);
                break;
            case BetaWebhookVaultCredentialRefreshFailedEventData value:
                vaultCredentialRefreshFailed(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebhookEventData"
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
    ///     (BetaWebhookSessionCreatedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionPendingEventData value) =&gt; {...},
    ///     (BetaWebhookSessionRunningEventData value) =&gt; {...},
    ///     (BetaWebhookSessionIdledEventData value) =&gt; {...},
    ///     (BetaWebhookSessionRequiresActionEventData value) =&gt; {...},
    ///     (BetaWebhookSessionArchivedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionDeletedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionStatusRescheduledEventData value) =&gt; {...},
    ///     (BetaWebhookSessionStatusRunStartedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionStatusIdledEventData value) =&gt; {...},
    ///     (BetaWebhookSessionStatusTerminatedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionThreadCreatedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionThreadIdledEventData value) =&gt; {...},
    ///     (BetaWebhookSessionThreadTerminatedEventData value) =&gt; {...},
    ///     (BetaWebhookSessionOutcomeEvaluationEndedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCreatedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultArchivedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultDeletedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCredentialCreatedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCredentialArchivedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCredentialDeletedEventData value) =&gt; {...},
    ///     (BetaWebhookVaultCredentialRefreshFailedEventData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaWebhookSessionCreatedEventData, T> sessionCreated,
        Func<BetaWebhookSessionPendingEventData, T> sessionPending,
        Func<BetaWebhookSessionRunningEventData, T> sessionRunning,
        Func<BetaWebhookSessionIdledEventData, T> sessionIdled,
        Func<BetaWebhookSessionRequiresActionEventData, T> sessionRequiresAction,
        Func<BetaWebhookSessionArchivedEventData, T> sessionArchived,
        Func<BetaWebhookSessionDeletedEventData, T> sessionDeleted,
        Func<BetaWebhookSessionStatusRescheduledEventData, T> sessionStatusRescheduled,
        Func<BetaWebhookSessionStatusRunStartedEventData, T> sessionStatusRunStarted,
        Func<BetaWebhookSessionStatusIdledEventData, T> sessionStatusIdled,
        Func<BetaWebhookSessionStatusTerminatedEventData, T> sessionStatusTerminated,
        Func<BetaWebhookSessionThreadCreatedEventData, T> sessionThreadCreated,
        Func<BetaWebhookSessionThreadIdledEventData, T> sessionThreadIdled,
        Func<BetaWebhookSessionThreadTerminatedEventData, T> sessionThreadTerminated,
        Func<BetaWebhookSessionOutcomeEvaluationEndedEventData, T> sessionOutcomeEvaluationEnded,
        Func<BetaWebhookVaultCreatedEventData, T> vaultCreated,
        Func<BetaWebhookVaultArchivedEventData, T> vaultArchived,
        Func<BetaWebhookVaultDeletedEventData, T> vaultDeleted,
        Func<BetaWebhookVaultCredentialCreatedEventData, T> vaultCredentialCreated,
        Func<BetaWebhookVaultCredentialArchivedEventData, T> vaultCredentialArchived,
        Func<BetaWebhookVaultCredentialDeletedEventData, T> vaultCredentialDeleted,
        Func<BetaWebhookVaultCredentialRefreshFailedEventData, T> vaultCredentialRefreshFailed
    )
    {
        return this.Value switch
        {
            BetaWebhookSessionCreatedEventData value => sessionCreated(value),
            BetaWebhookSessionPendingEventData value => sessionPending(value),
            BetaWebhookSessionRunningEventData value => sessionRunning(value),
            BetaWebhookSessionIdledEventData value => sessionIdled(value),
            BetaWebhookSessionRequiresActionEventData value => sessionRequiresAction(value),
            BetaWebhookSessionArchivedEventData value => sessionArchived(value),
            BetaWebhookSessionDeletedEventData value => sessionDeleted(value),
            BetaWebhookSessionStatusRescheduledEventData value => sessionStatusRescheduled(value),
            BetaWebhookSessionStatusRunStartedEventData value => sessionStatusRunStarted(value),
            BetaWebhookSessionStatusIdledEventData value => sessionStatusIdled(value),
            BetaWebhookSessionStatusTerminatedEventData value => sessionStatusTerminated(value),
            BetaWebhookSessionThreadCreatedEventData value => sessionThreadCreated(value),
            BetaWebhookSessionThreadIdledEventData value => sessionThreadIdled(value),
            BetaWebhookSessionThreadTerminatedEventData value => sessionThreadTerminated(value),
            BetaWebhookSessionOutcomeEvaluationEndedEventData value =>
                sessionOutcomeEvaluationEnded(value),
            BetaWebhookVaultCreatedEventData value => vaultCreated(value),
            BetaWebhookVaultArchivedEventData value => vaultArchived(value),
            BetaWebhookVaultDeletedEventData value => vaultDeleted(value),
            BetaWebhookVaultCredentialCreatedEventData value => vaultCredentialCreated(value),
            BetaWebhookVaultCredentialArchivedEventData value => vaultCredentialArchived(value),
            BetaWebhookVaultCredentialDeletedEventData value => vaultCredentialDeleted(value),
            BetaWebhookVaultCredentialRefreshFailedEventData value => vaultCredentialRefreshFailed(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebhookEventData"
            ),
        };
    }

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionCreatedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionPendingEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionRunningEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(BetaWebhookSessionIdledEventData value) =>
        new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionRequiresActionEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionArchivedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionDeletedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionStatusRescheduledEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionStatusRunStartedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionStatusIdledEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionStatusTerminatedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionThreadCreatedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionThreadIdledEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionThreadTerminatedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookSessionOutcomeEvaluationEndedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(BetaWebhookVaultCreatedEventData value) =>
        new(value);

    public static implicit operator BetaWebhookEventData(BetaWebhookVaultArchivedEventData value) =>
        new(value);

    public static implicit operator BetaWebhookEventData(BetaWebhookVaultDeletedEventData value) =>
        new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookVaultCredentialCreatedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookVaultCredentialArchivedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookVaultCredentialDeletedEventData value
    ) => new(value);

    public static implicit operator BetaWebhookEventData(
        BetaWebhookVaultCredentialRefreshFailedEventData value
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
                "Data did not match any variant of BetaWebhookEventData"
            );
        }
        this.Switch(
            (sessionCreated) => sessionCreated.Validate(),
            (sessionPending) => sessionPending.Validate(),
            (sessionRunning) => sessionRunning.Validate(),
            (sessionIdled) => sessionIdled.Validate(),
            (sessionRequiresAction) => sessionRequiresAction.Validate(),
            (sessionArchived) => sessionArchived.Validate(),
            (sessionDeleted) => sessionDeleted.Validate(),
            (sessionStatusRescheduled) => sessionStatusRescheduled.Validate(),
            (sessionStatusRunStarted) => sessionStatusRunStarted.Validate(),
            (sessionStatusIdled) => sessionStatusIdled.Validate(),
            (sessionStatusTerminated) => sessionStatusTerminated.Validate(),
            (sessionThreadCreated) => sessionThreadCreated.Validate(),
            (sessionThreadIdled) => sessionThreadIdled.Validate(),
            (sessionThreadTerminated) => sessionThreadTerminated.Validate(),
            (sessionOutcomeEvaluationEnded) => sessionOutcomeEvaluationEnded.Validate(),
            (vaultCreated) => vaultCreated.Validate(),
            (vaultArchived) => vaultArchived.Validate(),
            (vaultDeleted) => vaultDeleted.Validate(),
            (vaultCredentialCreated) => vaultCredentialCreated.Validate(),
            (vaultCredentialArchived) => vaultCredentialArchived.Validate(),
            (vaultCredentialDeleted) => vaultCredentialDeleted.Validate(),
            (vaultCredentialRefreshFailed) => vaultCredentialRefreshFailed.Validate()
        );
    }

    public virtual bool Equals(BetaWebhookEventData? other) =>
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
            BetaWebhookSessionCreatedEventData _ => 0,
            BetaWebhookSessionPendingEventData _ => 1,
            BetaWebhookSessionRunningEventData _ => 2,
            BetaWebhookSessionIdledEventData _ => 3,
            BetaWebhookSessionRequiresActionEventData _ => 4,
            BetaWebhookSessionArchivedEventData _ => 5,
            BetaWebhookSessionDeletedEventData _ => 6,
            BetaWebhookSessionStatusRescheduledEventData _ => 7,
            BetaWebhookSessionStatusRunStartedEventData _ => 8,
            BetaWebhookSessionStatusIdledEventData _ => 9,
            BetaWebhookSessionStatusTerminatedEventData _ => 10,
            BetaWebhookSessionThreadCreatedEventData _ => 11,
            BetaWebhookSessionThreadIdledEventData _ => 12,
            BetaWebhookSessionThreadTerminatedEventData _ => 13,
            BetaWebhookSessionOutcomeEvaluationEndedEventData _ => 14,
            BetaWebhookVaultCreatedEventData _ => 15,
            BetaWebhookVaultArchivedEventData _ => 16,
            BetaWebhookVaultDeletedEventData _ => 17,
            BetaWebhookVaultCredentialCreatedEventData _ => 18,
            BetaWebhookVaultCredentialArchivedEventData _ => 19,
            BetaWebhookVaultCredentialDeletedEventData _ => 20,
            BetaWebhookVaultCredentialRefreshFailedEventData _ => 21,
            _ => -1,
        };
    }
}

sealed class BetaWebhookEventDataConverter : JsonConverter<BetaWebhookEventData>
{
    public override BetaWebhookEventData? Read(
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
            case "session.created":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionCreatedEventData>(
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
            case "session.pending":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionPendingEventData>(
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
            case "session.running":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionRunningEventData>(
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
            case "session.idled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebhookSessionIdledEventData>(
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
            case "session.requires_action":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionRequiresActionEventData>(
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
            case "session.archived":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionArchivedEventData>(
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
            case "session.deleted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionDeletedEventData>(
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
            case "session.status_rescheduled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionStatusRescheduledEventData>(
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
            case "session.status_run_started":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionStatusRunStartedEventData>(
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
            case "session.status_idled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionStatusIdledEventData>(
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
            case "session.status_terminated":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionStatusTerminatedEventData>(
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
            case "session.thread_created":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionThreadCreatedEventData>(
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
            case "session.thread_idled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionThreadIdledEventData>(
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
            case "session.thread_terminated":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionThreadTerminatedEventData>(
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
            case "session.outcome_evaluation_ended":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookSessionOutcomeEvaluationEndedEventData>(
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
            case "vault.created":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebhookVaultCreatedEventData>(
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
            case "vault.archived":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookVaultArchivedEventData>(
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
            case "vault.deleted":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebhookVaultDeletedEventData>(
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
            case "vault_credential.created":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookVaultCredentialCreatedEventData>(
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
            case "vault_credential.archived":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookVaultCredentialArchivedEventData>(
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
            case "vault_credential.deleted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookVaultCredentialDeletedEventData>(
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
            case "vault_credential.refresh_failed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWebhookVaultCredentialRefreshFailedEventData>(
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
                return new BetaWebhookEventData(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebhookEventData value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
