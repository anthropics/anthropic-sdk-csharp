using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Cover every workspace of the organization. Doesn't take `workspace_ids`.
///
/// <para>An update that sets `all` empties the destination's workspace list.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationWorkspacesAllParams,
        BetaTelemetryDestinationWorkspacesAllParamsFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationWorkspacesAllParams : JsonModel
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

    public BetaTelemetryDestinationWorkspacesAllParams()
    {
        this.Type = JsonSerializer.SerializeToElement("all");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationWorkspacesAllParams(
        BetaTelemetryDestinationWorkspacesAllParams betaTelemetryDestinationWorkspacesAllParams
    )
        : base(betaTelemetryDestinationWorkspacesAllParams) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationWorkspacesAllParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("all");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationWorkspacesAllParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationWorkspacesAllParamsFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationWorkspacesAllParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationWorkspacesAllParamsFromRaw
    : IFromRawJson<BetaTelemetryDestinationWorkspacesAllParams>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationWorkspacesAllParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationWorkspacesAllParams.FromRawUnchecked(rawData);
}
