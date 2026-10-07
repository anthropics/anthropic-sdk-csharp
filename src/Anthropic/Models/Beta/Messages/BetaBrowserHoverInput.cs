using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Move the cursor to a coordinate or element without clicking.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserHoverInput, BetaBrowserHoverInputFromRaw>))]
public sealed record class BetaBrowserHoverInput : JsonModel
{
    /// <summary>
    /// Where to act: either a viewport coordinate or an element reference.
    /// </summary>
    public required BetaBrowserClickTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserClickTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Tab to act on. Defaults to the active tab when omitted.
    /// </summary>
    public string? TabID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tab_id");
        }
        init { this._rawData.Set("tab_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Target.Validate();
        _ = this.TabID;
    }

    public BetaBrowserHoverInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserHoverInput(BetaBrowserHoverInput betaBrowserHoverInput)
        : base(betaBrowserHoverInput) { }
#pragma warning restore CS8618

    public BetaBrowserHoverInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserHoverInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserHoverInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserHoverInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserHoverInput(BetaBrowserClickTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BetaBrowserHoverInputFromRaw : IFromRawJson<BetaBrowserHoverInput>
{
    /// <inheritdoc/>
    public BetaBrowserHoverInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserHoverInput.FromRawUnchecked(rawData);
}
