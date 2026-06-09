using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// The deployment's workspace was archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError,
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError(
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError betaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError
    )
        : base(betaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorTypeConverter))]
public enum BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType
{
    WorkspaceArchivedError,
}

sealed class BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "workspace_archived_error" =>
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError,
            _ => (BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError =>
                    "workspace_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
