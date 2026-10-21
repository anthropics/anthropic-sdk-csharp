using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The destination covers the workspaces on its list, and no others.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationWorkspacesInclude,
        BetaTelemetryDestinationWorkspacesIncludeFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationWorkspacesInclude : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("include")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationWorkspacesInclude()
    {
        this.Type = JsonSerializer.SerializeToElement("include");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationWorkspacesInclude(
        BetaTelemetryDestinationWorkspacesInclude betaTelemetryDestinationWorkspacesInclude
    )
        : base(betaTelemetryDestinationWorkspacesInclude) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationWorkspacesInclude(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("include");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationWorkspacesInclude(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationWorkspacesIncludeFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationWorkspacesInclude FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationWorkspacesIncludeFromRaw
    : IFromRawJson<BetaTelemetryDestinationWorkspacesInclude>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationWorkspacesInclude FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationWorkspacesInclude.FromRawUnchecked(rawData);
}
