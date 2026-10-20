using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Cover only the workspaces on the list.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationWorkspacesIncludeParams,
        BetaTelemetryDestinationWorkspacesIncludeParamsFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationWorkspacesIncludeParams : JsonModel
{
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
    /// The IDs of the workspaces on the destination's list (`wrkspc_...`). At most
    /// 100 per request.
    ///
    /// <para>On create, these workspaces become the destination's list. If you leave
    /// `workspace_ids` out, the list starts empty. If the API refuses one of the
    /// IDs, it doesn't create the destination.</para>
    ///
    /// <para>On update, `workspace_ids` replaces the whole list. A workspace that
    /// stays on the list keeps its entry and its `created_at`. An empty array empties
    /// the list. If you leave `workspace_ids` out and the type stays the same, the
    /// list doesn't change. If you leave it out and the type changes, the new list
    /// starts empty. After a change to `include` without `workspace_ids`, the destination
    /// doesn't cover any workspace until one is added. After a change to `exclude`
    /// without `workspace_ids`, it covers every workspace.</para>
    ///
    /// <para>An ID sent more than once is added once. An archived workspace can't
    /// be added to a list. An update can keep an archived workspace that is already
    /// on the list.</para>
    /// </summary>
    public IReadOnlyList<string>? WorkspaceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("workspace_ids");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("workspace_ids");
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "workspace_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("include")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceIds;
    }

    public BetaTelemetryDestinationWorkspacesIncludeParams()
    {
        this.Type = JsonSerializer.SerializeToElement("include");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationWorkspacesIncludeParams(
        BetaTelemetryDestinationWorkspacesIncludeParams betaTelemetryDestinationWorkspacesIncludeParams
    )
        : base(betaTelemetryDestinationWorkspacesIncludeParams) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationWorkspacesIncludeParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("include");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationWorkspacesIncludeParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationWorkspacesIncludeParamsFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationWorkspacesIncludeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationWorkspacesIncludeParamsFromRaw
    : IFromRawJson<BetaTelemetryDestinationWorkspacesIncludeParams>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationWorkspacesIncludeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationWorkspacesIncludeParams.FromRawUnchecked(rawData);
}
