using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// The failing step of an MCP validation probe.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsMcpProbe, BetaManagedAgentsMcpProbeFromRaw>)
)]
public sealed record class BetaManagedAgentsMcpProbe : JsonModel
{
    /// <summary>
    /// An HTTP response captured during a credential validation probe.
    /// </summary>
    public required BetaManagedAgentsRefreshHttpResponse? HttpResponse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsRefreshHttpResponse>(
                "http_response"
            );
        }
        init { this._rawData.Set("http_response", value); }
    }

    /// <summary>
    /// The MCP method that failed (for example `initialize` or `tools/list`).
    /// </summary>
    public required string Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.HttpResponse?.Validate();
        _ = this.Method;
    }

    public BetaManagedAgentsMcpProbe() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpProbe(BetaManagedAgentsMcpProbe betaManagedAgentsMcpProbe)
        : base(betaManagedAgentsMcpProbe) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpProbe(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpProbe(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpProbeFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpProbe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpProbeFromRaw : IFromRawJson<BetaManagedAgentsMcpProbe>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpProbe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpProbe.FromRawUnchecked(rawData);
}
