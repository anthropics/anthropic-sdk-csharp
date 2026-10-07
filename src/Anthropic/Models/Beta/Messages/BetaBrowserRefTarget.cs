using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// An element on the page, identified by a reference from a prior `read_page` or
/// `find` result. References are scoped to the tab that produced them and become
/// stale after navigation or a major re-render.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserRefTarget, BetaBrowserRefTargetFromRaw>))]
public sealed record class BetaBrowserRefTarget : JsonModel
{
    /// <summary>
    /// An element reference (e.g. "ref_7") returned by a prior `read_page` or `find` result.
    /// </summary>
    public required string Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
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
        _ = this.Ref;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("ref")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBrowserRefTarget()
    {
        this.Type = JsonSerializer.SerializeToElement("ref");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserRefTarget(BetaBrowserRefTarget betaBrowserRefTarget)
        : base(betaBrowserRefTarget) { }
#pragma warning restore CS8618

    public BetaBrowserRefTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("ref");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserRefTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserRefTargetFromRaw.FromRawUnchecked"/>
    public static BetaBrowserRefTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserRefTarget(string ref_)
        : this()
    {
        this.Ref = ref_;
    }
}

class BetaBrowserRefTargetFromRaw : IFromRawJson<BetaBrowserRefTarget>
{
    /// <inheritdoc/>
    public BetaBrowserRefTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserRefTarget.FromRawUnchecked(rawData);
}
