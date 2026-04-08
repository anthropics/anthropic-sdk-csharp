using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Limited network access.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaLimitedNetwork, BetaLimitedNetworkFromRaw>))]
public sealed record class BetaLimitedNetwork : JsonModel
{
    /// <summary>
    /// Permits outbound access to MCP server endpoints configured on the agent, beyond
    /// those listed in the `allowed_hosts` array.
    /// </summary>
    public required bool AllowMcpServers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allow_mcp_servers");
        }
        init { this._rawData.Set("allow_mcp_servers", value); }
    }

    /// <summary>
    /// Permits outbound access to public package registries (PyPI, npm, etc.) beyond
    /// those listed in the `allowed_hosts` array.
    /// </summary>
    public required bool AllowPackageManagers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allow_package_managers");
        }
        init { this._rawData.Set("allow_package_managers", value); }
    }

    /// <summary>
    /// Specifies domains the container can reach.
    /// </summary>
    public required IReadOnlyList<string> AllowedHosts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("allowed_hosts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "allowed_hosts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Network policy type
    /// </summary>
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
        _ = this.AllowMcpServers;
        _ = this.AllowPackageManagers;
        _ = this.AllowedHosts;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("limited")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaLimitedNetwork()
    {
        this.Type = JsonSerializer.SerializeToElement("limited");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaLimitedNetwork(BetaLimitedNetwork betaLimitedNetwork)
        : base(betaLimitedNetwork) { }
#pragma warning restore CS8618

    public BetaLimitedNetwork(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("limited");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaLimitedNetwork(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaLimitedNetworkFromRaw.FromRawUnchecked"/>
    public static BetaLimitedNetwork FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaLimitedNetworkFromRaw : IFromRawJson<BetaLimitedNetwork>
{
    /// <inheritdoc/>
    public BetaLimitedNetwork FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaLimitedNetwork.FromRawUnchecked(rawData);
}
