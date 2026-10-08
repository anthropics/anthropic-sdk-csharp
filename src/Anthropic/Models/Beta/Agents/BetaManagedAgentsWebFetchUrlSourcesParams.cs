using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Which sources contribute URLs the web_fetch tool may fetch. When web_fetch is
/// limited to URLs the conversation has already shown the model (in a user message,
/// a custom tool's result, or an earlier web_search or web_fetch result), each key
/// narrows one of those sources and defaults to "all". Setting all three keys to
/// "none" is rejected.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWebFetchUrlSourcesParams,
        BetaManagedAgentsWebFetchUrlSourcesParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWebFetchUrlSourcesParams : JsonModel
{
    /// <summary>
    /// Which custom tools' results contribute URLs that may be fetched: "all" (the
    /// default), "none", or an only or except list. Each name in a list must be a
    /// custom tool in the same tools array.
    /// </summary>
    public BetaManagedAgentsWebFetchUrlSourceToolFilterParams? ClientToolResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsWebFetchUrlSourceToolFilterParams>(
                "client_tool_results"
            );
        }
        init { this._rawData.Set("client_tool_results", value); }
    }

    /// <summary>
    /// Which of the web_search and web_fetch tools' results contribute URLs that
    /// may be fetched: "all" (the default), "none", or an only or except list. Each
    /// name in a list must be "web_search" or "web_fetch".
    /// </summary>
    public BetaManagedAgentsWebFetchUrlSourceToolFilterParams? ServerToolResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsWebFetchUrlSourceToolFilterParams>(
                "server_tool_results"
            );
        }
        init { this._rawData.Set("server_tool_results", value); }
    }

    /// <summary>
    /// Whether URLs in the text of user messages may be fetched: "all" (the default)
    /// or "none".
    /// </summary>
    public BetaManagedAgentsWebFetchUrlSourceUserInputParams? UserInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsWebFetchUrlSourceUserInputParams>(
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

    public BetaManagedAgentsWebFetchUrlSourcesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourcesParams(
        BetaManagedAgentsWebFetchUrlSourcesParams betaManagedAgentsWebFetchUrlSourcesParams
    )
        : base(betaManagedAgentsWebFetchUrlSourcesParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWebFetchUrlSourcesParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWebFetchUrlSourcesParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWebFetchUrlSourcesParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWebFetchUrlSourcesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWebFetchUrlSourcesParamsFromRaw
    : IFromRawJson<BetaManagedAgentsWebFetchUrlSourcesParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWebFetchUrlSourcesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWebFetchUrlSourcesParams.FromRawUnchecked(rawData);
}
