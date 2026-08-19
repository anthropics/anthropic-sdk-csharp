using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A tab this call's execution opened that remains open at its end — the creation
/// delta of the `tabs` inventory, not an event log.
///
/// <para>Carries only the `tab_id`; the tab's `title` and `url` live on its `tabs`
/// entry, which must include the same `tab_id`. A tab opened during a failed call
/// gets no deferred `tab_opened`; it simply appears in the next result's `tabs` inventory.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaBrowserStateChangeTabOpened,
        BetaBrowserStateChangeTabOpenedFromRaw
    >)
)]
public sealed record class BetaBrowserStateChangeTabOpened : JsonModel
{
    /// <summary>
    /// The `tab_id` of the opened tab, present in `tabs`.
    /// </summary>
    public required string TabID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tab_id");
        }
        init { this._rawData.Set("tab_id", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TabID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tab_opened")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBrowserStateChangeTabOpened()
    {
        this.Type = JsonSerializer.SerializeToElement("tab_opened");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserStateChangeTabOpened(
        BetaBrowserStateChangeTabOpened betaBrowserStateChangeTabOpened
    )
        : base(betaBrowserStateChangeTabOpened) { }
#pragma warning restore CS8618

    public BetaBrowserStateChangeTabOpened(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tab_opened");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserStateChangeTabOpened(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserStateChangeTabOpenedFromRaw.FromRawUnchecked"/>
    public static BetaBrowserStateChangeTabOpened FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserStateChangeTabOpened(string tabID)
        : this()
    {
        this.TabID = tabID;
    }
}

class BetaBrowserStateChangeTabOpenedFromRaw : IFromRawJson<BetaBrowserStateChangeTabOpened>
{
    /// <inheritdoc/>
    public BetaBrowserStateChangeTabOpened FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserStateChangeTabOpened.FromRawUnchecked(rawData);
}
