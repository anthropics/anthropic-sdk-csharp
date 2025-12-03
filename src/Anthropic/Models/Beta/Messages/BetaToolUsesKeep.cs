using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaToolUsesKeep, BetaToolUsesKeepFromRaw>))]
public sealed record class BetaToolUsesKeep : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required long Value
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
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

    public BetaToolUsesKeep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolUsesKeep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaToolUsesKeepFromRaw : IFromRaw<BetaToolUsesKeep>
{
    /// <inheritdoc/>
    public BetaToolUsesKeep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolUsesKeep.FromRawUnchecked(rawData);
}
