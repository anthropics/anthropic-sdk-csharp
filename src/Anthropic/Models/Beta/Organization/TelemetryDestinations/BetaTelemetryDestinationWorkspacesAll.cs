using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The destination covers every workspace of the organization, including the default
/// workspace, archived workspaces, and workspaces created later. It doesn't have
/// a list.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationWorkspacesAll,
        BetaTelemetryDestinationWorkspacesAllFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationWorkspacesAll : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("all")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationWorkspacesAll()
    {
        this.Type = JsonSerializer.SerializeToElement("all");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationWorkspacesAll(
        BetaTelemetryDestinationWorkspacesAll betaTelemetryDestinationWorkspacesAll
    )
        : base(betaTelemetryDestinationWorkspacesAll) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationWorkspacesAll(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("all");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationWorkspacesAll(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationWorkspacesAllFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationWorkspacesAll FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationWorkspacesAllFromRaw
    : IFromRawJson<BetaTelemetryDestinationWorkspacesAll>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationWorkspacesAll FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationWorkspacesAll.FromRawUnchecked(rawData);
}
