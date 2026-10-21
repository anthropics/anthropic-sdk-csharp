using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Which sources contribute URLs the web_fetch tool may fetch. A key that is null
/// was not set and allows every URL from that source.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWebFetchUrlSources,
        BetaManagedAgentsWebFetchUrlSourcesFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWebFetchUrlSources : JsonModel
{
    /// <summary>
    /// Which custom tools' results contribute URLs that may be fetched. Null when
    /// not set, which allows every custom tool's results.
    /// </summary>
    public required BetaManagedAgentsWebFetchUrlSourceToolFilter? ClientToolResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsWebFetchUrlSourceToolFilter>(
                "client_tool_results"
            );
        }
        init { this._rawData.Set("client_tool_results", value); }
    }

    /// <summary>
    /// Which of the web_search and web_fetch tools' results contribute URLs that
    /// may be fetched. Null when not set, which allows both.
    /// </summary>
    public required BetaManagedAgentsWebFetchUrlSourceToolFilter? ServerToolResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsWebFetchUrlSourceToolFilter>(
                "server_tool_results"
            );
        }
        init { this._rawData.Set("server_tool_results", value); }
    }

    /// <summary>
    /// Whether URLs in the text of user messages may be fetched. Null when not set,
    /// which allows them.
    /// </summary>
    public required BetaManagedAgentsWebFetchUrlSourceUserInput? UserInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsWebFetchUrlSourceUserInput>(
                "user_input"
            );
        }
        init { this._rawData.Set("user_input", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ClientToolResults?.Validate();
        this.ServerToolResults?.Validate();
        this.UserInput?.Validate();
    }

    public BetaManagedAgentsWebFetchUrlSources() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSources(
        BetaManagedAgentsWebFetchUrlSources betaManagedAgentsWebFetchUrlSources
    )
        : base(betaManagedAgentsWebFetchUrlSources) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWebFetchUrlSources(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWebFetchUrlSources(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWebFetchUrlSourcesFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWebFetchUrlSources FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWebFetchUrlSourcesFromRaw : IFromRawJson<BetaManagedAgentsWebFetchUrlSources>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWebFetchUrlSources FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWebFetchUrlSources.FromRawUnchecked(rawData);
}
