using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The destination covers every workspace of the organization except the workspaces
/// on its list. A workspace created later is covered until it is added to the list.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationWorkspacesExclude,
        BetaTelemetryDestinationWorkspacesExcludeFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationWorkspacesExclude : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("exclude")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationWorkspacesExclude()
    {
        this.Type = JsonSerializer.SerializeToElement("exclude");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationWorkspacesExclude(
        BetaTelemetryDestinationWorkspacesExclude betaTelemetryDestinationWorkspacesExclude
    )
        : base(betaTelemetryDestinationWorkspacesExclude) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationWorkspacesExclude(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("exclude");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationWorkspacesExclude(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationWorkspacesExcludeFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationWorkspacesExclude FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationWorkspacesExcludeFromRaw
    : IFromRawJson<BetaTelemetryDestinationWorkspacesExclude>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationWorkspacesExclude FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationWorkspacesExclude.FromRawUnchecked(rawData);
}
