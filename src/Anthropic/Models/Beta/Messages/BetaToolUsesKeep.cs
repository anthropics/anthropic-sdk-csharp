using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaToolUsesKeep, BetaToolUsesKeepFromRaw>))]
public sealed record class BetaToolUsesKeep : JsonModel
{
    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    public required long Value
    {
        get { return this._rawData.GetNotNullStruct<long>("value"); }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public BetaToolUsesKeep()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
    }

    public BetaToolUsesKeep(BetaToolUsesKeep betaToolUsesKeep)
        : base(betaToolUsesKeep) { }

    public BetaToolUsesKeep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolUsesKeep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolUsesKeepFromRaw.FromRawUnchecked"/>
    public static BetaToolUsesKeep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolUsesKeep(long value)
        : this()
    {
        this.Value = value;
    }
}

class BetaToolUsesKeepFromRaw : IFromRawJson<BetaToolUsesKeep>
{
    /// <inheritdoc/>
    public BetaToolUsesKeep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolUsesKeep.FromRawUnchecked(rawData);
}
