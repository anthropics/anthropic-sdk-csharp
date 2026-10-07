using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Return console output (log entries, errors, warnings) accumulated since the driver
/// attached to the tab and since the last read, one line per entry. An empty result
/// does not mean no traffic for a tab that predates attach.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserReadConsoleInput, BetaBrowserReadConsoleInputFromRaw>)
)]
public sealed record class BetaBrowserReadConsoleInput : JsonModel
{
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
        _ = this.TabID;
    }

    public BetaBrowserReadConsoleInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserReadConsoleInput(BetaBrowserReadConsoleInput betaBrowserReadConsoleInput)
        : base(betaBrowserReadConsoleInput) { }
#pragma warning restore CS8618

    public BetaBrowserReadConsoleInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserReadConsoleInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserReadConsoleInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserReadConsoleInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserReadConsoleInputFromRaw : IFromRawJson<BetaBrowserReadConsoleInput>
{
    /// <inheritdoc/>
    public BetaBrowserReadConsoleInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserReadConsoleInput.FromRawUnchecked(rawData);
}
