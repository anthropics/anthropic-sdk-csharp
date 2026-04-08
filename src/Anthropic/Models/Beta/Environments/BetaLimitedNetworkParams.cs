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
/// Limited network request params.
///
/// <para>Fields default to null; on update, omitted fields preserve the existing value.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaLimitedNetworkParams, BetaLimitedNetworkParamsFromRaw>)
)]
public sealed record class BetaLimitedNetworkParams : JsonModel
{
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

    /// <summary>
    /// Permits outbound access to MCP server endpoints configured on the agent, beyond
    /// those listed in the `allowed_hosts` array. Defaults to `false`.
    /// </summary>
    public bool? AllowMcpServers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_mcp_servers");
        }
        init { this._rawData.Set("allow_mcp_servers", value); }
    }

    /// <summary>
    /// Permits outbound access to public package registries (PyPI, npm, etc.) beyond
    /// those listed in the `allowed_hosts` array. Defaults to `false`.
    /// </summary>
    public bool? AllowPackageManagers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allow_package_managers");
        }
        init { this._rawData.Set("allow_package_managers", value); }
    }

    /// <summary>
    /// Specifies domains the container can reach.
    /// </summary>
    public IReadOnlyList<string>? AllowedHosts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowed_hosts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_hosts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("limited")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.AllowMcpServers;
        _ = this.AllowPackageManagers;
        _ = this.AllowedHosts;
    }

    public BetaLimitedNetworkParams()
    {
        this.Type = JsonSerializer.SerializeToElement("limited");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaLimitedNetworkParams(BetaLimitedNetworkParams betaLimitedNetworkParams)
        : base(betaLimitedNetworkParams) { }
#pragma warning restore CS8618

    public BetaLimitedNetworkParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("limited");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaLimitedNetworkParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaLimitedNetworkParamsFromRaw.FromRawUnchecked"/>
    public static BetaLimitedNetworkParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaLimitedNetworkParamsFromRaw : IFromRawJson<BetaLimitedNetworkParams>
{
    /// <inheritdoc/>
    public BetaLimitedNetworkParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaLimitedNetworkParams.FromRawUnchecked(rawData);
}
