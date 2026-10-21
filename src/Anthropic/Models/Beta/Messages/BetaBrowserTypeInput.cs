using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Type a literal string at the current focus.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserTypeInput, BetaBrowserTypeInputFromRaw>))]
public sealed record class BetaBrowserTypeInput : JsonModel
{
    /// <summary>
    /// The text to type.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
        _ = this.Text;
        _ = this.TabID;
    }

    public BetaBrowserTypeInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserTypeInput(BetaBrowserTypeInput betaBrowserTypeInput)
        : base(betaBrowserTypeInput) { }
#pragma warning restore CS8618

    public BetaBrowserTypeInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserTypeInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserTypeInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserTypeInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserTypeInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaBrowserTypeInputFromRaw : IFromRawJson<BetaBrowserTypeInput>
{
    /// <inheritdoc/>
    public BetaBrowserTypeInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserTypeInput.FromRawUnchecked(rawData);
}
