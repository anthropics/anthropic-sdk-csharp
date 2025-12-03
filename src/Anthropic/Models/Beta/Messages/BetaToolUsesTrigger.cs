using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaToolUsesTrigger, BetaToolUsesTriggerFromRaw>))]
public sealed record class BetaToolUsesTrigger : ModelBase
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

    public BetaToolUsesTrigger()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
    }

    public BetaToolUsesTrigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolUsesTrigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolUsesTriggerFromRaw.FromRawUnchecked"/>
    public static BetaToolUsesTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolUsesTrigger(long value)
        : this()
    {
        this.Value = value;
    }
}

class BetaToolUsesTriggerFromRaw : IFromRaw<BetaToolUsesTrigger>
{
    /// <inheritdoc/>
    public BetaToolUsesTrigger FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolUsesTrigger.FromRawUnchecked(rawData);
}
