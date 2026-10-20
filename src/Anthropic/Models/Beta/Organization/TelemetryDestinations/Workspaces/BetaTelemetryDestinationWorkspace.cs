using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations.Workspaces;

/// <summary>
/// A workspace on a telemetry destination's workspace list.
///
/// <para>Under `include`, the destination covers the workspace. Under `exclude`,
/// the destination covers every workspace except this one. The entry doesn't have
/// an `id`. Its `telemetry_destination_id` and `workspace_id` together identify it.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationWorkspace,
        BetaTelemetryDestinationWorkspaceFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationWorkspace : JsonModel
{
    /// <summary>
    /// Time the workspace was added to the list.
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
    /// ID of the workspace (`wrkspc_...`).
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
        _ = this.CreatedAt;
        _ = this.TelemetryDestinationID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("telemetry_destination_workspace")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaTelemetryDestinationWorkspace()
    {
        this.Type = JsonSerializer.SerializeToElement("telemetry_destination_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationWorkspace(
        BetaTelemetryDestinationWorkspace betaTelemetryDestinationWorkspace
    )
        : base(betaTelemetryDestinationWorkspace) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationWorkspace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("telemetry_destination_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationWorkspace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationWorkspaceFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationWorkspace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationWorkspaceFromRaw : IFromRawJson<BetaTelemetryDestinationWorkspace>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationWorkspace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationWorkspace.FromRawUnchecked(rawData);
}
