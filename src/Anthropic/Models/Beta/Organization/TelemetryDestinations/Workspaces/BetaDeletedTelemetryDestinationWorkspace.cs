using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations.Workspaces;

/// <summary>
/// Confirmation that a workspace was removed from a destination's list.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaDeletedTelemetryDestinationWorkspace,
        BetaDeletedTelemetryDestinationWorkspaceFromRaw
    >)
)]
public sealed record class BetaDeletedTelemetryDestinationWorkspace : JsonModel
{
    /// <summary>
    /// ID of the telemetry destination (`tdst_...`).
    /// </summary>
    public required string TelemetryDestinationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("telemetry_destination_id");
        }
        init { this._rawData.Set("telemetry_destination_id", value); }
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

    /// <summary>
    /// ID of the workspace that was removed (`wrkspc_...`).
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TelemetryDestinationID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("telemetry_destination_workspace_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaDeletedTelemetryDestinationWorkspace()
    {
        this.Type = JsonSerializer.SerializeToElement("telemetry_destination_workspace_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDeletedTelemetryDestinationWorkspace(
        BetaDeletedTelemetryDestinationWorkspace betaDeletedTelemetryDestinationWorkspace
    )
        : base(betaDeletedTelemetryDestinationWorkspace) { }
#pragma warning restore CS8618

    public BetaDeletedTelemetryDestinationWorkspace(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("telemetry_destination_workspace_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedTelemetryDestinationWorkspace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDeletedTelemetryDestinationWorkspaceFromRaw.FromRawUnchecked"/>
    public static BetaDeletedTelemetryDestinationWorkspace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDeletedTelemetryDestinationWorkspaceFromRaw
    : IFromRawJson<BetaDeletedTelemetryDestinationWorkspace>
{
    /// <inheritdoc/>
    public BetaDeletedTelemetryDestinationWorkspace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDeletedTelemetryDestinationWorkspace.FromRawUnchecked(rawData);
}
