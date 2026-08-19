using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The caller's browser state after a browser toolset member call — the full inventory
/// of open tabs, which tab is active, and any side effects (tabs opened, download
/// state changes) the call produced.
///
/// <para>At most one per `tool_result`, only on a non-error result answering a browser
/// toolset member `tool_use`. The server renders the model-visible text from it;
/// the model never sees the raw fields.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserStateBlockParam, BetaBrowserStateBlockParamFromRaw>)
)]
public sealed record class BetaBrowserStateBlockParam : JsonModel
{
    /// <summary>
    /// All tabs open in the browser after this call — the full inventory, not a delta.
    /// May be empty. Whenever non-empty, exactly one entry carries `active: true`.
    /// </summary>
    public required IReadOnlyList<BetaBrowserStateTabEntry> Tabs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaBrowserStateTabEntry>>("tabs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaBrowserStateTabEntry>>(
                "tabs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// Tabs opened and download state changes during this call. "Nothing to report"
    /// is expressed by omitting the field, never by an empty list.
    /// </summary>
    public IReadOnlyList<BetaBrowserStateChange>? StateChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaBrowserStateChange>>(
                "state_changes"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaBrowserStateChange>?>(
                "state_changes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tabs)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("browser_state")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        foreach (var item in this.StateChanges ?? [])
        {
            item.Validate();
        }
    }

    public BetaBrowserStateBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("browser_state");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserStateBlockParam(BetaBrowserStateBlockParam betaBrowserStateBlockParam)
        : base(betaBrowserStateBlockParam) { }
#pragma warning restore CS8618

    public BetaBrowserStateBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("browser_state");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserStateBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserStateBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaBrowserStateBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserStateBlockParam(IReadOnlyList<BetaBrowserStateTabEntry> tabs)
        : this()
    {
        this.Tabs = tabs;
    }
}

class BetaBrowserStateBlockParamFromRaw : IFromRawJson<BetaBrowserStateBlockParam>
{
    /// <inheritdoc/>
    public BetaBrowserStateBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserStateBlockParam.FromRawUnchecked(rawData);
}
